
#region Imports
using Mono.Cecil;
#endregion

namespace Cecil.Decompiler.Gui.Controls
{
    internal class NamespaceWrapper
    {
        #region Fields
        private readonly string @namespace;
        private readonly ModuleDefinition modef;
        #endregion

        #region Methods
        public NamespaceWrapper(ModuleDefinition modef, string @namespace)
        {
            this.modef = modef;
            this.@namespace = string.IsNullOrEmpty(@namespace) ? "-" : @namespace;
        }

        public override bool Equals(object obj)
        {
            if (obj is NamespaceWrapper)
            {
                NamespaceWrapper other = obj as NamespaceWrapper;
                return (modef.Equals(other.modef)) && (@namespace == other.@namespace);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (modef.GetHashCode().ToString() + "|" + @namespace.GetHashCode().ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return @namespace;
        }
        #endregion
    }
}
