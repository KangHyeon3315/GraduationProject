using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IndicatorCalculating
{
    class Processing
    {
        DBController DB;
        Calculate calc;
        int ExtraDataLength;
        public Processing()
        {
            ExtraDataLength = 120;
            DB = new DBController("localhost", "bot", "kanghyeon#3315");
            calc = new Calculate();

            process();
        }

        DataTable TableFilter(DataTable data, string date)
        {
            DataTable result = data.Clone();
            
            for(int i = 0; i < data.Rows.Count; i++)
            {
                if(int.Parse(data.Rows[i]["date"].ToString()) > int.Parse(date))
                {
                    result.ImportRow(data.Rows[i]);
                }
                
            }
            return result;
        }

        void process()
        {
            DataTable CompanyInfo = DB.SelectCompanyInfo();

            foreach (DataRow info in CompanyInfo.Rows)
            {
                string code = info["code"].ToString();
                string name = info["name"].ToString();
                string lastCalculateTime = info["indicator"].ToString();

                if(!DB.TableCheck(name, "daily_chart"))
                {
                    continue;
                }

                if (int.Parse(lastCalculateTime) >= int.Parse(DateTime.Now.ToString("yyyyMMdd")))
                {
                    continue;
                }

                List<string> DateList = DB.SelectDateList("indicator", name, ExtraDataLength);
                string ExtraDate = DateList.Count > 0 ? DateList[DateList.Count - 1] : "0";

                DataTable priceData = DB.SelectPriceData(name, string.Format("date>={0}", ExtraDate));

                DataTable result = calc.CalculateData(priceData);

                // Column 체크
                if(DB.TableCheck(name, "indicator"))
                {
                    List<string> columnList = DB.SelectColumnList("indicator", name);
                    if(columnList.Count != result.Columns.Count)
                    {
                        DataTable PrevData = DB.SelectPriceData(name, string.Format("date<={0}", DateList[0]));
                        DataTable PrevResult = calc.CalculateData(PrevData);

                        List<string> UpdateColumnList = new List<string>();
                        foreach (DataColumn column in result.Columns)
                        {
                            if (!columnList.Contains(column.ColumnName))
                            {
                                DB.AddColumn("indicator", name, column.ColumnName, column.DataType, null);
                                UpdateColumnList.Add(column.ColumnName);
                            }
                        }

                        DB.UpdateColumn("indicator", name, UpdateColumnList, "date", PrevResult);
                    }
                    
                }

                
                DB.UpdateTable("indicator", name, TableFilter(result, DateList.Count > 0 ? DateList[0] : "0"));  // Date > dateList[0] 구현
                DB.UpdateCompanyInfo(name, "indicator", DateTime.Now.ToString("yyyyMMdd"));
                
                /*  
                 *  result = CalculatingClass.Calculate(data)
                 *  
                 *  if table is exists
                 *      for column in columnList
                 *          if  column is not exists in DB
                 *              Create Column
                 *       
                 *              prevData = SelectPriceData(prev all)
                 *      
                 *              columnData = CalculatingClass.columnCalculate(column, prevData);
                 *              UpdateColumn(columnData)
                 *  
                 *  UpdateTable(result)         <= date > DateList[0] 
                 *  UpdateCompanyInfo()
                 */
                break;
            }

        }
    }
}
