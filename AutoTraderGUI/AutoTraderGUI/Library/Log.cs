using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace AutoTraderGUI.Library
{
    class Log
    {
        bool isDBConnected;

        DataTable logData;
        
        DBController DB;
        Settings settings;
        public Log()
        {
            settings = new Settings();
            DB = new DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);
            isDBConnected = DB.SchemaCheck("log");      // 스키마가 존재하는지 확인해서 DB 연결여부 확인
                                                        // 연결이 안되었거나 스키마가 존재하지 않는경우 false

            if (!isDBConnected)
            {
                MessageBox.Show("DB에 연결이 안되어있습니다. DB를 확인해주세요.");
            }

            logData = new DataTable();
            logData.Columns.Add("Info", typeof(string));
            logData.Columns.Add("Time", typeof(string));
            logData.Columns.Add("Task", typeof(string));
            logData.Columns.Add("Company", typeof(string));
            logData.Columns.Add("Log", typeof(string));

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
            if (!isDBConnected)
            {
                // DB가 연결이 안되었을 때 DB를 생성 시도
                // 만약 성공했으면 DB가 연결되었다는 뜻이므로 연결된것으로 간주
                if (DB.SchemaCheck("log"))
                {
                    isDBConnected = true;
                }
                else
                {
                    isDBConnected = DB.CreateSchema("log");
                }

                if (!isDBConnected)
                {
                    MessageBox.Show("DB에 연결이 안되어있습니다. DB를 확인해주세요.");
                    return;
                }
                
            }

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
