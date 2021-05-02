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
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoTraderGUI.Forms
{
    public partial class AlgorithmEidt : Form, SymbolInterface
    {
        bool overWrite;
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

        public void AddSymbol(object symbol)
        {
            symbols.Add((Symbol)symbol);
        }

        List<Symbol> symbols;
        AlgorithmInfoInterface algorithmInfoInterface;
        public AlgorithmEidt(AlgorithmInfoInterface algorithmInfoInterface)
        {
            InitializeComponent();
            this.CenterToParent();

            overWrite = false;

            this.algorithmInfoInterface = algorithmInfoInterface;
            symbolTable = new SymbolTable();
            symbols = new List<Symbol>();

            TradeFrequency.SelectedIndex = 1;
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

        public void LoadAlgorithm(string algorithmName)
        {
            symbolTable = new SymbolTable();
            symbols = new List<Symbol>();

            overWrite = true;

            buyOption = new AlgorithmOptionManager(this as SymbolInterface);
            sellOption = new AlgorithmOptionManager(this as SymbolInterface);

            Library.AlgorithmInfo info;
            FileStream fs = new FileStream(Application.StartupPath + "\\Algorithm\\" + algorithmName + ".trstr", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            info = (Library.AlgorithmInfo)bf.Deserialize(fs);

            AlgorithmName.Text = algorithmName;
            DistributeCount.Text = info.DistributeNum.ToString();
            MaxOwnDay.Text = info.MaxOwnDate.ToString();

            TradeFrequency.SelectedIndex = (int)info.TradeFrequency;
            BuyTimingCombo.SelectedIndex = (int)info.buyTiming;
            SellTimingCombo.SelectedIndex = (int)info.sellTiming;
            TrendsCombo.SelectedIndex = (int)info.marketTrends;

            LosscutTextBox.Text = info.lossCut.ToString();
            ProfitcutTextBox.Text = info.profitCut.ToString();

            buyOption.SQL = info.buySQLFormat;
            buyOption.Option = info.buyOption;
            sellOption.SQL = info.sellSQLFormat;
            sellOption.Option = info.sellOption;

            symbolTable.SymbolsListView.Items.Clear();
            for (int i = 0; i < info.symbols.Count; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(info.symbols[i].varName);
                item.SubItems.Add(info.symbols[i].indicatorName);
                item.SubItems.Add(info.symbols[i].offset.ToString());
                item.SubItems.Add(info.symbols[i].Parameter);
                item.SubItems.Add(info.symbols[i].ParameterValue);
                symbolTable.SymbolsListView.Items.Add(item);
            }

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

            if (checkAlgorithmName(AlgorithmName.Text))
            {
                MessageBox.Show("이미 존재하는 알고리즘 이름입니다.");
                return;
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

            algorithmInfo.DateCount = buyOption.offsetRange > sellOption.offsetRange ? buyOption.offsetRange : sellOption.offsetRange;
            switch (TradeFrequency.SelectedIndex)
            {
                case 0:
                    algorithmInfo.TradeFrequency = Frequency.Min;
                    break;
                case 1:
                    algorithmInfo.TradeFrequency = Frequency.Date;
                    break;
                case 2:
                    algorithmInfo.TradeFrequency = Frequency.Month;
                    break;
                default:
                    algorithmInfo.TradeFrequency = Frequency.Year;
                    break;
            }
            algorithmInfo.buyOption = buyOption.Option;
            algorithmInfo.buySQLFormat = buyOption.SQL;
            algorithmInfo.sellOption = sellOption.Option;
            algorithmInfo.sellSQLFormat = sellOption.SQL;
            algorithmInfo.symbols = symbols;

            if(!overWrite && File.Exists(Application.StartupPath + "\\Algorithm\\" + algorithmInfo.AlgorithmName + ".trstr"))
            {
                MessageBox.Show("해당 이름의 알고리즘이 존재합니다 ");
                return;
            }

            FileStream fs = new FileStream(Application.StartupPath + "\\Algorithm\\" + algorithmInfo.AlgorithmName + ".trstr", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, algorithmInfo);
            fs.Close();
            // bin파일로 저장하기
            algorithmInfoInterface.refreshAlgorithmInfo();
            Close();

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

        private void AlgorithmCreate_Load(object sender, EventArgs e)
        {
            // 화면 초기화
            ResetData();
        }

        void ResetData()
        {
            AlgorithmName.Text = "";
            DistributeCount.Text = "";
            MaxOwnDay.Text = "";

            TradeFrequency.SelectedIndex = 1;
            BuyTimingCombo.SelectedIndex = 0;
            SellTimingCombo.SelectedIndex = 0;
            TrendsCombo.SelectedIndex = 0;

            LosscutTextBox.Text = "";
            ProfitcutTextBox.Text = "";
            buyOption.ResetInfo();
            sellOption.ResetInfo();
            symbolTable.SymbolsListView.Items.Clear();
        }

        private void AlgorithmLoad(object sender, EventArgs e)
        {
            // 파일 탐색기로 파일 Load
            // 화면에 정보 표시
            // FileStream fs = new FileStream()
            openFileDialog1.Filter = "알고리즘 파일 (*.trstr)   |*.trstr";
            openFileDialog1.ShowDialog();

            Library.AlgorithmInfo algorithmInfo;
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            algorithmInfo = (Library.AlgorithmInfo)bf.Deserialize(fs);
            fs.Close();

            AlgorithmName.Text = algorithmInfo.AlgorithmName;
            DistributeCount.Text = algorithmInfo.DistributeNum.ToString();
            MaxOwnDay.Text = algorithmInfo.MaxOwnDate.ToString();

            TradeFrequency.SelectedIndex = (int)algorithmInfo.TradeFrequency;            
            BuyTimingCombo.SelectedIndex = (int)algorithmInfo.buyTiming;
            SellTimingCombo.SelectedIndex = (int)algorithmInfo.sellTiming;
            TrendsCombo.SelectedIndex = (int)algorithmInfo.marketTrends;

            LosscutTextBox.Text = algorithmInfo.lossCut.ToString();
            ProfitcutTextBox.Text = algorithmInfo.profitCut.ToString();
            buyOption.SQL = algorithmInfo.buySQLFormat;
            buyOption.Option = algorithmInfo.buyOption;
            sellOption.SQL = algorithmInfo.sellSQLFormat;
            sellOption.Option = algorithmInfo.sellOption;
            symbolTable.SymbolsListView.Items.Clear();
            for (int i = 0; i < algorithmInfo.symbols.Count; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(algorithmInfo.symbols[i].varName);
                item.SubItems.Add(algorithmInfo.symbols[i].indicatorName);
                item.SubItems.Add(algorithmInfo.symbols[i].offset.ToString());
                item.SubItems.Add(algorithmInfo.symbols[i].Parameter);
                item.SubItems.Add(algorithmInfo.symbols[i].ParameterValue);
                symbolTable.SymbolsListView.Items.Add(item);
            }


            if (checkAlgorithmName(AlgorithmName.Text))
            {
                DialogResult result = MessageBox.Show("동일한 이름의 알고리즘이 이미 존재합니다. 이름을 변경하여 저장하겠습니까?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AlgorithmName.Text = "";
                }
                else
                {
                    ResetData();
                }
            }

        }

        bool checkAlgorithmName(string name)
        {
            // 기존에 동일한 이름의 알고리즘이 있는지 확인
            for (int i = 0; i < algorithmInfoInterface.AlgorithmNames.Length; i++)
            {
                if (AlgorithmName.Text == algorithmInfoInterface.AlgorithmNames[i])
                {
                    return true;  
                }
            }
            return false;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ResetData();
        }
    }
}
