using System.Collections;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IWindowCollection : ICollection
    {
        IWindow Add(string identifier, Control content, string caption);
        void Remove(string identifier);
        IWindow this[string identifier] { get; }
    }
}
