using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace AutoTraderGUI.Library
{
    [Serializable]
    class SimulateAgent
    {
        public bool isSelected;
        public AlgorithmInfo algorithm;
        public List<TradeInfo> TradeInfo;                   // 과거 거래 기록
        public List<TradeInfo> OwnList;
        public List<TradeInfo> sellTradeInfo;
        public List<ulong> EvaluationAssets;                // 평가금
        public List<float> AlgorithmMDDList;

        public List<float> Yield;                           // 일 수익률
        public List<float> Profit;                          // 일 평균 수익
        public List<float> Loss;                            // 일 평균 손실
        public List<int> ProfitCount;                       // 일별 수익 횟수
        public List<int> LossCount;                         // 일별 손실 횟수

        public List<float> MDD;                             // 일 평균 최대 누적 손실률
        public List<float> MFE;                             // 일 평균 최대 미실현 수익
        public List<float> MAE;                             // 일 평균 최대 미실현 손실

        public float TotalYieldAverage;                     // 전체 평균 수익률
        public float AlgorithmMDD;                          // 해당 알고리즘의 MDD

        public string Date;
        public int CompleteDateLength;
        public List<string> DateList;
        public int DateLength;
        public ulong Assets;
        public string SimulateUnit;
        public float Tax;
        public float Charge;

        ulong MaxAssests;

        [NonSerialized]
        public Forms.SimulateChart chart;
        [NonSerialized]
        public Forms.SImulateInfoForm info;

        [NonSerialized]
        SimulateInterface simulateInterface;
        public SimulateAgent(SimulateInterface simulateInterface)
        {
            this.simulateInterface = simulateInterface;
            isSelected = false;
            TradeInfo = new List<TradeInfo>();
            EvaluationAssets = new List<ulong>();
            OwnList = new List<TradeInfo>();
            sellTradeInfo = new List<TradeInfo>();
            AlgorithmMDDList = new List<float>();

            Yield = new List<float>();
            Profit = new List<float>();
            Loss = new List<float>();
            ProfitCount = new List<int>();
            LossCount = new List<int>();

            MDD = new List<float>();
            MFE = new List<float>();
            MAE = new List<float>();

            TotalYieldAverage = 0;

            Date = "20000101";
            DateList = new List<string>();
            DateLength = 0;
            CompleteDateLength = 0;
            Assets = 0;
            SimulateUnit = "일";
            Tax = 0;
            Charge = 0;

            chart = new Forms.SimulateChart();
            info = new Forms.SImulateInfoForm(simulateInterface);
        }
        public void LoadChart()
        {
            chart = new Forms.SimulateChart();
            for (int i = 0; i < EvaluationAssets.Count; i++)
            {
                chart.AddData(EvaluationAssets[i], Yield[i], ProfitCount[i] + LossCount[i], AlgorithmMDDList[i], Profit[i], Loss[i], MFE[i], MAE[i]);
            }
            
        }
        public void LoadInfo(SimulateInterface simulateInterface)
        {
            info = new Forms.SImulateInfoForm(simulateInterface);
            for (int i = 0; i < EvaluationAssets.Count; i++)
            {
                info.Update(CompleteDateLength, DateLength, Date, EvaluationAssets[i], Yield[i], ProfitCount.Sum(), LossCount.Sum(), Profit.Average(), Loss.Average(), Yield.Average(), AlgorithmMDD);
            }
        }

        public bool isOwn(string name)
        {
            for (int i = 0; i < OwnList.Count; i++)
            {
                if (OwnList[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable GetOnlyOwnData(DataTable data)
        {
            DataTable result = data.Clone();
            result.Rows.Clear();

            for (int i = 0; i < OwnList.Count; i++)
            {
                string name = OwnList[i].name;

                for (int j = 0; j < data.Rows.Count; j++)
                {
                    if (data.Rows[j]["name"].ToString() == name)
                    {
                        int open = int.Parse(data.Rows[j]["open"].ToString());
                        int high = int.Parse(data.Rows[j]["high"].ToString());
                        int low = int.Parse(data.Rows[j]["low"].ToString());
                        int close = int.Parse(data.Rows[j]["close"].ToString());
                        int volume = int.Parse(data.Rows[j]["volume"].ToString());

                        DataRow row = result.NewRow();
                        row["name"] = name;
                        row["open"] = open;
                        row["high"] = high;
                        row["low"] = low;
                        row["close"] = close;
                        row["volume"] = volume;

                        result.Rows.Add(row);

                        break;
                    }
                }
            }

            return result;
        }

        public int GetTradeInfo(string name)
        {
            for (int i = 0; i < OwnList.Count; i++)
            {
                if (OwnList[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetBuySQL(List<string> dateList, List<string> realtime)
        {
            string SQL = algorithm.buySQLFormat;

            for (int j = 0; j < dateList.Count; j++)
            {
                SQL = SQL.Replace(string.Format("[테이블{0}]", j), string.Format("`{0}`", dateList[dateList.Count - 1 - j]));
            }
            for (int j = 0; j < realtime.Count; j++)
            {
                SQL = SQL.Replace(string.Format("[리얼타임테이블{0}]", j), string.Format("`{0}`", realtime[realtime.Count - 1 - j]));
            }

            return SQL;
        }

        public string GetSellSQL(List<string> dateList, List<string> realtime)
        {
            string SQL = algorithm.sellSQLFormat;

            for (int j = 0; j < dateList.Count; j++)
            {
                SQL = SQL.Replace(string.Format("[테이블{0}]", j), string.Format("`{0}`", dateList[dateList.Count - 1 - j]));
            }
            for (int j = 0; j < realtime.Count; j++)
            {
                SQL = SQL.Replace(string.Format("[리얼타임테이블{0}]", j), string.Format("`{0}`", realtime[realtime.Count - 1 - j]));
            }

            return SQL;
        }

        public string GetTodayDateSQL()
        {
            string todaySQL = string.Format("SELECT name, open, high, low, close, volume FROM `{0}` WHERE ", Date);
            for (int k = 0; k < OwnList.Count; k++)
            {
                todaySQL += string.Format("name='{0}' ", OwnList[k].name);

                if (k < OwnList.Count - 1)
                {
                    todaySQL += "or ";
                }
            }

            return todaySQL;
        }

        public int CalculateSellPrice(int price)
        {
            return (int)(price * (1f - Charge - Tax));
            //return price;
        }
        public int CalculateBuyPrice(int price)
        {
            return (int)(price * (1f + Charge));
            //return price;
        }
        public void Sell(int index, int price, string action)
        {
            TradeInfo tradeinfo = OwnList[index];
            OwnList.RemoveAt(index);

            tradeinfo.sellDate = Date;

            int sellAmount = price * tradeinfo.Volume;

            tradeinfo.sellPrice = price;
            tradeinfo.totalSellAmount = sellAmount;
            tradeinfo.Yield = (float)(sellAmount - tradeinfo.totalBuyAmount) / tradeinfo.totalBuyAmount * 100;
            tradeinfo.action = action;
            Assets += (ulong)sellAmount;
            sellTradeInfo.Add(tradeinfo);
        }

        public void Buy(string name, ulong purchaseAssets, int price, int open, int high, int low, int close)
        {
            int buyNum = (int)(purchaseAssets / (ulong)price);
            int buyAmount = price * buyNum;
            Assets -= (ulong)buyAmount;

            TradeInfo tradeInfo = new TradeInfo();
            tradeInfo.name = name;

            tradeInfo.buyDate = Date;
            tradeInfo.buyPrice = price;
            tradeInfo.Volume = buyNum;
            tradeInfo.totalBuyAmount = buyAmount;

            tradeInfo.RTopen = open;
            tradeInfo.RThigh = high;
            tradeInfo.RTlow = low;
            tradeInfo.RTclose = close;

            OwnList.Add(tradeInfo);
        }

        // 정산
        public void Settlement()
        {
            List<float> tmpprofitList = new List<float>();
            List<float> tmplossList = new List<float>();
            List<float> tmpmdd  = new List<float>();
            List<float> tmpmfe  = new List<float>();
            List<float> tmpmae  = new List<float>();
            ulong Evaluation = Assets;
            int profitCount = 0;
            int lossCount = 0;
            float todayYield = 0;


            for (int i = 0; i < sellTradeInfo.Count; i++)
            {
                float yield = (float)(sellTradeInfo[i].totalSellAmount - sellTradeInfo[i].totalBuyAmount) / sellTradeInfo[i].totalBuyAmount * 100;

                if (yield > 0f)
                {
                    tmpprofitList.Add(yield);
                    profitCount++;
                }
                else
                {
                    tmplossList.Add(yield);
                    lossCount++;
                }

                tmpmdd.Add(sellTradeInfo[i].MDD);
                tmpmfe.Add(sellTradeInfo[i].MFE);
                tmpmae.Add(sellTradeInfo[i].MAE);

                TradeInfo.Add(sellTradeInfo[i]);
            }

            sellTradeInfo.Clear();
            

            for (int i = 0; i < OwnList.Count; i++)
            {
                OwnList[i].maxPrice = OwnList[i].maxPrice > OwnList[i].RTclose ? OwnList[i].maxPrice : OwnList[i].RTclose;
                OwnList[i].minPrice = OwnList[i].minPrice < OwnList[i].RTclose ? OwnList[i].minPrice : OwnList[i].RTclose;

                OwnList[i].MDD = (float)(OwnList[i].RTclose - OwnList[i].maxPrice) / OwnList[i].maxPrice * 100 < OwnList[i].MDD ? (float)(OwnList[i].RTclose - OwnList[i].maxPrice) / OwnList[i].maxPrice * 100 : OwnList[i].MDD;
                OwnList[i].MFE = (float)(OwnList[i].maxPrice - OwnList[i].buyPrice) / OwnList[i].buyPrice > OwnList[i].MFE ? (float)(OwnList[i].maxPrice - OwnList[i].buyPrice) / OwnList[i].buyPrice : OwnList[i].MFE;
                OwnList[i].MAE = (float)(OwnList[i].minPrice - OwnList[i].buyPrice) / OwnList[i].buyPrice < OwnList[i].MAE ? (float)(OwnList[i].minPrice - OwnList[i].buyPrice) / OwnList[i].buyPrice : OwnList[i].MAE;

                OwnList[i].Evaluation = (ulong)(OwnList[i].RTclose * OwnList[i].Volume);
                Evaluation += OwnList[i].Evaluation;
            }

            float todayProfit = tmpprofitList.Count > 0 ? tmpprofitList.Average() : 0;
            float todayLoss = tmplossList.Count > 0 ? tmplossList.Average() : 0;
            float todayMDD = tmpmdd.Count > 0 ? tmpmdd.Average() : 0;
            float todayMFE = tmpmfe.Count > 0 ? tmpmfe.Average() : 0;
            float todayMAE = tmpmae.Count > 0 ? tmpmae.Average() : 0;

            EvaluationAssets.Add(Evaluation);
            Profit.Add(todayProfit);
            Loss.Add(todayLoss);
            ProfitCount.Add(profitCount);
            LossCount.Add(lossCount);

            

            MDD.Add(todayMDD);
            MFE.Add(todayMFE);
            MAE.Add(todayMAE);

            MaxAssests = MaxAssests > Evaluation ? MaxAssests : Evaluation;
            
            AlgorithmMDD = AlgorithmMDD > (float)((decimal)((long)Evaluation - (long)MaxAssests) / (long)MaxAssests * 100) ? (float)((float)((long)Evaluation - (long)MaxAssests) / (long)MaxAssests * 100) : AlgorithmMDD;
            AlgorithmMDDList.Add(AlgorithmMDD);
            if (EvaluationAssets.Count > 1)
            {
                todayYield = (float)(((long)EvaluationAssets[EvaluationAssets.Count - 1] - (long)EvaluationAssets[EvaluationAssets.Count - 2]) / (double)EvaluationAssets[EvaluationAssets.Count - 2]);
                Yield.Add(todayYield);
            }
            else
            {
                Yield.Add(0);
            }

            TotalYieldAverage = Yield.Average();

            // 차트 최신화

            try
            {
                chart.AddData(Evaluation, todayYield, OwnList.Count, AlgorithmMDD, todayProfit, todayLoss, todayMFE, todayMAE);
                info.Update(CompleteDateLength, DateLength, Date, Evaluation, todayYield, ProfitCount.Sum(), LossCount.Sum(), Profit.Average(), Loss.Average(), Yield.Average(), AlgorithmMDD); ;
            }
            catch
            {

            }
            

            if(CompleteDateLength == DateLength)
            {
                info.SimulatingButton.Text = "거래기록 분석하기";
                info.isComplete = true;
            }

        }
    }
}
