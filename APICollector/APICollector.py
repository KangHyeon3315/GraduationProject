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

from PyQt5.QtWidgets import *

pd.set_option('display.max_columns', 100)                       # 출력할 열의 최대개수
pd.set_option('display.max_colwidth', 1000)                      # 출력할 열의 너비
pd.set_option('display.unicode.east_asian_width', True)        # 유니코드 사용 너비 조정


class Collector:
    def __init__(self):
        self.net = Network("APICollector")
        self.api = OpenApi(self.net)
        self.DB = DataBase()

        self.open_time = "0840"
        self.close_time = "1535"

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
        self.net.Log("CompanyInfoUpdate")

        # th = threading.Thread(target=self.CheckRqCount)
        # th.start()

        self.net.Requests("RequestsInterval")
        while True:
            if len(self.net.receiveQueue) > 0:
                if self.net.receiveQueue[0].split(";")[0] == "RequestsInterval":
                    self.api.TR_REQ_TIME_INTERVAL = float(self.net.receiveQueue[0].split(";")[1])
                    break
                else:
                    self.net.receiveQueue.append(self.net.receiveQueue[0])
                    self.net.receiveQueue = self.net.receiveQueue[1:]
        self.net.Log("Settings Requests Interval : {}".format(self.api.TR_REQ_TIME_INTERVAL))

        try:
            self.DailyChartCollecting()
        except:
            self.net.Log(traceback.format_exc())

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

        if not self.DB.IsSchemaExists("daily_chart_data"):
            self.DB.CreateSchema("daily_chart_data")

        count = 0
        for i in range(len(self.df_code)):
            code = self.df_code.loc[i, "code"]
            name = self.df_code.loc[i, "name"]
            count += 1

            if self.df_code.loc[self.df_code["code"] == code, "daily_collecting"].iloc[0] >= self.today:
                continue

            self.net.Company(name)
            self.net.Log("{} 일봉차트 수집".format(name))
            self.net.CompleteCount(count)

            # DB의 최신 데이터 가져오기기
            if self.DB.IsTableExists("daily_chart_data", name):
                LatestData = self.DB.GetLatestData("daily_chart_data", name)

                date = LatestData["date"]
            else:
                LatestData = None
                date = "0"

            self.net.Log("chart Collecting")
            chart_data = self.api.GetDailyData(code=code, date=date)

            self.net.Log("투자자 매수 수량")
            investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date=date)

            self.net.Log("투자자 매도 수량")
            investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date=date)

            result = pd.merge(chart_data, investor_infomation_buy_volume)
            result = pd.merge(result, investor_infomation_sell_volume)

            # 무결성 체크
            if LatestData is not None and result.loc[result["date"] == date, "close"].iloc[0] != LatestData["close"]:
                self.net.Log("Data is Not Equal")
                # 데이터 삭제
                self.net.Log("Drop Table")
                self.DB.DropTable("daily_chart_data", name)

                self.net.Log("chart Collecting")
                chart_data = self.api.GetDailyData(code=code, date="0")
                self.net.Log("투자자 매수 수량")
                investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date="0")
                self.net.Log("투자자 매도 수량")
                investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date="0")

                result = pd.merge(chart_data, investor_infomation_buy_volume)
                result = pd.merge(result, investor_infomation_sell_volume)

            result = result.loc[result["date"] != date]
            result = result.loc[result["date"] <= self.today]

            # DB 업로드
            self.DB.UpdateTable("daily_chart_data", name, result)
            self.DB.SetScheduleInfo(code, "daily_collecting", self.today)
            self.net.Log("Complete {}".format(name))
            # break

    def MinChartCollecting(self):

        self.df_code = self.DB.GetCompanyInfoTotalTable()
        self.net.Work("Min Chart Collecting")
        self.net.Log("Min Collecting Start")
        self.net.CompanyCount(len(self.df_code))

        if not self.DB.IsSchemaExists("min_chart_data"):
            self.DB.CreateSchema("min_chart_data")

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
            if self.DB.IsTableExists("min_chart_data", name):
                LatestData = self.DB.GetLatestData("min_chart_data", name)

                date = LatestData["date"]
            else:
                LatestData = None
                date = "0"

            self.net.Log("chart collecting")
            chart_data = self.api.GetDailyData(code=code, date=date)
            self.net.Log("투자자 매수 수량")
            investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date=date)
            self.net.Log("투자자 매도 수량")
            investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date=date)

            result = pd.merge(chart_data, investor_infomation_buy_volume)
            result = pd.merge(result, investor_infomation_sell_volume)

            # 무결성 체크
            if LatestData is not None and result.loc[result["date"] == date, "close"].iloc[0] != LatestData["close"]:
                self.net.Log("Data is Not Equal")
                # 데이터 삭제
                self.DB.DropTable("daily_chart_data", name)

                chart_data = self.api.GetDailyData(code=code, date="0")
                investor_infomation_buy_volume = self.api.GetInvestorBuyVolume(code=code, date="0")
                investor_infomation_sell_volume = self.api.GetInvestorSellVolume(code=code, date="0")

                result = pd.merge(chart_data, investor_infomation_buy_volume)
                result = pd.merge(result, investor_infomation_sell_volume)

            result = result.loc[result["date"] != date]

            # DB 업로드
            self.DB.UpdateTable("min_chart_data", name, result)
            self.DB.SetScheduleInfo(code, "min_collecting", self.today)
            self.net.Log("Complete {}".format(name))
            # break

if __name__ == "__main__":
    app = QApplication(sys.argv)

    collector = Collector()

    app.exec_()
