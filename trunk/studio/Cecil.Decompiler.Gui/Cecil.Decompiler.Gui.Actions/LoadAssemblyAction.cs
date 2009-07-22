using System.Windows.Forms;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Actions
{
    internal partial class LoadAssemblyAction : BaseAction
    {
        #region IAction
        public override string Name
        {
            get { return ActionNames.LoadAssembly.ToString(); }
        }

        public override void Execute()
        {
            var assemblyManager = ServiceProvider.GetInstance().GetService<IAssemblyManager>();
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Assembly files|*.exe;*.dll|All files|*.*";
                openFileDialog.Title = "Open Assembly...";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    assemblyManager.LoadFile(openFileDialog.FileName);
                }
            }
        }
        #endregion
    }
}