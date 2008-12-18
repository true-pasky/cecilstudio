using System;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IAssemblyBrowser : IService 
    {
        event EventHandler ActiveItemChanged;

        object ActiveItem { get; set; }

        void GoBack();
        void GoForward();
    }
}
