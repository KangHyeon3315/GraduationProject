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

namespace AutoTraderGUI.Forms
{
    public partial class SimulateChart : UserControl
    {
        ulong EvaluationMax = 0;
        ulong EvaluationMin = 999999999999999;

        public SimulateChart()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            EvaluationChart.Titles.Add("평가금");
            EvaluationChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            EvaluationChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            YieldChart.Titles.Add("수익률");
            YieldChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            YieldChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            DistChart.Titles.Add("분산투자 개수");
            DistChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            DistChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            MDDChart.Titles.Add("MDD");
            MDDChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            MDDChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            ProfitLossChart.Titles.Add("수익/손실");
            ProfitLossChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            ProfitLossChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

            MFEMAEChart.Titles.Add("MFE / MDD");
            MFEMAEChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            MFEMAEChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

        }

        public void AddData(ulong Evaluation, float Yield, int DistNum, float MDD, float Profit, float Loss, float MFE, float MAE)
        {
            lock (this)
            {
                ulong Eval = Evaluation / 10000;
                EvaluationChart.Series["Series1"].Points.Add(Eval);
                EvaluationMax = EvaluationMax > Eval ? EvaluationMax : Eval;
                EvaluationMin = EvaluationMin < Eval ? EvaluationMin : Eval;

                if (EvaluationMax == EvaluationMin)
                {
                    EvaluationMax += 100;
                    EvaluationMin -= 100;
                }

                this.EvaluationChart.ChartAreas[0].AxisY.Maximum = EvaluationMax;
                this.EvaluationChart.ChartAreas[0].AxisY.Minimum = EvaluationMin;

                YieldChart.Series["Series1"].Points.Add(Yield);
                DistChart.Series["Series1"].Points.Add(DistNum);
                MDDChart.Series["Series1"].Points.Add(MDD);
                ProfitLossChart.Series["Profit"].Points.Add(Profit);
                ProfitLossChart.Series["Loss"].Points.Add(Loss);
                MFEMAEChart.Series["MFE"].Points.Add(MFE);
                MFEMAEChart.Series["MAE"].Points.Add(MAE);
            }
        }
    }
}
