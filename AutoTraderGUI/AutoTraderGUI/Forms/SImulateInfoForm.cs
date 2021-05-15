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

namespace AutoTraderGUI.Forms
{
    public partial class SImulateInfoForm : UserControl
    {
        SimulateInterface simulateInterface;
        public bool isComplete;
        public SImulateInfoForm(SimulateInterface simulateInterface)
        {
            isComplete = false;
            this.simulateInterface = simulateInterface;
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        public void Update(int CompleteLength, int TotalLength, string Date, ulong Evaluation, float Yield, int ProfitCount, int LossCount, float ProfitAverage, float LossAverage, float YieldAverage, float MDD)
        {
            SimulateProgress.Value = (int)((float)CompleteLength / TotalLength * 100);
            SimulateProgressText.Text = string.Format("{0:D4}/{1:D4}", CompleteLength, TotalLength);
            DateText.Text = DateTime.ParseExact(Date, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
            EvaluationAssets.Text = Evaluation.ToString("N0");
            WinRate.Text = string.Format("{0}/{1}", ProfitCount, LossCount);
            ProfitLossRatio.Text = string.Format("{0:N2}/{1:N2}", ProfitAverage, LossAverage);
            AverageYield.Text = string.Format("{0:N3}", YieldAverage);
            MDDText.Text = string.Format("{0:N2}", MDD);
        }

        private void SimulatingButton_Click(object sender, EventArgs e)
        {
            if (!simulateInterface.isSimulating) //(SimulatingButton.Text == "시뮬레이트 시작"
            {
                SimulatingButton.Text = "시뮬레이트 중지";
                simulateInterface.SimulateStart();
            }
            else
            {
                SimulatingButton.Text = "시뮬레이트 시작";
                simulateInterface.SimulateStop();
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if(simulateInterface != null)
                simulateInterface.ClickAnalyze();
        }
    }
}
