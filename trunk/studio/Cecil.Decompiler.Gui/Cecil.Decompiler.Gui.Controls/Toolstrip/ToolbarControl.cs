using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class ToolbarControl : BarControl 
    {
        public ILanguageManager LanguageManager
        {
            get { return languageSelector; }
        }

        public ToolbarControl()
        {
            InitializeComponent();
            WireCollection(toolStrip.Items);
        }

        internal void WireItems()
        {
            WireItems(toolStrip.Items);
        }
    }
}
