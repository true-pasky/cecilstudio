using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class ToolbarControl : UserControl
    {
        private readonly Dictionary<ActionNames, System.Windows.Forms.ToolStripItem> actionitems = new Dictionary<ActionNames, System.Windows.Forms.ToolStripItem>();

        public ILanguageManager LanguageManager
        {
            get { return languageSelector; }
        }

        public ToolbarControl()
        {
            InitializeComponent();
        }

        // TODO : factorize with helper
        internal void WireItems()
        {
            // Because events are set after 'Items' initialization
            foreach (System.Windows.Forms.ToolStripItem item in toolStrip.Items)
            {
                ToolStrip_ItemAdded(toolStrip, new ToolStripItemEventArgs(item));
            }
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is IActionNameContainer)
            {
                var anc = e.ClickedItem as IActionNameContainer;
                var actionManager = Services.ServiceProvider.GetInstance().GetService<IActionManager>();
                actionManager.ExecuteAction(anc.ActionName);
            }
        }

        private void ToolStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item is IActionNameContainer)
            {
                var anc = e.Item as IActionNameContainer;
                if (anc.ActionName != ActionNames.None)
                {
                    var actionManager = Services.ServiceProvider.GetInstance().GetService<IActionManager>();
                    actionitems.Add(anc.ActionName, e.Item as System.Windows.Forms.ToolStripItem);
                    actionManager.GetAction(anc.ActionName).EnabledChanged +=
                        new EventHandler(ToolbarControl_EnabledChanged);
                }
            }
        }

        void ToolbarControl_EnabledChanged(object sender, EventArgs e)
        {
            var action = sender as IAction;
            actionitems[action.Name].Enabled = action.Enabled;
        }
    }
}
