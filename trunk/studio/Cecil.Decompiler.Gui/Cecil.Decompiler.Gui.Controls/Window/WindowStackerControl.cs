using System;
using System.Collections;
using System.Collections.Generic;
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

        public void Add(string identifier, StackedWindowControl window)
        {
            window.Dock = DockStyle.Fill;
            layoutPanel.Controls.Add(window);
            windows.Add(identifier, window);
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
