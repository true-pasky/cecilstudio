using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Gui.Collections;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class BarMenu : ToolStripMenuItem, IBarMenu 
    {
        public ActionNames ActionName
        {
            get; set;
        }

        public IBarItemCollection Items
        {
            get { return new WiredBarItemCollection(DropDownItems); }
        }
    }
}
