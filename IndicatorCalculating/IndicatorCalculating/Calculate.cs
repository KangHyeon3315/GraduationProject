using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IndicatorCalculating
{
    enum CandleType
    {
        plus,
        minus,
        cross
    }
    
    class Calculate
    {
        public Calculate()
        {
            /*
            DataTable data = new DataTable("동화약품_daily");

            data.Columns.Add(new DataColumn("open", typeof(System.Int64)));
            data.Columns.Add(new DataColumn("high", typeof(System.Int64)));
            data.Columns.Add(new DataColumn("low", typeof(System.Int64)));
            data.Columns.Add(new DataColumn("close", typeof(System.Int64)));
            data.Columns.Add(new DataColumn("volume", typeof(System.Int64)));

            data.ReadXml(@"C:\Users\KangHyeon\Desktop\IndicatorCalculating\IndicatorCalculating\bin\Debug\동화약품_daily.xml");

            CalculateData(data);
            */
        }
        CandleType GetCandleType(int open, int high, int low, int close)
        {
            if (Math.Abs((open - close) / (float)close) * 100 < 1)
            {
                return CandleType.cross;
            }
            else if (open > close)
            {
                return CandleType.minus;
            }
            else
            {
                return CandleType.plus;
            }
        }
        public DataColumn CreateColumn(string name, Type type, bool AllowNull)
        {
            DataColumn col = new DataColumn();
            col.DataType = type;
            col.AllowDBNull = AllowNull;
            col.ColumnName = name;
            col.DefaultValue = null;

            return col;
        }

        public DataTable CalculateData(DataTable data)
        {
            DateTime startTime = DateTime.Now;

            DataTable result = new DataTable("indicator");

            result.Columns.Add("date", typeof(string));

            for(int i = 0; i < data.Rows.Count; i++)
            {
                result.Rows.Add(data.Rows[i]["date"].ToString());
            }

            result.Columns.Add(CreateColumn("sma5", typeof(int), true));
            result.Columns.Add(CreateColumn("sma10", typeof(int), true));
            result.Columns.Add(CreateColumn("sma20", typeof(int), true));
            result.Columns.Add(CreateColumn("sma60", typeof(int), true));
            result.Columns.Add(CreateColumn("sma120", typeof(int), true));
            result.Columns.Add(CreateColumn("bollinger_bands_upper", typeof(int), true));
            result.Columns.Add(CreateColumn("bollinger_bands_lower", typeof(int), true));
            result.Columns.Add(CreateColumn("macd", typeof(int), true));
            result.Columns.Add(CreateColumn("macd_signal", typeof(int), true));
            result.Columns.Add(CreateColumn("rsi", typeof(int), true));
            result.Columns.Add(CreateColumn("rsi_signal", typeof(int), true));
            result.Columns.Add(CreateColumn("stocastic_fask_K", typeof(int), true));
            result.Columns.Add(CreateColumn("stocastic_slow_K", typeof(int), true));
            result.Columns.Add(CreateColumn("stocastic_slow_D", typeof(int), true));
            result.Columns.Add(CreateColumn("mfi", typeof(int), true));
            result.Columns.Add(CreateColumn("pocs", typeof(float), true));
            result.Columns.Add(CreateColumn("atr", typeof(int), true));
            result.Columns.Add(CreateColumn("demark_up", typeof(int), true));
            result.Columns.Add(CreateColumn("demark_down", typeof(int), true));
            result.Columns.Add(CreateColumn("price_channel_high", typeof(int), true));
            result.Columns.Add(CreateColumn("price_channel_low", typeof(int), true));
            result.Columns.Add(CreateColumn("pivot", typeof(int), true));
            result.Columns.Add(CreateColumn("pivot_resistance_1", typeof(int), true));
            result.Columns.Add(CreateColumn("pivot_resistance_2", typeof(int), true));
            result.Columns.Add(CreateColumn("pivot_support_1", typeof(int), true));
            result.Columns.Add(CreateColumn("pivot_support_2", typeof(int), true));
            result.Columns.Add(CreateColumn("trix", typeof(float), true));
            result.Columns.Add(CreateColumn("trix_signal", typeof(float), true));
            result.Columns.Add(CreateColumn("psar", typeof(int), true));
            result.Columns.Add(CreateColumn("psar_bull", typeof(int), true));
            result.Columns.Add(CreateColumn("psar_bear", typeof(int), true));
            result.Columns.Add(CreateColumn("rmi", typeof(int), true));

            List<int> sma5 = SMA(data, 5);
            List<int> sma10 = SMA(data, 10);
            List<int> sma20 = SMA(data, 20);
            List<int> sma60 = SMA(data, 60);
            List<int> sma120 = SMA(data, 120);
            List<int>[] Bollinger = BolingerBand(data, 20);
            List<int>[] macd = MACD(data);
            List<int>[] rsi = RSI(data, 14, 6);
            List<int>[] stocastic = Stochastic(data, 5, 3);
            List<int> mfi = MFI(data, 14);
            List<float> pocs = POCS(data, 9, 20);
            List<int> atr = ATR(data, 14);
            List<int>[] demark = DeMark(data);
            List<int>[] priceChannel = PriceChannel(data, 5);
            List<int>[] pivot = Pivot(data);
            List<float>[] trix = TRIX(data, 12, 9);
            List<int>[] PSAR = ParabolicSAR(data, 0.02f, 0.2f);
            List<int> rmi = RMI(data, 20, 10);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                //{ pivot, resistance_1, resistance_2, support_1, support_2 };
                result.Rows[i]["demark_up"] = demark[0][i];
                result.Rows[i]["demark_down"] = demark[1][i];
                result.Rows[i]["pivot"] = pivot[0][i];
                result.Rows[i]["pivot_resistance_1"] = pivot[1][i];
                result.Rows[i]["pivot_resistance_2"] = pivot[2][i];
                result.Rows[i]["pivot_support_1"] = pivot[3][i];
                result.Rows[i]["pivot_support_2"] = pivot[4][i];
                result.Rows[i]["psar"] = PSAR[0][i];
                result.Rows[i]["psar_bull"] = PSAR[1][i];
                result.Rows[i]["psar_bear"] = PSAR[2][i];

                if (i >= 5)
                {
                    result.Rows[i]["sma5"] = sma5[i];
                    result.Rows[i]["price_channel_high"] = priceChannel[0][i];
                    result.Rows[i]["price_channel_low"] = priceChannel[1][i];
                }
                    
                if (i >= 10)
                    result.Rows[i]["sma10"] = sma10[i];
                if(i >= 11)
                {
                    result.Rows[i]["stocastic_fask_K"] = stocastic[0][i];
                    result.Rows[i]["stocastic_slow_K"] = stocastic[1][i];
                    result.Rows[i]["stocastic_slow_D"] = stocastic[2][i];
                }
                if(i >= 14)
                {
                    result.Rows[i]["mfi"] = mfi[i];
                    result.Rows[i]["atr"] = atr[i];
                }
                if (i >= 20)
                {
                    result.Rows[i]["pocs"] = pocs[i];
                    result.Rows[i]["sma20"] = sma20[i];
                    result.Rows[i]["bollinger_bands_upper"] = Bollinger[0][i];
                    result.Rows[i]["bollinger_bands_lower"] = Bollinger[1][i];
                    result.Rows[i]["rsi"] = rsi[0][i];
                    result.Rows[i]["rsi_signal"] = rsi[1][i];
                    
                }
                if(i >= 21)
                {
                    result.Rows[i]["trix"] = trix[0][i];
                    result.Rows[i]["trix_signal"] = trix[1][i];
                }
                if(i >= 35)
                {
                    result.Rows[i]["macd"] = macd[0][i];
                    result.Rows[i]["macd_signal"] = macd[1][i];
                }
                if(i >= 30)
                {
                    result.Rows[i]["rmi"] = rmi[i];
                }
                if (i >= 60)
                    result.Rows[i]["sma60"] = sma60[i];
                if (i >= 120)
                    result.Rows[i]["sma120"] = sma120[i];
            }

            //List<int> ema10 = EMA(data, 10);
            //List<float> pocs = POCS(data, 9, 20);
            //List<int> atr = ATR(data, 14);

            //List<int>[] tmp = DeMark(data);
            //List<int> DeMarkUp = tmp[0];
            //List<int> DeMarkDown = tmp[1];

            //List<int>[] tmp = PriceChannel(data, 5);
            //List<int> PriceChannelUp = tmp[0];
            //List<int> PriceChannelDown = tmp[1];

            //List<int>[] tmp = Pivot(data);
            //List<int> pivot = tmp[0];
            //List<int> resistance_1 = tmp[1];
            //List<int> resistance_2 = tmp[2];
            //List<int> support_1 = tmp[3];
            //List<int> support_2 = tmp[4];

            //List<float>[] tmpf = TRIX(data, 12, 9);
            //List<float> trix = tmpf[0];
            //List<float> trix_signal = tmpf[1];

            //List<int>[] tmp = ParabolicSAR(data, 0.02f, 0.2f);
            //List<int> psar = tmp[0];
            //List<int> psarbull = tmp[1];
            //List<int> psarbear = tmp[2];

            //List<int> rmi = RMI(data, 20, 10);

            //List<int>[] tmp = RSI(data, 14, 6);
            //List<int> rsi = tmp[0];
            //List<int> rsi_signal = tmp[1];
            DateTime endTime = DateTime.Now;

            return result;
            //PrintData(rmi);
            //Console.WriteLine(string.Format("Calculate Time : {0}", (endTime - startTime).ToString()));
        }

        void PrintData(List<int> data)
        {
            foreach (var tmp in data)
            {
                Console.WriteLine(tmp);
            }
        }
        void PrintData(List<float> data)
        {
            foreach (var tmp in data)
            {
                Console.WriteLine(tmp);
            }
        }
        List<int> SMA(DataTable data, int window)
        {
            List<int> result = new List<int>();

            List<int> windowData = new List<int>();
            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                windowData.Add(int.Parse(data.Rows[idx]["close"].ToString()));

                if(windowData.Count > window)
                {
                    windowData.RemoveAt(0);

                    result.Add((int)windowData.Average());
                }
                else
                {
                    result.Add(0);
                }
            }

            return result;
        }
        List<int> SMA(List<int> data, int window)
        {
            List<int> result = new List<int>();

            List<int> windowData = new List<int>();
            for (int idx = 0; idx < data.Count; idx++)
            {
                windowData.Add(data[idx]);

                if (windowData.Count > window)
                {
                    windowData.RemoveAt(0);

                    result.Add((int)windowData.Average());
                }
                else
                {
                    result.Add(0);
                }
            }

            return result;
        }
        List<float> SMA(List<float> data, int window)
        {
            List<float> result = new List<float>();

            List<float> windowData = new List<float>();
            for (int idx = 0; idx < data.Count; idx++)
            {
                windowData.Add(data[idx]);

                if (windowData.Count > window)
                {
                    windowData.RemoveAt(0);

                    result.Add(windowData.Average());
                }
                else
                {
                    result.Add(0);
                }
            }

            return result;
        }
        List<int> EMA(DataTable data, int window)
        {
            float k = 2f / (window + 1);
            
            float prevEMA = 0;

            List<int> windowData = new List<int>();
            List<int> result = new List<int>();

            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                int price = int.Parse(data.Rows[idx]["close"].ToString());

                if (idx < window - 1)
                {
                    windowData.Add(price);
                    result.Add(0);
                    continue;
                }
                else if (idx == window - 1)
                {
                    prevEMA = (float)windowData.Average();
                    result.Add((int)prevEMA);
                    continue;
                }
                else
                {
                    int ema = (int)((1 - k) * prevEMA + k * price);
                    result.Add(ema);
                    prevEMA = ema;
                }
            }

            return result;
        }
        List<int> EMA(List<int> data, int window)
        {
            float k = 2f / (window + 1);

            float prevEMA = 0;

            List<int> windowData = new List<int>();
            List<int> result = new List<int>();

            for (int idx = 0; idx < data.Count; idx++)
            {
                int price = data[idx];

                if (idx < window - 1)
                {
                    windowData.Add(price);
                    result.Add(0);
                    continue;
                }
                else if (idx == window - 1)
                {
                    prevEMA = (float)windowData.Average();
                    result.Add((int)prevEMA);
                    continue;
                }
                else
                {
                    int ema = (int)((1 - k) * prevEMA + k * price);
                    result.Add(ema);
                    prevEMA = ema;
                }
            }

            return result;
        }
        double Std(List<int> windowList)
        {
            double average = windowList.Average();
            double sumOfDerivation = 0;
            foreach (double value in windowList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / windowList.Count;
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }
        public List<int>[] BolingerBand(DataTable data, int windowLength)
        {

            List<int> window = new List<int>();
            List<int> BollingerUpper = new List<int>();
            List<int> BollingerLower = new List<int>();

            List<int> sma = SMA(data, windowLength);
            
            for(int i = 0; i < data.Rows.Count; i++)
            {
                window.Add(int.Parse(data.Rows[i]["close"].ToString()));
                if(window.Count > windowLength)
                {
                    window.RemoveAt(0);

                    double std = Std(window);
                    BollingerUpper.Add((int)(sma[i] + 2 * std));
                    BollingerLower.Add((int)(sma[i] - 2 * std));
                }
                else
                {
                    BollingerUpper.Add(0);
                    BollingerLower.Add(0);
                }

            }

            List<int>[] result = { BollingerUpper, BollingerLower };
            return result;
        }
        public List<int>[] MACD(DataTable table) //MACD 곡선 구하기
        {
            List<int> smaShort = SMA(table, 12);
            List<int> smaLong = SMA(table, 26);
            List<int> macd = new List<int>();

            for (int i = 0; i < smaLong.Count; i++)
            {
                macd.Add(smaShort[i] - smaLong[i]);
            }
            List<int> macd_signal = SMA(macd, 9);

            List<int>[] result = { macd, macd_signal };

            return result;

        }
        
        /* Price Osillator
         *      POSC = ((단기(9)이동평균 - 장기(20)이동평균) / 단기(9) 이동평균) * 100
         *      
         *      단위 : %
        */
            List<float> POCS(DataTable data, int shortWindow, int longWindow)
        {
            List<float> result = new List<float>();

            List<int> shortSMA = SMA(data, shortWindow);
            List<int> longSMA = SMA(data, longWindow);

            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                if(idx < longWindow)
                {
                    result.Add(0);
                }
                else
                {
                    result.Add(((shortSMA[idx] - longSMA[idx]) / (float)shortSMA[idx]) * 100);
                }
            }

            return result;
        }
        /* ATR
         *      TR = Max(금일고가 - 금일저가, 금일고가 - 전일종가, 금일저가 - 전일 종가)
         *      ATR = SMA(14)(TR)
         *      
         *      단위 : 원
         */
        List<int> ATR(DataTable data, int window)
        {
            List<int> TRList = new List<int>();
            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                if (idx < 1)
                {
                    TRList.Add(0);
                }
                else
                {
                    int todayHigh = int.Parse(data.Rows[idx]["high"].ToString());
                    int todayLow = int.Parse(data.Rows[idx]["low"].ToString());
                    int yestClose = int.Parse(data.Rows[idx - 1]["high"].ToString());

                    int TR = todayHigh - todayLow > todayHigh - yestClose ? todayHigh - todayLow : todayHigh - yestClose;
                    TR = TR > todayLow - yestClose ? TR : todayLow - yestClose;

                    TRList.Add(TR);
                }
            }
            return SMA(TRList, window); ;
        }
        /* DeMark
         *      전일 가격이 양봉일때
         *          x = (전일시가 + 전일고가 + 전일종가 + 전일고가) / 2
         *      전일 가격이 음봉일때
         *          x = (전일시가 + 전일고가 + 전일종가 + 전일저가) / 2
         *      전일 가격이 십자형일때
         *          x = (전일시가 + 전일고가 + 전일종가 + 전일종가) / 2
         *          
         *      DeMark Up = x - 전일 저가
         *      DeMark Down = x - 전일 고가
         *      
         *      단위 : 원
         */
        List<int>[] DeMark(DataTable data)
        {
            List<int> DeMarkUp = new List<int>();
            List<int> DeMarkDown = new List<int>();

            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                int open = int.Parse(data.Rows[idx]["open"].ToString());
                int high = int.Parse(data.Rows[idx]["high"].ToString());
                int low = int.Parse(data.Rows[idx]["low"].ToString());
                int close = int.Parse(data.Rows[idx]["close"].ToString());

                int x = open + high + close;
                switch (GetCandleType(open, high, low, close)) {
                    case CandleType.plus:
                        x += high;
                        break;
                    case CandleType.minus:
                        x += low;
                        break;
                    default:
                        x += close;
                        break;
                }

                x /= 2;

                DeMarkUp.Add(x - low);
                DeMarkDown.Add(x - high);
            }

            List<int>[] result = {DeMarkUp, DeMarkDown};

            return result;
        }
        /* Price Channel
         *      상한선 = 일정기간(5)의 최고가를 연결한 선
         *      하한선 = 일정기간(5)의 최저가를 연결한 선
         *      
         *      단위 : 원
         */
        List<int>[] PriceChannel(DataTable data, int window)
        {
            List<int> highLine = new List<int>();
            List<int> lowLine = new List<int>();

            List<int> highWindowData = new List<int>();
            List<int> lowWindowData = new List<int>();
            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                highWindowData.Add(int.Parse(data.Rows[idx]["high"].ToString()));
                lowWindowData.Add(int.Parse(data.Rows[idx]["low"].ToString()));

                if (highWindowData.Count > window)
                {
                    highWindowData.RemoveAt(0);
                    lowWindowData.RemoveAt(0);

                    highLine.Add(highWindowData.Max());
                    lowLine.Add(lowWindowData.Min());
                }
                else
                {
                    highLine.Add(0);
                    lowLine.Add(0);
                }
            }

            List<int>[] result = { highLine, lowLine };

            return result;
        }
        /* Pivot
         *      2차 저항선 = pivot point + 고가 - 저가
         *      1차 저항선 = pivot point * 2 - 저가
         *      Pivot Point = (고가 + 저가 + 종가) / 3
         *      1차 지지선 = pivot point * 2 - 고가
         *      2차 지지선 = pivot point *- 고가 + 저가
         *      
         *      단위 : 원
         */
        List<int>[] Pivot(DataTable data)
        {
            List<int> pivot = new List<int>();
            List<int> resistance_1 = new List<int>();
            List<int> resistance_2 = new List<int>();
            List<int> support_1 = new List<int>();
            List<int> support_2 = new List<int>();

            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                int open = int.Parse(data.Rows[idx]["open"].ToString());
                int high = int.Parse(data.Rows[idx]["high"].ToString());
                int low = int.Parse(data.Rows[idx]["low"].ToString());
                int close = int.Parse(data.Rows[idx]["close"].ToString());

                int pivotPoint = (high + low + close) / 3;
                pivot.Add(pivotPoint);
                resistance_1.Add(pivotPoint * 2 - low);
                resistance_2.Add(pivotPoint + high - low);
                support_1.Add(pivotPoint * 2 - high);
                support_2.Add(pivotPoint - high + low);
            }

            List<int>[] result = { pivot, resistance_1, resistance_2, support_1, support_2 };
            return result;
        }
        /* Trix
         *      EMA1 = 종가의 N(12)일 지수 이동평균
         *      EMA2 = EMA1의 N(12)일 지수 이동평균
         *      EMA3 = EMA2의 N(12)일 지수 이동평균
         *      
         *      TRIX = ((금일의 EMA3 - 전일 EMA3)/전일 EMA3) * 100
         *      TRIX_Signal = TRIX의 N(9)일 지수 이동평균
         */
        List<float>[] TRIX(DataTable data, int window, int signal_window)
        {
            List<int> EMA1 = EMA(data, window);
            List<int> EMA2 = EMA(EMA1, window);
            List<int> EMA3 = EMA(EMA2, window);

            List<float> trix = new List<float>();
            List<int> tmpTrix = new List<int>();
            for (int idx = 0; idx < data.Rows.Count; idx++)
            {
                if(idx == 0)
                {
                    trix.Add(0);
                    tmpTrix.Add(0);
                }
                else
                {
                    if(EMA3[idx - 1] != 0)
                    {
                        trix.Add(((float)(EMA3[idx] - EMA3[idx - 1]) / EMA3[idx - 1]) * 100);
                        // Trix로 다시 EMA를 구하면, Nan 오류가 수정이 안되므로 int로 조정후 계산
                        tmpTrix.Add((int)(((float)(EMA3[idx] - EMA3[idx - 1]) / EMA3[idx - 1]) * 100 * 1000000));
                    }
                    else
                    {
                        trix.Add(0);
                        tmpTrix.Add(0);
                    }
                    
                }
            }

            tmpTrix = EMA(tmpTrix, signal_window);

            List<float> trix_signal = new List<float>();

            foreach(int tmp in tmpTrix)
            {
                trix_signal.Add((float)tmp / 1000000);
            }

            List<float>[] result = { trix, trix_signal };

            return result;
        }
        /* Parabolic SAR
         *      전일 SAR 초기값 : Low
         *      EP
         *          상승 추세를 계속해 고가를 갱신하고 있는 동안은 갱신한 고가
         *          하락 추세를 계속해 저가를 갱신하고 있는 동안은 갱신한 저가
         *          
         *      SAR = 전일SAR + { 가속변수AF(주로 0.02) * ( EP(최저가 or 최저가) - 전일SAR) }
         */
        List<int>[] ParabolicSAR (DataTable data, float Acceleration, float AccelerationLimit)
        {

            // initialize
            List<int> high = new List<int>();
            List<int> low = new List<int>();
            List<int> close = new List<int>();
            List<int> psar = new List<int>();
            List<int> psarbull = new List<int>();
            List<int> psarbear = new List<int>();
            for(int i = 0; i < data.Rows.Count; i++)
            {
                high.Add(int.Parse(data.Rows[i]["high"].ToString()));
                low.Add(int.Parse(data.Rows[i]["low"].ToString()));
                close.Add(int.Parse(data.Rows[i]["close"].ToString()));
                psar.Add(int.Parse(data.Rows[i]["close"].ToString()));
                psarbull.Add(0);
                psarbear.Add(0);
            }

            bool bull = true;
            float af = Acceleration;
            float ep = low[0];
            float hp = high[0];
            float lp = low[0];

            for(int i = 2; i < data.Rows.Count; i++)
            {
                if (bull)
                    psar[i] = (int)(psar[i - 1] + af * (hp - psar[i - 1]));
                else
                    psar[i] = (int)(psar[i - 1] + af * (lp - psar[i - 1]));

                bool reverse = false;

                if (bull)
                {
                    if (low[i] < psar[i])
                    {
                        bull = false;
                        reverse = true;
                        psar[i] = (int)hp;
                        lp = high[i];
                        af = Acceleration;
                    }
                }
                else
                {
                    if(high[i] > psar[i])
                    {
                        bull = true;
                        reverse = true;
                        psar[i] = (int)lp;
                        hp = high[i];
                        af = Acceleration;
                    }
                }

                if (!reverse)
                {
                    if (bull)
                    {
                        if(high[i] > hp)
                        {
                            hp = high[i];
                            af = Math.Min(af + Acceleration, AccelerationLimit);
                        }
                        if(low[i - 1] < psar[i])
                        {
                            psar[i] = low[i - 1];
                        }
                        if(low[i - 2] < psar[i])
                        {
                            psar[i] = low[i - 2];
                        }
                    }
                    else
                    {
                        if(low[i] < lp)
                        {
                            lp = low[i];
                            af = Math.Min(af + Acceleration, AccelerationLimit);
                        }
                        if(high[i - 1] > psar[i])
                        {
                            psar[i] = high[i - 1];
                        }
                        if(high[i - 2] > psar[i])
                        {
                            psar[i] = high[i - 2];
                        }
                    }
                }

                if (bull)
                {
                    psarbull[i] = psar[i];
                }
                else
                {
                    psarbear[i] = psar[i];
                }
            }
            List<int>[] result = { psar, psarbull, psarbear };
            return result;
        }
        /* RSI
         *      U = 현재가격이 전일가격보다 상승할때의 폭
         *      D = 현재가격이 전일가격보다 하락할때의 폭
         *      
         *      AU = 일정 기간(14)동안의 U평균
         *      AD = 일정 기간(14)동안의 D평균
         *      
         *      RS = AU / AD
         *      RSI = RS / (1 + RS)
         *      
         *      RSI_signal = RSI의 6일 이동평균선
         *      
         *      단위 : %
         */
        List<int>[] RSI(DataTable data, int windowSize, int signalWindow)
        {
            List<int> list = new List<int>();
            List<int> upList = new List<int>();
            List<int> downList = new List<int>();
            List<int> rsiList = new List<int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Add(int.Parse(data.Rows[i]["close"].ToString()));
                if (i >= 1)
                {
                    if (int.Parse(data.Rows[i - 1]["close"].ToString()) > int.Parse(data.Rows[i]["close"].ToString()))
                    {
                        upList.Add(0);
                        downList.Add(int.Parse(data.Rows[i - 1]["close"].ToString()) - int.Parse(data.Rows[i]["close"].ToString()));
                    }
                    else if (int.Parse(data.Rows[i - 1]["close"].ToString()) < int.Parse(data.Rows[i]["close"].ToString()))
                    {
                        upList.Add(int.Parse(data.Rows[i]["close"].ToString()) - int.Parse(data.Rows[i - 1]["close"].ToString()));
                        downList.Add(0);
                    }
                    else
                    {
                        upList.Add(0);
                        downList.Add(0);
                    }
                }

                if (list.Count > windowSize + 1)
                {
                    upList.RemoveAt(0);
                    downList.RemoveAt(0);
                    list.RemoveAt(0);

                    float ad = (float)(downList.Average());
                    float au = (float)(upList.Average());
                    
                    float rsi;
                    if (ad != 0)
                    {
                        float rs = au / ad;
                        rsi = rs / (rs + 1) * 100;
                    }
                    else
                    {
                        rsi = 100;
                    }
                    
                    rsiList.Add((int)rsi);
                }
                else
                {
                    rsiList.Add(0);
                }
            }

            List<int> RSI_signal = SMA(rsiList, signalWindow);

            List<int>[] result = { rsiList, RSI_signal };
            return result;

        }
        /* RMI
         *      U = 현재가격이 N(20)일전 가격보다 상승할때의 폭
         *      D = 현재가격이 N(20)일전 가격보다 하락할때의 폭
         *      
         *      AU = 일정 기간(10)동안의 U평균
         *      AD = 일정 기간(10)동안의 D평균
         *      
         *      RM = AU / AD
         *      RMI = RM / (1 + RM)
         *      
         *      단위 : %
         */
        List<int> RMI(DataTable data, int prevWindow, int window)
        {
            List<int> list = new List<int>();
            List<int> upList = new List<int>();
            List<int> downList = new List<int>();
            List<int> rmiList = new List<int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Add(int.Parse(data.Rows[i]["close"].ToString()));
                if (i >= Math.Max(prevWindow, window))
                {
                    if (int.Parse(data.Rows[i - prevWindow]["close"].ToString()) > int.Parse(data.Rows[i]["close"].ToString()))
                    {
                        upList.Add(0);
                        downList.Add(int.Parse(data.Rows[i - prevWindow]["close"].ToString()) - int.Parse(data.Rows[i]["close"].ToString()));
                    }
                    else if (int.Parse(data.Rows[i - prevWindow]["close"].ToString()) < int.Parse(data.Rows[i]["close"].ToString()))
                    {
                        upList.Add(int.Parse(data.Rows[i]["close"].ToString()) - int.Parse(data.Rows[i - prevWindow]["close"].ToString()));
                        downList.Add(0);
                    }
                    else
                    {
                        upList.Add(0);
                        downList.Add(0);
                    }
                }

                if (list.Count > window)
                {
                    list.RemoveAt(0);

                    if (upList.Count > window)
                    {
                        upList.RemoveAt(0);
                        downList.RemoveAt(0);

                        float ad = (float)(downList.Average());
                        float au = (float)(upList.Average());

                        float rmi;
                        if (ad != 0)
                        {
                            float rm = au / ad;
                            rmi = rm / (rm + 1) * 100;
                        }
                        else
                        {
                            rmi = 100;
                        }

                        rmiList.Add((int)rmi);
                    }
                    else
                    {
                        rmiList.Add(0);
                    }
                }
                else
                {
                    rmiList.Add(0);
                }
            }

            return rmiList;
        }

        List<int>[] Stochastic(DataTable table, int windowSize, int slowWindowSize)
        {
            List<int> close = new List<int>(); //windowSize 만큼 크기를 갖는 리스트
            List<int> fastK = new List<int>();
            List<int> low = new List<int>();
            List<int> high = new List<int>();
            float r = 0;


            for (int i = 0; i < table.Rows.Count; i++) //list가 windowSize이상 크기를 가질때 가장 오래된 값 하나를 지움
            {
                close.Add(int.Parse(table.Rows[i]["close"].ToString()));
                low.Add(int.Parse(table.Rows[i]["low"].ToString()));
                high.Add(int.Parse(table.Rows[i]["high"].ToString()));

                if (close.Count >= windowSize)
                {
                    if (high.Max() != low.Min())
                    {
                        r = ((float)(close[4] - low.Min()) / (float)(high.Max() - low.Min())) * 100;
                        fastK.Add((int)r);
                    }
                    else if (high.Max() == low.Min() && close[4] - low.Min() > 0)
                        fastK.Add(100);
                    else
                        fastK.Add(0);

                    close.RemoveAt(0);
                    low.RemoveAt(0);
                    high.RemoveAt(0);//가장 오래된 값 하나 삭제

                }
                else
                {
                    fastK.Add(0); //windowSize에 미치지 못하는 데이터 삭제
                }
            }

            List<int> slowK = SMA(fastK, slowWindowSize);
            List<int> slowD = SMA(slowK, slowWindowSize);

            List<int>[] result = { fastK, slowK, slowD };

            return result; //현재 테이블의 이동평균 리스트 반환
        }

        public List<int> MFI(DataTable data, int windowSize)
        {
            List<int> BasePriceList = new List<int>();
            List<ulong> MoneyFlow = new List<ulong>();
            List<ulong> PositiveMoneyFlowList = new List<ulong>();
            List<ulong> NegativeMoneyFlowList = new List<ulong>();

            List<int> result = new List<int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                int high = int.Parse(data.Rows[i]["high"].ToString());
                int low = int.Parse(data.Rows[i]["low"].ToString());
                int close = int.Parse(data.Rows[i]["close"].ToString());
                int volume = int.Parse(data.Rows[i]["volume"].ToString());
                int BasePrice = (high + low + close) / 3;
                BasePriceList.Add(BasePrice);
                MoneyFlow.Add((ulong)BasePrice * (ulong)volume);
                
                if (i > 0)
                {
                    PositiveMoneyFlowList.Add(BasePriceList[i] >= BasePriceList[i - 1] ? (ulong)BasePrice * (ulong)volume : 0);
                    NegativeMoneyFlowList.Add(BasePriceList[i] <= BasePriceList[i - 1] ? (ulong)BasePrice * (ulong)volume : 0);
                }
                else
                {
                    PositiveMoneyFlowList.Add(0);
                    NegativeMoneyFlowList.Add(0);
                }
                
                if(MoneyFlow.Count > windowSize)
                {
                    MoneyFlow.RemoveAt(0);
                    PositiveMoneyFlowList.RemoveAt(0);
                    NegativeMoneyFlowList.RemoveAt(0);

                    ulong PositiveMoneyFlow = 0;
                    ulong NegativeMoneyFlow = 0;

                    for(int idx = 0; idx < windowSize; idx++)
                    {
                        PositiveMoneyFlow += PositiveMoneyFlowList[idx];
                        NegativeMoneyFlow += NegativeMoneyFlowList[idx];
                    }

                    decimal MoneyRatio;
                    if (NegativeMoneyFlow != 0) {
                        MoneyRatio = (decimal)PositiveMoneyFlow / (decimal)NegativeMoneyFlow;
                        result.Add((int)(100 - (100 / (1 + MoneyRatio)))); 
                    }
                    else
                    {
                        result.Add(100);
                    }
                        


                    
                }
                else
                {
                    result.Add(0);
                }
            }
            return result;
        }
    }
}
