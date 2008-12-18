using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class GoForwardAction : BaseAction
    {
        #region IAction
        public override ActionNames Name
        {
            get { return ActionNames.GoForward; }
        }

        public override void Execute()
        {
            var assemblyBrowser = ServiceProvider.GetInstance().GetService<IAssemblyBrowser>();
            assemblyBrowser.GoForward();
        }
        #endregion
    }
}
