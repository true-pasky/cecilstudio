using Cecil.Decompiler.Gui.Actions;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class ToolStripMenuItem : System.Windows.Forms.ToolStripMenuItem, IActionNameContainer
    {
        public ActionNames ActionName
        {
            get; set;
        }
    }
}
