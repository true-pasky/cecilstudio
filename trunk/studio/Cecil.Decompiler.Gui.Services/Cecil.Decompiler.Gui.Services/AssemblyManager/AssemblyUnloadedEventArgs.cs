using System;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Services
{
    public class AssemblyUnloadedEventArgs : EventArgs
    {
        public AssemblyDefinition Assembly { get; set; }

        public AssemblyUnloadedEventArgs(AssemblyDefinition assembly)
        {
            Assembly = assembly;
        }
    }

    public delegate void AssemblyUnloadedEventHandler(Object sender, AssemblyUnloadedEventArgs e);
}
