using System;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IAssemblyBrowser : IService 
    {
        event EventHandler ActiveItemChanged;

        object ActiveItem { get; set; }
        object[] ActiveItemObjectHierarchy { get; }

        void GoBack();
        void GoForward();
    }
}
