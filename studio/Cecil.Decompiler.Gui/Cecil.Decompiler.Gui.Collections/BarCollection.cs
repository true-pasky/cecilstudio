using System.Collections.Generic;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Collections
{
    internal class BarCollection : Dictionary<string, IBar>, IBarCollection
    {
        public void Add(IBar bar)
        {
            this.Add(bar.Name, bar);
        }

        public bool Contains(IBar bar)
        {
            return this.ContainsKey(bar.Name);
        }

        public void Remove(IBar bar)
        {
            this.Remove(bar.Name);
        }


        IBar IBarCollection.this[BarNames name]
        {
            get
            {
                return this[name.ToString()];
            }
        }
    }
}
