﻿using System;
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

        Forms.HistoricalLogViewer historicalLogViewer;

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


            if (APICollecotrPro != null && !APICollecotrPro.HasExited)
            {
                CloseAPICollector();
            }
            else
            {
                APICollectorTh = new Thread(new ThreadStart(ExecuteAPICollector));
                APICollectorTh.Start();
            }

            

        }

        void ExecuteAPICollector()
        {
            try
            {
                APICollectorPri = new System.Diagnostics.ProcessStartInfo();
                APICollectorPri.FileName = settings.info.InterpreterPath;
                APICollectorPri.Arguments = settings.info.APICollectorPath + string.Format(" {0} {1} {2} {3} {4}", settings.info.RequestsInterval, settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW);

                APICollectorPri.UseShellExecute = false;
                APICollectorPri.CreateNoWindow = true;
                APICollectorPri.RedirectStandardOutput = false;
                APICollectorPri.RedirectStandardError = false;

                logInterface.WriteLog("Log", "None", "None", "Execute API Collector");
                APICollecotrPro = System.Diagnostics.Process.Start(APICollectorPri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "ExecuteAPICollector", "None", ex.Message);
            }
        }
        void CloseAPICollector()
        {
            if (APICollecotrPro != null && !APICollecotrPro.HasExited)
            {
                net.apiCollector.Close();
                logInterface.WriteLog("Log", "None", "None", "Close API Collector");
                APICollecotrPro.Kill();
                progressInterface.Company = "None";
                progressInterface.RqCount = 0;
                net.RebootServer();
            }
        }



        private void SettingsClick(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();

            settings.info.APICollectorPath = settingsForm.APICollectorPath.Text;
            settings.info.DartCollectorPath = settingsForm.DartCollectorPath.Text + string.Format(" {0} {1} {2} {3} {4}", settings.info.DartAPI, settings.info.DBIP, settings.info.DBPort, settings.info.DBID, settings.info.DBPW);
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

            if (DartCollecotrPro != null && !DartCollecotrPro.HasExited)
            {
                CloseDartCollector();
            }
            else
            {
                DartCollectorTh = new Thread(new ThreadStart(ExecuteDartCollector));
                DartCollectorTh.Start();
            }
        }

        void ExecuteDartCollector()
        {
            try
            {
                DartCollectorPri = new System.Diagnostics.ProcessStartInfo();
                DartCollectorPri.FileName = settings.info.InterpreterPath;
                DartCollectorPri.Arguments = settings.info.DartCollectorPath;

                DartCollectorPri.UseShellExecute = false;
                DartCollectorPri.CreateNoWindow = true;
                DartCollectorPri.RedirectStandardOutput = false;
                DartCollectorPri.RedirectStandardError = false;

                logInterface.WriteLog("Log", "None", "None", "Execute Dart Collector");
                DartCollecotrPro = System.Diagnostics.Process.Start(DartCollectorPri);
            }
            catch (Exception ex)
            {
                logInterface.WriteLog("Exception", "ExecuteDartCollector", "None", ex.Message);
            }
        }
        void CloseDartCollector()
        {
            if (DartCollecotrPro != null && !DartCollecotrPro.HasExited)
            {
                net.dartCollector.Close();
                logInterface.WriteLog("Log", "None", "None", "Close Dart Collector");
                DartCollecotrPro.Kill();
                net.RebootServer();
            }

        }

        private void CheckSystem(object sender, EventArgs e)
        {
            
            if (APICollecotrPro != null && !APICollecotrPro.HasExited)
            {
                aPICollectorToolStripMenuItem.Text = "API Collector 종료";
            }
            else
            {
                aPICollectorToolStripMenuItem.Text = "API Collector 시작";
            }
            
            
            if (DartCollecotrPro != null && !DartCollecotrPro.HasExited)
            {
                dartCollectorToolStripMenuItem.Text = "Dart Collector 종료";
            }
            else
            {
                dartCollectorToolStripMenuItem.Text = "Dart Collector 시작";
            }

            if (progressInterface.RqCount == settings.info.MaxRequestsCount - 10)
            {
                CloseAPICollector();
                progressInterface.RqCount = 0;
                progressInterface.Company = "None";
                ExecuteAPICollector();
            }
            
            if (net.dartCollector != null && net.dartCollector.Complete)
            {
                CloseDartCollector();
            }
        }

        private void ClickHome(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
        }

        private void HistoricalLogClick(object sender, EventArgs e)
        {
            historicalLogViewer = new Forms.HistoricalLogViewer();
            historicalLogViewer.Show();
        }
    }
}
