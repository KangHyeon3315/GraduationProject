using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTraderGUI.Library
{
    [Serializable]
    class TradeInfo
    {
        // company info
        public string name;
        public string code;

        // buy info
        public string buyDate;
        public int buyPrice;
        public int Volume;
        public int totalBuyAmount;

        // sell info
        public string sellDate;
        public int sellPrice;
        public int totalSellAmount;

        // 실시간 가격정보
        public int RTopen;
        public int RThigh;
        public int RTlow;
        public int RTclose;
        public int RTvolume;
        public ulong Evaluation;

        // Analyze info
        public float Yield;
        public float MDD;   // 최대 누적 하락 수익률
        public float MFE;   // 최대 미실현 수익
        public float MAE;   // 최대 미실현 손실

        // 임시 변수
        public int maxPrice;
        public int minPrice;
        public int ownDate; // 보유일

        public void SetRealTimeData(int open, int high, int low, int close, int volume)
        {
            RTopen = open;
            RThigh = high;
            RTlow = low;
            RTclose = close;
            RTvolume = volume;
        }
    }
}
