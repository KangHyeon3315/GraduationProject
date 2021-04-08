﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AutoTraderGUI.Forms
{
    public partial class SettingsForm : Form
    {
        Library.SettingsInfo original;
        public SettingsForm(object info)
        {
            original = (Library.SettingsInfo)info;

            InitializeComponent();

            InterpreterPath.Text = original.InterpreterPath;
            APICollectorPath.Text = original.APICollectorPath;
            DartCollectorPath.Text = original.DartCollectorPath;
            MaxRequestsCount.Text = original.MaxRequestsCount.ToString();
            RequestsInterval.Text = original.RequestsInterval.ToString();
            DartAPI.Text = original.DartAPI;

        }

        private void ApplicationButtonClick(object sender, EventArgs e)
        {
            int tmp;
            float tmp2;
            if (InterpreterPath.Text != "" && APICollectorPath.Text != "" && DartCollectorPath.Text != "" && MaxRequestsCount.Text != "" && RequestsInterval.Text != "" && DartAPI.Text != "")
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
                else
                {
                    original.InterpreterPath = InterpreterPath.Text;
                    original.APICollectorPath = APICollectorPath.Text;
                    original.DartCollectorPath = DartCollectorPath.Text;
                    original.MaxRequestsCount = int.Parse(MaxRequestsCount.Text);
                    original.RequestsInterval = float.Parse(RequestsInterval.Text);
                    original.DartAPI = DartAPI.Text;

                    Close();
                }
            }
            else
            {
                MessageBox.Show("아직 기입하지 않은 정보가 있습니다.");
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            InterpreterPath.Text = original.InterpreterPath;
            APICollectorPath.Text = original.APICollectorPath;
            DartCollectorPath.Text = original.DartCollectorPath;
            MaxRequestsCount.Text = original.MaxRequestsCount.ToString();
            RequestsInterval.Text = original.RequestsInterval.ToString();
            DartAPI.Text = original.DartAPI;
        }
    }
}

