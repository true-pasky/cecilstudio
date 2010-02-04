using System;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Controls
{
    public partial class BreadCrumbControl : UserControl
    {
        public BreadCrumbControl()
        {
            InitializeComponent();

            iconsImageList.Images.AddStrip(IconHelper.GetImageStrip());
        }

        public void Wire() {
            var asmBrowser = Services.ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            asmBrowser.ActiveItemChanged += new EventHandler(ActiveItemChanged);
        }

        string GetDescription(object item)
        {
            return ObjectTreeNode.GetDescription(item);
        }

        void RefreshPath(object[] items)
        {
            toolStrip.Items.Clear();
            foreach (object item in items)
            {
                var ts = toolStrip.Items.Add(GetDescription(item));
                ts.ImageIndex = (int)IconHelper.GetImageIndex(item);
                ts.ToolTipText = item.GetType().Name;
                ts.Tag = item;
                ts.Click += new EventHandler(ItemClick);
            }
        }

        void ItemClick(object sender, EventArgs e)
        {
            var asmBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            asmBrowser.ActiveItem = (sender as System.Windows.Forms.ToolStripItem).Tag;
        }

        void ActiveItemChanged(object sender, EventArgs e)
        {
            var asmBrowser = sender as IAssemblyBrowser;
            RefreshPath(asmBrowser.ActiveItemObjectHierarchy);
        }
    }
}
