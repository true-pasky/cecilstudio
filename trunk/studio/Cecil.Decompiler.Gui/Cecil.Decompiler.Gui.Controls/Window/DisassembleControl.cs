using System;
using System.IO;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Languages;
using Mono.Cecil;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class DisassembleControl : StackedWindowControl
    {
        private ILanguageWriter writer;
        private StringWriter swriter;

        public DisassembleControl()
        {
            InitializeComponent();
        }

        private void DisassembleControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
                var languageManager = ServiceProvider.GetInstance().GetService<ILanguageManager>();

                assemblyBrowser.ActiveItemChanged += new EventHandler(AssemblyBrowser_ActiveItemChanged);
                languageManager.ActiveLanguageChanged += new EventHandler(LanguageManager_ActiveLanguageChanged);

                setupDisplay(languageManager.ActiveLanguage);
                displayItem(assemblyBrowser.ActiveItem);
            }
        }

        void LanguageManager_ActiveLanguageChanged(object sender, EventArgs e)
        {
            var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            var languageManager = ServiceProvider.GetInstance().GetService<ILanguageManager>();

            setupDisplay(languageManager.ActiveLanguage);
            displayItem(assemblyBrowser.ActiveItem);
        }

        void AssemblyBrowser_ActiveItemChanged(object sender, EventArgs e)
        {
            var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            displayItem(assemblyBrowser.ActiveItem);
        }

        void setupDisplay(ILanguage language)
        {
            textEditorControl.SetHighlighting(language is CSharp ? "C#" : "VBNET");
            textEditorControl.ShowEOLMarkers = false;
            textEditorControl.ShowInvalidLines = false;

            swriter = new StringWriter();

            if (language != null)
            {
                writer = language.GetWriter(new PlainTextFormatter(swriter));
            }
        }

        void displayItem(object item)
        {
            swriter.GetStringBuilder().Length = 0;
            if (item is MethodDefinition)
            {
                if (writer != null)
                {
                    var mdef = item as MethodDefinition;
                    try
                    {
                        writer.Write(mdef);
                    }
                    catch (Exception e)
                    {
                        swriter.WriteLine(e.ToString());
                    }
                }
            }
            textEditorControl.Document.TextContent = swriter.ToString();
            textEditorControl.Refresh();
        }
    }
}
