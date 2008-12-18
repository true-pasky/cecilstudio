using System;

namespace Cecil.Decompiler.Gui.Actions
{
    public interface IAction
    {
        event EventHandler EnabledChanged;
        bool Enabled { get; set; }
        ActionNames Name { get; } 
        void Execute();
    }
}
