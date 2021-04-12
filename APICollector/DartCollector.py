import sys
import time
import numpy as np
import datetime
import pandas as pd
import dart_fss as dart
from dart_fss.errors import NoDataReceived
from pykrx import stock

from DB import DataBase
from Network import Network


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

        self.DB = DataBase(DBIP, DBPort, DBID, DBPW)

        self.corp_info = self.DB.GetCompanyInfoTotalTable()

        # 이번달에 전부 최신화 했으므로 pass
        if self.corp_info.loc[self.corp_info["financial_statement"] < self.month].empty:
            return

        # API_Key = self.net.Requests("RequestsDartKey").split(';')[1]

        API_Key = sys.argv[1]

        self.net.receiveQueue.clear()
        self.net.Log("Settings Requests Dart API Key")

        dart.set_api_key(API_Key)

        self.net.Log("Collect Start Financial Statement")
        self.corp_list = dart.get_corp_list()

        self.get_financial_statement()

    def get_financial_statement(self):
        for idx in range(len(self.corp_info)):
            code = self.corp_info.loc[idx, "code"]
            name = self.corp_info.loc[idx, "name"]
            info = self.corp_list.find_by_stock_code(code)

            if info:
                corp_code = info.to_dict()['corp_code']
            else:
                self.net.Log("corp_class data not queried")
                continue

            if self.corp_info.loc[idx, "financial_statement"] == "0":
                year_range = range(2015, datetime.date.today().year)
            elif self.corp_info.loc[idx, "financial_statement"] == self.month:
                continue
            else:
                year_range = [datetime.date.today().year - 1]

            self.net.Company(name)
            self.net.Log("Parsing Financial Statement Data [{}/{}]".format(idx + 1, len(self.corp_info)))

            result = None
            for year in year_range:
                for reprt_code in ["11013", "11012", "11014", "11011"]:
                    if reprt_code == "11013":
                        reprt_type = "1분기"
                    elif reprt_code == "11012":
                        reprt_type = "2분기"
                    elif reprt_code == "11014":
                        reprt_type = "3분기"
                    else:
                        reprt_type = "사업"

                    try:
                        # dart.api.finance.get_single_corp(corp_code: str, bsns_year: str, reprt_code: str)
                        # corp_code: corp_code(종목코드가 아님, 공시대상회사의 고유번호(8자리)),
                        # bsns_year: 연도를(사업연도(4자리))
                        # reprt_code: 1분기보고서 : 11013, 반기보고서 : 11012, 3분기보고서 : 11014, 사업보고서 : 11011
                        res = dart.api.finance.get_single_corp(corp_code, str(year), reprt_code)

                    except NoDataReceived as e:
                        self.net.Log("[{}] {} year data not queried".format(reprt_type, year))
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

            result = self.processing(result)

            self.DB.UpdateTable("collector", "financial_statement", result)
            self.DB.SetScheduleInfo(code, "financial_statement", self.month)

            self.net.CompleteCount(idx + 1)

        self.net.Send("Complete")

    def processing(self, data):
        self.net.Log("Processing Table Data")
        result = {'report_date': [], 'report_type': [], 'type': [], 'start_date': [], 'end_date': [], 'name': [],
                  'code': [], '유동자산': [], '비유동자산': [], '자산총계': [],
                  '유동부채': [], '비유동부채': [], '부채총계': [], '이익잉여금': [], '자본총계': [], '매출액': [], '영업이익': [], '법인세차감전순이익': [],
                  '당기순이익': [], '주식수': [], '시가총액': []} # 'EPS': [], 'PER': [], '주당순자산': [], 'PBR': [], 'ROE': [], '순이익률': []}

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

                    if end_date[4:6] == "12":
                        rept_date = "{}0331".format(int(end_date[:4]) + 1)
                    elif end_date[4:6] == "03":
                        rept_date = "{}0515".format(int(end_date[:4]) + 1)
                    elif end_date[4:6] == "06":
                        rept_date = "{}0815".format(int(end_date[:4]) + 1)
                    else:  # end_date[4:6] == "09":
                        rept_date = "{}1115".format(int(end_date[:4]) + 1)
                    result['report_date'].append(rept_date)  # 나중에 50기까지 수정하기

                    if tmp.loc[0, 'reprt_type'] == "사업":
                        result['주식수'].append(krx.loc[krx["날짜"].str[:4] == end_date[:4], "상장주식수"].iloc[0])
                        result['시가총액'].append(krx.loc[krx["날짜"].str[:4] == end_date[:4], "시가총액"].iloc[0])
                    else:
                        result['주식수'].append(krx.loc[krx["날짜"].str[:4] == str(int(end_date[:4]) - 1), "상장주식수"].iloc[0])
                        result['시가총액'].append(krx.loc[krx["날짜"].str[:4] == str(int(end_date[:4]) - 1), "시가총액"].iloc[0])
                    # result['EPS'].append(0)
                    # result['PER'].append(0)
                    # result['주당순자산'].append(0)
                    # result['PBR'].append(0)
                    # result['ROE'].append(0)
                    # result['순이익률'].append(0)

        result = pd.DataFrame(result)
        result = result.drop_duplicates(["type", "end_date"])
        result = result.sort_values(by="end_date")

        return result

if __name__ == "__main__":
    statement = Statement()

