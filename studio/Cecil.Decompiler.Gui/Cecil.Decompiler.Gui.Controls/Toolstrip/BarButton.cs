using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class BarButton : ToolStripButton, IBarButton  
    {
        public ActionNames ActionName
        {
            get;
            set;
        }
    }
}
