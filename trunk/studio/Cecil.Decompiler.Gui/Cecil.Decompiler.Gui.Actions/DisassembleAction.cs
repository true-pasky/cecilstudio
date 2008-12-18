using Cecil.Decompiler.Gui.Controls;

namespace Cecil.Decompiler.Gui.Actions
{
    internal class DisassembleAction : BaseStackedWindowControlAction<DisassembleControl>
    {
        public DisassembleAction() : base(ActionNames.Disassemble)
        {
        }
    }
}
