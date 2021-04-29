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
        public string AlgorithmName;
        public int DistributeNum;
        public int MaxOwnDate;

        public TradeTiming buyTiming;
        public Trends marketTrends;

        public TradeTiming sellTiming;
        public float profitCut;
        public float lossCut;

        public int tableCount;
        public string buyOption;
        public string buySQLFormat;
        public string sellOption;
        public string sellSQLFormat;

        public Forms.SymbolTable SymbolTable;
    }
}
