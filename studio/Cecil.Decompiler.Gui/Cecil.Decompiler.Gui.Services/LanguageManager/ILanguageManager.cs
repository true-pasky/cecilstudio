using System;
using System.Collections.Generic;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Services
{
    public interface ILanguageManager : IService 
    {
        event EventHandler ActiveLanguageChanged;

        void RegisterLanguage(ILanguage language);
        void UnregisterLanguage(ILanguage language);

        ILanguage ActiveLanguage { get; set; }
        ICollection<ILanguage> Languages { get; }
    }
}
