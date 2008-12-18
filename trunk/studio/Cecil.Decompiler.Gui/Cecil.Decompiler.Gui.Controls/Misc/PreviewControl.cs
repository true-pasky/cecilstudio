using System;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class PreviewControl : UserControl
    {
        public PreviewControl()
        {
            InitializeComponent();
        }

        private void PreviewControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();

                assemblyBrowser.ActiveItemChanged += new EventHandler(AssemblyBrowser_ActiveItemChanged);
            }
        }

        void AssemblyBrowser_ActiveItemChanged(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = ((IAssemblyBrowser) sender).ActiveItem;
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            var selection = assemblyBrowser.ActiveItem;
            assemblyBrowser.ActiveItem = null;
            assemblyBrowser.ActiveItem = selection;
        }
    }
}
