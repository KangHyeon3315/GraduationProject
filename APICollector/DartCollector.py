import sys
import time
import numpy as np
import traceback
import datetime
import pandas as pd
import dart_fss as dart
from dart_fss.errors import NoDataReceived
from pykrx import stock

from DB import DataBase
from Network import Network

"""
Report Date 수정하기
    우선 저장할 때 -> 수신받은 데이터에서 year & month를 가져와서 저장
    
    유무 파악하기 -> year와 보고서 타입으로 분류
"""

class Statement:
    def __init__(self):
        self.net = Network("DartCollector")
        # self.net.Requests("Reset")

        self.today = datetime.datetime.today().strftime("%Y%m%d")
        self.month = datetime.datetime.today().strftime("%Y%m")

        # DBInfo = self.net.Requests("DBInfo").split(";")
        # self.net.receiveQueue.clear()
        # self.net.Log("Settings DB info")

        # DBIP = DBInfo[1]
        # DBPort = int(DBInfo[2])
        # DBID = DBInfo[3]
        # DBPW = DBInfo[4]

        DBIP = sys.argv[2]
        DBPort = int(sys.argv[3])
        DBID = sys.argv[4]
        DBPW = sys.argv[5]

        self.net.Debug("DB info Setting")
        self.DB = DataBase(DBIP, DBPort, DBID, DBPW)

        self.corp_info = self.DB.GetCompanyInfoTotalTable()
        self.RqCount = 0

        self.net.Work("Financial Statement Collecting")
        self.net.Company("None")
        self.net.RqCount(self.RqCount)
        self.net.CompleteCount(0)
        self.net.CompanyCount(len(self.corp_info))

        # 이번달에 전부 최신화 했으므로 pass
        if self.corp_info.loc[self.corp_info["financial_statement"] < self.month].empty:
            return

        # API_Key = self.net.Requests("RequestsDartKey").split(';')[1]

        API_Key = sys.argv[1]

        self.net.receiveQueue.clear()
        self.net.Debug("Settings Dart API Key")

        dart.set_api_key(API_Key)

        self.net.Log("재무제표 데이터 수집 시작")
        self.corp_list = dart.get_corp_list()
        self.empty_list = []

        try:
            self.get_financial_statement()
        except:
            self.net.Exception(traceback.format_exc())


    def get_financial_statement(self):
        for idx in range(len(self.corp_info)):
            code = self.corp_info.loc[idx, "code"]
            name = self.corp_info.loc[idx, "name"]

            info = self.corp_list.find_by_stock_code(code)

            self.empty_list = []

            if info:
                corp_code = info.to_dict()['corp_code']
            else:
                self.net.Debug("corp_class data not queried")
                continue

            # if self.corp_info.loc[idx, "financial_statement"] == "0":

            if str(self.corp_info.loc[idx, "financial_statement"]) == str(self.month):
                continue
            else:
                year_range = range(2015, datetime.date.today().year + 1)
                # year_range = range(int(self.corp_info.loc[idx, "financial_statement"][:4]), datetime.date.today().year)

            self.net.Company(name)
            self.net.Log("{} 재무재표 데이터 수집".format(name))

            result = None
            for year in year_range:
                for reprt_code in ["11013", "11012", "11014", "11011"]:
                    if reprt_code == "11013":
                        reprt_type = "1분기"
                        report_date = "{}0515".format(year)
                    elif reprt_code == "11012":
                        reprt_type = "2분기"
                        report_date = "{}0815".format(year)
                    elif reprt_code == "11014":
                        reprt_type = "3분기"
                        report_date = "{}1115".format(year)
                    else:
                        reprt_type = "사업"
                        report_date = "{}0331".format(year + 1)
                        
                    # 오늘 날짜가 해당 report를 공시하기 전인경우 continue

                    if report_date > self.today:
                        continue

                    if self.DB.IsTableExists("financial_statement", name) and self.DB.IsDataExists("financial_statement",name, "report_date='{}' and code='{}'".format(report_date, code)):
                        self.net.Debug("Report Date : {} is already Exists".format(report_date))
                        continue

                    try:
                        # dart.api.finance.get_single_corp(corp_code: str, bsns_year: str, reprt_code: str)
                        # corp_code: corp_code(종목코드가 아님, 공시대상회사의 고유번호(8자리)),
                        # bsns_year: 연도를(사업연도(4자리))
                        # reprt_code: 1분기보고서 : 11013, 반기보고서 : 11012, 3분기보고서 : 11014, 사업보고서 : 11011
                        self.RqCount += 1
                        self.net.RqCount(self.RqCount)
                        res = dart.api.finance.get_single_corp(corp_code, str(year), reprt_code)

                    except NoDataReceived as e:
                        self.net.Debug("[{}] {} year data not queried".format(reprt_type, year))

                        self.empty_list.append((code, name, reprt_type, report_date))
                        continue

                    df = pd.DataFrame(res['list'])

                    # 콤마 제거
                    # 당해 연도
                    for column in df.columns:
                        df[column] = df[column].str.replace(',', '')
                        df.loc[df[column] == '-', column] = None

                    # stock_code 라는 컬럼명을 code로 변경
                    df = df.rename(columns={'stock_code': 'code'})

                    # 데이터프레임에 코드명 컬럼이 없어서 새롭게 생성
                    df['code_name'] = name
                    df['reprt_type'] = reprt_type

                    if result is None:
                        result = df
                    else:
                        result = result.append(df)

            if result is not None and len(result) > 0:
                result = self.processing(result)
                
                self.DB.UpdateTable("financial_statement", name, result)
            self.DB.SetScheduleInfo(code, "financial_statement", self.month)
            self.net.CompleteCount(idx + 1)

        self.net.Send("Complete")
        self.net.sock.close()

    def processing(self, data):
        # print(data)
        self.net.Debug("Processing Table Data")
        result = {'report_date': [], 'report_type': [], 'type': [], 'start_date': [], 'end_date': [], 'name': [],
                  'code': [], '유동자산': [], '비유동자산': [], '자산총계': [],
                  '유동부채': [], '비유동부채': [], '부채총계': [], '이익잉여금': [], '자본총계': [], '매출액': [], '영업이익': [], '법인세차감전순이익': [],
                  '당기순이익': [], '주식수': [], '시가총액': []}

        krx = stock.get_market_cap_by_date("20000101", self.today, "155660", "y").reset_index()
        krx["날짜"] = krx["날짜"].astype(str)

        for report_date in data['rcept_no'].drop_duplicates():

            for rept_type in ["연결재무제표", "재무제표"]:
                tmp = data.loc[(data['rcept_no'] == report_date) & (data['fs_nm'] == rept_type)].reset_index(drop=True)
                tmp = tmp.fillna('None')

                if tmp.empty:
                    continue

                for columns in [('thstrm_dt', 'thstrm_amount'), ('frmtrm_dt', 'frmtrm_amount'),
                                ('bfefrmtrm_dt', 'bfefrmtrm_amount')]:

                    if tmp.loc[0, columns[1]] == 'None':
                        continue

                    result['report_type'].append(tmp.loc[0, 'reprt_type'])
                    result['type'].append(tmp.loc[0, 'fs_nm'])
                    result['name'].append(tmp.loc[0, 'code_name'])
                    result['code'].append(tmp.loc[0, 'code'])

                    end_date = str(tmp.loc[0, columns[0]]).replace(" 현재", "").replace(".", "")
                    start_date = "{}0101".format(end_date[:4])

                    result['start_date'].append(start_date)
                    result['end_date'].append(end_date)

                    for data_name in ['유동자산', '비유동자산', '자산총계', '유동부채', '비유동부채', '부채총계', '이익잉여금', '자본총계', '매출액', '영업이익', '법인세차감전순이익', '당기순이익']:
                        if not tmp.loc[tmp["account_nm"] == data_name, columns[1]].empty:
                            result[data_name].append(tmp.loc[tmp["account_nm"] == data_name, columns[1]].iloc[0])
                        else:
                            result[data_name].append(0)

                    # 사업
                    if end_date[4:6] == "12":
                        rept_date = "{}0331".format(int(end_date[:4]) + 1)
                    # 1분기
                    elif end_date[4:6] == "03":
                        rept_date = "{}0515".format(int(end_date[:4]))
                    # 2분기
                    elif end_date[4:6] == "06":
                        rept_date = "{}0815".format(int(end_date[:4]))
                    # 3분기
                    else:  # end_date[4:6] == "09":
                        rept_date = "{}1115".format(int(end_date[:4]))

                    result['report_date'].append(rept_date)  # 나중에 50기까지 수정하기

                    if tmp.loc[0, 'reprt_type'] == "사업":
                        result['주식수'].append(krx.loc[krx["날짜"].str[:4] == end_date[:4], "상장주식수"].iloc[0])
                        result['시가총액'].append(krx.loc[krx["날짜"].str[:4] == end_date[:4], "시가총액"].iloc[0])
                    else:
                        result['주식수'].append(krx.loc[krx["날짜"].str[:4] == str(int(end_date[:4]) - 1), "상장주식수"].iloc[0])
                        result['시가총액'].append(krx.loc[krx["날짜"].str[:4] == str(int(end_date[:4]) - 1), "시가총액"].iloc[0])

        for code, name, reprt_type, report_date in self.empty_list:
            result['code'].append(code)
            result['name'].append(name)
            result['report_type'].append(reprt_type)
            result['report_date'].append(report_date)
            result['type'].append('0')
            result['start_date'].append('0')
            result['end_date'].append('0')
            result['유동자산'].append('0')
            result['비유동자산'].append('0')
            result['자산총계'].append('0')
            result['유동부채'].append('0')
            result['비유동부채'].append('0')
            result['부채총계'].append('0')
            result['이익잉여금'].append('0')
            result['자본총계'].append('0')
            result['매출액'].append('0')
            result['영업이익'].append('0')
            result['법인세차감전순이익'].append('0')
            result['당기순이익'].append('0')
            result['주식수'].append('0')
            result['시가총액'].append('0')

        result = pd.DataFrame(result).astype(str)
        result = result.drop_duplicates(["type", "report_date"])
        result = result.sort_values(by="report_date")

        return result

if __name__ == "__main__":
    statement = Statement()

