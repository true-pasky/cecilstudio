using Cecil.Decompiler.Gui.Controls;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class DisassembleAction : BaseStackedWindowControlAction<DisassembleControl>
    {
        public DisassembleAction()
            : base(ActionNames.Disassemble)
        {
        }
    }
}
