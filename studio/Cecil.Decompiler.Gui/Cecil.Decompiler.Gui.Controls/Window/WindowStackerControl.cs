using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class WindowStackerControl : UserControl, IWindowManager, IWindowCollection, IService
    {
        private readonly Dictionary<string, IWindow> windows = new Dictionary<string, IWindow>();
 
        public WindowStackerControl()
        {
            InitializeComponent();
        }

        public IWindow Add(string identifier, Control content, string caption)
        {
            var window = new StackedWindowControl(content, caption) {Dock = DockStyle.Fill};
            Add(identifier, window);
            return window;
        }

        public void Remove(string identifier)
        {
            windows.Remove(identifier);
        }

        public void ResizeCells()
        {
            int visiblecount = 0;
            int visibleindex = 0;

            for (int i=0; i< layoutPanel.RowStyles.Count; i++)
            {
                RowStyle rowstyle = layoutPanel.RowStyles[i];

                if (layoutPanel.Controls.Count > i)
                {
                    Control control = layoutPanel.Controls[i];

                    if (control.Visible)
                    {
                        visiblecount++;
                        visibleindex = i;
                        if (i == layoutPanel.RowStyles.Count - 1)
                        {
                            rowstyle.SizeType = SizeType.AutoSize;
                            rowstyle.SizeType = SizeType.Absolute;
                        }
                        else
                        {
                            rowstyle.SizeType = SizeType.Absolute;
                            rowstyle.Height = Convert.ToInt32(layoutPanel.Height / windows.Count);
                        }
                    }
                    else
                    {
                        rowstyle.SizeType = SizeType.Absolute;
                        rowstyle.Height = 0;
                    }
                }
            }

            if (visiblecount == 1)
            {
                RowStyle rowstyle = layoutPanel.RowStyles[visibleindex];
                rowstyle.SizeType = SizeType.Percent;
                rowstyle.Height = 100;
            }
        }

        public void Add(string identifier, StackedWindowControl window)
        {
            window.Dock = DockStyle.Fill;
            windows.Add(identifier, window);

            while (layoutPanel.RowCount < windows.Count)
            {
                layoutPanel.RowCount++;
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute));
            }

            layoutPanel.Controls.Add(window, 0, windows.Count - 1);

            ResizeCells();
        }

        public IWindow this[string identifier]
        {
            get
            {
                IWindow result;
                windows.TryGetValue(identifier, out result);
                return result;
            }
        }

        public IWindowCollection Windows
        {
            get { return this; }
        }

        public IEnumerator GetEnumerator()
        {
            return windows.Values.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { return windows.Count; }
        }

        public object SyncRoot
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
