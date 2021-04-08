using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace AutoTraderGUI
{
    public partial class Main : Form
    {
        Library.Settings settings;
        Forms.SettingsForm settingsForm;

        System.Diagnostics.ProcessStartInfo APICollectorPri;
        System.Diagnostics.Process APICollecotrPro;
        Thread APICollectorTh;

        System.Diagnostics.ProcessStartInfo DartCollectorPri;
        System.Diagnostics.Process DartCollecotrPro;
        Thread DartCollectorTh;

        Forms.Home home;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;
        Library.Network net;

        public Main()
        {
            InitializeComponent();

            settings = new Library.Settings();
            settingsForm = new Forms.SettingsForm(settings.info);

            home = new Forms.Home();
            logInterface = home.logInterface;
            progressInterface = home.progressInterface;

            net = new Library.Network(logInterface, progressInterface, settings);

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAPICollector();

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void APICollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(settings.info.APICollectorPath != "" || settings.info.InterpreterPath != "" || settings.info.RequestsInterval != 0 || settings.info.MaxRequestsCount != 0))
            {
                MessageBox.Show("설정 정보를 먼저 세팅하세요.");
                return;
            }

            APICollectorTh = new Thread(new ThreadStart(ExecuteAPICollector));
            APICollectorTh.Start();

        }

        void ExecuteAPICollector()
        {
            try
            {
                APICollectorPri = new System.Diagnostics.ProcessStartInfo();
                APICollectorPri.FileName = settings.info.InterpreterPath;
                APICollectorPri.Arguments = settings.info.APICollectorPath;

                APICollectorPri.UseShellExecute = false;
                APICollectorPri.CreateNoWindow = false;
                APICollectorPri.RedirectStandardOutput = false;
                APICollectorPri.RedirectStandardError = false;

                logInterface.WriteLog("log", "None", "None", "Execute API Collector");
                APICollecotrPro = System.Diagnostics.Process.Start(APICollectorPri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("exception", "ExecuteAPICollector", "None", ex.Message);
            }
        }
        void CloseAPICollector()
        {
            if (APICollecotrPro != null && !APICollecotrPro.HasExited)
            {
                logInterface.WriteLog("log", "None", "None", "Close API Collector");
                APICollecotrPro.Kill();
            }
                
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();

            settings.info.APICollectorPath = settingsForm.APICollectorPath.Text;
            settings.info.DartCollectorPath = settingsForm.DartCollectorPath.Text;
            settings.info.InterpreterPath = settingsForm.InterpreterPath.Text;
            settings.info.MaxRequestsCount = int.Parse(settingsForm.MaxRequestsCount.Text);
            settings.info.RequestsInterval = float.Parse(settingsForm.RequestsInterval.Text);
            settings.info.DartAPI = settingsForm.DartAPI.Text;
            settings.SaveSettings();

            // Net 클래스에 Requests 정보들 저장
            logInterface.WriteLog("log", "None", "None", "Saved Settings");
        }

        private void DartCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(settings.info.DartCollectorPath != "" || settings.info.InterpreterPath != "" || settings.info.DartAPI != ""))
            {
                MessageBox.Show("설정 정보를 먼저 세팅하세요.");
                return;
            }

            DartCollectorTh = new Thread(new ThreadStart(ExecuteDartCollector));
            DartCollectorTh.Start();
        }

        void ExecuteDartCollector()
        {
            try
            {
                DartCollectorPri = new System.Diagnostics.ProcessStartInfo();
                DartCollectorPri.FileName = settings.info.InterpreterPath;
                DartCollectorPri.Arguments = settings.info.DartCollectorPath;

                DartCollectorPri.UseShellExecute = false;
                DartCollectorPri.CreateNoWindow = false;
                DartCollectorPri.RedirectStandardOutput = false;
                DartCollectorPri.RedirectStandardError = false;

                logInterface.WriteLog("log", "None", "None", "Execute Dart Collector");
                DartCollecotrPro = System.Diagnostics.Process.Start(DartCollectorPri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("exception", "ExecuteDartCollector", "None", ex.Message);
            }
        }
        void CloseDartCollector()
        {
            if (DartCollecotrPro != null && !DartCollecotrPro.HasExited)
            {
                logInterface.WriteLog("log", "None", "None", "Close Dart Collector");
                DartCollecotrPro.Kill();
            }

        }

        private void CheckSystem(object sender, EventArgs e)
        {
            if(home.RqCount == settings.info.MaxRequestsCount - 10)
            {
                CloseAPICollector();
                home.RqCount = 0;
            }
            if (net.dartCollector.Complete)
            {
                CloseDartCollector();
            }
        }
    }
}
