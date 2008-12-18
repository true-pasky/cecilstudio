using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Controls
{
    internal class LanguageSelectorControl : ToolStripComboBox, ILanguageManager
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

        public ICollection<ILanguage> Languages
        {
            get
            {
                return new ReadOnlyCollection<ILanguage>(languages.Values.ToList());
            }
        }
        
        public LanguageSelectorControl()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void RegisterLanguage(ILanguage language)
        {
            languages.Add(language.Name, language);
            this.Items.Add(language.Name);
        }

        public void UnregisterLanguage(ILanguage language)
        {
            languages.Remove(language.Name);
            this.Items.Remove(language.Name);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (ActiveLanguageChanged != null)
            {
                ActiveLanguageChanged(this, EventArgs.Empty);
            }
        }
    }
}
