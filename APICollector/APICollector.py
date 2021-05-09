from API import OpenApi
from DB import DataBase
from Network import Network
from DartCollector import Statement

import os
import sys
import time
import psutil
import threading
import datetime
import traceback
import numpy as np
import pandas as pd

from pykrx import stock
from PyQt5.QtWidgets import *

class Collector:
    def __init__(self):
        self.net = Network("APICollector")

        self.net.Company("None")
        self.net.CompleteCount(0)
        self.net.CompanyCount(0)

        DBIP = sys.argv[2]
        DBPort = int(sys.argv[3])
        DBID = sys.argv[4]
        DBPW = sys.argv[5]
        self.DB = DataBase(DBIP, DBPort, DBID, DBPW)


        self.api = OpenApi(self.net)

        # DBInfo = self.net.Requests("DBInfo").split(";")
        # self.net.receiveQueue.clear()
        # self.net.Log("Settings DB info")

        # DBIP = DBInfo[1]
        # DBPort = int(DBInfo[2])
        # DBID = DBInfo[3]
        # DBPW = DBInfo[4]



        self.open_time = "0840"
        self.close_time = "1535"
        # self.close_time = "2035"

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            self.today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            self.today = datetime.datetime.today().strftime("%Y%m%d")

        self.df_code_kospi = pd.DataFrame()
        self.df_code_kosdaq = pd.DataFrame()
        self.df_code_konex = pd.DataFrame()

        self.get_kospi_code()
        self.get_kosdaq_code()
        self.get_konex_code()

        self.df_code = self.df_code_kospi
        self.df_code = self.df_code.append(self.df_code_kosdaq).reset_index(drop=True)
        self.df_code = self.df_code.append(self.df_code_konex).reset_index(drop=True)

        self.company_info_update()
        self.net.Debug("CompanyInfoUpdate")

        # th = threading.Thread(target=self.CheckRqCount)
        # th.start()

        # interval = float(self.net.Requests("RequestsInterval").split(';')[1])
        interval = float(sys.argv[1])
        self.api.TR_REQ_TIME_INTERVAL = interval
        self.net.Debug("Settings Requests Interval : {}".format(self.api.TR_REQ_TIME_INTERVAL))

        try:
            self.DailyChartCollecting()
        except:
            self.net.Exception(traceback.format_exc())

        self.net.Send("Complete")
        sys.exit(0)

    def get_kospi_code(self):
        df_code_kospi = pd.read_html('http://kind.krx.co.kr/corpgeneral/corpList.do?method=download&searchType=13&marketType=stockMkt', header=0)[0]
        df_code_kospi.loc[:, "종목코드"] = df_code_kospi.종목코드.map('{:06d}'.format)
        df_code_kospi = df_code_kospi[['회사명', '종목코드', '업종']]
        self.df_code_kospi = df_code_kospi.rename(columns={'회사명': 'name', '종목코드': 'code', '업종': 'industries'})
        for idx in range(len(self.df_code_kospi)):
            self.df_code_kospi.loc[idx, 'name'] = self.df_code_kospi.loc[idx, 'name'].lower()
        self.df_code_kospi['category'] = "KOSPI"

    def get_kosdaq_code(self):
        df_code_kosdaq = pd.read_html('http://kind.krx.co.kr/corpgeneral/corpList.do?method=download&searchType=13&marketType=kosdaqMkt', header=0)[0]
        df_code_kosdaq.loc[:, "종목코드"] = df_code_kosdaq.종목코드.map('{:06d}'.format)
        df_code_kosdaq = df_code_kosdaq[['회사명', '종목코드', '업종']]
        self.df_code_kosdaq = df_code_kosdaq.rename(columns={'회사명': 'name', '종목코드': 'code', '업종': 'industries'})
        for idx in range(len(self.df_code_kosdaq)):
            self.df_code_kosdaq.loc[idx, 'name'] = self.df_code_kosdaq.loc[idx, 'name'].lower()
        self.df_code_kosdaq['category'] = "KOSDAQ"

    def get_konex_code(self):
        df_code_konex = pd.read_html('http://kind.krx.co.kr/corpgeneral/corpList.do?method=download&searchType=13&marketType=konexMkt', header=0)[0]
        df_code_konex.loc[:, "종목코드"] = df_code_konex.종목코드.map('{:06d}'.format)
        df_code_konex = df_code_konex[['회사명', '종목코드', '업종']]
        self.df_code_konex = df_code_konex.rename(columns={'회사명': 'name', '종목코드': 'code', '업종': 'industries'})
        for idx in range(len(self.df_code_konex)):
            self.df_code_konex.loc[idx, 'name'] = self.df_code_konex.loc[idx, 'name'].lower()
        self.df_code_konex['category'] = "KONEX"

    def company_info_update(self):
        if not self.DB.IsTableExists("collector", "company_info"):
            self.df_code["daily_collecting"] = "0"
            self.df_code["min_collecting"] = "0"
            self.df_code["indicator"] = "0"
            self.df_code["reprocessing"] = "0"
            self.df_code["financial_statement"] = "0"

            self.DB.UpdateTable("collector", "company_info", self.df_code)
        else:
            update_data = {'code': [], 'name': [], 'category': [], 'industries': []}
            for i in range(len(self.df_code)):
                code = self.df_code.loc[i, "code"]
                name = self.df_code.loc[i, "name"]
                category = self.df_code.loc[i, "category"]
                industries = self.df_code.loc[i, "industries"]

                if not self.DB.IsDataExists("collector", "company_info", "code='{}'".format(code)):
                    update_data['code'].append(code)
                    update_data['name'].append(name)
                    update_data['category'].append(category)
                    update_data['industries'].append(industries)
            update_data = pd.DataFrame(update_data, columns=["code", "name", "category", "industries"])

            update_data["daily_collecting"] = "0"
            update_data["min_collecting"] = "0"
            update_data["indicator"] = "0"
            update_data["reprocessing"] = "0"
            update_data["financial_statement"] = "0"

            self.DB.UpdateTable("collector", "company_info", update_data)

    def DailyChartCollecting(self):
        self.df_code = self.DB.GetCompanyInfoTotalTable()
        self.net.Work("Daily Chart Collecting")
        self.net.Log("Daily Collecting Start")
        self.net.CompanyCount(len(self.df_code))

        if not self.DB.IsSchemaExists("daily_chart"):
            self.DB.CreateSchema("daily_chart")

        count = 0
        for i in range(len(self.df_code)):
            code = self.df_code.loc[i, "code"]
            name = self.df_code.loc[i, "name"]
            count += 1


            if self.df_code.loc[self.df_code["code"] == code, "daily_collecting"].iloc[0] >= self.today:
                continue

            self.net.CompleteCount(count)
            self.net.Company(name)
            self.net.Log("{} 일봉차트 수집".format(name))


            # DB의 최신 데이터 가져오기기
            if self.DB.IsTableExists("daily_chart", name):
                LatestData = self.DB.GetLatestData("daily_chart", name)

                date = LatestData["date"]
            else:
                LatestData = None
                date = "0"

            self.net.Log("일봉 차트 조회")
            chart_data = self.api.GetDailyData(code=code, date=date)

            # start_date = chart_data.loc[0, "date"]
            # end_date = chart_data.loc[len(chart_data) - 1, "date"]

            # self.net.Log("일자별 DIV/BPS/PER/EPS 조회")
            # data = stock.get_market_fundamental_by_date(start_date, end_date, code).reset_index()
            # data = data.rename(columns={"날짜": "date"})

            # if not data.empty:
            #    self.net.Log("data is empty")
            #    data["date"] = data["date"].astype(str).str.replace("-", "")
            # else:
            #    data = pd.DataFrame(columns=data.columns, index=range(len(chart_data))).fillna(0)
            #    data["date"] = chart_data["date"]
            # result = pd.merge(chart_data, data)
            result = chart_data

            if len(result) == 0:
                self.net.Log("조회된 데이터가 없습니다.")
                self.DB.SetScheduleInfo(code, "daily_collecting", self.today)
                self.net.Log("{} 수집 완료".format(name))
                continue

            self.net.Log("투자자 매수 수량 조회")
            investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date=date)

            for column in investor_infomation_buy_volume.columns[1:]:
                investor_infomation_buy_volume[column] = investor_infomation_buy_volume[column].astype(int).abs()

            self.net.Log("투자자 매도 수량 조회")
            investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date=date)

            for column in investor_infomation_sell_volume.columns[1:]:
                investor_infomation_sell_volume[column] = investor_infomation_sell_volume[column].astype(int).abs()

            result = pd.merge(result, investor_infomation_buy_volume)
            result = pd.merge(result, investor_infomation_sell_volume)

            # 무결성 체크
            if LatestData is not None and result.loc[result["date"] == date, "close"].iloc[0] != LatestData["close"]:
                self.net.Log("Data is Not Equal")
                # 데이터 삭제
                self.net.Log("Drop Table")
                self.DB.DropTable("daily_chart", name)
                self.DB.DropTable("indicator", name)
                self.DB.SetScheduleInfo(code, "reprocessing", "Rewrite")
                self.net.Log("chart Collecting")
                chart_data = self.api.GetDailyData(code=code, date="0")

                # start_date = chart_data.loc[0, "date"]
                # end_date = chart_data.loc[len(chart_data) - 1, "date"]

                # self.net.Log("일자별 DIV/BPS/PER/EPS 조회")
                # data = stock.get_market_fundamental_by_date(start_date, end_date, code).reset_index()

                # data = data.rename(columns={"날짜": "date"})

                # if not data.empty:
                #     self.net.Log("data is empty")
                #     data["date"] = data["date"].astype(str).str.replace("-", "")
                # else:
                #     data = pd.DataFrame(columns=data.columns, index=range(len(chart_data))).fillna(0)
                #     data["date"] = chart_data["date"]

                # result = pd.merge(chart_data, data)
                result = chart_data

                self.net.Log("투자자 매수 수량 조회")
                investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date="0")

                for column in investor_infomation_buy_volume.columns[1:]:
                    investor_infomation_buy_volume[column] = investor_infomation_buy_volume[column].astype(int).abs()

                self.net.Log("투자자 매도 수량 조회")
                investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date="0")

                for column in investor_infomation_sell_volume.columns[1:]:
                    investor_infomation_sell_volume[column] = investor_infomation_sell_volume[column].astype(int).abs()

                result = pd.merge(result, investor_infomation_buy_volume)
                result = pd.merge(result, investor_infomation_sell_volume)

            start_date = result.loc[0, "date"]
            end_date = result.loc[len(result) - 1, "date"]

            try:
                self.net.Log("기관별 순매수 금액 조회")
                data = stock.get_market_trading_value_by_date(start_date, end_date, code, detail=True).reset_index()
                data = data.iloc[:, :-1]
                data = data.rename(columns={"날짜": "date"})
                data["date"] = data["date"].astype(str).str.replace("-", "")
                for column in data.columns[1:]:
                    data = data.rename(columns={column: "{}_순매수금액".format(column)})

                result = pd.merge(result, data)
                time.sleep(1)

                self.net.Log("기관별 매수 금액 조회")
                data = stock.get_market_trading_value_by_date(start_date, end_date, code, on="매수", detail=True).reset_index()
                data = data.iloc[:, :-1]
                data = data.rename(columns={"날짜": "date"})
                data["date"] = data["date"].astype(str).str.replace("-", "")
                for column in data.columns[1:]:
                    data = data.rename(columns={column: "{}_매수금액".format(column)})

                result = pd.merge(result, data)
                time.sleep(1)

                self.net.Log("기관별 매도 금액 조회")
                data = stock.get_market_trading_value_by_date(start_date, end_date, code, on="매도", detail=True).reset_index()
                data = data.iloc[:, :-1]
                data = data.rename(columns={"날짜": "date"})
                data["date"] = data["date"].astype(str).str.replace("-", "")
                for column in data.columns[1:]:
                    data = data.rename(columns={column: "{}_매도금액".format(column)})

                result = pd.merge(result, data)

                result = result.loc[result["date"] != date]
                result = result.loc[result["date"] <= self.today]
                result = result.reset_index(drop=True)

            except Exception as ex:
                self.net.Exception(ex)
                continue

            # DB 업로드
            self.DB.UpdateTable("daily_chart", name, result)
            self.DB.SetScheduleInfo(code, "daily_collecting", self.today)
            self.net.Log("{} 수집 완료".format(name))
            # break
        self.net.CompleteCount(count)

    def MinChartCollecting(self):

        self.df_code = self.DB.GetCompanyInfoTotalTable()
        self.net.Work("Min Chart Collecting")
        self.net.Log("Min Collecting Start")
        self.net.CompanyCount(len(self.df_code))

        if not self.DB.IsSchemaExists("min_chart"):
            self.DB.CreateSchema("min_chart")

        count = 0

        for i in range(len(self.df_code)):
            code = self.df_code.loc[i, "code"]
            name = self.df_code.loc[i, "name"]
            count += 1

            if self.df_code.loc[self.df_code["code"] == code, "min_collecting"].iloc[0] >= self.today:
                continue

            self.net.Company(name)
            self.net.Log("{} 분봉차트 수집".format(name))
            self.net.CompleteCount(count)

            # DB의 최신 데이터 가져오기기
            if self.DB.IsTableExists("min_chart", name):
                LatestData = self.DB.GetLatestData("min_chart", name)

                date = LatestData["date"]
            else:
                LatestData = None
                date = "0"

            self.net.Log("chart collecting")
            result = self.api.GetMinData(code=code, date=date)

            # 무결성 체크
            if LatestData is not None and result.loc[result["date"] == date, "close"].iloc[0] != LatestData["close"]:

                self.net.Log("Data is Not Equal")

                adjust_ratio = result.loc[result["date"] == date, "close"].iloc[0] / LatestData["close"]
                volume_ratio = result.loc[result["date"] == date, "volume"].iloc[0] / LatestData["volume"]

                data = self.DB.GetTotalTable(schema="min_chart", table=name)
                data["open"] = (data["open"] * adjust_ratio).astype(int)
                data["high"] = (data["high"] * adjust_ratio).astype(int)
                data["low"] = (data["low"] * adjust_ratio).astype(int)
                data["close"] = (data["close"] * adjust_ratio).astype(int)
                data["volume"] = (data["volume"] * volume_ratio).astype(int)
                self.DB.DropTable(schema="min_chart", table=name)
                self.DB.UpdateTable("min_chart", name, data)

                result = self.api.GetDailyData(code=code, date="0")

            result = result.loc[result["date"] != date]

            # DB 업로드
            self.DB.UpdateTable("min_chart", name, result)
            self.DB.SetScheduleInfo(code, "min_collecting", self.today)
            self.net.Log("Complete {}".format(name))
            # break

if __name__ == "__main__":
    app = QApplication(sys.argv)

    collector = Collector()

    app.exec_()
