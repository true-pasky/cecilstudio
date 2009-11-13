using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IAssemblyManager : IService 
    {
        event AssemblyLoadedEventHandler AssemblyLoaded;
        event AssemblyUnloadedEventHandler AssemblyUnloaded;

        AssemblyDefinition LoadFile(string location);
        void SaveFile(AssemblyDefinition value, string location);
        void Unload(AssemblyDefinition value);

        ICollection<AssemblyDefinition> Assemblies { get; }
    }
}
