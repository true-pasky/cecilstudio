using System;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IAction
    {
        event EventHandler EnabledChanged;
        bool Enabled { get; set; }
        string Name { get; } 
        void Execute();
    }
}
