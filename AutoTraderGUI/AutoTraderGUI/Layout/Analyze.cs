using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

        VerticalLineAnnotation mainVerticalLine;
        VerticalLineAnnotation volunmeVerticalLine;

        int GridCount;

        bool ConnectFinancialStatement;

        bool trendsIndicatorVisible = false;
        bool smaVisible = false;
        bool variabilityIndicatorVisible = false;
        bool momentumIndicatorVisible = false;
        bool strengthIndicatorVisible = false;

        public Analyze()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            settings = new Library.Settings();

            ConnectFinancialStatement = false;

            DB = new Library.DBController(settings.info.DBIP, settings.info.DBID, settings.info.DBPW);

            CompanyInfo = DB.SelectCompanyInfo();
            
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

            foreach(Series series in mainChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in volumeChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in MACDChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in RSIChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in StocasticChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in MFIChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in POCSChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in ATRChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in TRIXChart.Series)
            {
                series.Points.Clear();
            }
            foreach (Series series in RMIChart.Series)
            {
                series.Points.Clear();
            }


            DisplayChart();
            DisplayFinancialStatement(DateTime.Now.ToString("yyyyMMdd"));

            //mainChart.ChartAreas[0].AxisX.Crossing = 2500;
            //volumeChart.ChartAreas[0].AxisX.Crossing = 2500;
        }

        void DisplayChart()
        {
            GridCount = 15;
            // Grid Line Color
            mainChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            mainChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            volumeChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            volumeChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            StocasticChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            StocasticChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            MACDChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            MACDChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            RSIChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            RSIChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            MFIChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            MFIChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            POCSChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            POCSChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            ATRChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            ATRChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            TRIXChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            TRIXChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            RMIChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            RMIChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            mainChart.ChartAreas[0].Position.X = 10;
            mainChart.ChartAreas[0].Position.Width = 100;
            mainChart.ChartAreas[0].Position.Height = 100;
            mainChart.ChartAreas[0].Position.Y = 0;

            StocasticChart.ChartAreas[0].Position.X = 10;
            StocasticChart.ChartAreas[0].Position.Width = 100;
            StocasticChart.ChartAreas[0].Position.Height = 100;
            StocasticChart.ChartAreas[0].Position.Y = 0;

            volumeChart.ChartAreas[0].Position.X = 10;
            volumeChart.ChartAreas[0].Position.Width = 100;
            volumeChart.ChartAreas[0].Position.Height = 100;
            volumeChart.ChartAreas[0].Position.Y = 0;

            MACDChart.ChartAreas[0].Position.X = 10;
            MACDChart.ChartAreas[0].Position.Width = 100;
            MACDChart.ChartAreas[0].Position.Height = 100;
            MACDChart.ChartAreas[0].Position.Y = 0;

            RSIChart.ChartAreas[0].Position.X = 10;
            RSIChart.ChartAreas[0].Position.Width = 100;
            RSIChart.ChartAreas[0].Position.Height = 100;
            RSIChart.ChartAreas[0].Position.Y = 0;

            MFIChart.ChartAreas[0].Position.X = 10;
            MFIChart.ChartAreas[0].Position.Width = 100;
            MFIChart.ChartAreas[0].Position.Height = 100;
            MFIChart.ChartAreas[0].Position.Y = 0;

            POCSChart.ChartAreas[0].Position.X = 10;
            POCSChart.ChartAreas[0].Position.Width = 100;
            POCSChart.ChartAreas[0].Position.Height = 100;
            POCSChart.ChartAreas[0].Position.Y = 0;

            ATRChart.ChartAreas[0].Position.X = 10;
            ATRChart.ChartAreas[0].Position.Width = 100;
            ATRChart.ChartAreas[0].Position.Height = 100;
            ATRChart.ChartAreas[0].Position.Y = 0;

            TRIXChart.ChartAreas[0].Position.X = 10;
            TRIXChart.ChartAreas[0].Position.Width = 100;
            TRIXChart.ChartAreas[0].Position.Height = 100;
            TRIXChart.ChartAreas[0].Position.Y = 0;

            RMIChart.ChartAreas[0].Position.X = 10;
            RMIChart.ChartAreas[0].Position.Width = 100;
            RMIChart.ChartAreas[0].Position.Height = 100;
            RMIChart.ChartAreas[0].Position.Y = 0;

            //volumeChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            MACDChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            RSIChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            StocasticChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            MFIChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            POCSChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            ATRChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            TRIXChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;
            RMIChart.ChartAreas[0].InnerPlotPosition = volumeChart.ChartAreas[0].InnerPlotPosition;

            Series chartSeries = mainChart.Series["Candle"];
            mainChart.Series["Candle"]["PriceUpColor"] = "Red";
            mainChart.Series["Candle"]["PriceDownColor"] = "Blue";
            mainChart.AxisViewChanged += ChartAxisViewChanged;
            //volumeChart.AxisViewChanged += ChartAxisViewChanged;

            int max = 0;
            int min = 0;
            for (int i = 0; i < price.Rows.Count; i++)
            {
                string date = price.Rows[i]["date"].ToString();
                max = max < int.Parse(price.Rows[i]["high"].ToString()) ? int.Parse(price.Rows[i]["high"].ToString()) : max;
                min = min < int.Parse(price.Rows[i]["low"].ToString()) ? min : int.Parse(price.Rows[i]["low"].ToString());

                mainChart.Series["Candle"].Points.AddXY(date, int.Parse(price.Rows[i]["high"].ToString()));
                // adding low 
                mainChart.Series["Candle"].Points[i].YValues[1] = int.Parse(price.Rows[i]["low"].ToString());
                //adding open 
                mainChart.Series["Candle"].Points[i].YValues[2] = int.Parse(price.Rows[i]["open"].ToString());
                // adding close 
                mainChart.Series["Candle"].Points[i].YValues[3] = int.Parse(price.Rows[i]["close"].ToString());

                volumeChart.Series["Volume"].Points.AddXY(date, int.Parse(price.Rows[i]["volume"].ToString()));

                int value = Indicator.Rows[i]["macd"].ToString() != "" ? int.Parse(Indicator.Rows[i]["macd"].ToString()) : 0;
                MACDChart.Series["MACD"].Points.AddXY(date, value);
                value = Indicator.Rows[i]["macd_signal"].ToString() != "" ? int.Parse(Indicator.Rows[i]["macd_signal"].ToString()) : 0;
                MACDChart.Series["MACD_Signal"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["RSI"].ToString() != "" ? int.Parse(Indicator.Rows[i]["RSI"].ToString()) : 0;
                RSIChart.Series["RSI"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["RSI_Signal"].ToString() != "" ? int.Parse(Indicator.Rows[i]["RSI_Signal"].ToString()) : 0;
                RSIChart.Series["RSI_Signal"].Points.AddXY(date, value);

                value = Indicator.Rows[i]["stocastic_fask_K"].ToString() != "" ? int.Parse(Indicator.Rows[i]["stocastic_fask_K"].ToString()) : 0;
                StocasticChart.Series["FAST_K"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["stocastic_slow_K"].ToString() != "" ? int.Parse(Indicator.Rows[i]["stocastic_slow_K"].ToString()) : 0;
                StocasticChart.Series["SLOW_K"].Points.AddXY(date, value);
                value = Indicator.Rows[i]["stocastic_slow_D"].ToString() != "" ? int.Parse(Indicator.Rows[i]["stocastic_slow_D"].ToString()) : 0;
                StocasticChart.Series["SLOW_D"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["mfi"].ToString() != "" ? int.Parse(Indicator.Rows[i]["mfi"].ToString()) : 0;
                MFIChart.Series["MFI"].Points.AddXY(date.ToString(), value);

                float value2 = Indicator.Rows[i]["pocs"].ToString() != "" ? float.Parse(Indicator.Rows[i]["pocs"].ToString()) : 0;
                POCSChart.Series["POCS"].Points.AddXY(date, value2);

                value = Indicator.Rows[i]["atr"].ToString() != "" ? int.Parse(Indicator.Rows[i]["atr"].ToString()) : 0;
                ATRChart.Series["ATR"].Points.AddXY(date, value);

                value2 = Indicator.Rows[i]["trix"].ToString() != "" ? float.Parse(Indicator.Rows[i]["trix"].ToString()) : 0;
                TRIXChart.Series["TRIX"].Points.AddXY(date.ToString(), value2);
                value2 = Indicator.Rows[i]["trix_signal"].ToString() != "" ? float.Parse(Indicator.Rows[i]["trix_signal"].ToString()) : 0;
                TRIXChart.Series["TRIX_Signal"].Points.AddXY(date, value2);

                value = Indicator.Rows[i]["rmi"].ToString() != "" ? int.Parse(Indicator.Rows[i]["rmi"].ToString()) : 0;
                RMIChart.Series["RMI"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["sma5"].ToString() != "" ? int.Parse(Indicator.Rows[i]["sma5"].ToString()) : 0;
                mainChart.Series["SMA5"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["sma10"].ToString() != "" ? int.Parse(Indicator.Rows[i]["sma10"].ToString()) : 0;
                mainChart.Series["SMA10"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["sma20"].ToString() != "" ? int.Parse(Indicator.Rows[i]["sma20"].ToString()) : 0;
                mainChart.Series["SMA20"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["sma60"].ToString() != "" ? int.Parse(Indicator.Rows[i]["sma60"].ToString()) : 0;
                mainChart.Series["SMA60"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["sma120"].ToString() != "" ? int.Parse(Indicator.Rows[i]["sma120"].ToString()) : 0;
                mainChart.Series["SMA120"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["bollinger_bands_upper"].ToString() != "" ? int.Parse(Indicator.Rows[i]["bollinger_bands_upper"].ToString()) : 0;
                mainChart.Series["BollingerUp"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["bollinger_bands_lower"].ToString() != "" ? int.Parse(Indicator.Rows[i]["bollinger_bands_lower"].ToString()) : 0;
                mainChart.Series["BollingerLow"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["demark_up"].ToString() != "" ? int.Parse(Indicator.Rows[i]["demark_up"].ToString()) : 0;
                mainChart.Series["DeMarkUp"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["demark_down"].ToString() != "" ? int.Parse(Indicator.Rows[i]["demark_down"].ToString()) : 0;
                mainChart.Series["DeMarkDown"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["price_channel_high"].ToString() != "" ? int.Parse(Indicator.Rows[i]["price_channel_high"].ToString()) : 0;
                mainChart.Series["PriceChannelHigh"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["price_channel_low"].ToString() != "" ? int.Parse(Indicator.Rows[i]["price_channel_low"].ToString()) : 0;
                mainChart.Series["PriceChannelLow"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["pivot"].ToString() != "" ? int.Parse(Indicator.Rows[i]["pivot"].ToString()) : 0;
                mainChart.Series["Pivot"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["pivot_resistance_1"].ToString() != "" ? int.Parse(Indicator.Rows[i]["pivot_resistance_1"].ToString()) : 0;
                mainChart.Series["PivotResi1"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["pivot_resistance_2"].ToString() != "" ? int.Parse(Indicator.Rows[i]["pivot_resistance_2"].ToString()) : 0;
                mainChart.Series["PivotResi2"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["pivot_support_1"].ToString() != "" ? int.Parse(Indicator.Rows[i]["pivot_support_1"].ToString()) : 0;
                mainChart.Series["PivotSup1"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["pivot_support_2"].ToString() != "" ? int.Parse(Indicator.Rows[i]["pivot_support_2"].ToString()) : 0;
                mainChart.Series["PivotSup2"].Points.AddXY(date.ToString(), value);

                value = Indicator.Rows[i]["psar_bull"].ToString() != "" ? int.Parse(Indicator.Rows[i]["psar_bull"].ToString()) : 0;
                mainChart.Series["PSAR_Bull"].Points.AddXY(date.ToString(), value);
                value = Indicator.Rows[i]["psar_bear"].ToString() != "" ? int.Parse(Indicator.Rows[i]["psar_bear"].ToString()) : 0;
                mainChart.Series["PSAR_Bear"].Points.AddXY(date.ToString(), value);




            }
            mainChart.ChartAreas[0].AxisX.MajorGrid.Interval = price.Rows.Count / GridCount;
            mainChart.ChartAreas[0].AxisY.MajorGrid.Interval = (max - min) / GridCount;

            //volumeChart.ChartAreas[0].AxisX.MajorGrid.Interval = table.Rows.Count / GridCount;
            //volumeChart.ChartAreas[0].AxisY.MajorGrid.Interval = (max - min) / GridCount;


            RMIChart.ChartAreas[0].AxisY.Maximum = 100;
            RMIChart.ChartAreas[0].AxisY.Minimum = 0;

            MFIChart.ChartAreas[0].AxisY.Maximum = 100;
            MFIChart.ChartAreas[0].AxisY.Minimum = 0;

            RMIChart.ChartAreas[0].AxisY.Maximum = 100;
            RMIChart.ChartAreas[0].AxisY.Minimum = 0;

            StocasticChart.ChartAreas[0].AxisY.Maximum = 100;
            StocasticChart.ChartAreas[0].AxisY.Minimum = 0;

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

        private void ChartAxisViewChanged(object sender, ViewEventArgs e)
        {
            int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
            int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

            //volumeChart.ChartAreas[0].AxisX.ScaleView = mainChart.ChartAreas[0].AxisX.ScaleView;

            volumeChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            volumeChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            volumeChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            MACDChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            MACDChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            MACDChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            RSIChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            RSIChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            RSIChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            StocasticChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            StocasticChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            StocasticChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            MFIChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            MFIChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            MFIChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            POCSChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            POCSChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            POCSChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            ATRChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            ATRChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            ATRChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            TRIXChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            TRIXChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            TRIXChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            RMIChart.ChartAreas[0].AxisX.ScaleView.MinSize = mainChart.ChartAreas[0].AxisX.ScaleView.MinSize;
            RMIChart.ChartAreas[0].AxisX.ScaleView.Size = mainChart.ChartAreas[0].AxisX.ScaleView.Size;
            RMIChart.ChartAreas[0].AxisX.ScaleView.Position = mainChart.ChartAreas[0].AxisX.ScaleView.Position;

            int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
            int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;
            int maxVolume = 0;
            int maxMACD = (int)MACDChart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            int minMACD = (int)MACDChart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            int maxATR = (int)ATRChart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            int minATR = (int)ATRChart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            float maxPOCS = (float)POCSChart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            float minPOCS = (float)POCSChart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            float maxTRIX = (float)TRIXChart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            float minTRIX = (float)TRIXChart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
            
            for (int i = startPosition - 1; i < endPosition; i++)
            {
                if (i >= price.Rows.Count)
                    break;
                if (i < 0)
                    i = 0;

                if (int.Parse(price.Rows[i]["high"].ToString()) > max)
                    max = int.Parse(price.Rows[i]["high"].ToString());
                if (Indicator.Rows[i]["sma5"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma5"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["sma5"].ToString());
                if (Indicator.Rows[i]["sma10"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma10"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["sma10"].ToString());
                if (Indicator.Rows[i]["sma20"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma20"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["sma20"].ToString());
                if (Indicator.Rows[i]["sma60"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma60"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["sma60"].ToString());
                if (Indicator.Rows[i]["sma120"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma120"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["sma120"].ToString());
                if (Indicator.Rows[i]["bollinger_bands_upper"].ToString() != "" && int.Parse(Indicator.Rows[i]["bollinger_bands_upper"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["bollinger_bands_upper"].ToString());
                if (Indicator.Rows[i]["price_channel_high"].ToString() != "" && int.Parse(Indicator.Rows[i]["price_channel_high"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["price_channel_high"].ToString());
                if (Indicator.Rows[i]["demark_up"].ToString() != "" && int.Parse(Indicator.Rows[i]["demark_up"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["demark_up"].ToString());
                if (Indicator.Rows[i]["pivot_resistance_2"].ToString() != "" && (int.Parse(Indicator.Rows[i]["pivot_resistance_2"].ToString()) > max))
                    max = int.Parse(Indicator.Rows[i]["pivot_resistance_2"].ToString());
                if (Indicator.Rows[i]["psar_bear"].ToString() != "" && int.Parse(Indicator.Rows[i]["psar_bear"].ToString()) > max)
                    max = int.Parse(Indicator.Rows[i]["psar_bear"].ToString());

                if (int.Parse(price.Rows[i]["low"].ToString()) < min)
                    min = int.Parse(price.Rows[i]["low"].ToString());
                if (Indicator.Rows[i]["sma5"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma5"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["sma5"].ToString());
                if (Indicator.Rows[i]["sma10"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma10"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["sma10"].ToString());
                if (Indicator.Rows[i]["sma20"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma20"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["sma20"].ToString());
                if (Indicator.Rows[i]["sma60"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma60"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["sma60"].ToString());
                if (Indicator.Rows[i]["sma120"].ToString() != "" && int.Parse(Indicator.Rows[i]["sma120"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["sma120"].ToString());
                if (Indicator.Rows[i]["bollinger_bands_lower"].ToString() != "" && int.Parse(Indicator.Rows[i]["bollinger_bands_lower"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["bollinger_bands_lower"].ToString());
                if (Indicator.Rows[i]["price_channel_low"].ToString() != "" && int.Parse(Indicator.Rows[i]["price_channel_low"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["price_channel_low"].ToString());
                if (Indicator.Rows[i]["demark_down"].ToString() != "" && int.Parse(Indicator.Rows[i]["demark_down"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["demark_down"].ToString());
                if (Indicator.Rows[i]["pivot_support_2"].ToString() != "" && int.Parse(Indicator.Rows[i]["pivot_support_2"].ToString()) < min)
                    min = int.Parse(Indicator.Rows[i]["pivot_support_2"].ToString());
                if (Indicator.Rows[i]["psar_bull"].ToString() != "" && int.Parse(Indicator.Rows[i]["psar_bull"].ToString()) < min && int.Parse(Indicator.Rows[i]["psar_bull"].ToString()) > 0)
                    min = int.Parse(Indicator.Rows[i]["psar_bull"].ToString());

                if (int.Parse(price.Rows[i]["volume"].ToString()) > maxVolume)
                    maxVolume = int.Parse(price.Rows[i]["volume"].ToString());

                int MACD = int.Parse(Indicator.Rows[i]["MACD"].ToString() != "" ? Indicator.Rows[i]["MACD"].ToString() : "0");
                if (MACD > maxMACD)
                    maxMACD = MACD;
                if (MACD < minMACD)
                    minMACD = MACD;

                int ATR = int.Parse(Indicator.Rows[i]["atr"].ToString() != "" ? Indicator.Rows[i]["atr"].ToString() : "0");
                if (ATR > maxATR)
                    maxATR = ATR;
                if (ATR < minATR)
                    minATR = ATR;

                float pocs = float.Parse(Indicator.Rows[i]["pocs"].ToString() != "" ? Indicator.Rows[i]["pocs"].ToString() : "0");
                if (pocs > maxPOCS)
                    maxPOCS = pocs;
                if (pocs < minPOCS)
                    minPOCS = pocs;

                float trix = float.Parse(Indicator.Rows[i]["trix"].ToString() != "" ? Indicator.Rows[i]["trix"].ToString() : "0");
                if (trix > maxTRIX)
                    maxTRIX = trix;
                if (trix < minTRIX)
                    minTRIX = trix;
            }

            mainChart.ChartAreas[0].AxisY.Maximum = max;
            mainChart.ChartAreas[0].AxisY.Minimum = min;

            volumeChart.ChartAreas[0].AxisY.Maximum = maxVolume;

            MACDChart.ChartAreas[0].AxisY.Maximum = maxMACD;
            MACDChart.ChartAreas[0].AxisY.Minimum = minMACD;

            ATRChart.ChartAreas[0].AxisY.Maximum = maxATR;
            ATRChart.ChartAreas[0].AxisY.Minimum = minATR;

            POCSChart.ChartAreas[0].AxisY.Maximum = maxPOCS;
            POCSChart.ChartAreas[0].AxisY.Minimum = minPOCS;

            TRIXChart.ChartAreas[0].AxisY.Maximum = maxTRIX;
            TRIXChart.ChartAreas[0].AxisY.Minimum = minTRIX;

            POCSChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F2}";

            ChartArea plots = mainChart.ChartAreas[0];
            plots.AxisX.MajorGrid.Interval = (endPosition - startPosition) / GridCount;
            plots.AxisY.MajorGrid.Interval = (max - min) / GridCount;
        }

        private void ZoomButton_Click(object sender, EventArgs e)
        {
            ZoomButton.Checked = !ZoomButton.Checked;
            mainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = !mainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled;
        }

        private void TrendsIndicator_Click(object sender, EventArgs e)
        {
            if (!trendsIndicatorVisible)
            {
                // 펼치기
                TrendsPanel.Visible = true;
                SMAPanel.Visible = false;
                TrendsPanel.Height = 40 * 7;
            }
            else
            {
                // 접기
                TrendsPanel.Visible = false;
            }
            trendsIndicatorVisible = !trendsIndicatorVisible;
        }

        private void SMAButton_Click(object sender, EventArgs e)
        {
            if (!smaVisible)
            {
                //펼치기
                SMAPanel.Visible = true;
                TrendsPanel.Height = 40 * 11;
            }
            else
            {
                // 접기
                SMAPanel.Visible = false;
                TrendsPanel.Height = 40 * 6;
            }
            smaVisible = !smaVisible;
        }

        private void VariabilityButton_Click(object sender, EventArgs e)
        {
            if (!variabilityIndicatorVisible)
            {
                //펼치기
                VariabilityPanel.Visible = true;
            }
            else
            {
                // 접기
                VariabilityPanel.Visible = false;
            }
            variabilityIndicatorVisible = !variabilityIndicatorVisible;
        }

        private void MomentumButton_Click(object sender, EventArgs e)
        {
            if (!momentumIndicatorVisible)
            {
                //펼치기
                MomentumPanel.Visible = true;
            }
            else
            {
                // 접기
                MomentumPanel.Visible = false;
            }
            momentumIndicatorVisible = !momentumIndicatorVisible;
        }

        private void StrengthButton_Click(object sender, EventArgs e)
        {
            if (!strengthIndicatorVisible)
            {
                //펼치기
                StrengthPanel.Visible = true;
            }
            else
            {
                //접기
                StrengthPanel.Visible = false;
            }
            strengthIndicatorVisible = !strengthIndicatorVisible;
        }

        private void MACDButton_Click(object sender, EventArgs e)
        {
            MACDChart.Visible = !MACDChart.Visible;
            if (MACDChart.Visible) 
            {
                MACDButton.BackColor = Color.Gainsboro;
            }
            else
            {
                MACDButton.BackColor = Color.White;
            }

        }

        private void ATRButton_Click(object sender, EventArgs e)
        {
            ATRChart.Visible = !ATRChart.Visible;
            if (ATRChart.Visible)
            {
                ATRButton.BackColor = Color.Gainsboro;
            }
            else
            {
                ATRButton.BackColor = Color.White;
            }
        }

        private void RSIButton_Click(object sender, EventArgs e)
        {
            RSIChart.Visible = !RSIChart.Visible;
            if (RSIChart.Visible)
            {
                RSIButton.BackColor = Color.Gainsboro;
            }
            else
            {
                RSIButton.BackColor = Color.White;
            }
        }

        private void StocasticButton_Click(object sender, EventArgs e)
        {
            StocasticChart.Visible = !StocasticChart.Visible;
            if (StocasticChart.Visible)
            {
                StocasticButton.BackColor = Color.Gainsboro;
            }
            else
            {
                StocasticButton.BackColor = Color.White;
            }
        }

        private void PriceOscilator_Click(object sender, EventArgs e)
        {
            POCSChart.Visible = !POCSChart.Visible;
            if (POCSChart.Visible)
            {
                PriceOscilator.BackColor = Color.Gainsboro;
            }
            else
            {
                PriceOscilator.BackColor = Color.White;
            }
        }

        private void TRIXButton_Click(object sender, EventArgs e)
        {
            TRIXChart.Visible = !TRIXChart.Visible;
            if (TRIXChart.Visible)
            {
                TRIXButton.BackColor = Color.Gainsboro;
            }
            else
            {
                TRIXButton.BackColor = Color.White;
            }
        }

        private void RMIButton_Click(object sender, EventArgs e)
        {
            RMIChart.Visible = !RMIChart.Visible;
            if (RMIChart.Visible)
            {
                RMIButton.BackColor = Color.Gainsboro;
            }
            else
            {
                RMIButton.BackColor = Color.White;
            }
        }

        private void MFIButton_Click(object sender, EventArgs e)
        {
            MFIChart.Visible = !MFIChart.Visible;
            if (MFIChart.Visible)
            {
                MFIButton.BackColor = Color.Gainsboro;
            }
            else
            {
                MFIButton.BackColor = Color.White;
            }
        }

        private void SMA5Button_Click(object sender, EventArgs e)
        {
            mainChart.Series["SMA5"].Enabled = !mainChart.Series["SMA5"].Enabled;
            if (mainChart.Series["SMA5"].Enabled)
            {
                SMA5Button.BackColor = Color.Gainsboro;
            }
            else
            {
                SMA5Button.BackColor = Color.White;
            }
        }

        private void SMA10Button_Click(object sender, EventArgs e)
        {
            mainChart.Series["SMA10"].Enabled = !mainChart.Series["SMA10"].Enabled;
            if (mainChart.Series["SMA10"].Enabled)
            {
                SMA10Button.BackColor = Color.Gainsboro;
            }
            else
            {
                SMA10Button.BackColor = Color.White;
            }
        }

        private void SMA20Button_Click(object sender, EventArgs e)
        {
            mainChart.Series["SMA20"].Enabled = !mainChart.Series["SMA20"].Enabled;
            if (mainChart.Series["SMA20"].Enabled)
            {
                SMA20Button.BackColor = Color.Gainsboro;
            }
            else
            {
                SMA20Button.BackColor = Color.White;
            }
        }

        private void SMA60Button_Click(object sender, EventArgs e)
        {
            mainChart.Series["SMA60"].Enabled = !mainChart.Series["SMA60"].Enabled;
            if (mainChart.Series["SMA60"].Enabled)
            {
                SMA60Button.BackColor = Color.Gainsboro;
            }
            else
            {
                SMA60Button.BackColor = Color.White;
            }
        }

        private void SMA120Button_Click(object sender, EventArgs e)
        {
            mainChart.Series["SMA120"].Enabled = !mainChart.Series["SMA120"].Enabled;
            if (mainChart.Series["SMA120"].Enabled)
            {
                SMA120Button.BackColor = Color.Gainsboro;
            }
            else
            {
                SMA120Button.BackColor = Color.White;
            }
        }

        private void PIVOTButton_Click(object sender, EventArgs e)
        {

            mainChart.Series["Pivot"].Enabled = !mainChart.Series["Pivot"].Enabled;
            mainChart.Series["PivotResi1"].Enabled = mainChart.Series["Pivot"].Enabled;
            mainChart.Series["PivotResi2"].Enabled = mainChart.Series["Pivot"].Enabled;
            mainChart.Series["PivotSup1"].Enabled = mainChart.Series["Pivot"].Enabled;
            mainChart.Series["PivotSup2"].Enabled = mainChart.Series["Pivot"].Enabled;
            if (mainChart.Series["Pivot"].Enabled)
            {
                PIVOTButton.BackColor = Color.Gainsboro;
            }
            else
            {
                PIVOTButton.BackColor = Color.White;
            }
        }

        private void PSARButton_Click(object sender, EventArgs e)
        {
            mainChart.Series["PSAR_Bull"].Enabled = !mainChart.Series["PSAR_Bull"].Enabled;
            mainChart.Series["PSAR_Bear"].Enabled = mainChart.Series["PSAR_Bull"].Enabled;
            if (mainChart.Series["PSAR_Bull"].Enabled)
            {
                PSARButton.BackColor = Color.Gainsboro;
            }
            else
            {
                PSARButton.BackColor = Color.White;
            }
        }

        private void DeMarkButton_Click(object sender, EventArgs e)
        {
            mainChart.Series["DeMarkUp"].Enabled = !mainChart.Series["DeMarkUp"].Enabled;
            mainChart.Series["DeMarkDown"].Enabled = mainChart.Series["DeMarkUp"].Enabled;
            if (mainChart.Series["DeMarkUp"].Enabled)
            {
                DeMarkButton.BackColor = Color.Gainsboro;
            }
            else
            {
                DeMarkButton.BackColor = Color.White;
            }
        }

        private void PriceChannelButton_Click(object sender, EventArgs e)
        {
            mainChart.Series["PriceChannelHigh"].Enabled = !mainChart.Series["PriceChannelHigh"].Enabled;
            mainChart.Series["PriceChannelLow"].Enabled = mainChart.Series["PriceChannelHigh"].Enabled;
            if (mainChart.Series["PriceChannelHigh"].Enabled)
            {
                PriceChannelButton.BackColor = Color.Gainsboro;
            }
            else
            {
                PriceChannelButton.BackColor = Color.White;
            }
        }

        private void BollingerBandsButton_Click(object sender, EventArgs e)
        {
            mainChart.Series["BollingerUp"].Enabled = !mainChart.Series["BollingerUp"].Enabled;
            mainChart.Series["BollingerLow"].Enabled = mainChart.Series["BollingerUp"].Enabled;
            if (mainChart.Series["BollingerUp"].Enabled)
            {
                BollingerBandsButton.BackColor = Color.Gainsboro;
            }
            else
            {
                BollingerBandsButton.BackColor = Color.White;
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (price != null)
            {
                // VerticalLine
                int index = (int)mainChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X) - 1 >= 0 ? (int)mainChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X) - 1 : 0;
                index = index < price.Rows.Count ? index : price.Rows.Count - 1;
                string date = price.Rows[index]["date"].ToString();

                DateText.Text = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
                OpenText.Text = "시가 : " + price.Rows[index]["open"].ToString();
                HighText.Text = "고가 : " + price.Rows[index]["high"].ToString();
                LowText.Text = "저가 : " + price.Rows[index]["low"].ToString();
                CloseText.Text = "종가 : " + price.Rows[index]["close"].ToString();
                VolumeText.Text = "거래량 : " + price.Rows[index]["volume"].ToString();

                DisplayFinancialStatement(date);
            }
            
        }
    }
}
