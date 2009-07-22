using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Collections;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class BarControl : UserControl, IBar
    {
        private readonly Dictionary<string, ToolStripItem> actionitems = new Dictionary<string, ToolStripItem>();
        IBarItemCollection items;

        public IBarItemCollection Items
        {
            get
            {
                return items;
            }
        }

        internal void WireCollection(ToolStripItemCollection collection)
        {
            items = new WiredBarItemCollection(collection);
        }

        internal void WireItems(ToolStripItemCollection collection)
        {
            foreach (System.Windows.Forms.ToolStripItem item in collection)
            {
                ItemAdded(null, new ToolStripItemEventArgs(item));
            }
        }

        internal void ItemClick(object sender, EventArgs e)
        {
            if (sender is IActionNameContainer)
            {
                var anc = sender as IActionNameContainer;
                var actionManager = ServiceProvider.GetInstance().GetService<IActionManager>();
                actionManager.Actions[anc.ActionName].Execute();
            }
        }

        internal void ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item is IActionNameContainer)
            {
                var anc = e.Item as IActionNameContainer;
                if (anc.ActionName != ActionNames.None)
                {
                    actionitems.Add(anc.ActionName.ToString(), e.Item as ToolStripItem);
                    var actionManager = Services.ServiceProvider.GetInstance().GetService<IActionManager>();
                    actionManager.Actions[anc.ActionName].EnabledChanged +=
                        new EventHandler(ActionEnabledChanged);
                }
            }

            if (e.Item is ToolStripMenuItem)
            {
                var menuItem = (e.Item as ToolStripMenuItem);
                menuItem.Click += new EventHandler(ItemClick);
                foreach (System.Windows.Forms.ToolStripItem subitem in menuItem.DropDownItems)
                {
                    ItemAdded(e.Item, new ToolStripItemEventArgs(subitem));
                }
            }
        }

        internal void ActionEnabledChanged(object sender, EventArgs e)
        {
            var action = sender as IAction;
            actionitems[action.Name.ToString()].Enabled = action.Enabled;
        }
    }
}
