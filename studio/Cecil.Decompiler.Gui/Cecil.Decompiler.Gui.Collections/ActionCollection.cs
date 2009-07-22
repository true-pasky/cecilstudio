using System.Collections.Generic;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Collections
{
    internal class ActionCollection : Dictionary<string, IAction>, IActionCollection
    {
        public IAction this[ActionNames name]
        {
            get { return this[name.ToString()]; }
        }

        public void Add(IAction action)
        {
            Add(action.Name, action);
        }

        public bool Contains(IAction action)
        {
            return this.ContainsKey(action.Name);
        }

        public void Remove(IAction action)
        {
            this.Remove(action.Name);
        }
    }
}
