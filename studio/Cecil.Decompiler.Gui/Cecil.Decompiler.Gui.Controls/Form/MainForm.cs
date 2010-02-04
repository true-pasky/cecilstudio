using System;
using System.IO;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Collections;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class MainForm : Form, IActionManager, IBarManager 
    {
        ActionCollection actions = new ActionCollection();
        BarCollection bars = new BarCollection();

        #region Registration
        private void RegisterLanguages()
        {
            ILanguage selected;
            ILanguageCollection languages;

            languages = toolbarControl.LanguageManager.Languages;
            languages.Add(new CSharp());
            languages.Add(new CSharpV1());
            languages.Add(new CSharpV2());
            languages.Add(selected = new CSharpV3());

            languages.Add(new VisualBasic());
            languages.Add(new VisualBasic7());
            languages.Add(new VisualBasic8());
            languages.Add(new VisualBasic9());

            toolbarControl.LanguageManager.ActiveLanguage = selected;
        }

        private void RegisterServices()
        {
            ServiceProvider serviceProvider = ServiceProvider.GetInstance();
            serviceProvider.RegisterService(typeof(IServiceProvider), serviceProvider);
            serviceProvider.RegisterService(typeof(IAssemblyManager), assemblyManager);
            serviceProvider.RegisterService(typeof(IAssemblyBrowser), assemblyBrowserControl);
            serviceProvider.RegisterService(typeof(ILanguageManager), toolbarControl.LanguageManager);
            serviceProvider.RegisterService(typeof(IWindowManager), windowStackerControl);
        }

        private void RegisterBars()
        {
            toolbarControl.Name = BarNames.Toolbar.ToString();
            bars.Add(toolbarControl);

            menuControl.Name = BarNames.Menu.ToString();
            bars.Add(menuControl);

            statusbarControl.Name = BarNames.Status.ToString();
            bars.Add(statusbarControl);

            assemblyBrowserControl.assemblyDefinitionBrowserMenu.Name = BarNames.AssemblyDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.assemblyDefinitionBrowserMenu);

            assemblyBrowserControl.moduleDefinitionBrowserMenu.Name = BarNames.ModuleDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.moduleDefinitionBrowserMenu);

            assemblyBrowserControl.assemblyNameReferenceBrowserMenu.Name = BarNames.AssemblyNameReferenceBrowser.ToString();
            bars.Add(assemblyBrowserControl.assemblyNameReferenceBrowserMenu);

            assemblyBrowserControl.typeDefinitionBrowserMenu.Name = BarNames.TypeDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.typeDefinitionBrowserMenu);

            assemblyBrowserControl.methodDefinitionBrowserMenu.Name = BarNames.MethodDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.methodDefinitionBrowserMenu);

            assemblyBrowserControl.propertyDefinitionBrowserMenu.Name = BarNames.PropertyDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.propertyDefinitionBrowserMenu);

            assemblyBrowserControl.eventDefinitionBrowserMenu.Name = BarNames.EventDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.eventDefinitionBrowserMenu);

            assemblyBrowserControl.fieldDefinitionBrowserMenu.Name = BarNames.FieldDefinitionBrowser.ToString();
            bars.Add(assemblyBrowserControl.fieldDefinitionBrowserMenu);
        }

        private void RegisterActions()
        {
            actions.Add(new LoadAssemblyAction());
            actions.Add(new UnloadAssemblyAction());
            actions.Add(new DisassembleAction());
            actions.Add(new GoBackAction());
            actions.Add(new GoForwardAction());
            actions.Add(new AnalyzeAction());
            actions.Add(new VoidAction());
        }
        #endregion

        #region IActionManager
        IActionCollection IActionManager.Actions
        {
            get
            {
                return actions;
            }
        }

        #endregion

        #region IBarManager
        IBarCollection IBarManager.Bars
        {
            get
            {
                return bars;
            }
        }
        #endregion

        #region Methods
        public MainForm()
        {
            if (!DesignMode)
            {
                RegisterActions();
                ServiceProvider serviceProvider = ServiceProvider.GetInstance();
                serviceProvider.RegisterService(typeof(IActionManager), this);
                serviceProvider.RegisterService(typeof(IBarManager), this);
            }

            InitializeComponent();

            if (!DesignMode)
            {
                toolbarControl.WireItems();
                menuControl.WireItems();

                RegisterBars();
                RegisterLanguages();
                RegisterServices();

                breadCrumbControl.Wire();
            }

            string path = Path.GetDirectoryName(Application.ExecutablePath);
            ServiceProvider.GetInstance().LoadPlugins(path);
        }
        #endregion

    }
}
