using System;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class StackedWindowControl : UserControl, IWindow
    {
        public WindowNames Identifier
        {
            get; set;
        }

        public string Caption
        {
            get { return label.Text; }
        }

        public Control Content
        {
            get
            {
                return contentPanel.Controls[0];
            }
        }

        public StackedWindowControl()
        {
            InitializeComponent();
        }

        public StackedWindowControl(Control content, string caption)
        {
            InitializeComponent();

            label.Text = caption;
            content.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(content);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Parent != null && Parent.Parent is WindowStackerControl)
            {
                (Parent.Parent as WindowStackerControl).ResizeCells();
            }
        }

        private void CloseBox_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        public System.Drawing.Image Image
        {
            get
            {
                return iconBox.Image;
            }
            set
            {
                iconBox.Image = value;
            }
        }
    }
}
