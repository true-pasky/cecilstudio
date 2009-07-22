using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    class VoidAction : BaseAction
    {
        #region IAction
        public override string Name
        {
            get { return ActionNames.None.ToString(); }
        }

        public override void Execute()
        {
        }
        #endregion
    }
}
