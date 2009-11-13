using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IActionCollection : ICollection
    {
        void Add(IAction action);
        void Clear();
        bool Contains(IAction action);
        void Remove(IAction action);

        IAction this[string name] { get; }
        IAction this[ActionNames name] { get; }
    }
}
