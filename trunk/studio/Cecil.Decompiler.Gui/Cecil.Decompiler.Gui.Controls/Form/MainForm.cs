using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cecil.Decompiler.Gui.Actions;
using Cecil.Decompiler.Gui.Services;
using Cecil.Decompiler.Gui.Tests;
using Cecil.Decompiler.Languages;

namespace Cecil.Decompiler.Gui.Controls
{
    internal partial class MainForm : Form, IActionManager 
    {
        private readonly Dictionary<ActionNames, IAction> actions = new Dictionary<ActionNames, IAction>();

        #region Registration
        private void RegisterLanguages()
        {
            ILanguage selected;

            toolbarControl.LanguageManager.RegisterLanguage(new CSharp());
            toolbarControl.LanguageManager.RegisterLanguage(new CSharpV1());
            toolbarControl.LanguageManager.RegisterLanguage(new CSharpV2());
            toolbarControl.LanguageManager.RegisterLanguage(selected = new CSharpV3());

            toolbarControl.LanguageManager.RegisterLanguage(new VisualBasic());
            toolbarControl.LanguageManager.RegisterLanguage(new VisualBasic7());
            toolbarControl.LanguageManager.RegisterLanguage(new VisualBasic8());
            toolbarControl.LanguageManager.RegisterLanguage(new VisualBasic9());

            toolbarControl.LanguageManager.ActiveLanguage = selected;
        }

        private void RegisterServices()
        {
            ServiceProvider serviceProvider = ServiceProvider.GetInstance();
            serviceProvider.RegisterService(typeof(IAssemblyManager), assemblyManager);
            serviceProvider.RegisterService(typeof(IAssemblyBrowser), assemblyBrowserControl);
            serviceProvider.RegisterService(typeof(ILanguageManager), toolbarControl.LanguageManager);
            serviceProvider.RegisterService(typeof(IWindowManager), windowStackerControl);
        }

        private void RegisterActions()
        {
            RegisterAction(new LoadAssemblyAction());
            RegisterAction(new UnloadAssemblyAction());
            RegisterAction(new DisassembleAction());
            RegisterAction(new GoBackAction());
            RegisterAction(new GoForwardAction());
            RegisterAction(new AnalyzeAction());
        }

        public void RegisterAction(IAction action)
        {
            actions.Add(action.Name, action);
        }

        public void UnRegisterAction(IAction action)
        {
            actions.Remove(action.Name);
        }
        #endregion

        #region IActionManager
        public void ExecuteAction(ActionNames name)
        {
            if (name != ActionNames.None)
            {
                GetAction(name).Execute();

            }
        }

        public IAction GetAction(ActionNames name)
        {
            if (!actions.ContainsKey(name))
            {
                throw new ArgumentException(name + " is not registered");
            }
            return actions[name];
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
            }

            InitializeComponent();

            if (!DesignMode)
            {
                toolbarControl.WireItems();
                menuControl.WireItems();

                RegisterLanguages();
                RegisterServices();
            }
        }
        #endregion
    }
}
