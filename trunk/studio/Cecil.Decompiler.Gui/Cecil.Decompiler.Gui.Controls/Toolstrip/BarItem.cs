using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class BarItem : ToolStripItem, IBarItem 
    {
        public ActionNames ActionName
        {
            get;
            set;
        }
    }
}
