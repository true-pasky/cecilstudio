using Cecil.Decompiler.Gui.Controls;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class AnalyzeAction : BaseStackedWindowControlAction<AnalyzeControl>
    {
        public AnalyzeAction() : base(ActionNames.Analyze)
        {
        }
    }
}
