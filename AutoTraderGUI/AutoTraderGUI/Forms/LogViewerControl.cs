﻿using System;
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
    public partial class LogViewerControl : UserControl, LogInterface
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

        public LogViewerControl()
        {
            InitializeComponent();
            scrollToEnd = true;
            Dock = DockStyle.Fill;
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
        }
    }
}