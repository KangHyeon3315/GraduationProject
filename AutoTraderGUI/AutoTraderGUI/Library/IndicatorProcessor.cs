using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoTraderGUI.Library
{
    class IndicatorProcessor
    {
        DataTable CompanyInfo;
        DBController DB;
        public IndicatorProcessor()
        {
            DB = new DBController();
            // 계산 클래스 선언
        }

        void Initialize()
        {
            // 종목 리스트 가져오기
        }

        void Processing()
        {
            foreach(string name in NameList)
            {
                /*
                 *  if Already Calculate Indicator
                 *      continue;
                 *  
                 *  data = GetTable(Calculating Data + Alpha Data)
                 *  
                 *  result = CalculatingClass.Calculate(data)
                 *  
                 *  if column is mismatch with DB
                 *      Create Column
                 *      
                 *      prevData = GetTable(prev all)
                 *      
                 *      columnData = CalculatingClass.columnCalculate(column, prevData);
                 *      UpdateColumn(columnData)
                 *  
                 *  UpdateTable(result)
                 *  UpdateCompanyInfo()
                 */
            }

        }
    }
}
