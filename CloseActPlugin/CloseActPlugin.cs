using System;
using System.Diagnostics;
using System.Globalization;
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

        public void DeInitPlugin()
        {
            CloseWorkerThread.Abort();
            ActGlobals.oFormActMain.OnCombatEnd -= CombatEnded;
            UpdateText("Plugin Exited");
        }
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            //((TabControl)pluginScreenSpace.Parent).TabPages.Remove(pluginScreenSpace);
            lblStatus = pluginStatusText;
            UpdateText("Plugin Started");
            CloseWorker w = new CloseWorker(this);
            CloseWorkerThread = new Thread(w.Main);
            CloseWorkerThread.Start();
            ActGlobals.oFormActMain.WindowState = FormWindowState.Minimized;
            ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;
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
