using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloseActPlugin
{
    public partial class SettingsPage : UserControl
    {
        private CloseActPluginMain p;
        public SettingsPage(CloseActPluginMain p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void ChkMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (!p.Initialized) return;
            p.SettingsUpdated();
            Settings.SaveToFile(p);
        }

        private void ChkClose_CheckedChanged(object sender, EventArgs e)
        {
            if (!p.Initialized) return;
            p.SettingsUpdated();
            Settings.SaveToFile(p);
        }

        private void ChkClear_CheckedChanged(object sender, EventArgs e)
        {
            if (!p.Initialized) return;
            p.SettingsUpdated();
            Settings.SaveToFile(p);
        }

        private void ChkSingleton_CheckedChanged(object sender, EventArgs e)
        {
            if (!p.Initialized) return;
            p.SettingsUpdated();
            Settings.SaveToFile(p);
        }
    }
}
