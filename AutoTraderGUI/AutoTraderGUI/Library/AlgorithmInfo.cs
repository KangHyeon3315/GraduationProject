using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace AutoTraderGUI.Library
{
    [Serializable]
    class AlgorithmInfo
    {
        public float Yield = 0;             // 수익률
        public float ProfitLossRatio = 0;   // 손익비
        public float winRate = 0;           // 승률
        public float MDD = 0;               // 최대 누적 하락률
        public float MFE = 0;               // 최대 미실현 수익
        public float AFE = 0;               // 평균 미실현 수익
        public float MAE = 0;               // 최대 미실현 손실
        public float AAE = 0;               // 평균 미실현 손실

        public string AlgorithmName;
        public int DistributeNum = 0;
        public int MaxOwnDate = 0;
        public Frequency TradeFrequency;

        public TradeTiming buyTiming;
        public Trends marketTrends;

        public TradeTiming sellTiming;
        public float profitCut = 0;
        public float lossCut = 0;

        public int DateCount;
        public int RealTimeDateCount;
        public string buyOption;
        public string buySQLFormat;
        public string sellOption;
        public string sellSQLFormat;

        public List<Symbol> symbols;
    }
}
