using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace CloseActPlugin 
{
    public class CloseActPluginMain : IActPluginV1
    {
        private Label lblStatus;   
        private Thread CloseWorkerThread;
        public SettingsPage SettingsCtr = null;
        private bool isCombatEventRegistered = false;
        private bool isCloseThreadStarted = false;
        private readonly string SingletonFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\CloseActPlugin.singleton");
        private FileStream SingletonFS = null;
        public Boolean Initialized = false;

        public void DeInitPlugin()
        {
            StopCloseTask();
            UnregisterClearEvent();
            UpdateText("Plugin Exited");
            Initialized = false;
        }
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            if (SettingsCtr == null) SettingsCtr = new SettingsPage(this);
            pluginScreenSpace.Controls.Add(SettingsCtr);
            lblStatus = pluginStatusText;
            Settings.ReadFromFile(this);
            if (Settings.GetMinimizeEnabled()) ActGlobals.oFormActMain.WindowState = FormWindowState.Minimized;
            SettingsUpdated();
            UpdateText("Plugin Started");
            Initialized = true;
        }

        public void StartCloseTask()
        {
            if (!isCloseThreadStarted) 
            { 
                CloseWorker w = new CloseWorker(this);
                CloseWorkerThread = new Thread(w.Main);
                CloseWorkerThread.Start();
                isCloseThreadStarted = true;
            }
        }

        public void StopCloseTask()
        {
            if (isCloseThreadStarted)
            {
                CloseWorkerThread.Abort();
                isCloseThreadStarted = false;
            }
        }

        public void RegisterClearEvent()
        {
            if (!isCombatEventRegistered)
            {
                ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;
                isCombatEventRegistered = true;
            }
        }

        public void UnregisterClearEvent()
        {
            if (isCombatEventRegistered)
            {
                ActGlobals.oFormActMain.OnCombatEnd -= CombatEnded;
                isCombatEventRegistered = false;
            }
        }

        public void ObtainSingletonLock()
        {
            try
            {
                if (SingletonFS == null) SingletonFS = new FileStream(SingletonFile, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                MessageBox.Show("You have set CloseActPlugin to prevent running of 2nd copy of ACT. This instance will now close."
                    , "Another ACT instance is running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActGlobals.oFormActMain.Close();
            }
        }

        public void ReleaseSingletonLock()
        {
            if (SingletonFS != null) 
            { 
                SingletonFS.Close();
                SingletonFS = null;
            }
        }

        public void SettingsUpdated()
        {
            Settings.ReadSettingsFromTab(this);
            if (Settings.GetCloseEnabled()) StartCloseTask(); else StopCloseTask();
            if (Settings.GetClearEnabled()) RegisterClearEvent(); else UnregisterClearEvent();
            if (Settings.GetSingletonEnabled()) ObtainSingletonLock(); else ReleaseSingletonLock();
        }
        
        public void UpdateText(String txt)
        {
            lblStatus.Text = txt;
        }

        private void CombatEnded(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            UpdateText("Cleared encounters at " + DateTime.Now.ToString(CultureInfo.CurrentCulture));
            ActGlobals.oFormActMain.GetType().GetMethod("btnClear_Click", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(ActGlobals.oFormActMain, new object[] { null, null }); 
        }
    }
    
    class CloseWorker
    {
        private CloseActPluginMain c;
        public CloseWorker(CloseActPluginMain c)
        {
            this.c = c;
        }
        public void Main()
        {
            while (true)
            {
                Process[] p = Process.GetProcessesByName("ffxiv_dx11");
                if(p.Length == 0) p = Process.GetProcessesByName("ffxiv");
                if (p.Length > 0)
                {
                    c.UpdateText("Process found "+ p[0].ProcessName + "("+ p[0].Id +"), now waiting for exit");
                    p[0].WaitForExit();
                    ActGlobals.oFormActMain.Close();
                    break;
                }
                else
                {
                    c.UpdateText("Process not found, waiting for process");
                    Thread.Sleep(3000);
                }
            }

        }
    }
}
