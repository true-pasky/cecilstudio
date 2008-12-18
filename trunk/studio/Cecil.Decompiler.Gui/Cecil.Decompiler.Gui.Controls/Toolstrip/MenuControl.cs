using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class MenuControl : UserControl
    {
        private readonly Dictionary<ActionNames, System.Windows.Forms.ToolStripItem> actionitems = new Dictionary<ActionNames, System.Windows.Forms.ToolStripItem>();

        public MenuControl()
        {
            InitializeComponent();

            // Events are set after 'Items' initialization
            if (!DesignMode)
            {
            }
        }

        // TODO : factorize with helper
        internal void WireItems()
        {
            // Because events are set after 'Items' initialization
            foreach (System.Windows.Forms.ToolStripItem item in menuStrip.Items)
            {
                MenuStrip_ItemAdded(menuStrip, new ToolStripItemEventArgs(item));
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is IActionNameContainer)
            {
                var anc = sender as IActionNameContainer;
                var actionManager = ServiceProvider.GetInstance().GetService<IActionManager>();
                actionManager.ExecuteAction(anc.ActionName);
            }
        }

        private void MenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item is IActionNameContainer)
            {
                var anc = e.Item as IActionNameContainer;
                if (anc.ActionName != ActionNames.None)
                {
                    actionitems.Add(anc.ActionName, e.Item as System.Windows.Forms.ToolStripItem);
                    var actionManager = Services.ServiceProvider.GetInstance().GetService<IActionManager>();
                    actionManager.GetAction(anc.ActionName).EnabledChanged +=
                        new EventHandler(MenuControl_EnabledChanged);
                }
            }

            if (e.Item is System.Windows.Forms.ToolStripMenuItem)
            {
                var menuItem = (e.Item as System.Windows.Forms.ToolStripMenuItem);
                menuItem.Click += new EventHandler(MenuItem_Click);
                foreach (System.Windows.Forms.ToolStripItem subitem in menuItem.DropDownItems)
                {
                    MenuStrip_ItemAdded(e.Item, new ToolStripItemEventArgs(subitem));
                }
            }
        }

        private void MenuControl_EnabledChanged(object sender, EventArgs e)
        {
            var action = sender as IAction;
            actionitems[action.Name].Enabled = action.Enabled;
        }
    }
}
