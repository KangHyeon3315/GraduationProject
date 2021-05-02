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
        public float Yield;             // 수익률
        public float ProfitLossRatio;   // 손익비
        public float winRate;           // 승률
        public float MDD;               // 최대 누적 하락률
        public float maxFE;             // 최대 미실현 수익
        public float meanFE;            // 평균 미실현 수익
        public float maxAE;             // 최대 미실현 손실
        public float meanAE;            // 평균 미실현 손실

        public string AlgorithmName;
        public int DistributeNum;
        public int MaxOwnDate;
        public Frequency TradeFrequency;

        public TradeTiming buyTiming;
        public Trends marketTrends;

        public TradeTiming sellTiming;
        public float profitCut = 0;
        public float lossCut = 0;

        public int DateCount;
        public string buyOption;
        public string buySQLFormat;
        public string sellOption;
        public string sellSQLFormat;

        public List<Symbol> symbols;
    }
}
