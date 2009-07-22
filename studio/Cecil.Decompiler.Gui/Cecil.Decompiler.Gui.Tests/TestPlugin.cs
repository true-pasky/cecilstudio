using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Gui.Services;
using System.Windows.Forms;

namespace Cecil.Decompiler.Gui.Tests
{
    class TestPlugin : IPlugin
    {
        const string WINDOW_NAME = "WDN_PLUGIN";
        const string MENU_NAME = "MEN_PLUGIN";

        IServiceProvider sp;
        IWindowManager wm;
        IBarManager bm;
        IBarMenu menu;
        IBarButton button;
        IBarButton button2;

        public void Click(Object sender, EventArgs args)
        {
            MessageBox.Show("Hello from " + sender.GetType().Name);
            Unload();
        }

        public void Load(IServiceProvider serviceProvider)
        {
            sp = serviceProvider;
            wm = sp.GetService(typeof (IWindowManager)) as IWindowManager;
            var pw = wm.Windows.Add(WINDOW_NAME, new PluginControl(), "Plugin test");
            pw.Visible = true;

            bm = serviceProvider.GetService(typeof(IBarManager)) as IBarManager;
            button = bm.Bars[BarNames.Menu].Items.AddButton("Plugin - test button!", new EventHandler(Click));
            menu = bm.Bars[BarNames.Menu].Items.AddMenu(MENU_NAME, "Plugin - test menu!");

            button2 = bm.Bars[MENU_NAME].Items.AddButton("test #2!", new EventHandler(Click));
        }

        public void Unload()
        {
            bm.Bars[MENU_NAME].Items.Remove(button2);
            bm.Bars[BarNames.Menu].Items.Remove(button);
            bm.Bars[BarNames.Menu].Items.Remove(menu);

            wm.Windows[WINDOW_NAME].Visible = false;
            wm.Windows.Remove(WINDOW_NAME);
        }
    }
}
