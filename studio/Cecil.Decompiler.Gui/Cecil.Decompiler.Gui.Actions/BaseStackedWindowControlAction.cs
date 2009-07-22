using System.Windows.Forms;
using Cecil.Decompiler.Gui.Controls;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class BaseStackedWindowControlAction<T> : BaseAction where T : StackedWindowControl, new()
    {
        private readonly T window = new T();
        private readonly string actionName;

        public BaseStackedWindowControlAction(string actionName)
        {
            this.actionName = actionName;
        }

        public BaseStackedWindowControlAction(ActionNames actionName)
        {
            this.actionName = actionName.ToString();
        }

        #region IAction
        public override string Name
        {
            get { return actionName; }
        }

        public override void Execute()
        {
            var windowManager = ServiceProvider.GetInstance().GetService<IWindowManager>();
            var controlWindow = windowManager.Windows[window.Identifier.ToString()];

            if (controlWindow != null)
            {
                controlWindow.Visible = true;
            }
            else
            {
                if (windowManager is WindowStackerControl)
                {
                    var stacker = windowManager as WindowStackerControl;
                    stacker.Add(window.Identifier.ToString(), window);
                }
            }
        }
        #endregion
    }
}
