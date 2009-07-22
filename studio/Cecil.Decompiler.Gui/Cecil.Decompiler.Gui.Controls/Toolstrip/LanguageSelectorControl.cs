using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class LanguageSelectorControl : ToolStripComboBox, ILanguageManager, ILanguageCollection 
    {
        private readonly Dictionary<string, ILanguage> languages = new Dictionary<string, ILanguage>();

        public event EventHandler ActiveLanguageChanged;

        public ILanguage ActiveLanguage
        {
            get
            {
                return this.SelectedItem == null ? null : languages[this.SelectedItem.ToString()];
            }
            set
            {
                this.SelectedItem = value == null ? null : value.Name;
            }
        }

        public LanguageSelectorControl()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (ActiveLanguageChanged != null)
            {
                ActiveLanguageChanged(this, EventArgs.Empty);
            }
        }

        ILanguageCollection ILanguageManager.Languages
        {
            get { return this; }
        }

        public void Add(ILanguage language)
        {
            languages.Add(language.Name, language);
            this.Items.Add(language.Name);
        }

        public void Remove(ILanguage language)
        {
            languages.Remove(language.Name);
            this.Items.Remove(language.Name);
        }

        public void CopyTo(Array array, int index)
        {
            languages.ToArray().CopyTo(array, index);
        }

        public int Count
        {
            get { return languages.Count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return languages.Values.GetEnumerator();
        }
    }
}
