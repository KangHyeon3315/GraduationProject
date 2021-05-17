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

    public partial class Main : Form, SettingsInterface
    {
        bool CollectFold;
        bool isPriceCollecting;
        bool isFSCollecting;

        Library.Settings settings;
        Forms.SettingsControl settingsControl;

        System.Diagnostics.ProcessStartInfo Pri;
        System.Diagnostics.Process Pro;
        Thread CollectorTh;
        Thread IndicatorAndReprocessingTh;
        ProcessInfo processinfo;

        Forms.EmptyControl empty;
        Layout.Home home;
        Layout.Analyze analyze;
        Forms.SimulateForm simulate;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;

        Library.Network net;

        public string InterpreterPath 
        { 
            get
            {
                return settings.info.InterpreterPath;
            }

            set
            {
                settings.info.InterpreterPath = value;
            }
        }
        public string APICollectorPath
        {
            get
            {
                return settings.info.APICollectorPath;
            }
            set
            {
                settings.info.APICollectorPath = value;
            }
        }
        public string DartCollectorPath
        {
            get
            {
                return settings.info.DartCollectorPath;
            }
            set
            {
                settings.info.DartCollectorPath = value;
            }
        }
        public float RequestsInterval
        {
            get
            {
                return settings.info.RequestsInterval;
            }
            set
            {
                settings.info.RequestsInterval = value;
            }
        }
        public int MaxRequests
        {
            get
            {
                return settings.info.MaxRequestsCount;
            }
            set
            {
                settings.info.MaxRequestsCount = value;
            }
        }
        public string DartAPIKey
        {
            get
            {
                return settings.info.DartAPI;
            }
            set
            {
                settings.info.DartAPI = value;
            }
        }
        public string DBIP
        {
            get
            {
                return settings.info.DBIP;
            }
            set
            {
                settings.info.DBIP = value;
            }
        }
        public int DBPort
        {
            get
            {
                return settings.info.DBPort;
            }
            set
            {
                settings.info.DBPort = value;
            }
        }
        public string DBID
        {
            get
            {
                return settings.info.DBID;
            }
            set
            {
                settings.info.DBID = value;
            }
        }
        public string DBPW
        {
            get
            {
                return settings.info.DBPW;
            }
            set
            {
                settings.info.DBPW = value;
            }
        }

        public void SaveSetting()
        {
            settings.SaveSettings();
            logInterface.WriteLog("Log", "None", "None", "Saved Settings");
        }

        public Main()
        {
            InitializeComponent();

            CollectFold = true;

            processinfo = ProcessInfo.None;
            settings = new Library.Settings();

            settingsControl = new Forms.SettingsControl(this as SettingsInterface);
            empty = new Forms.EmptyControl("Empty");
            simulate = new Forms.SimulateForm(this as SettingsInterface);
            analyze = new Layout.Analyze();
            home = new Layout.Home(this as SettingsInterface);
            logInterface = home.logInterface;
            progressInterface = home.progressInterface;

            net = new Library.Network(logInterface, progressInterface, settings);

            this.WindowState = FormWindowState.Maximized;

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

        private void CheckSystem(object sender, EventArgs e)
        {
            
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

                // 보조지표 계산 및 시뮬레이션 데이터 수집 진행
                IndicatorAndReprocessingTh = new Thread(new ThreadStart(CalculateIndicatorAndRecollect));
                IndicatorAndReprocessingTh.Start();
                net.apiCollector.Complete = false;
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

        
        private void HomeClick(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
        }

        private void AnalyzeClick(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(analyze);
        }

        private void SimulateClick(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(simulate);
        }

        private void TradeClick(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(empty);
        }

        private void SettingClick(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(settingsControl);
        }
        private void CollectClick(object sender, EventArgs e)
        {
            if (CollectFold)
            {
                PriceCollectButton.Visible = true;
                FSCollectButton.Visible = true;
                CollectFold = false;
            }
            else
            {
                PriceCollectButton.Visible = false;
                FSCollectButton.Visible = false;
                CollectFold = true;
            }
        }
        private void PriceCollectClick(object sender, EventArgs e)
        {
            if (isFSCollecting)
            {
                MessageBox.Show("다른 작업이 진행중입니다. 작업을 완료하고 실행하세요.");
                return;
            }

            if (settings.info.APICollectorPath == null || settings.info.InterpreterPath == null || settings.info.APICollectorPath.Trim() == "" || settings.info.InterpreterPath.Trim() == "" || settings.info.RequestsInterval == 0 || settings.info.MaxRequestsCount == 0)
            {
                MessageBox.Show("설정 정보를 먼저 세팅하세요.");
                return;
            }

            if (isPriceCollecting)
            {
                // 작업 중지 기능 수행
                PriceCollectButton.Text = "가격 지표 수집";
                isPriceCollecting = !isPriceCollecting;
                CloseAPICollector();
                
            }
            else
            {
                // 작업 실행 기능 수행
                PriceCollectButton.Text = "가격 지표 수집 중단";
                isPriceCollecting = !isPriceCollecting;
                
                CollectorTh = new Thread(new ThreadStart(ExecuteAPICollector));
                CollectorTh.Start();
            }
        }

        private void FSClick(object sender, EventArgs e)
        {
            if (isPriceCollecting)
            {
                MessageBox.Show("다른 작업이 진행중입니다. 작업을 완료하고 실행하세요.");
                return;
            }

            if (settings.info.DartCollectorPath == null || settings.info.InterpreterPath == null || settings.info.DartAPI == null || settings.info.DartCollectorPath.Trim() == "" || settings.info.InterpreterPath.Trim() == "" || settings.info.DartAPI.Trim() == "")
            {
                MessageBox.Show("설정 정보를 먼저 세팅하세요.");
                return;
            }

            if (isFSCollecting)
            {
                // 작업 중지 기능 수행
                FSCollectButton.Text = "재무제표 수집";
                isFSCollecting = !isFSCollecting;
                CloseDartCollector();
            }
            else
            {
                // 작업 실행 기능 수행
                FSCollectButton.Text = "재무제표 수집 중단";
                isFSCollecting = !isFSCollecting;

                CollectorTh = new Thread(new ThreadStart(ExecuteDartCollector));
                CollectorTh.Start();
            }
        }

        void ExecuteAPICollector()
        {
            try
            {
                Library.DBController DB = new Library.DBController(DBIP, DBID, DBPW);
                DataTable corpinfo = DB.SelectCompanyInfo();

                string date = DateTime.Now.ToString("yyyyMMdd");

                for(int i = 0; i < corpinfo.Rows.Count; i++)
                {
                    if(int.Parse(corpinfo.Rows[i]["daily_collecting"].ToString()) < int.Parse(date))
                    {
                        date = corpinfo.Rows[i]["daily_collecting"].ToString();
                    }
                    /*
                    if (int.Parse(corpinfo.Rows[i]["min_collecting"].ToString()) < int.Parse(date))
                    {
                        date = corpinfo.Rows[i]["min_collecting"].ToString();
                    }
                    */
                }

                string today;
                if(int.Parse(DateTime.Now.ToString("HHmm")) <= 1530)
                {
                    today = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
                }
                else
                {
                    today = DateTime.Now.ToString("yyyyMMdd");
                }
                
                if(int.Parse(date) < int.Parse(today))
                {
                    net.open();

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
                else
                {
                    CalculateIndicatorAndRecollect();
                }
                
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

                logInterface.WriteLog("Debug", "None", "None", "Close API Collector");
                Pro.Kill();
                net.close();
                logInterface.WriteLog("Debug", "None", "None", "Complete Close API Collector");
                progressInterface.Company = "None";
                progressInterface.RqCount = 0;
                processinfo = ProcessInfo.None;
                
            }
        }

        void ExecuteDartCollector()
        {
            try
            {
                net.open();

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
                logInterface.WriteLog("Log", "None", "None", "Close Dart Collector");
                Pro.Kill();
                net.close();
                processinfo = ProcessInfo.None;
            }

        }

        public void CalculateIndicatorAndRecollect()
        {
            Library.IndicatorProcessor indicator = new Library.IndicatorProcessor(logInterface, progressInterface, settings);
            Library.SimulateDataRecollect recollect = new Library.SimulateDataRecollect(settings, logInterface, progressInterface);
        }
    }
}
