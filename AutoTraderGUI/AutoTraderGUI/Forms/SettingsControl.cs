using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AutoTraderGUI.Forms
{
    public partial class SettingsControl : UserControl
    {

        SettingsInterface info;
        public SettingsControl(SettingsInterface info)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.info = info;

            InterpreterPath.Text = info.InterpreterPath;
            APICollectorPath.Text = info.APICollectorPath;
            DartCollectorPath.Text = info.DartCollectorPath;
            MaxRequestsCount.Text = info.MaxRequests.ToString();
            RequestsInterval.Text = info.RequestsInterval.ToString();
            DartAPI.Text = info.DartAPIKey;

            DBIP.Text = info.DBIP;
            DBPort.Text = info.DBPort.ToString();
            DBID.Text = info.DBID;
            DBPW.Text = info.DBPW;
        }

        private void ApplicationButtonClick(object sender, EventArgs e)
        {
            int tmp;
            float tmp2;
            IPAddress tmp3;
            
            if (InterpreterPath.Text != "" && APICollectorPath.Text != "" && DartCollectorPath.Text != "" && MaxRequestsCount.Text != "" && RequestsInterval.Text != "" && DartAPI.Text != "" && DBIP.Text != "" && DBPort.Text != "" && DBID.Text != "" && DBPW.Text != "")
            {
                if (!(File.Exists(InterpreterPath.Text) && InterpreterPath.Text.Contains("python.exe")))
                {
                    MessageBox.Show("인터프리터 경로를 정확하게 입력하세요.");
                }
                else if (!(File.Exists(APICollectorPath.Text) && APICollectorPath.Text.Contains(".py")))
                {
                    MessageBox.Show("APICollector 경로를 정확하게 입력하세요.");
                }
                else if (!(File.Exists(DartCollectorPath.Text) && DartCollectorPath.Text.Contains(".py")))
                {
                    MessageBox.Show("DartCollector 경로를 정확하게 입력하세요.");
                }
                else if (!int.TryParse(MaxRequestsCount.Text, out tmp))
                {
                    MessageBox.Show("최대 호출 횟수를 정확하게 입력하세요.");
                }
                else if (!float.TryParse(RequestsInterval.Text, out tmp2))
                {
                    MessageBox.Show("호출 간격을 정확하게 입력하세요.");
                }
                else if (!IPAddress.TryParse(DBIP.Text, out tmp3))
                {
                    MessageBox.Show("DB IP를 정확하게 입력하세요.");
                }
                else if (!int.TryParse(DBPort.Text, out tmp))
                {
                    MessageBox.Show("DB Port를 정확하게 입력하세요.");
                }
                else if (DBID.Text == "")
                {
                    MessageBox.Show("DB ID를 입력하세요.");
                }
                else if (DBPW.Text == "")
                {
                    MessageBox.Show("DB PW를 입력하세요.");
                }
                else
                {
                    info.InterpreterPath = InterpreterPath.Text;
                    info.APICollectorPath = APICollectorPath.Text;
                    info.DartCollectorPath = DartCollectorPath.Text;
                    info.MaxRequests = int.Parse(MaxRequestsCount.Text);
                    info.RequestsInterval = float.Parse(RequestsInterval.Text);
                    info.DartAPIKey = DartAPI.Text;

                    info.DBIP = DBIP.Text;
                    info.DBPort = int.Parse(DBPort.Text);
                    info.DBID = DBID.Text;
                    info.DBPW = DBPW.Text;

                    info.SaveSetting();
                }
            }
            else
            {
                MessageBox.Show("아직 기입하지 않은 정보가 있습니다.");
            }
            

            info.InterpreterPath = InterpreterPath.Text;
            info.APICollectorPath = APICollectorPath.Text;
            info.DartCollectorPath = DartCollectorPath.Text;
            info.MaxRequests = int.Parse(MaxRequestsCount.Text);
            info.RequestsInterval = float.Parse(RequestsInterval.Text);
            info.DartAPIKey = DartAPI.Text;

            info.DBIP = DBIP.Text;
            info.DBPort = int.Parse(DBPort.Text);
            info.DBID = DBID.Text;
            info.DBPW = DBPW.Text;

            info.SaveSetting();
        }

        private void Cancel(object sender, EventArgs e)
        {
            InterpreterPath.Text = info.InterpreterPath;
            APICollectorPath.Text = info.APICollectorPath;
            DartCollectorPath.Text = info.DartCollectorPath;
            MaxRequestsCount.Text = info.MaxRequests.ToString();
            RequestsInterval.Text = info.RequestsInterval.ToString();
            DartAPI.Text = info.DartAPIKey;

            DBIP.Text = info.DBIP;
            DBPort.Text = info.DBPort.ToString();
            DBID.Text = info.DBID;
            DBPW.Text = info.DBPW;
        }

        private void InterpreterSearch(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "응용프로그램 파일 (*.exe)   |*.exe";
            openFileDialog1.FileName = "";
            DialogResult OpenResult = openFileDialog1.ShowDialog();

            if (OpenResult == DialogResult.OK)
            {
                InterpreterPath.Text = openFileDialog1.FileName;
            }
        }

        private void APICollectorSearch(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "파이썬 파일 (*.py)   |*.py";
            openFileDialog1.FileName = "";
            DialogResult OpenResult = openFileDialog1.ShowDialog();

            if (OpenResult == DialogResult.OK)
            {
                APICollectorPath.Text = openFileDialog1.FileName;
            }
        }

        private void DartCollectorSearch(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "파이썬 파일 (*.py)   |*.py";
            openFileDialog1.FileName = "";
            DialogResult OpenResult = openFileDialog1.ShowDialog();

            if (OpenResult == DialogResult.OK)
            {
                DartCollectorPath.Text = openFileDialog1.FileName;
            }
        }
    }
}
