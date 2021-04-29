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
        public string Option 
        {
            get
            {
                return OptionWriter.Text;
            }
        }

        public string SQL
        {
            get
            {
                return SQLCommand.Text;
            }
        }
        SymbolInterface symbolInterface;
        public AlgorithmOptionManager(SymbolInterface symbolInterface)
        {
            InitializeComponent();
            this.symbolInterface = symbolInterface;

            
            OffsetCombo.SelectedIndex = 0;

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
            if (e.Node.Level == 0)
            {
                indicatorName.Text = "None";
                return;
            }
            else
            {
                indicatorName.Text = e.Node.Text;
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

            ListViewItem item = new ListViewItem(symbolInterface.SymbolTable.SymbolsListView.Items.Count.ToString());
            item.SubItems.Add(VarName.Text);
            item.SubItems.Add(indicatorName.Text.Replace(" ", ""));
            item.SubItems.Add(OffsetCombo.Text);


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

            item.SubItems.Add(PropertyName);
            item.SubItems.Add(Property);

            symbolInterface.SymbolTable.SymbolsListView.Items.Add(item);
            SeparationCombo.Items.Add(VarName.Text);
            Reset();
        }

        void Reset()
        {
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
            offsetRange = 0;
            string firstPart = "SELECT t0.code FROM ";
            for (int i = 0; i < symbolInterface.SymbolTable.SymbolsListView.Items.Count; i++)
            {
                offsetRange = int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) > offsetRange ? int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text) : offsetRange;
            }

            string tableList = "";
            string baseOption = " WHERE ";
            string OrderOption = "";

            for(int i = 0; i <= offsetRange; i++)
            {
                tableList += string.Format("[테이블{0}] t{0}", i);

                if(i > 0)
                {
                    baseOption += string.Format("t0.code = t{0}.code and", i);
                }

                if(i != offsetRange)
                {
                    tableList += ", ";
                }
            }

            string option = string.Format(" ( {0} )", OptionWriter.Text);

            for (int i = symbolInterface.SymbolTable.SymbolsListView.Items.Count - 1; i >= 0 ; i--)
            {
                string keyword = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[1].Text;
                int offset = int.Parse(symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[3].Text);
                string indicator = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[2].Text;

                if (symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text.Trim() != "")
                {
                    string[] Parameter = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[4].Text.Split(',');
                    string[] ParameterValue = symbolInterface.SymbolTable.SymbolsListView.Items[i].SubItems[5].Text.Split(',');
                    for(int j = 0; j < Parameter.Length; j++)
                    {
                        if(Parameter[j].Trim() == "이격도")
                        {
                            option = option.Replace(keyword, string.Format("t{0}.{1} / {2} * 100", offset, GetTableColumn(indicator), ParameterValue[j].Trim()));
                        }
                        else if(Parameter[j].Trim() == "거래 우선순위")
                        {
                            if(ParameterValue[j] == "오름차순")
                            {
                                OrderOption = string.Format(" ORDER BY t{0}.{1}", offset, GetTableColumn(indicator));
                            }
                            else if(ParameterValue[j] == "내림차순")
                            {
                                OrderOption = string.Format(" ORDER BY t{0}.{1} DESC", offset, GetTableColumn(indicator));
                            }
                            
                        }
                    }
                }
                else
                {
                    // 단순 지표
                    option = option.Replace(keyword, string.Format("t{0}.{1}",offset ,GetTableColumn(indicator)));
                }
            }

            string result = firstPart + tableList + baseOption + option + OrderOption;
            SQLCommand.Text = result;
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
                case "기관순매수금액":
                    column = "기관_순매수금액";
                    break;
                case "기관매수금액":
                    column = "기관_매수금액";
                    break;
                case "기관매도금액":
                    column = "기관_매도금액";
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
                case "연기금등순매수금액":
                    column = "연기금등_순매수금액";
                    break;
                case "연기금등매수금액":
                    column = "연기금등_매수금액";
                    break;
                case "연기금등매도금액":
                    column = "연기금등_매도금액";
                    break;
                case "사모펀드순매수금액":
                    column = "사모펀드_순매수금액";
                    break;
                case "사모펀드매수금액":
                    column = "사모펀드_매수금액";
                    break;
                case "사모펀드매도금액":
                    column = "사모펀드_매도금액";
                    break;
                case "국가순매수금액":
                    column = "국가_순매수금액";
                    break;
                case "국가매수금액":
                    column = "국가_매수금액";
                    break;
                case "국가매도금액":
                    column = "국가_매도금액";
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
                case "내외국인순매수금액":
                    column = "내외국인_순매수금액";
                    break;
                case "내외국인매수금액":
                    column = "내외국인_매수금액";
                    break;
                case "내외국인매도금액":
                    column = "내외국인_매도금액";
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
                case "ParabolicSAR상승":
                    column = "psar_bull";
                    break;
                case "ParabolicSAR하락":
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

    }
}
