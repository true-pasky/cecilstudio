using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    public interface IActionManager : IService
    {
        void ExecuteAction(ActionNames name);
        IAction GetAction(ActionNames name);
    }
}
