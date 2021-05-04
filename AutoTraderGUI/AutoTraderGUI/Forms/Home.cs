using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTraderGUI.Forms
{
    public partial class Home : UserControl, LogInterface, ProgressInterface
    {
        bool scrollToEnd;
        private readonly object thisLock = new object();
        public LogInterface logInterface
        {
            get
            {
                return (this as LogInterface);
            }
        }

        public ProgressInterface progressInterface
        {
            get
            {
                return (this as ProgressInterface);
            }
        }

        public string Task
        {
            get
            {
                return TaskInfoText.Text;
            }
            set
            {
                TaskInfoText.Text = value;
            }
        }
        public string Company
        {
            get
            {
                return CompanyText.Text;
            }
            set
            {
                CompanyText.Text = value;
            }
        }
        public int RqCount
        {
            get
            {
                return int.Parse(RqCountText.Text);
            }
            set
            {
                RqCountText.Text = value.ToString();
            }
        }
        public int CompleteCount
        {
            get
            {
                return int.Parse(CompleteCountText.Text);
            }
            set
            {
                CompleteCountText.Text = value.ToString();
            }
        }
        public int CompanyCount
        {
            get
            {
                return int.Parse(CompanyCountText.Text);
            }
            set
            {
                CompanyCountText.Text = value.ToString();
            }
        }
        public int Progress
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                progressBar1.Value = value;
            }
        }

        public Home()
        {
            InitializeComponent();
            scrollToEnd = true;
            this.Dock = DockStyle.Fill;
        }
        public void WriteLog(string info, string task, string company, string log)
        {
            lock (thisLock)
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ListViewItem item = new ListViewItem(info);
                item.SubItems.Add(time);
                item.SubItems.Add(task);
                item.SubItems.Add(company);
                item.SubItems.Add(log);
                LogViewer.Items.Add(item);

                if (scrollToEnd)
                {
                    LogViewer.Items[LogViewer.Items.Count - 1].EnsureVisible();
                }

                // 나중에 로그 개수가 n개 이상 넘어가면 넘어간 양만큼 삭제
                // Log 저장 Stream 만들기
            }
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            ResizeForm();
        }

        void ResizeForm()
        {
            int totalWidth = LogViewer.Size.Width;
            int restWidth = totalWidth;
            LogViewer.Columns[0].Width = 70;            // info
            restWidth -= LogViewer.Columns[0].Width;

            LogViewer.Columns[1].Width = 120;           // Time
            restWidth -= LogViewer.Columns[1].Width;

            int temp = restWidth / 4;

            LogViewer.Columns[2].Width = temp;          // Task
            restWidth -= LogViewer.Columns[2].Width;

            LogViewer.Columns[3].Width = temp;          // Company
            restWidth -= LogViewer.Columns[3].Width;

            LogViewer.Columns[4].Width = restWidth;     // Log


            totalWidth = AlgorithmInfo.Size.Width;
            restWidth = totalWidth;
            AlgorithmInfo.Columns[0].Width = 90;            // Algorithm Number
            restWidth -= AlgorithmInfo.Columns[0].Width;

            temp = restWidth / 5;

            AlgorithmInfo.Columns[1].Width = temp;
            restWidth -= AlgorithmInfo.Columns[1].Width;

            AlgorithmInfo.Columns[2].Width = temp;
            restWidth -= AlgorithmInfo.Columns[2].Width;

            AlgorithmInfo.Columns[3].Width = temp;
            restWidth -= AlgorithmInfo.Columns[3].Width;

            AlgorithmInfo.Columns[4].Width = temp;
            restWidth -= AlgorithmInfo.Columns[4].Width;

            AlgorithmInfo.Columns[5].Width = restWidth;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
