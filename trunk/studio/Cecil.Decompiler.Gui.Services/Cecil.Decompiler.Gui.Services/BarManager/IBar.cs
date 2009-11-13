using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IBar
    {
        string Name { get; }
        IBarItemCollection Items { get; }
    }
}
