using System;

namespace Cecil.Decompiler.Gui.Actions
{
    internal abstract class BaseAction : IAction 
    {
        private bool enabled = true;

        #region IAction
        public event EventHandler EnabledChanged;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
            }
        }
        public abstract ActionNames Name { get; }
        public abstract void Execute();
        #endregion
    }
}
