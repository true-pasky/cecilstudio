using System.Collections;
using System.Windows.Forms;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Services
{
    public interface ILanguageCollection : ICollection
    {
        void Add(ILanguage language);
        void Remove(ILanguage language);
    }
}
