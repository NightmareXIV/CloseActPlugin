using System;
using Advanced_Combat_Tracker;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CloseActPlugin
{
    public class Settings
    {
        public static bool[] cfg = new bool[] { true, true, false, false };

        public static bool GetMinimizeEnabled()
        {
            return cfg[0];
        }
        public static bool GetCloseEnabled()
        {
            return cfg[1];
        }
        public static bool GetClearEnabled()
        {
            return cfg[2];
        }
        public static bool GetSingletonEnabled()
        {
            return cfg[3];
        }

        public static void ReadSettingsFromTab(CloseActPluginMain p)
        {
            cfg = new bool[]
            {
                p.SettingsCtr.ChkMinimize.Checked,
                p.SettingsCtr.ChkClose.Checked,
                p.SettingsCtr.ChkClear.Checked,
                p.SettingsCtr.ChkSingleton.Checked
            };
        }

        public static void ReadFromFile(CloseActPluginMain p)
        {
            String settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\CloseActPlugin.dat");
            try
            {
                String[] s = File.ReadAllText(settingsFile).Split(',');
                for (int i = 0; i < s.Length; i++)
                {
                    cfg[i] = Boolean.Parse(s[i]);
                }
            }
            catch (Exception) { }
            p.SettingsCtr.ChkMinimize.Checked = GetMinimizeEnabled();
            p.SettingsCtr.ChkClose.Checked = GetCloseEnabled();
            p.SettingsCtr.ChkClear.Checked = GetClearEnabled();
            p.SettingsCtr.ChkSingleton.Checked = GetSingletonEnabled();
        }

        public static void SaveToFile(CloseActPluginMain p)
        {
            String settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\CloseActPlugin.dat");
            try
            {
                String s = String.Join(",", cfg);
                File.WriteAllText(settingsFile, s);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Error occurred during attempt to save settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
