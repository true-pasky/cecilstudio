using System;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Tests
{
    public partial class PluginControl : UserControl
    {
        public PluginControl()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you rocks!");
        }
    }
}
