using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IBarCollection : ICollection 
    {
        void Add(IBar bar);
        void Clear();
        bool Contains(IBar bar);
        void Remove(IBar bar);

        IBar this[string name] { get; }
        IBar this[BarNames name] { get; }
    }
}
