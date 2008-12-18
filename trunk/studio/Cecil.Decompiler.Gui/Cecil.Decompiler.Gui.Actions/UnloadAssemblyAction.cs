using System;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class UnloadAssemblyAction : BaseAction
    {
        #region IAction
        public override ActionNames Name
        {
            get { return ActionNames.UnloadAssembly; }
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
