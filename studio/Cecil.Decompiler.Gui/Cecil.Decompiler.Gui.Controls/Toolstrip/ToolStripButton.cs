using Cecil.Decompiler.Gui.Actions;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class ToolStripButton : System.Windows.Forms.ToolStripButton, IActionNameContainer 
    {
        public ActionNames ActionName
        {
            get;
            set;
        }
    }
}
