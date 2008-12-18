
#region Imports
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Cecil.Decompiler.Gui.Services;
using Mono.Cecil;
#endregion

namespace Cecil.Decompiler.Gui.Controls
{
    internal class AssemblyManagerComponent : Component, IAssemblyManager
    {
        #region Fields
        private readonly List<AssemblyDefinition> assemblies = new List<AssemblyDefinition>();
        #endregion

        #region Events
        public event AssemblyLoadedEventHandler AssemblyLoaded;
        public event AssemblyUnloadedEventHandler AssemblyUnloaded;
        #endregion

        #region Properties
        public ICollection<AssemblyDefinition> Assemblies
        {
            get
            {
                return new ReadOnlyCollection<AssemblyDefinition>(assemblies);
            }
        }
        #endregion

        #region Methods
        public AssemblyDefinition LoadFile(string location)
        {
            var asmdef = AssemblyFactory.GetAssembly(location);
            assemblies.Add(asmdef);
            if (AssemblyLoaded != null)
                AssemblyLoaded(this, new AssemblyLoadedEventArgs(asmdef));
            return asmdef;
        }

        public void SaveFile(AssemblyDefinition value, string location)
        {
            AssemblyFactory.SaveAssembly(value, location);
        }

        public void Unload(AssemblyDefinition value)
        {
            assemblies.Remove(value);
            if (AssemblyUnloaded != null)
                AssemblyUnloaded(this, new AssemblyUnloadedEventArgs(value));
        }
        #endregion
    }
}
