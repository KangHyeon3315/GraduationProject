using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoTraderGUI.Forms
{
    public partial class AlgorithmCreate : Form, SymbolInterface
    {
        
        AlgorithmOptionManager buyOption;
        AlgorithmOptionManager sellOption;

        Forms.SymbolTable symbolTable;
        public SymbolInterface symbolInterface
        {
            get
            {
                return (this as SymbolInterface);
            }
        }
        public Forms.SymbolTable SymbolTable
        {
            get
            {
                return symbolTable;
            }
        }
        public AlgorithmCreate()
        {
            InitializeComponent();
            this.CenterToParent();
            symbolTable = new SymbolTable();
            if(!Directory.Exists(string.Format("{0}\\{1}", Application.StartupPath, "Algorithm")))
            {
                Directory.CreateDirectory(string.Format("{0}\\{1}", Application.StartupPath, "Algorithm"));
                AlgorithmNumber.Text = "0000";
            }
            else
            {
                AlgorithmNumber.Text = Directory.GetFiles(string.Format("{0}\\{1}", Application.StartupPath, "Algorithm")).Length.ToString("D4");
            }

            BuyTimingCombo.SelectedIndex = 2;       // 항상 매수
            SellTimingCombo.SelectedIndex = 2;      // 항상 매도
            TrendsCombo.SelectedIndex = 0;          // None


            buyOption = new AlgorithmOptionManager(this as SymbolInterface);
            sellOption = new AlgorithmOptionManager(this as SymbolInterface);
            

            buyOptionPage.Controls.Clear();
            buyOptionPage.Controls.Add(buyOption);

            sellOptionPage.Controls.Clear();
            sellOptionPage.Controls.Add(sellOption);
        }
        private void tabTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabTable.SelectedIndex == 1)
            {
                buyOption.SetSymbolTable();
            }
            else if(tabTable.SelectedIndex == 2)
            {
                sellOption.SetSymbolTable();
            }
        }


        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            Library.AlgorithmInfo algorithmInfo = new Library.AlgorithmInfo();

            if(AlgorithmName.Text.Trim() == "")
            {
                MessageBox.Show("알고리즘 이름을 입력하세요.");
                return;
            }
            else
            {
                algorithmInfo.AlgorithmName = AlgorithmName.Text;
            }

            if(DistributeCount.Text.Trim() == "")
            {
                algorithmInfo.DistributeNum = 0;
            }
            else
            {
                algorithmInfo.DistributeNum = int.Parse(DistributeCount.Text);
            }

            if(MaxOwnDay.Text.Trim() == "")
            {
                algorithmInfo.MaxOwnDate = -1;
            }
            else
            {
                algorithmInfo.MaxOwnDate = int.Parse(MaxOwnDay.Text);
            }

            switch (BuyTimingCombo.SelectedIndex)
            {
                case 0:
                    algorithmInfo.buyTiming = TradeTiming.Open;
                    break;
                case 1:
                    algorithmInfo.buyTiming = TradeTiming.Close;
                    break;
                default:
                    algorithmInfo.buyTiming = TradeTiming.All;
                    break;
            }

            switch (SellTimingCombo.SelectedIndex)
            {
                case 0:
                    algorithmInfo.sellTiming = TradeTiming.Open;
                    break;
                case 1:
                    algorithmInfo.sellTiming = TradeTiming.Close;
                    break;
                default:
                    algorithmInfo.sellTiming = TradeTiming.All;
                    break;
            }

            switch (TrendsCombo.SelectedIndex)
            {
                case 1:
                    algorithmInfo.marketTrends = Trends.UpTrends;
                    break;
                case 2:
                    algorithmInfo.marketTrends = Trends.DownTrends;
                    break;
                case 3:
                    algorithmInfo.marketTrends = Trends.LateralTrends;
                    break;
                default:
                    algorithmInfo.marketTrends = Trends.None;
                    break;
            }

            algorithmInfo.buyOption = buyOption.Option;
            algorithmInfo.buySQLFormat = buyOption.SQL;
            algorithmInfo.sellOption = sellOption.Option;
            algorithmInfo.sellSQLFormat = sellOption.SQL;
            algorithmInfo.SymbolTable = symbolTable;

            // bin파일로 저장하기
        }

        private void DistributeKey_Press(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void MaxOwnDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void ProfitcutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void LosscutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        
    }
}
