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
        string logDate;
        DBController DB;
        public Log()
        {
            Settings settings = new Settings();
            DB = new DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);

            logData = new DataTable();
            logData.Columns.Add("Info", typeof(string));
            logData.Columns.Add("Time", typeof(string));
            logData.Columns.Add("Task", typeof(string));
            logData.Columns.Add("Company", typeof(string));
            logData.Columns.Add("Log", typeof(string));

            if (!DB.SchemaCheck("log"))
            {
                DB.CreateSchema("log");
            }
        }

        public void WriteLog(string info, string time, string task, string company, string log)
        {
            DataRow row;
            row = logData.NewRow();
            row["Info"] = info;
            row["Time"] = time;
            row["Task"] = task;
            row["Company"] = company;
            row["Log"] = log;
            logData.Rows.Add(row);

            WriteToDB(info, time, task, company, log);
        }
        public void CreateLogTable(string name, DataColumnCollection columns)
        {
            DB.CreateTable("collector", name, columns);
        }
        public void WriteToDB(string info, string logtime, string task, string company, string logText)
        {
            string time = DateTime.Now.ToString("yyyyMMdd_HH");

            if (!DB.TableCheck(time, "log"))
            {
                CreateLogTable(time, logData.Columns);
            }

            DataTable logTable = new DataTable();
            logTable.Columns.Add(new DataColumn("Info", typeof(System.String)));
            logTable.Columns.Add(new DataColumn("Time", typeof(System.String)));
            logTable.Columns.Add(new DataColumn("Task", typeof(System.String)));
            logTable.Columns.Add(new DataColumn("Company", typeof(System.String)));
            logTable.Columns.Add(new DataColumn("Log", typeof(System.String)));

            DataRow log = logTable.NewRow();
            log["info"] = info;
            log["Time"] = logtime;
            log["Task"] = task;
            log["Company"] = company;
            log["Log"] = logText;
            logTable.Rows.Add(log);
            DB.UpdateTable("log", time, logTable);
        }
    }
}
