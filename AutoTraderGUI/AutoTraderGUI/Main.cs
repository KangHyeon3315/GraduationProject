using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Data;


namespace AutoTraderGUI
{
    enum ProcessInfo
    {
        None,
        APICollector,
        DartCollector
    }

    public partial class Main : Form
    {
        Library.Settings settings;
        Forms.SettingsForm settingsForm;

        System.Diagnostics.ProcessStartInfo Pri;
        System.Diagnostics.Process Pro;
        Thread CollectorTh;
        ProcessInfo processinfo;

        Forms.EmptyControl empty;
        Layout.Home home;
        Layout.Analyze analyze;
        Forms.SimulateForm simulate;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;

        Library.Network net;

        Forms.HistoricalLogViewer historicalLogViewer;

        public Main()
        {
            InitializeComponent();

            processinfo = ProcessInfo.None;
            settings = new Library.Settings();
            settingsForm = new Forms.SettingsForm(settings.info);

            empty = new Forms.EmptyControl("Empty");
            simulate = new Forms.SimulateForm();
            analyze = new Layout.Analyze();
            home = new Layout.Home();
            logInterface = home.logInterface;
            progressInterface = home.progressInterface;

            net = new Library.Network(logInterface, progressInterface, settings);

            this.WindowState = FormWindowState.Maximized;

            TabMenu.Items["MainToolStripLabel"].Font = new Font(TabMenu.Items["MainToolStripLabel"].Font, FontStyle.Bold);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);

            timer1.Start();

        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseDartCollector();
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


            if (Pro != null && !Pro.HasExited)
            {
                if(processinfo == ProcessInfo.APICollector)
                {
                    CloseAPICollector();
                }
                else
                {
                    MessageBox.Show("다른 하위 프로세스가 작동중입니다.");
                }
                
            }
            else
            {
                CollectorTh = new Thread(new ThreadStart(ExecuteAPICollector));
                CollectorTh.Start();
            }

        }

        void ExecuteAPICollector()
        {
            try
            {
                Pri = new System.Diagnostics.ProcessStartInfo();
                Pri.FileName = settings.info.InterpreterPath;
                Pri.Arguments = settings.info.APICollectorPath + string.Format(" {0} {1} {2} {3} {4}", settings.info.RequestsInterval, settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW);

                Pri.UseShellExecute = false;
                Pri.CreateNoWindow = true;
                Pri.RedirectStandardOutput = false;
                Pri.RedirectStandardError = false;

                processinfo = ProcessInfo.APICollector;
                progressInterface.Title = "API Collector";
                logInterface.WriteLog("Debug", "None", "None", "Execute API Collector");

                Pro = System.Diagnostics.Process.Start(Pri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "ExecuteAPICollector", "None", ex.Message);
            }
        }
        void CloseAPICollector()
        {
            if (Pro != null && !Pro.HasExited && processinfo == ProcessInfo.APICollector)
            {
                net.apiCollector.Close();
                logInterface.WriteLog("Debug", "None", "None", "Close API Collector");
                Pro.Kill();
                progressInterface.Company = "None";
                progressInterface.RqCount = 0;
                processinfo = ProcessInfo.None;
                net.RebootServer();                     // Listen 카운팅 해서 필요할때만 Reboot하도록 수정
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

            logInterface.WriteLog("Log", "None", "None", "Saved Settings");
        }

        private void DartCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(settings.info.DartCollectorPath != "" || settings.info.InterpreterPath != "" || settings.info.DartAPI != ""))
            {
                MessageBox.Show("설정 정보를 먼저 세팅하세요.");
                return;
            }

            if (Pro != null && !Pro.HasExited)
            {
                if(processinfo == ProcessInfo.DartCollector)
                {
                    CloseDartCollector();
                }
                else
                {
                    MessageBox.Show("다른 하위 프로세스가 작동중입니다.");
                }
                    
            }
            else
            {
                CollectorTh = new Thread(new ThreadStart(ExecuteDartCollector));
                CollectorTh.Start();
            }
        }

        void ExecuteDartCollector()
        {
            try
            {
                Pri = new System.Diagnostics.ProcessStartInfo();
                Pri.FileName = settings.info.InterpreterPath;
                Pri.Arguments = settings.info.DartCollectorPath + string.Format(" {0} {1} {2} {3} {4}", settings.info.DartAPI, settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW);

                Pri.UseShellExecute = false;
                Pri.CreateNoWindow = false;
                Pri.RedirectStandardOutput = false;
                Pri.RedirectStandardError = false;

                processinfo = ProcessInfo.DartCollector;
                progressInterface.Title = "Dart Collector";
                logInterface.WriteLog("Log", "None", "None", "Execute Dart Collector");

                Pro = System.Diagnostics.Process.Start(Pri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "ExecuteDartCollector", "None", ex.Message);
            }
        }
        void CloseDartCollector()
        {
            if (Pro != null && !Pro.HasExited && processinfo == ProcessInfo.DartCollector)
            {
                net.dartCollector.Close();
                logInterface.WriteLog("Log", "None", "None", "Close Dart Collector");
                Pro.Kill();
                processinfo = ProcessInfo.None;
                net.RebootServer();
            }

        }

        private void CheckSystem(object sender, EventArgs e)
        {
            
            if (Pro != null && !Pro.HasExited && processinfo == ProcessInfo.APICollector)
            {
                aPICollectorToolStripMenuItem.Text = "API Collector 종료";
            }
            else
            {
                aPICollectorToolStripMenuItem.Text = "API Collector 시작";
            }
            
            
            if (Pro != null && !Pro.HasExited && processinfo == ProcessInfo.DartCollector)
            {
                dartCollectorToolStripMenuItem.Text = "Dart Collector 종료";
            }
            else
            {
                dartCollectorToolStripMenuItem.Text = "Dart Collector 시작";
            }

            if (progressInterface.RqCount == settings.info.MaxRequestsCount - 10 && processinfo == ProcessInfo.APICollector)
            {
                CloseAPICollector();
                progressInterface.RqCount = 0;
                progressInterface.Company = "None";
                ExecuteAPICollector();
            }
            if(net.apiCollector != null && net.apiCollector.Complete)
            {
                CloseAPICollector();
            }

            if (net.dartCollector != null && net.dartCollector.Complete)
            {
                net.dartCollector.ReceiveTh.Abort();
                net.dartCollector.LogTh.Abort();
                processinfo = ProcessInfo.None;
            }

            // 2분 이상 API Collector가 응답이 없으면 재실행
            if (Pro != null && !Pro.HasExited && net.apiCollector != null && !net.apiCollector.Complete && processinfo == ProcessInfo.APICollector)
            {
                if (home.logViewer.LastLogTime != "")
                {
                    TimeSpan term = DateTime.Now - DateTime.Parse(home.logViewer.LastLogTime);

                    if (term.TotalMinutes > 2)
                    {
                        logInterface.WriteLog("Log", "None", "None", "API Collector가 응답이 없음. 재실행");
                        CloseAPICollector();
                        progressInterface.RqCount = 0;
                        progressInterface.Company = "None";
                        ExecuteAPICollector();
                    }
                }
            }

            if(Pro != null && Pro.HasExited)
            {
                processinfo = ProcessInfo.None;
            }
        }

        private void ResetClickToolStrip()
        {
            for(int i = 0; i < TabMenu.Items.Count; i++)
            {
                TabMenu.Items[i].Font = new Font(TabMenu.Items[i].Font, FontStyle.Regular);
            }
        }

        private void ClickHome(object sender, EventArgs e)
        {
            ResetClickToolStrip();
            TabMenu.Items["MainToolStripLabel"].Font = new Font(TabMenu.Items["MainToolStripLabel"].Font, FontStyle.Bold);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
        }
        private void ClickAnalyze(object sender, EventArgs e)
        {
            ResetClickToolStrip();
            TabMenu.Items["AnalyzeToolStripLabel"].Font = new Font(TabMenu.Items["AnalyzeToolStripLabel"].Font, FontStyle.Bold);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(analyze);
        }

        private void ClickSimulate(object sender, EventArgs e)
        {
            ResetClickToolStrip();
            TabMenu.Items["SimulationToolStripLabel"].Font = new Font(TabMenu.Items["SimulationToolStripLabel"].Font, FontStyle.Bold);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(simulate);
        }

        private void ClickTrade(object sender, EventArgs e)
        {
            ResetClickToolStrip();
            TabMenu.Items["TradeToolStripLabel"].Font = new Font(TabMenu.Items["TradeToolStripLabel"].Font, FontStyle.Bold);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(empty);
        }

        private void HistoricalLogClick(object sender, EventArgs e)
        {
            historicalLogViewer = new Forms.HistoricalLogViewer();
            historicalLogViewer.Show();
        }

    }
}
