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
        DataTable CompanyInfo;
        DBController DB;
        int ExtraDataLength;
        public IndicatorProcessor()
        {
            DB = new DBController();
        }

        void Processing()
        {
            foreach(DataRow info in CompanyInfo.Rows)
            {
                string code = info["code"].ToString();
                string name = info["name"].ToString();
                string lastCalculateTime = info["indicator"].ToString();

                if(int.Parse(lastCalculateTime) >= int.Parse(DateTime.Now.ToString("yyyyMMdd")))
                {
                    continue;
                }

                List<string> DateList = DB.SelectIndicatorDateList(name, ExtraDataLength);
                string ExtraDate = DateList.Count > 0 ? DateList[DateList.Count - 1] : "0";

                DataTable priceData = DB.SelectPriceData(name, string.Format("date>={0}", ExtraDate));

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
            }

        }
    }
}
