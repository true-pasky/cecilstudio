
#region Imports
using Mono.Cecil;
#endregion

namespace Cecil.Decompiler.Gui.Controls
{
    internal class AssemblyReferencesWrapper
    {
        #region Fields
        private readonly ModuleDefinition modef;
        #endregion

        #region Methods
        public AssemblyReferencesWrapper(ModuleDefinition modef)
        {
            this.modef = modef;
        }

        public override bool Equals(object obj)
        {
            if (obj is AssemblyReferencesWrapper)
            {
                AssemblyReferencesWrapper other = obj as AssemblyReferencesWrapper;
                return (modef.Equals(other.modef));
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (this.GetType().ToString()+"|"+modef.GetHashCode().ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return "References";
        }
        #endregion
    }
}
