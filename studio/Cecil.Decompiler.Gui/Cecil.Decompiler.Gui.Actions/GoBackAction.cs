using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class GoBackAction : BaseAction
    {
        #region IAction
        public override ActionNames Name
        {
            get { return ActionNames.GoBack; }
        }

        public override void Execute()
        {
            var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            assemblyBrowser.GoBack();
        }
        #endregion
    }
}
