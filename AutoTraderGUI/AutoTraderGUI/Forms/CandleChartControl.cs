using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AutoTraderGUI.Forms
{
    public partial class CandleChartControl : UserControl
    {
        Series chartSeries;
        DataTable table;

        int GridCount;
        public CandleChartControl(DataTable table)
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            GridCount = 15;
            ChartArea plots = chart1.ChartAreas[0];
            plots.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            plots.AxisY.MajorGrid.LineColor = Color.Gainsboro;

            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Width = 100;
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].Position.Y = 0;

            chartSeries = chart1.Series["Series1"];
            chart1.Series["Series1"]["PriceUpColor"] = "Red";
            chart1.Series["Series1"]["PriceDownColor"] = "Blue";
            chart1.AxisViewChanged += chart1_AxisViewChanged;

            this.table = table;

            int max = 0;
            int min = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                max = max < int.Parse(table.Rows[i]["high"].ToString()) ? int.Parse(table.Rows[i]["high"].ToString()) : max;
                min = min < int.Parse(table.Rows[i]["low"].ToString()) ? min : int.Parse(table.Rows[i]["low"].ToString());

                chart1.Series["Series1"].Points.AddXY(table.Rows[i]["date"].ToString(), int.Parse(table.Rows[i]["high"].ToString()));
                // adding low 
                chart1.Series["Series1"].Points[i].YValues[1] = int.Parse(table.Rows[i]["low"].ToString());
                //adding open 
                chart1.Series["Series1"].Points[i].YValues[2] = int.Parse(table.Rows[i]["open"].ToString());
                // adding close 
                chart1.Series["Series1"].Points[i].YValues[3] = int.Parse(table.Rows[i]["close"].ToString());

            }
            plots.AxisX.MajorGrid.Interval = table.Rows.Count / GridCount;
            plots.AxisY.MajorGrid.Interval = (max - min) / GridCount;
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (sender.Equals(chart1))
            {
                int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

                int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
                int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;

                for (int i = startPosition - 1; i < endPosition; i++)
                {
                    if (i >= table.Rows.Count)
                        break;
                    if (i < 0)
                        i = 0;

                    if (int.Parse(table.Rows[i]["high"].ToString()) > max)
                        max = int.Parse(table.Rows[i]["high"].ToString());
                    if (int.Parse(table.Rows[i]["low"].ToString()) < min)
                        min = int.Parse(table.Rows[i]["low"].ToString());
                }

                this.chart1.ChartAreas[0].AxisY.Maximum = max;
                this.chart1.ChartAreas[0].AxisY.Minimum = min;

                ChartArea plots = chart1.ChartAreas[0];
                plots.AxisX.MajorGrid.Interval = (endPosition - startPosition) / GridCount;
                plots.AxisY.MajorGrid.Interval = (max - min) / GridCount;
            }

        }
    }
}
