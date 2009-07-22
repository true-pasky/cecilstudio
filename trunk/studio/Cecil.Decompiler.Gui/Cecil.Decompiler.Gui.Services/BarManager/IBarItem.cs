using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cecil.Decompiler.Gui.Services
{
    public interface IBarItem
    {
        bool Enabled { get; set; }
        Image Image { get; set; }
        string Text { get; set; }
        bool Visible { get; set; }
    }
}
