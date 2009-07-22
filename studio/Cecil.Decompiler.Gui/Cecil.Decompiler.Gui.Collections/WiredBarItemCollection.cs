using System;
using System.Collections;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Gui.Controls;
using System.Drawing;


namespace Cecil.Decompiler.Gui.Collections
{
    internal class WiredBarItemCollection : IBarItemCollection
    {
        ToolStripItemCollection collection;

        public WiredBarItemCollection(ToolStripItemCollection collection)
        {
            this.collection = collection;
        }

        public IBarItem this[int index]
        {
            get {
                return collection[index] as IBarItem;
            }
        }

        public void Add(IBarItem value)
        {
            Insert(collection.Count, value);
        }

        public IBarButton AddButton(string caption, EventHandler clickHandler)
        {
            return InsertButton(collection.Count, caption, clickHandler);
        }

        public IBarButton AddButton(string caption, Image image, EventHandler clickHandler)
        {
            return InsertButton(collection.Count, caption, image, clickHandler);
        }

        public IBarMenu AddMenu(string name, string caption)
        {
            return InsertMenu(collection.Count, name, caption);
        }

        public IBarMenu AddMenu(string name, string caption, System.Drawing.Image image)
        {
            return InsertMenu(collection.Count, name, caption, image);
        }

        public IBarSeparator AddSeparator()
        {
            return InsertSeparator(collection.Count);
        }

        public bool Contains(IBarItem item)
        {
            return collection.Contains(item as ToolStripItem);
        }

        public int IndexOf(IBarItem item)
        {
            return collection.IndexOf(item as ToolStripItem);
        }

        public void Insert(int index, IBarItem value)
        {
            collection.Insert(index, value as ToolStripItem);
        }

        public IBarButton InsertButton(int index, string caption, EventHandler clickHandler)
        {
            BarButton item = new BarButton();
            item.Text = caption;
            item.Click += clickHandler;
            Insert(index, item);
            return item;
        }

        public IBarButton InsertButton(int index, string caption, System.Drawing.Image image, EventHandler clickHandler)
        {
            IBarButton item = InsertButton(index, caption, clickHandler);
            item.Image = image;
            return item;
        }

        public IBarMenu InsertMenu(int index, string name, string caption)
        {
            BarMenu item = new BarMenu();
            item.Name = name;
            item.Text = caption;
            ServiceProvider.GetInstance().GetService<IBarManager>().Bars.Add(item);
            Insert(index, item);
            return item;
        }

        public IBarMenu InsertMenu(int index, string name, string caption, Image image)
        {
            IBarMenu item = InsertMenu(index, name, caption);
            item.Image = image;
            return item;
        }

        public IBarSeparator InsertSeparator(int index)
        {
            IBarSeparator item = new BarSeparator();
            Insert(index, item);
            return item;
        }

        public void Remove(IBarItem item)
        {
            collection.Remove(item as ToolStripItem);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            collection.CopyTo(array, index);
        }

        public int Count
        {
            get { return collection.Count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
