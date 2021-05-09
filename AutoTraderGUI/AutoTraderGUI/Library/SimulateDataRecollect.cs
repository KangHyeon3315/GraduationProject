﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoTraderGUI.Library
{
    class SimulateDataRecollect
    {
        DBController DB;
        LogInterface logInterface;
        ProgressInterface progressInterface;
        public SimulateDataRecollect(Settings settings, LogInterface logInterface , ProgressInterface progressInterface) {
            this.logInterface = logInterface;
            this.progressInterface = progressInterface;
            DB = new DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);

            if (!DB.SchemaCheck("daily_simulate"))
            {
                DB.CreateSchema("daily_simulate");
            }

            recollectDailyData();
        }

        public List<List<string>> GetTablesColumn()
        {
            List<List<string>> columnList = new List<List<string>>();
            List<string> DateList = DB.SelectTableList("daily_simulate");
            for(int i = 0; i < DateList.Count; i++)
            {
                columnList.Add(DB.SelectColumnList("daily_simulate", DateList[i]));
            }

            return columnList;
        }

        public void recollectDailyData()
        {
            DataTable CompanyInfo = DB.SelectCompanyInfo();
            progressInterface.CompanyCount = CompanyInfo.Rows.Count;
            progressInterface.Task = "시뮬레이션용 데이터 재가공";
            progressInterface.Task = "Recollect";
            for (int company_idx = 0;company_idx < CompanyInfo.Rows.Count; company_idx++)
            {
                string name = CompanyInfo.Rows[company_idx]["name"].ToString();
                string lastProcess = CompanyInfo.Rows[company_idx]["reprocessing"].ToString();

                progressInterface.Company = name;
                progressInterface.CompleteCount = company_idx;
                progressInterface.Progress = 0;

                if (lastProcess == "Rewrite" || lastProcess == "0")
                {
                    lastProcess = "20000101";
                }

                if (int.Parse(lastProcess) < int.Parse(DateTime.Now.ToString("yyyyMMdd")))
                {
                    progressInterface.Progress = (int)((float)company_idx / CompanyInfo.Rows.Count * 100);
                    logInterface.WriteLog("Log", "Recollect", name, "데이터 재가공 시작");
                    string SQL = string.Format("SELECT t1.*, t2.* FROM daily_chart.`{0}` t1, indicator.`{0}` t2 WHERE t1.date = t2.date and t1.date >= {1}", name, lastProcess);

                    DataTable data = DB.SelectSQLData("daily_chart", SQL);
                
                    for(int i = 0; i < data.Columns.Count; i++)
                    {
                        if(data.Columns[i].ColumnName == "date1")
                        {
                            data.Columns.RemoveAt(i);
                            break;
                        }
                    }

                    data.Columns["date"].ColumnName = "name";
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        string date = data.Rows[i]["name"].ToString();
                        
                        if(int.Parse(date) >= int.Parse(lastProcess))
                        {
                            logInterface.WriteLog("Debug", "Recollect", name, string.Format("{0} 업로드", date));
                            data.Rows[i]["name"] = name;
                            if (!DB.TableCheck(date, "daily_simulate"))
                            {
                                DB.CreateTable("daily_simulate", date, data.Columns, "date");
                            }

                            if(DB.DataCheck("daily_simulate", date, "name", name))
                            {
                                DB.UpdateRow("daily_simulate", date, data.Columns, data.Rows[i], name);
                            }
                            else
                            {
                                DB.InsertRow("daily_simulate", date, data.Columns, data.Rows[i], data.Columns["name"]);
                            }
                            
                        }
                        
                        
                    }
                    logInterface.WriteLog("Log", "Recollect", name, "데이터 재가공 완료");
                    DB.UpdateCompanyInfo(name, "reprocessing", DateTime.Now.ToString("yyyyMMdd"));
                }

                
            }
        }
        
    }
}
