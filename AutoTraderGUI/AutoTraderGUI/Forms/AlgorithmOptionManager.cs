using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;

namespace AutoTraderGUI.Forms
{
    public partial class AlgorithmOptionManager : UserControl
    {
        public int offsetRange;
        public int realtimeOffsetRange;
        public string Option 
        {
            get
            {
                return OptionWriter.Text;
            }
            set
            {
                OptionWriter.Text = value;
            }
        }

        public string SQL
        {
            get
            {
                return SQLCommand.Text;
            }
            set
            {
                SQLCommand.Text = value;
            }
        }
        SymbolInterface symbolInterface;
        AlgorithmDetailsInterface algorithmDetailsInterface;
        string tradeType;
        public AlgorithmOptionManager(string tradeType, SymbolInterface symbolInterface, AlgorithmDetailsInterface algorithmDetailsInterface)
        {
            InitializeComponent();
            this.symbolInterface = symbolInterface;
            this.algorithmDetailsInterface = algorithmDetailsInterface;
            this.tradeType = tradeType;

            OffsetCombo.SelectedIndex = 0;

            IndicatorViewer.ExpandAll();
            Dock = DockStyle.Fill;
        }

        public void SetSymbolTable()
        {
            OptionInputLayout.Controls.Clear();
            OptionInputLayout.Controls.Add(symbolInterface.SymbolTable);
            OptionInputLayout.Controls.Add(groupBox3);
            OptionInputLayout.Controls.Add(groupBox4);
        }
        
        private void itemClick(object sender, TreeViewEventArgs e)
        {
            OffsetCombo.Items.Clear();
            OffsetCombo.Items.Add("0");
            OffsetCombo.Items.Add("1");
            OffsetCombo.Items.Add("2");
            OffsetCombo.Items.Add("3");
            OffsetCombo.Items.Add("4");
            OffsetCombo.Items.Add("5");
            OffsetCombo.SelectedIndex = 0;
            if (e.Node.Level == 0)
            {
                indicatorName.Text = "None";
                return;
            }
            else
            {
                if(e.Node.Text == "이동평균선")
                {
                    indicatorName.Text = "None";
                    return;
                }

                if(e.Node.Parent.Text == "실시간정보")
                {
                    indicatorName.Text = e.Node.Text + "(실시간)";

                    if (algorithmDetailsInterface.TradeFrequencyInfo != "분")
                    {
                        OffsetCombo.Items.Clear();
                        OffsetCombo.Items.Add("0");
                        OffsetCombo.SelectedIndex = 0;
                    }
                }
                else
                {
                    indicatorName.Text = e.Node.Text;
                }
                
            }
        }

        private void AddSymbol(object sender, EventArgs e)
        {
            float tmp;
            
            if(indicatorName.Text == "None")
            {
                MessageBox.Show("지표를 선택하세요.");
                return;
            }
            if(float.TryParse(indicatorName.Text, out tmp))
            {
                MessageBox.Show("변수명은 숫자로만 정의할 수 없습니다.");
                return;
            }
            for(int i = 0; i < symbolInterface.SymbolTable.SymbolsListView.Items.Count; i++)
            {
                if(VarName.Text == symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[1].Text)
                {
                    MessageBox.Show("이미 존재하는 변수 명입니다.");
                    return;
                }
                if (OrderCheck.Checked && symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text.Contains("거래 우선순위"))
                {
                    MessageBox.Show("거래 우선순위는 한개만 지정이 가능합니다.");
                    return;
                }
            }

            //ListViewItem item = new ListViewItem(symbolInterface.SymbolTable.SymbolsListView.Items.Count.ToString());
            //item.SubItems.Add(VarName.Text);
            //item.SubItems.Add(indicatorName.Text.Replace(" ", ""));
            //item.SubItems.Add(OffsetCombo.Text);


            string PropertyName = "";
            string Property = "";

            if (SeparationCheck.Checked)
            {
                if (SeparationCombo.Text == "")
                {
                    MessageBox.Show("이격도 속성을 지정하세요.");
                    return;
                }
                    
                PropertyName += "이격도";
                Property += SeparationCombo.Text;

                if (OrderCheck.Checked)
                {
                    PropertyName += ",";
                    Property += ",";
                }
            }

            if (OrderCheck.Checked)
            {
                if(OrderCombo.Text == "")
                {
                    MessageBox.Show("거래 우선순위 속성을 지정하세요.");
                    return;
                }
                PropertyName += "거래 우선순위";
                Property += OrderCombo.Text;
            }

            if (indicatorName.Text.Contains("(실시간)"))
            {
                if(PropertyName != "")
                {
                    PropertyName += ",";
                    Property += ",";
                }

                PropertyName += "실시간";
                Property += algorithmDetailsInterface.TradeFrequencyInfo;
            }

            symbolInterface.AddSymbol(new Symbol(VarName.Text, indicatorName.Text.Replace(" ", ""), int.Parse(OffsetCombo.Text), PropertyName, Property));
            SeparationCombo.Items.Add(VarName.Text);
            Reset();
        }

        void Reset()
        {
            IndicatorViewer.SelectedNode = null;
            indicatorName.Text = "None";
            OffsetCombo.SelectedIndex = 0;
            SeparationCheck.Checked = false;
            SeparationCombo.Text = "";
            OrderCheck.Checked = false;
            SeparationCombo.Text = "";
            VarName.Text = "";
        }

        void Reformating()
        {
            string result = OptionWriter.Text;
            result = result.Replace(")", " ) ");
            result = result.Replace("(", " ( ");
            result = result.Replace(")and", " ) and ");
            result = result.Replace("and(", " and ( ");
            result = result.Replace(")or", " ) or ");
            result = result.Replace("or(", " or ( ");
            result = result.Replace(">", " > ");
            result = result.Replace("<", " < ");
            result = result.Replace("> =", " >= ");
            result = result.Replace("< =", " <= ");
            result = result.Replace("+", " + ");
            result = result.Replace("-", " - ");
            result = result.Replace("*", " * ");
            result = result.Replace("/", " / ");
            result = result.Replace("%", " % ");

            while (result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }

            OptionWriter.Text = result;

        }
        
        bool TokenAnalyze()
        {
            OptionWriter.Text = OptionWriter.Text.Replace("\n", " ");
            string[] token = OptionWriter.Text.Split(' ');
            int opened_parentheses = 0;
            int unknown_keyword = 0;

            int cursor_start = 0;
            for (int i = 0; i < token.Length; i++)
            {
                // 토큰 타입 분석 및 괄호검사
                float tmp;
                if (float.TryParse(token[i], out tmp))
                {
                    OptionWriter.Select(cursor_start, token[i].Length);
                    OptionWriter.SelectionColor = Color.Green;
                }
                else if (token[i] == ")" || token[i] == "(" || token[i] == "and" || token[i] == "or" || token[i] == ">" || token[i] == "<" || token[i] == ">=" || token[i] == "<=" || token[i] == "+" || token[i] == "-" || token[i] == "*" || token[i] == "/" || token[i] == "%")
                {
                    if(token[i] == "(")
                    {
                        opened_parentheses++;
                    }
                    else if(token[i] == ")")
                    {
                        opened_parentheses--;
                    }
                }
                else
                {
                    OptionWriter.Select(cursor_start, token[i].Length);
                    OptionWriter.SelectionColor = Color.Red;
                    unknown_keyword++;

                    for (int j = 0; j < symbolInterface.SymbolTable.SymbolsListView.Items.Count; j++)
                    {
                        if(symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[1].Text == token[i])
                        {
                            OptionWriter.Select(cursor_start, token[i].Length);
                            OptionWriter.SelectionColor = Color.Blue;
                            unknown_keyword--;
                            break;
                        }
                    }
                }
                cursor_start += token[i].Length + 1;    // 토큰 단어 길이 + 공백
            }

            if(opened_parentheses != 0)
            {
                SQLCommand.Text = "괄호가 정상적으로 닫혀있지 않습니다.";
                return false;
            }
            else if(unknown_keyword != 0)
            {
                SQLCommand.Text = "알수없는 키워드가 존재합니다.";
                return false;
            }

            return true;
        }

        void MakeSQLTemplate()
        {
            OptionWriter.Text = " " + OptionWriter.Text;
            offsetRange = 0;
            realtimeOffsetRange = 0;
            string firstPart = "";
            string standardTable = "";

            for (int i = 0; i < symbolInterface.SymbolTable.SymbolsListView.Items.Count; i++)
            {
                if (!symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text.Contains("실시간"))
                {
                    offsetRange = int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) > offsetRange ? int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) : offsetRange;
                }
                else
                {
                    realtimeOffsetRange = int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) > realtimeOffsetRange ? int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) : realtimeOffsetRange;
                }
                
            }

            List<string> addedtable = new List<string>();
            addedtable.Add("r0");
            addedtable.Add("t0");
            string tableList = "[리얼타임테이블0] r0, [테이블0] t0";
            string baseOption = " WHERE ";
            string TrendsOption = "";
            string OrderOption = "";

            if(tradeType == "buy")
            {
                switch (algorithmDetailsInterface.marketTrends)
                {
                    case "상승 추세":
                        TrendsOption = " and (t0.sma20 > t0.sma60 and t0.sma60 > t0.sma120)";
                        break;
                    case "하락 추세":
                        TrendsOption = " and (t0.sma20 < t0.sma60 and t0.sma60 < t0.sma120)";
                        break;
                    case "횡보 추세":
                        TrendsOption = " and (not(t0.sma20 > t0.sma60 and t0.sma60 > t0.sma120) and not(t0.sma20 < t0.sma60 and t0.sma60 < t0.sma120))";
                        break;
                }
            }
            
            

            for(int i = 0; i <= offsetRange; i++)
            {
                
                for (int j = 0; j < symbolInterface.SymbolTable.SymbolsListView.Items.Count; j++)
                {
                    if (!symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[4].Text.Contains("실시간") && int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[3].Text) == i)
                    {
                        //if (!OptionWriter.Text.Contains(string.Format("{0}", symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[1].Text)))
                        if (!OptionTokenContains(symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[1].Text))
                            continue;

                        if(firstPart == "")
                        {
                            firstPart = string.Format("SELECT r0.name, r0.open, r0.high, r0.low, r0.close, r0.volume FROM ", i);
                            standardTable = string.Format("t{0}", i);


                        }
                        if(i > 0)
                        {
                            if (tableList != "")
                            {
                                tableList += ", ";
                            }
                            tableList += string.Format("[테이블{0}] t{0}", i);
                            addedtable.Add(string.Format("t{0}", i));
                        }
                         
                        break;
                    }
                }
            }

            
            for (int i = 0; i <= realtimeOffsetRange; i++)
            {
                for (int j = 0; j < symbolInterface.SymbolTable.SymbolsListView.Items.Count; j++)
                {
                    if (symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[4].Text.Contains("실시간") && int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[3].Text) == i)
                    {
                        //if (!OptionWriter.Text.Contains(string.Format("{0}", symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[1].Text)))
                        if(!OptionTokenContains(symbolInterface.SymbolTable.SymbolsListView.Items[j].SubItems[1].Text))
                            continue;

                        if (firstPart == "")
                        {
                            firstPart = string.Format("SELECT r0.name, r0.open, r0.high, r0.low, r0.close, r0.volume FROM ", i);
                            standardTable = string.Format("r{0}", i);
                        }
                        if(i > 0)
                        {
                            if (tableList != "")
                            {
                                tableList += ", ";
                            }
                            tableList += string.Format("[리얼타임테이블{0}] r{0}", i);
                            addedtable.Add(string.Format("r{0}", i));
                        }
                        
                        break;
                    }
                }
            }

            foreach(string t in addedtable)
            {
                if (t == "r0")
                    continue;

                baseOption += string.Format("r0.name = {0}.name and ", t);
            }

            string option = string.Format(" ( {0} )", OptionWriter.Text);

            for (int i = symbolInterface.SymbolTable.SymbolsListView.Items.Count - 1; i >= 0 ; i--)
            {
                string keyword = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[1].Text; // 변수
                int offset = int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text); // 오프셋
                string indicator = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[2].Text; // 지표
                string Parameter = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text;
                string ParameterValue = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[5].Text;
                string tableType = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text.Contains("실시간") ? "r" : "t";

                if (Parameter.Trim() != "")
                {
                    if (Parameter.Contains("거래 우선순위"))
                    {
                        if (ParameterValue.Contains("오름차순"))
                        {
                            OrderOption += string.Format(" ORDER BY {0} ", keyword);
                        }
                        else
                        {
                            OrderOption += string.Format(" ORDER BY {0} DESC", keyword);
                        }

                    }

                    if (Parameter.Contains("이격도"))
                    {
                        string[] splitedParam = Parameter.Split(',');
                        string[] splitedParamValue = ParameterValue.Split(',');
                        //option = option.Replace(keyword, string.Format("{3}{0}.{1} / {2} * 100", offset, GetTableColumn(indicator), ParameterValue[j].Trim(), tableType));

                        for(int j = 0; j < splitedParam.Length; j++)
                        {
                            if (splitedParam[j].Contains("이격도"))
                            {
                                option = option.Replace(keyword, string.Format("{0}{1}.{2} / {3} * 100", tableType, offset, GetTableColumn(indicator), splitedParamValue[j].Trim()));
                                OrderOption = OrderOption.Replace(keyword, string.Format("{0}{1}.{2} / {3} * 100", tableType, offset, GetTableColumn(indicator), splitedParamValue[j].Trim()));
                            }
                        }
                    }

                    //option = option.Replace(string.Format(" {0} ", keyword), string.Format(" {2}{0}.{1} ", offset, GetTableColumn(indicator), tableType));


                }
                
                    // 단순 지표
                option = option.Replace(string.Format(" {0} ", keyword), string.Format(" {2}{0}.{1} ",offset ,GetTableColumn(indicator), tableType));
                OrderOption = OrderOption.Replace(string.Format(" {0} ", keyword), string.Format(" {2}{0}.{1} ", offset, GetTableColumn(indicator), tableType));

            }
            string result;
            if (tradeType == "buy")
                 result = firstPart + tableList + baseOption + option + TrendsOption + OrderOption;
            else
                result = firstPart + tableList + baseOption + option + TrendsOption;

            SQLCommand.Text = result;
            OptionWriter.Text.Remove(0, 1);
        }
        bool OptionTokenContains(string data)
        {
            string[] tokens = OptionWriter.Text.Split(' ');

            foreach(string token in tokens)
            {
                if(token.Trim() == data)
                {
                    return true;
                }
            }
            return false;
        }
        string GetTableColumn(string indicator)
        {
            string column = "";
            switch (indicator)
            {
                case "시가":
                    column = "open";
                    break;
                case "고가":
                    column = "high";
                    break;
                case "저가":
                    column = "low";
                    break;
                case "종가":
                    column = "close";
                    break;
                case "거래량":
                    column = "volume";
                    break;
                case "시가(실시간)":
                    column = "open";
                    break;
                case "고가(실시간)":
                    column = "high";
                    break;
                case "저가(실시간)":
                    column = "low";
                    break;
                case "종가(실시간)":
                    column = "close";
                    break;
                case "거래량(실시간)":
                    column = "volume";
                    break;
                case "개인순매수금액":
                    column = "개인_순매수금액";
                    break;
                case "개인매수금액":
                    column = "개인_매수금액";
                    break;
                case "개인매도금액":
                    column = "개인_매도금액";
                    break;
                case "외국인순매수금액":
                    column = "외국인_순매수금액";
                    break;
                case "외국인매수금액":
                    column = "외국인_매수금액";
                    break;
                case "외국인매도금액":
                    column = "외국인_매도금액";
                    break;
                case "금융투자순매수금액":
                    column = "금융_투자순매수금액";
                    break;
                case "금융투자매수금액":
                    column = "금융_투자매수금액";
                    break;
                case "금융투자매도금액":
                    column = "금융_투자매도금액";
                    break;
                case "보험순매수금액":
                    column = "보험_순매수금액";
                    break;
                case "보험매수금액":
                    column = "보험_매수금액";
                    break;
                case "보험매도금액":
                    column = "보험_매도금액";
                    break;
                case "투신순매수금액":
                    column = "투신_순매수금액";
                    break;
                case "투신매수금액":
                    column = "투신_매수금액";
                    break;
                case "투신매도금액":
                    column = "투신_매도금액";
                    break;
                case "기타금융순매수금액":
                    column = "기타금융_순매수금액";
                    break;
                case "기타금융매수금액":
                    column = "기타금융_매수금액";
                    break;
                case "기타금융매도금액":
                    column = "기타금융_매도금액";
                    break;
                case "은행순매수금액":
                    column = "은행_순매수금액";
                    break;
                case "은행매수금액":
                    column = "은행_매수금액";
                    break;
                case "은행매도금액":
                    column = "은행_매도금액";
                    break;
                case "연기금순매수금액":
                    column = "연기금_순매수금액";
                    break;
                case "연기금매수금액":
                    column = "연기금_매수금액";
                    break;
                case "연기금매도금액":
                    column = "연기금_매도금액";
                    break;
                case "사모순매수금액":
                    column = "사모_순매수금액";
                    break;
                case "사모매수금액":
                    column = "사모_매수금액";
                    break;
                case "사모매도금액":
                    column = "사모_매도금액";
                    break;
                case "기타법인순매수금액":
                    column = "기타법인_순매수금액";
                    break;
                case "기타법인매수금액":
                    column = "기타법인_매수금액";
                    break;
                case "기타법인매도금액":
                    column = "기타법인_매도금액";
                    break;
                case "기타외국인순매수금액":
                    column = "기타외국인_순매수금액";
                    break;
                case "기타외국인매수금액":
                    column = "기타외국인_매수금액";
                    break;
                case "기타외국인매도금액":
                    column = "기타외국인_매도금액";
                    break;
                case "이동평균선5":
                    column = "sma5";
                    break;
                case "이동평균선10":
                    column = "sma10";
                    break;
                case "이동평균선20":
                    column = "sma20";
                    break;
                case "이동평균선60":
                    column = "sma60";
                    break;
                case "이동평균선120":
                    column = "sma120";
                    break;
                case "MACD":
                    column = "macd";
                    break;
                case "MACDSignal":
                    column = "macd_signal";
                    break;
                case "피벗":
                    column = "pivot";
                    break;
                case "피벗1차지지선":
                    column = "pivot_support_1";
                    break;
                case "피벗2차지지선":
                    column = "pivot_support_2";
                    break;
                case "피벗1차저항선":
                    column = "pivot_resistance_1";
                    break;
                case "피벗2차저항선":
                    column = "pivot_resistance_1";
                    break;
                case "ParabolicSAR":
                    column = "psar";
                    break;
                case "ParabolicSARBull":
                    column = "psar_bull";
                    break;
                case "ParabolicSARBear":
                    column = "psar_bear";
                    break;
                case "DeMarkUP":
                    column = "demark_up";
                    break;
                case "DeMarkDown":
                    column = "demark_down";
                    break;
                case "PriceChennelUP":
                    column = "price_channel_high";
                    break;
                case "PriceChennelDown":
                    column = "price_channel_low";
                    break;
                case "볼린저밴드UP":
                    column = "bollinger_bands_upper";
                    break;
                case "볼린저밴드Down":
                    column = "bollinger_bands_lower";
                    break;
                case "ATR":
                    column = "atr";
                    break;
                case "RSI":
                    column = "rsi";
                    break;
                case "RSISignal":
                    column = "rsi_signal";
                    break;
                case "StocasticFastK":
                    column = "stocastic_fask_K";
                    break;
                case "StocasticSlowK":
                    column = "stocastic_slow_K";
                    break;
                case "StocasticSlowD":
                    column = "stocastic_slow_d";
                    break;
                case "Price오실레이터":
                    column = "pocs";
                    break;
                case "TRIX":
                    column = "trix";
                    break;
                case "TRIXSignal":
                    column = "trix_signal";
                    break;
                case "RMI":
                    column = "rmi";
                    break;
                case "MFI":
                    column = "mfi";
                    break;
            }

            return column;
        }

        private void OptionWriter_Leave(object sender, EventArgs e)
        {
            Reformating();
            TokenAnalyze();
            MakeSQLTemplate();
        }

        public void ResetInfo()
        {
            Reset();
            SQLCommand.Text = "";
            OptionWriter.Text = "";
        }

        private void SeparationCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SeparationCheck.Checked)
            {
                SeparationCombo.Items.Clear();
                for(int i = 0; i < symbolInterface.SymbolTable.SymbolsListView.Items.Count; i++)
                {
                    SeparationCombo.Items.Add(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[1].Text);
                }
            }
        }

    }
}
