using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Controls
{
    public class TableLayoutSplitter : Control
    {

        private Point clickPoint;
        public Control StackedControl
        {
            get; set;
        }

        public TableLayoutSplitter()
        {
            Dock = DockStyle.Bottom;
            Cursor = Cursors.HSplit; 
        }

       protected override Size DefaultSize
        {
            get { return new Size(4, 4); }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            clickPoint = Cursor.Position;
            this.Capture = true;

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if ((this.Capture))
            {
                Point changedPoint = Cursor.Position;
                Point deltas = new Point(changedPoint.X - clickPoint.X, changedPoint.Y - clickPoint.Y);
                AdjustHeight(deltas.Y);
                clickPoint = Cursor.Position;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Capture = false;
        }

        private void AdjustHeight(int height)
        {

            var parentPanel = StackedControl.Parent as TableLayoutPanel;
            if (parentPanel != null)
            {
                var row = parentPanel.GetRow(StackedControl);
                if (row >= 0)
                {
                    RowStyle currentRow = parentPanel.RowStyles[row];
                    currentRow.SizeType = SizeType.Absolute;
                    float newHeight = currentRow.Height + height;
                    if (((newHeight < parentPanel.Height) && newHeight > 0))
                    {
                        currentRow.Height = newHeight;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            if (Visible)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}