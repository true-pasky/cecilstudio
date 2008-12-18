using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Gui.Services;

namespace Cecil.Decompiler.Gui.Tests
{
    class TestPlugin : IPlugin
    {
        public void Load(IServiceProvider serviceProvider)
        {
            var wm = serviceProvider.GetService(typeof (IWindowManager)) as IWindowManager;
            var pw = wm.Windows.Add("test", new PluginControl(), "Plugin test");
            pw.Visible = true;
        }

        public void Unload()
        {
        }
    }
}
