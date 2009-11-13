using System;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Services
{
    public class AssemblyLoadedEventArgs : EventArgs
    {
        public AssemblyDefinition Assembly { get; set; }

        public AssemblyLoadedEventArgs(AssemblyDefinition assembly)
        {
            Assembly = assembly;
        }
    }

    public delegate void AssemblyLoadedEventHandler(Object sender, AssemblyLoadedEventArgs e);
}
