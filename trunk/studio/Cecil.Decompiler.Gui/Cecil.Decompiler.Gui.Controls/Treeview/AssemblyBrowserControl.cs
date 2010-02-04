
#region Imports
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Mono.Cecil;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Gui.Actions;
#endregion

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class AssemblyBrowserControl : UserControl, IComparer, IReflectionVisitor, IAssemblyBrowser
    {
        #region Constants
        private const string ExpanderNodeKey = "|-expander-|";
        #endregion

        #region Fields
        private readonly Dictionary<object, TreeNode> nodes = new Dictionary<object, TreeNode>();
        private readonly Dictionary<IReflectionVisitable, IReflectionVisitable> visiteditems = new Dictionary<IReflectionVisitable, IReflectionVisitable>();
        private readonly Dictionary<Type, int> orders = new Dictionary<Type, int>();
        private readonly List<TreeNode> history = new List<TreeNode>();
        private int historyindex = 0;
        private bool historydisable = false;
        #endregion

        #region IAssemblyBrowser
        public event EventHandler ActiveItemChanged;

        public object[] ActiveItemObjectHierarchy
        {
            get
            {
                var objects = new ArrayList();
                var node = treeView.SelectedNode;
                while (node != null)
                {
                    if (node.Tag != null)
                    {
                        objects.Add(node.Tag);
                    }
                    node = node.Parent;
                }

                objects.Reverse();
                return objects.ToArray();
            }
        }

        public object ActiveItem
        {
            get
            {
                return treeView.SelectedNode != null ? treeView.SelectedNode.Tag : null;
            }
            set
            {
                treeView.SelectedNode = value != null ? nodes[value] : null;
                if (treeView.SelectedNode is ObjectTreeNode)
                {
                    (treeView.SelectedNode as ObjectTreeNode).Refresh();
                }
            }
        }

        public void GoBack()
        {
            if (historyindex > 0)
            {
                historydisable = true;
                historyindex--;
                treeView.SelectedNode = history[historyindex];
                historydisable = false;
            }
        }

        public void GoForward()
        {
            if (historyindex < history.Count - 1)
            {
                historydisable = true;
                historyindex++;
                treeView.SelectedNode = history[historyindex];
                historydisable = false;
            }
        }
        #endregion

        #region Events
        private void AssemblyManager_AssemblyLoaded(object sender, AssemblyLoadedEventArgs args)
        {
            AppendRootNode(args.Assembly);
        }

        private void AssemblyManager_AssemblyUnloaded(object sender, AssemblyUnloadedEventArgs args)
        {
            // TODO: unload assembly, nodes, cache, history
            throw new NotImplementedException();
        }

        private void AssemblyBrowser_Load(Object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var assemblyManager = ServiceProvider.GetInstance().GetService(typeof(IAssemblyManager)) as IAssemblyManager;
                assemblyManager.AssemblyLoaded += new AssemblyLoadedEventHandler(AssemblyManager_AssemblyLoaded);
                assemblyManager.AssemblyUnloaded += new AssemblyUnloadedEventHandler(AssemblyManager_AssemblyUnloaded);
                RefreshActions();
            }
            treeView.Focus();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (!historydisable)
                {
                    history.Add(e.Node);
                    historyindex = history.Count - 1;
                }

                if (e.Node.Tag is AssemblyDefinition)
                {
                    treeView.ContextMenuStrip = assemblyDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is ModuleDefinition)
                {
                    treeView.ContextMenuStrip = moduleDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is AssemblyNameReference)
                {
                    treeView.ContextMenuStrip = assemblyNameReferenceBrowserMenu;
                }
                else if (e.Node.Tag is TypeDefinition)
                {
                    treeView.ContextMenuStrip = typeDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is MethodDefinition)
                {
                    treeView.ContextMenuStrip = methodDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is PropertyDefinition)
                {
                    treeView.ContextMenuStrip = propertyDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is EventDefinition)
                {
                    treeView.ContextMenuStrip = eventDefinitionBrowserMenu;
                }
                else if (e.Node.Tag is FieldDefinition)
                {
                    treeView.ContextMenuStrip = fieldDefinitionBrowserMenu;
                }
                else
                {
                    treeView.ContextMenuStrip = null;
                }
            }
            else
            {
                treeView.ContextMenuStrip = null;
            }

            RefreshActions();

            if (ActiveItemChanged != null)
                ActiveItemChanged(this, EventArgs.Empty);
        }

        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            LoadNodeOnDemand(e.Node);
        }
        #endregion

        #region Methods
        public AssemblyBrowserControl()
        {
            InitializeComponent();

            iconsImageList.Images.AddStrip(IconHelper.GetImageStrip());

            int order = 0;
            orders.Add(typeof(AssemblyDefinition), order++);
            orders.Add(typeof(ModuleDefinition), order++);
            orders.Add(typeof(AssemblyReferencesWrapper), order++);
            orders.Add(typeof(AssemblyNameReference), order++);
            orders.Add(typeof(NamespaceWrapper), order++);
            orders.Add(typeof(TypeDefinition), order++);
            orders.Add(typeof(MethodDefinition), order++);
            orders.Add(typeof(PropertyDefinition), order++);
            orders.Add(typeof(EventDefinition), order++);
            orders.Add(typeof(FieldDefinition), order++);

            treeView.TreeViewNodeSorter = this;
        }

        public void RefreshActions()
        {
            var actionManager = ServiceProvider.GetInstance().GetService<IActionManager>();

            var goback = actionManager.Actions[ActionNames.GoBack];
            goback.Enabled = historyindex > 0;

            var goforward = actionManager.Actions[ActionNames.GoForward];
            goforward.Enabled = historyindex < history.Count - 1;
        }

        public int Compare(object x, object y)
        {
            var xn = (TreeNode)x;
            var yn = (TreeNode)y;

            int result = 0;
            if (xn.Tag != null && yn.Tag != null)
            {
                if (orders.ContainsKey(xn.Tag.GetType()))
                {
                    result = orders[xn.Tag.GetType()].CompareTo(orders[yn.Tag.GetType()]);
                }
            }
            if (result == 0)
            {
                result = xn.Text.CompareTo(yn.Text);
            }
            return result;
        }
        #endregion

        #region Node management
        private void LoadNodeOnDemand(TreeNode node)
        {
            if (node.Nodes.ContainsKey(ExpanderNodeKey))
            {
                node.Nodes.RemoveAt(node.Nodes.IndexOfKey(ExpanderNodeKey));
            }
            if ((node.Tag) is IReflectionVisitable)
            {
                var visitable = (IReflectionVisitable)node.Tag;
                if (!visiteditems.ContainsKey(visitable))
                {
                    visitable.Accept(this);
                    visiteditems.Add(visitable, visitable);
                }
            } 
            else if ((node.Tag) is AssemblyDefinition)
            {
                AssemblyDefinition asmdef = node.Tag as AssemblyDefinition;
                foreach (ModuleDefinition moddef in asmdef.Modules)
                {
                    AppendNode(asmdef, moddef, moddef.Types.Count > 0);
                }
            }
        }

        private void AppendRootNode(AssemblyDefinition root)
        {
            var rootnode = new ObjectTreeNode(root);
            rootnode.Nodes.Add(ExpanderNodeKey, ExpanderNodeKey);
            treeView.Nodes.Add(rootnode);
            nodes.Add(root, rootnode);
        }

        private void AppendNode(TreeNode ownernode, object child, bool createExpander)
        {
            if (!nodes.ContainsKey(child))
            {
                var childnode = new ObjectTreeNode(child);
                if (createExpander)
                {
                    childnode.Nodes.Add(ExpanderNodeKey, ExpanderNodeKey);
                }
                ownernode.Nodes.Add(childnode);
                nodes.Add(child, childnode);
            }
        }

        private void AppendNode(object owner, object child, bool createExpander)
        {
            var ownernode = nodes[owner];
            AppendNode(ownernode, child, createExpander);
        }
        #endregion

        #region Visitor implementation
        public void VisitConstructorCollection(ConstructorCollection ctors)
        {
            foreach (MethodDefinition constructor in ctors)
            {
                AppendNode(constructor.DeclaringType, constructor, false);
            }
        }

        public void VisitEventDefinitionCollection(EventDefinitionCollection events)
        {
            foreach (EventDefinition evt in events)
            {
                AppendNode(evt.DeclaringType, evt, true);
                if (evt.AddMethod != null)
                {
                    AppendNode(evt, evt.AddMethod, false);
                }
                if (evt.RemoveMethod != null)
                {
                    AppendNode(evt, evt.RemoveMethod, false);
                }
            }
        }

        public void VisitFieldDefinitionCollection(FieldDefinitionCollection fields)
        {
            foreach (FieldDefinition field in fields)
            {
                AppendNode(field.DeclaringType, field, false);
            }
        }

        public void VisitMethodDefinitionCollection(MethodDefinitionCollection methods)
        {
            foreach (MethodDefinition method in methods)
            {
                if (!method.IsSpecialName || method.IsConstructor)
                {
                    AppendNode(method.DeclaringType, method, false);
                }
            }
        }

        public void VisitNestedTypeCollection(NestedTypeCollection nestedTypes)
        {
            foreach (TypeDefinition nestedType in nestedTypes)
            {
                AppendNode(nestedType.DeclaringType, nestedType, true);
            }
        }

        public void VisitPropertyDefinitionCollection(PropertyDefinitionCollection properties)
        {
            foreach (PropertyDefinition @property in properties)
            {
                AppendNode(@property.DeclaringType, @property, true);
                if (@property.GetMethod != null)
                {
                    AppendNode(@property, @property.GetMethod, false);
                }
                if (@property.SetMethod != null)
                {
                    AppendNode(@property, @property.SetMethod, false);
                }
            }
        }

        public void VisitTypeDefinitionCollection(TypeDefinitionCollection types)
        {
            foreach (TypeDefinition typedef in types)
            {
                if ((typedef.Attributes & TypeAttributes.VisibilityMask) <= TypeAttributes.Public)
                {
                    NamespaceWrapper wrapper = new NamespaceWrapper(typedef.Module, typedef.Namespace);
                    AppendNode(typedef.Module, wrapper, true);
                    AppendNode(wrapper, typedef, true);
                }
            }
        }

        public void VisitModuleDefinition(ModuleDefinition @module) {
            if (@module.AssemblyReferences.Count > 0)
            {
                AssemblyReferencesWrapper wrapper = new AssemblyReferencesWrapper(@module);
                AppendNode(@module, wrapper, false);
                foreach (AssemblyNameReference anref in @module.AssemblyReferences)
                {
                    AppendNode(wrapper, anref, false);
                }
            }
        }
        #endregion

        #region Unimplemented vistor
        public void VisitEventDefinition(EventDefinition evt) { }
        public void VisitFieldDefinition(FieldDefinition field) { }
        public void VisitNestedType(TypeDefinition nestedType) { }
        public void VisitPropertyDefinition(PropertyDefinition @property) { }
        public void VisitTypeDefinition(TypeDefinition type) { }
        public void VisitConstructor(MethodDefinition ctor) { }
        public void VisitMethodDefinition(MethodDefinition method) { }
        public void TerminateModuleDefinition(ModuleDefinition @module) { }
        public void VisitExternType(TypeReference externType) { }
        public void VisitExternTypeCollection(ExternTypeCollection externs) { }
        public void VisitInterface(TypeReference interf) { }
        public void VisitInterfaceCollection(InterfaceCollection interfaces) { }
        public void VisitMemberReference(MemberReference member) { }
        public void VisitMemberReferenceCollection(MemberReferenceCollection members) { }
        public void VisitCustomAttribute(CustomAttribute customAttr) { }
        public void VisitCustomAttributeCollection(CustomAttributeCollection customAttrs) { }
        public void VisitGenericParameter(GenericParameter genparam) { }
        public void VisitGenericParameterCollection(GenericParameterCollection genparams) { }
        public void VisitMarshalSpec(MarshalSpec marshalSpec) { }
        public void VisitSecurityDeclaration(SecurityDeclaration secDecl) { }
        public void VisitSecurityDeclarationCollection(SecurityDeclarationCollection secDecls) { }
        public void VisitTypeReference(TypeReference type) { }
        public void VisitTypeReferenceCollection(TypeReferenceCollection refs) { }
        public void VisitOverride(MethodReference ov) { }
        public void VisitOverrideCollection(OverrideCollection meth) { }
        public void VisitParameterDefinition(ParameterDefinition parameter) { }
        public void VisitParameterDefinitionCollection(ParameterDefinitionCollection parameters) { }
        public void VisitPInvokeInfo(PInvokeInfo pinvk) { }
        #endregion

    }
}
