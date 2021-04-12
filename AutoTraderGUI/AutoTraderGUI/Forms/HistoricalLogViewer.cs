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

namespace AutoTraderGUI.Forms
{
    public partial class HistoricalLogViewer : Form
    {
        public HistoricalLogViewer()
        {
            InitializeComponent();

            DirectoryInfo Dinfo = new DirectoryInfo("Log");
            foreach (FileInfo finfo in Dinfo.GetFiles())
            {
                DateList.Items.Add(finfo.Name.Replace(".xml", ""));
            }
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            int totalWidth = LogViewer.Size.Width;
            int restWidth = totalWidth;

            LogViewer.Columns[0].Width = 60;            // info
            restWidth -= LogViewer.Columns[0].Width;

            LogViewer.Columns[1].Width = 70;            // info
            restWidth -= LogViewer.Columns[1].Width;

            LogViewer.Columns[2].Width = 120;           // Time
            restWidth -= LogViewer.Columns[2].Width;

            LogViewer.Columns[3].Width = 180;          // Task
            restWidth -= LogViewer.Columns[3].Width;

            LogViewer.Columns[4].Width = 180;          // Company
            restWidth -= LogViewer.Columns[4].Width;

            LogViewer.Columns[5].Width = restWidth;     // Log
        }

        private void Search(object sender, EventArgs e)
        {
            if(File.Exists(string.Format("Log\\{0}.xml", DateList.Text))){
                LogViewer.Items.Clear();

                DataTable data = new DataTable("logs");
                data.Columns.Add(new DataColumn("Info", typeof(System.String)));
                data.Columns.Add(new DataColumn("Time", typeof(System.String)));
                data.Columns.Add(new DataColumn("Task", typeof(System.String)));
                data.Columns.Add(new DataColumn("Company", typeof(System.String)));
                data.Columns.Add(new DataColumn("Log", typeof(System.String)));

                data.ReadXml(string.Format("Log\\{0}.xml", DateList.Text));

                int idx = 0;
                foreach (DataRow dr in data.Rows) {
                    if (!DebugCheck.Checked)
                    {
                        if (dr[0].ToString() == "Debug")
                        {
                            continue;
                        }
                    }

                    idx++;
                    ListViewItem item = new ListViewItem();
                    item.Text = idx.ToString();
                    for (int i = 0; i < data.Columns.Count; i++) {
                        item.SubItems.Add(dr[i].ToString()); 
                    }
                    switch (dr[0].ToString())
                    {
                        case "Exception":
                            item.BackColor = Color.LightSalmon;
                            break;
                        case "Requests":
                            item.BackColor = Color.PowderBlue;
                            break;
                        case "Debug":
                            item.BackColor = Color.Silver;
                            break;
                    }

                    LogViewer.Items.Add(item); 
                }

            }
            else
            {
                MessageBox.Show("해날 데이터가 존재하지 않습니다.");
            }
        }
    }
}
