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

namespace AutoTraderGUI.Forms
{
    public partial class SimulateTradeInfoViewer : Form
    {
        Library.DBController DB;

        List<Library.TradeInfo> tradeinfos;
        public SimulateTradeInfoViewer(object DB, object tradeinfos)
        {
            InitializeComponent();

            this.tradeinfos = (List<Library.TradeInfo>)tradeinfos;
            this.DB = (Library.DBController)DB;
            
            for (int i = 0; i < this.tradeinfos.Count; i++)
            {
                string BuyDate = this.tradeinfos[i].buyDate;
                string SellDate = this.tradeinfos[i].sellDate;
                float yield = this.tradeinfos[i].Yield;
                string name = this.tradeinfos[i].name;
                string action = this.tradeinfos[i].action;
                TradeInfoCombo.Items.Add(string.Format("[{0} - {1}] {2,10:N2} {3, -20}\t{4, 20}", BuyDate, SellDate, yield, name, action));
            }

            
        }

        void DisplayData(Library.TradeInfo tradeinfo)
        {
            int GridCount = 15;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["BuySell"].Points.Clear();
            ActionText.Text = tradeinfo.action;
            BuyDateText.Text = tradeinfo.buyDate;
            BuyPriceText.Text = tradeinfo.buyPrice.ToString();
            SellDateText.Text = tradeinfo.sellDate;
            SellPriceText.Text = tradeinfo.sellPrice.ToString();
            YieldText.Text = tradeinfo.Yield.ToString("N2") + "%";
            MDDText.Text = tradeinfo.MDD.ToString("N2") + "%";
            MFEText.Text = tradeinfo.MFE.ToString("N2") + "%";
            MAEText.Text = tradeinfo.MAE.ToString("N2") + "%";

            Series chartSeries;
            List<string> DateList = DB.SelectTableList("daily_simulate");
            DateList.Sort();

            string startDate = "";
            string endDate = "";

            startDate = DateTime.ParseExact(tradeinfo.buyDate, "yyyyMMdd", CultureInfo.CurrentCulture).AddMonths(-1).ToString("yyyyMMdd");
            endDate = DateTime.ParseExact(tradeinfo.sellDate, "yyyyMMdd", CultureInfo.CurrentCulture).AddMonths(1).ToString("yyyyMMdd");

            /*
            int margin = 10;
            for(int i = 0; i < DateList.Count; i++)
            {
                if (DateList[i] == tradeinfo.buyDate)
                    startDate = i - margin >= 0 ? DateList[i - margin] : DateList[0];
                    

                if(DateList[i] == tradeinfo.sellDate)
                    endDate = i + margin <= DateList.Count - 1 ? DateList[i + margin] : DateList[DateList.Count - 1];
                    

                if (startDate != "" && endDate != "")
                    break;
            }
            */
            DataTable chartData = DB.SelectTableData("daily_chart", tradeinfo.name, string.Format("date >= {0} and date <= {1}", startDate, endDate));

            ChartArea plots = chart1.ChartAreas[0];
            plots.AxisX.MajorGrid.Enabled = false;
            plots.AxisY.MajorGrid.Enabled = false;
            //plots.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            //plots.AxisY.MajorGrid.LineColor = Color.Gainsboro;

            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Width = 100;
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].Position.Y = 0;

            chartSeries = chart1.Series["Series1"];
            chart1.Series["Series1"]["PriceUpColor"] = "Red";
            chart1.Series["Series1"]["PriceDownColor"] = "Blue";
            //chart1.AxisViewChanged += chart1_AxisViewChanged;

            int max = 0;
            int min = 999999999;
            for (int i = 0; i < chartData.Rows.Count; i++)
            {
                max = max < int.Parse(chartData.Rows[i]["high"].ToString()) ? int.Parse(chartData.Rows[i]["high"].ToString()) : max;
                min = min < int.Parse(chartData.Rows[i]["low"].ToString()) ? min : int.Parse(chartData.Rows[i]["low"].ToString());

                chart1.Series["Series1"].Points.AddXY(chartData.Rows[i]["date"].ToString(), int.Parse(chartData.Rows[i]["high"].ToString()));
                // adding low 
                chart1.Series["Series1"].Points[i].YValues[1] = int.Parse(chartData.Rows[i]["low"].ToString());
                //adding open 
                chart1.Series["Series1"].Points[i].YValues[2] = int.Parse(chartData.Rows[i]["open"].ToString());
                // adding close 
                chart1.Series["Series1"].Points[i].YValues[3] = int.Parse(chartData.Rows[i]["close"].ToString());

                if(chartData.Rows[i]["date"].ToString() == tradeinfo.buyDate)
                {
                    chart1.Series["BuySell"].Points.AddXY(chartData.Rows[i]["date"].ToString(), tradeinfo.buyPrice);
                }
                else if(chartData.Rows[i]["date"].ToString() == tradeinfo.sellDate)
                {
                    chart1.Series["BuySell"].Points.AddXY(chartData.Rows[i]["date"].ToString(), tradeinfo.sellPrice);
                }
                else
                {
                    chart1.Series["BuySell"].Points.AddXY(chartData.Rows[i]["date"].ToString(), 0);
                }

                
                
            }
            plots.AxisX.MajorGrid.Interval = chartData.Rows.Count / GridCount;
            plots.AxisY.MajorGrid.Interval = (max - min) / GridCount;
            this.chart1.ChartAreas[0].AxisY.Maximum = max;
            this.chart1.ChartAreas[0].AxisY.Minimum = min;

            
            
        }

        private void TradeInfoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData(tradeinfos[TradeInfoCombo.SelectedIndex]);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if(TradeInfoCombo.SelectedIndex + 1 < TradeInfoCombo.Items.Count)
            {
                TradeInfoCombo.SelectedIndex = TradeInfoCombo.SelectedIndex + 1;
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (TradeInfoCombo.SelectedIndex - 1 >= 0)
            {
                TradeInfoCombo.SelectedIndex = TradeInfoCombo.SelectedIndex - 1;
            }
        }

    }
}
