using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Data;

namespace AutoTraderGUI.Library
{
    class Simulate : SimulateInterface
    {
        Thread SimulateTh;
        Library.DBController DB;
        //Settings settings;
        Forms.SimulateTradeInfoViewer infoViewer;
        public SimulateAgent agent;
        string AlgorithmName;
        bool stopFlag;
        
        public bool isSimulating
        {
            get
            {
                if (SimulateTh != null && SimulateTh.IsAlive)
                    return true;
                else
                    return false;
            }
        }
        public SimulateInterface simulInterface
        {
            get
            {
                return this as SimulateInterface;
            }
        }
        SettingsInterface settings;
        public Simulate(SettingsInterface settings, string AlgorithmName, string Unit, int InitialAsset, float Tax, float Charge)
        {
            
            agent = new SimulateAgent(this as SimulateInterface);
            agent.SimulateUnit = Unit;
            agent.Assets = (ulong)InitialAsset;
            agent.Tax = Tax;
            agent.Charge = Charge;

            stopFlag = false;
            this.AlgorithmName = AlgorithmName;
            FileStream fs = new FileStream(Application.StartupPath + "\\Algorithm\\" + AlgorithmName + ".trstr", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            agent.algorithm = (Library.AlgorithmInfo)bf.Deserialize(fs);
            fs.Close();

            
            //settings = new Settings();
            

            if (settings.DBID == "" || settings.DBIP == "" || settings.DBPort == 0 || settings.DBPW == "")
            {
                MessageBox.Show("DB 정보를 먼저 입력하세요.");
                return;
            }
            
            DB = new Library.DBController(settings.DBIP, settings.DBID, settings.DBPW);
        }

        public void SimulateStart()
        {
            stopFlag = false;
            switch (agent.SimulateUnit) 
            {
                case "일":
                    SimulateTh = new Thread(new ThreadStart(Daily_Simulating));
                    SimulateTh.Start();
                    break;
                case "분":
                    // 분 시뮬레이트 기능 추가
                    break;
            }

            
        }
        public void SimulateStop()
        {
            stopFlag = true;
            
            if (!Directory.Exists(Application.StartupPath + "\\Simulate"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Simulate");
            }

            FileStream fs = new FileStream(Application.StartupPath + "\\Simulate\\" + DateTime.Now.ToString("yyyMMddHHmm_") + AlgorithmName + ".simul", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, agent);
            fs.Close();
        }

        void UpdateRealTimeData()
        {
            DataTable TodayPriceTable = DB.SelectSQLData("daily_simulate", agent.GetTodayDateSQL());

            for (int k = 0; k < TodayPriceTable.Rows.Count; k++)
            {
                string name = TodayPriceTable.Rows[k]["name"].ToString();
                int open = int.Parse(TodayPriceTable.Rows[k]["open"].ToString());
                int high = int.Parse(TodayPriceTable.Rows[k]["high"].ToString());
                int low = int.Parse(TodayPriceTable.Rows[k]["low"].ToString());
                int close = int.Parse(TodayPriceTable.Rows[k]["close"].ToString());
                int volume = int.Parse(TodayPriceTable.Rows[k]["volume"].ToString());

                int index = agent.GetTradeInfo(name);

                if (index == -1)
                {
                    continue;
                }

                agent.OwnList[index].ownDate++;
                agent.OwnList[index].SetRealTimeData(open, high, low, close, volume);
            }
        }

        void ProfitLossCut()
        {
            // 여기서 가격정보가 잘못 정해져있음 -> 수정할것
            for (int k = 0; k < agent.OwnList.Count; k++)
            {
                // 손절
                if (agent.algorithm.lossCut != 0f && (float)(agent.OwnList[k].RTlow - agent.OwnList[k].buyPrice) / agent.OwnList[k].buyPrice <= -agent.algorithm.lossCut / 100)
                {
                    int price = (int)(agent.OwnList[k].buyPrice * (1 - (agent.algorithm.lossCut / 100)));

                    if(price > agent.OwnList[k].RTopen)
                    {
                        price = agent.OwnList[k].RTopen;
                    }

                    agent.Sell(k, agent.CalculateSellPrice(price), "손절");
                }
                // 익절
                else if (agent.algorithm.profitCut != 0f && (float)(agent.OwnList[k].RThigh - agent.OwnList[k].buyPrice) / agent.OwnList[k].buyPrice >= agent.algorithm.profitCut / 100)
                {
                    int price = (int)(agent.OwnList[k].buyPrice * (1 + (agent.algorithm.profitCut / 100)));

                    if (price < agent.OwnList[k].RTopen)
                    {
                        price = agent.OwnList[k].RTopen;
                    }

                    agent.Sell(k, agent.CalculateSellPrice(price), "익절");
                }
            }
        }

        void DateCut()
        {
            if (agent.algorithm.MaxOwnDate != -1)
            {
                for (int j = agent.OwnList.Count - 1; j >= 0; j--)
                {
                    if (agent.OwnList[j].ownDate >= agent.algorithm.MaxOwnDate)
                    {
                        // 판매 가격 지정
                        int price = 0;
                        if (agent.algorithm.sellTiming == TradeTiming.Open)
                        {
                            price = agent.OwnList[j].RTopen;
                        }
                        else if (agent.algorithm.sellTiming == TradeTiming.Close)
                        {
                            price = agent.OwnList[j].RTclose;
                        }
                        else
                        {
                            MessageBox.Show("해당 알고리즘은 일별 시뮬레이션으로 진행이 불가능 합니다.");
                            return;
                        }

                        agent.Sell(j, agent.CalculateSellPrice(price), "최대보유일에 의한 청산");
                    }
                }
            }
        }

        void SellAction(List<string> dateList, List<string> realtime)
        {
            string sellSQL = agent.GetSellSQL(dateList, realtime);
            DataTable sellTable = DB.SelectSQLData("daily_simulate", sellSQL);

            // 매도 타이밍이 종가일 경우 손익절을 매도 전에 수행
            if (agent.algorithm.sellTiming == TradeTiming.Close)
            {
                ProfitLossCut();
            }

            // 매도 진행
            sellTable = agent.GetOnlyOwnData(sellTable);              // 보유중인 종목만 가져오기

            for (int k = 0; k < sellTable.Rows.Count; k++)
            {
                string name = sellTable.Rows[k]["name"].ToString();

                int index = agent.GetTradeInfo(name);

                if (index == -1)
                {
                    continue;
                }

                int price = 0;
                // 판매 가격 지정
                if (agent.algorithm.sellTiming == TradeTiming.Open)
                {
                    price = agent.OwnList[index].RTopen;
                }
                else if (agent.algorithm.sellTiming == TradeTiming.Close)
                {
                    price = agent.OwnList[index].RTclose;
                }
                else
                {
                    MessageBox.Show("해당 알고리즘은 일별 시뮬레이션으로 진행이 불가능 합니다.");
                    return;
                }

                agent.Sell(index, agent.CalculateSellPrice(price), "조건식에 의한 판매");
            }

            if (agent.algorithm.sellTiming == TradeTiming.Open)
            {
                ProfitLossCut();
            }

            // 최대 보유일이 지난경우 매도
            DateCut();
        }

        void BuyAction(List<string> dateList, List<string> realtime)
        {
            
            string buySQL = agent.GetBuySQL(dateList, realtime);
            DataTable buyTable = DB.SelectSQLData("daily_simulate", buySQL);

            // 매수 진행
            int purchasableCount = agent.algorithm.DistributeNum;
            purchasableCount = agent.algorithm.DistributeNum - agent.OwnList.Count;       // 구매 가능 개수
            if (purchasableCount > 0)
            {
                ulong purchaseAssets = (agent.Assets / (ulong)purchasableCount);         // 구매 가능 예산

                for (int k = 0; k < buyTable.Rows.Count; k++)
                {
                    if (agent.OwnList.Count >= agent.algorithm.DistributeNum)
                    {
                        break;
                    }

                    string name = buyTable.Rows[k]["name"].ToString();

                    int open = int.Parse(buyTable.Rows[k]["open"].ToString());
                    int high = int.Parse(buyTable.Rows[k]["high"].ToString());
                    int low = int.Parse(buyTable.Rows[k]["low"].ToString());
                    int close = int.Parse(buyTable.Rows[k]["close"].ToString());
                    int volume = int.Parse(buyTable.Rows[k]["volume"].ToString());

                    if (agent.isOwn(name))               // 이미 보유하고 있는 종목인 경우 중복구매 X
                        continue;

                    int price = 0;
                    // 구매 가격 지정
                    if (agent.algorithm.buyTiming == TradeTiming.Open)
                    {
                        price = open;
                    }
                    else if (agent.algorithm.buyTiming == TradeTiming.Close)
                    {
                        price = close;
                    }
                    else
                    {
                        MessageBox.Show("해당 알고리즘은 일별 시뮬레이션으로 진행이 불가능 합니다.");
                        return;
                    }

                    // 구매 가능 예산이 1주도 사기 힘든경우
                    if (purchaseAssets < (ulong)agent.CalculateBuyPrice(price))
                        continue;

                    agent.Buy(name, purchaseAssets, agent.CalculateBuyPrice(price), open, high, low, close);
                }
            }
        }

        void Daily_Simulating()
        {
            List<string> simulatedateList = DB.SelectTableList("daily_simulate");
            simulatedateList.Sort();
            agent.DateList = simulatedateList;
            agent.DateLength = simulatedateList.Count;

            List<string> dateList = new List<string>();
            List<string> realtime = new List<string>();

            
            for (int i = agent.CompleteDateLength; i < simulatedateList.Count; i++)
            {
                if (stopFlag)
                    return;

                agent.CompleteDateLength = i;
                agent.Date = simulatedateList[i];
                realtime.Clear();
                realtime.Add(agent.Date);     // 일봉은 리얼타임이 1개만

                try
                {

                    if (dateList.Count > agent.algorithm.DateCount + 2)
                    {
                        //dateList.RemoveAt(0);
                        
                        if (agent.OwnList.Count > 0)
                        {
                            // 금일 가격정보 최신화
                            UpdateRealTimeData();

                            SellAction(dateList, realtime);
                        }

                        BuyAction(dateList, realtime);

                        // 당일 손익절 진행
                        if (agent.algorithm.sellTiming == TradeTiming.Open)
                        {
                            ProfitLossCut();
                        }
                    }
                    // 정산
                    agent.Settlement();
                    dateList.Add(agent.Date);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            agent.CompleteDateLength = agent.DateLength;
            agent.Settlement();
        }

        public void ClickAnalyze()
        {
            infoViewer = new Forms.SimulateTradeInfoViewer(DB, agent.TradeInfo);
            infoViewer.Show();
        }
    }
}
