using Cecil.Decompiler.Gui.Actions;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class ToolStripItem : System.Windows.Forms.ToolStripItem, IActionNameContainer
    {
        public ActionNames ActionName
        {
            get;
            set;
        }
    }
}
