using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class StatusbarControl : BarControl 
    {
        public StatusbarControl()
        {
            InitializeComponent();
            WireCollection(statusStrip.Items);
        }
    }
}
