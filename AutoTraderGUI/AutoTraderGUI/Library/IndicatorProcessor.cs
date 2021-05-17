using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;

namespace AutoTraderGUI.Library
{
    class IndicatorProcessor
    {
        DBController DB;
        Calculate calc;
        int ExtraDataLength;
        Settings settings;
        LogInterface logInterface = null;
        ProgressInterface progressInterface = null;
        public IndicatorProcessor(LogInterface logInterface, ProgressInterface progressInterface, Settings settings)
        {
            this.settings = settings;
            this.logInterface = logInterface;
            this.progressInterface = progressInterface;

            ExtraDataLength = 120;
            DB = new DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);

            calc = new Calculate();

            /*
            if (!DB.SchemaCheck("indicator"))
            {
                DB.CreateSchema("indicator");
            }
            */
            
            process();
        }

        DataTable TableFilter(DataTable data, string date)
        {
            DataTable result = data.Clone();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (int.Parse(data.Rows[i]["date"].ToString()) > int.Parse(date))
                {
                    result.ImportRow(data.Rows[i]);
                }

            }
            return result;
        }

        void process()
        {
            DataTable CompanyInfo = DB.SelectCompanyInfo();

            progressInterface.Title = "지표 계산";
            progressInterface.Task = "Calculating";
            progressInterface.CompanyCount = CompanyInfo.Rows.Count;
            int count = 0;
            foreach (DataRow info in CompanyInfo.Rows)
            {
                string code = info["code"].ToString();
                string name = info["name"].ToString();
                string lastCalculateTime = info["indicator"].ToString();
                count++;
                progressInterface.CompleteCount = count;
                progressInterface.Progress = (int)((float)count / (float)(progressInterface.CompanyCount) * 100);

                if (int.Parse(lastCalculateTime) >= int.Parse(DateTime.Now.ToString("yyyyMMdd")))
                {
                    continue;
                }

                if (!DB.TableCheck(name, "daily_chart"))
                {
                    continue;
                }

                

                progressInterface.Company = name;

                List<string> DateList = DB.SelectDateList("indicator", name, ExtraDataLength);
                string ExtraDate = DateList.Count > 0 ? DateList[DateList.Count - 1] : "0";

                logInterface.WriteLog("Debug", "Indicator Calculate", name, "DB에서 가격지표 가져오기");
                DataTable priceData = DB.SelectPriceData(name, string.Format("date>={0}", ExtraDate));
                logInterface.WriteLog("Log", "Indicator Calculate", name, "보조지표 계산 시작");
                DataTable result = calc.CalculateData(priceData);

                // Column 체크
                if (DB.TableCheck(name, "indicator"))
                {
                    List<string> columnList = DB.SelectColumnList("indicator", name);
                    if (columnList.Count != result.Columns.Count)
                    {
                        logInterface.WriteLog("Log", "Indicator Calculate", name, "추가된 보조지표가 존재. 기존 DB에 추가된 보조지표 추가.");
                        DataTable PrevData = DB.SelectPriceData(name, string.Format("date<={0}", DateList[0]));
                        DataTable PrevResult = calc.CalculateData(PrevData);

                        List<string> UpdateColumnList = new List<string>();
                        foreach (DataColumn column in result.Columns)
                        {
                            if (!columnList.Contains(column.ColumnName))
                            {
                                logInterface.WriteLog("Debug", "Indicator Calculate", name, column.ColumnName + " 칼럼 추가");
                                DB.AddColumn("indicator", name, column.ColumnName, column.DataType, null);
                                UpdateColumnList.Add(column.ColumnName);
                            }
                        }
                        logInterface.WriteLog("Debug", "Indicator Calculate", name, "DB에 추가된 보조지표 업로드");
                        DB.UpdateColumn("indicator", name, UpdateColumnList, "date", PrevResult);
                    }

                }

                logInterface.WriteLog("Debug", "Indicator Calculate", name, "DB에 보조지표 업로드");
                DB.UpdateTable("indicator", name, TableFilter(result, DateList.Count > 0 ? DateList[0] : "0"));  // Date > dateList[0] 구현
                //DB.UpdateCompanyInfo(name, "indicator", DateTime.Now.ToString("yyyyMMdd"));
                DB.UpdateCompanyInfo(name, "indicator", DateTime.Now.ToString("yyyyMMdd"));

            }

        }
    }
}
