using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class MenuControl : BarControl 
    {
        public MenuControl()
        {
            InitializeComponent();
            WireCollection(menuStrip.Items);
        }

        internal void WireItems()
        {
            WireItems(menuStrip.Items);
        }

    }
}
