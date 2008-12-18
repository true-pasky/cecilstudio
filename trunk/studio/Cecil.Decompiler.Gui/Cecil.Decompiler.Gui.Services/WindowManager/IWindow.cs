using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IWindow
    {
        string Caption { get; }
        Control Content { get; }
        bool Visible { get; set; }
    }
}
