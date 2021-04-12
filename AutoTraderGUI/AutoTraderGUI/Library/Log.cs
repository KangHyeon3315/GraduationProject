using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace AutoTraderGUI.Library
{
    class Log
    {
        DataTable logData;

        public Log()
        {
            OpenLog();
        }

        void OpenLog()
        {
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            else
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd");

                logData = new DataTable("logs");
                logData.Columns.Add(new DataColumn("Info", typeof(System.String)));
                logData.Columns.Add(new DataColumn("Time", typeof(System.String)));
                logData.Columns.Add(new DataColumn("Task", typeof(System.String)));
                logData.Columns.Add(new DataColumn("Company", typeof(System.String)));
                logData.Columns.Add(new DataColumn("Log", typeof(System.String)));

                if (File.Exists(string.Format("Log\\{0}.xml", time)))
                {
                    logData.ReadXml(string.Format("Log\\{0}.xml", time));
                }

            }
        }

        public void WriteLog(string info, string time, string task, string company, string log)
        {
            if(DateTime.Parse(logData.Rows[0][1].ToString()).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                OpenLog();
            }

            DataRow row;
            row = logData.NewRow();
            row["Info"] = info;
            row["Time"] = time;
            row["Task"] = task;
            row["Company"] = company;
            row["Log"] = log;
            logData.Rows.Add(row);

            SaveLogFile();
        }

        public void SaveLogFile()
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            logData.WriteXml(string.Format("Log\\{0}.xml", time));
        }
    }
}
