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
        bool Debug;
        delegate void SetLogCallback(string info, string task, string company, string log);
        delegate void SetLogCallback2();
        Library.Log logs;
        string lastLogTime;

        public LogInterface logInterface
        {
            get
            {
                return (this as LogInterface);
            }
        }

        public string LastLogTime {
            get
            {
                return lastLogTime;
            }
        }
        
        public int LogCount
        {
            get
            {
                return LogViewer.Items.Count;
            }
        }


        public LogViewerControl()
        {
            lastLogTime = "";
            InitializeComponent();
            scrollToEnd = true;
            Debug = false;
            Dock = DockStyle.Fill;

            logs = new Library.Log();
        }
        public void WriteLog(string info, string task, string company, string log)
        {

                if (LogViewer.Items.Count > 1000)
                {
                    LogViewer.Items.RemoveAt(0);
                }

                if (!Debug && info == "Debug")
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    logs.WriteLog(info, time, task, company, log);
                }
                else
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ListViewItem item = new ListViewItem(info);
                    item.SubItems.Add(time);
                    item.SubItems.Add(task);
                    item.SubItems.Add(company);
                    item.SubItems.Add(log);

                if (this.LogViewer.InvokeRequired)
                {
                    SetLogCallback d = new SetLogCallback(WriteLog);
                    this.Invoke(d, new object[] { info, task, company, log });
                }
                else
                {
                    LogViewer.Items.Add(item);
                }

                    if (scrollToEnd)
                    {
                        if (this.LogViewer.InvokeRequired)
                        {
                            SetLogCallback2 d = new SetLogCallback2(SetScrollToEnd);
                            this.Invoke(d, new object[] { });
                        }
                        else
                        {
                            SetScrollToEnd();
                        }
                    }

                    logs.WriteLog(info, time, task, company, log);
                }

                lastLogTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        void SetScrollToEnd()
        {
            if (LogViewer.Items.Count > 0)
            {
                LogViewer.Items[LogViewer.Items.Count - 1].EnsureVisible();
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

        private void ScrollToEndEvent (object sender, EventArgs e)
        {
            scrollToEnd = !scrollToEnd;
        }

        private void DebugInfoEvent(object sender, EventArgs e)
        {
            Debug = !Debug;
        }
    }
}
