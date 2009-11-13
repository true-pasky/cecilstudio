using System;
using System.Collections.Generic;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Services
{
    public interface ILanguageManager : IService 
    {
        event EventHandler ActiveLanguageChanged;

        ILanguage ActiveLanguage { get; set; }
        ILanguageCollection Languages { get; }
    }
}
