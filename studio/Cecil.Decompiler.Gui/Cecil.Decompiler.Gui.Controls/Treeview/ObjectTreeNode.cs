using System.Windows.Forms;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class ObjectTreeNode : TreeNode
    {
        private object obj;

        public ObjectTreeNode(object obj)
        {
            Object = obj;
        }

        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                Tag = obj;
                Refresh();
            }
        }

        public static string GetDescription(object obj)
        {
            if (obj is MethodDefinition)
            {
                var metdef = (MethodDefinition)obj;
                return metdef.ToString().Substring(metdef.ToString().IndexOf("::") + 2) + " : " + metdef.ReturnType.ReturnType.ToString();
            }
            else if (obj is PropertyDefinition)
            {
                var propdef = (PropertyDefinition)obj;
                return propdef.ToString().Substring(propdef.ToString().IndexOf("::") + 2) + " : " + propdef.PropertyType.ToString();
            }
            else if (obj is FieldDefinition)
            {
                var flddef = (FieldDefinition)obj;
                return flddef.ToString().Substring(flddef.ToString().IndexOf("::") + 2) + " : " + flddef.FieldType.ToString();
            }
            else if (obj is ModuleDefinition)
            {
                var moddef = (ModuleDefinition)obj;
                return moddef.Name;
            }
            else if (obj is TypeDefinition)
            {
                var typedef = (TypeDefinition)obj;
                return typedef.Name;
            }
            else if (obj is AssemblyDefinition)
            {
                var asmdef = (AssemblyDefinition)obj;
                return asmdef.Name.Name;
            }
            else if (obj is EventDefinition)
            {
                var evtdef = (EventDefinition)obj;
                return evtdef.Name;
            }
            else if (obj is AssemblyNameReference)
            {
                var anref = (AssemblyNameReference)obj;
                return anref.Name;
            }
            else
            {
                return obj.ToString();
            }
        }

        public void Refresh()
        {
            Text = GetDescription(obj);
            ImageIndex = (int)IconHelper.GetImageIndex(obj);
            SelectedImageIndex = ImageIndex;
        }
    }
}
