using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AutoTraderGUI.Layout
{
    public partial class Analyze : UserControl
    {
        Library.DBController DB;
        Library.Settings settings;

        DataTable CompanyInfo;
        DataTable price;
        DataTable Indicator;
        DataTable FinancialStatement;

        Forms.CandleChartControl Candle;

        bool ConnectFinancialStatement;
        public Analyze()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            settings = new Library.Settings();

            ConnectFinancialStatement = false;

            DB = new Library.DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);

            CompanyInfo = DB.SelectCompanyInfo();

            IndicatorViewer.ExpandAll();

            
        }
        private void SearchEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void SearchClick(object sender, EventArgs e)
        {
            Search();
        }
        void Search()
        {
            int tmp;
            string companyName = "";
            if (SearchText.Text.Length == 6 && int.TryParse(SearchText.Text, out tmp))
            {
                // 코드로 검색
                for (int i = 0; i < CompanyInfo.Rows.Count; i++)
                {
                    if (CompanyInfo.Rows[i]["code"].ToString() == SearchText.Text)
                    {
                        companyName = CompanyInfo.Rows[i]["name"].ToString();
                        break;
                    }
                }
            }
            else
            {
                // 이름으로 검색
                for (int i = 0; i < CompanyInfo.Rows.Count; i++)
                {
                    if (CompanyInfo.Rows[i]["name"].ToString().Replace(" ", "") == SearchText.Text.Trim().Replace(" ", "").ToLower())
                    {
                        companyName = CompanyInfo.Rows[i]["name"].ToString();
                        break;
                    }
                }
            }

            if(companyName == "")
            {
                MessageBox.Show("해당 종목을 찾을 수 없습니다.");
                return;
            }

            price = DB.SelectTableData("daily_chart", companyName);
            Indicator = DB.SelectTableData("indicator", companyName);
            FinancialStatement = DB.SelectTableData("financial_statement", companyName);

            DisplayFinancialStatement(DateTime.Now.ToString("yyyyMMdd"));

            Candle = new Forms.CandleChartControl(price);

            ChartLayout.Controls.Clear();
            ChartLayout.Controls.Add(Candle);
            ChartLayout.Controls.Add(toolStrip1);
        }

        void DisplayFinancialStatement(string date)
        {
            bool year = false;
            bool quater = false;
            string type = ConnectFinancialStatement ? "연결재무제표" : "재무제표";
            for (int i = FinancialStatement.Rows.Count - 1; i >= 0; i--)
            {
                if(FinancialStatement.Rows[i]["type"].ToString() == type)
                {
                    if(int.Parse(FinancialStatement.Rows[i]["report_date"].ToString()) <= int.Parse(date))
                    {
                        if(!year && FinancialStatement.Rows[i]["report_type"].ToString() == "사업")
                        {
                            YearFinancialStatementListView.Items.Clear();
                            for(int column_idx = 0; column_idx < FinancialStatement.Columns.Count; column_idx++)
                            {
                                string columnName = FinancialStatement.Columns[column_idx].ColumnName;
                                string data = "";
                                switch (columnName)
                                {
                                    case "report_date":
                                        columnName = "공시일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "report_type":
                                        columnName = "재무제표 종류 1";
                                        data = FinancialStatement.Rows[i][column_idx].ToString();
                                        break;
                                    case "type":
                                        columnName = "재무제표 종류 2";
                                        data = FinancialStatement.Rows[i][column_idx].ToString() == "재무제표" ? "단일 재무제표" : "연결 재무제표";
                                        break;
                                    case "start_date":
                                        columnName = "시작일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "end_date":
                                        columnName = "종료일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "유동자산":
                                    case "비유동자산":
                                    case "자산총계":
                                    case "유동부채":
                                    case "비유동부채":
                                    case "부채총계":
                                    case "이익잉여금":
                                    case "자본총계":
                                    case "매출액":
                                    case "영업이익":
                                    case "당기순이익":
                                    case "주식수":
                                    case "시가총액":
                                        data = long.Parse(FinancialStatement.Rows[i][column_idx].ToString()).ToString("N").Replace(".00", "");
                                        break;
                                    default:
                                        continue;

                                }
                                ListViewItem item = new ListViewItem(columnName);
                                item.SubItems.Add(data);
                                YearFinancialStatementListView.Items.Add(item);
                            }
                            year = true;
                        }
                        else if(!quater && FinancialStatement.Rows[i]["report_type"].ToString() != "사업")
                        {
                            QuaterFinancialStatementListView.Items.Clear();
                            for (int column_idx = 0; column_idx < FinancialStatement.Columns.Count; column_idx++)
                            {
                                string columnName = FinancialStatement.Columns[column_idx].ColumnName;
                                string data = "";
                                switch (columnName)
                                {
                                    case "report_date":
                                        columnName = "공시일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "report_type":
                                        columnName = "재무제표 종류 1";
                                        data = FinancialStatement.Rows[i][column_idx].ToString();
                                        break;
                                    case "type":
                                        columnName = "재무제표 종류 2";
                                        data = FinancialStatement.Rows[i][column_idx].ToString() == "재무제표" ? "단일 재무제표" : "연결 재무제표";
                                        break;
                                    case "start_date":
                                        columnName = "시작일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "end_date":
                                        columnName = "종료일";
                                        data = DateTime.ParseExact(FinancialStatement.Rows[i][column_idx].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                                        break;
                                    case "유동자산":
                                    case "비유동자산":
                                    case "자산총계":
                                    case "유동부채":
                                    case "비유동부채":
                                    case "부채총계":
                                    case "이익잉여금":
                                    case "자본총계":
                                    case "매출액":
                                    case "영업이익":
                                    case "당기순이익":
                                    case "주식수":
                                    case "시가총액":
                                        data = long.Parse(FinancialStatement.Rows[i][column_idx].ToString()).ToString("N").Replace(".00", "");
                                        break;
                                    default:
                                        continue;

                                }
                                ListViewItem item = new ListViewItem(columnName);
                                item.SubItems.Add(data);
                                QuaterFinancialStatementListView.Items.Add(item);
                            }
                            quater = true;
                        }
                    }
                }
            }
        }
    }
}
