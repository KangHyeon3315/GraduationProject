import sys
import time
import datetime
import pandas as pd
from PyQt5.QtWidgets import *
from PyQt5.QAxContainer import *
from PyQt5.QtCore import *

pd.set_option('display.max_columns', 50)                       # 출력할 열의 최대개수
pd.set_option('display.max_colwidth', 100)                      # 출력할 열의 너비
pd.set_option('display.unicode.east_asian_width', True)        # 유니코드 사용 너비 조정


class OpenApi(QAxWidget):
    def __init__(self, net):
        super().__init__()
        self.net = net

        self.open_time = "0840"
        self.close_time = "1535"

        self.last_date = "0"

        # 기본 API관련 변수들
        self.TR_REQ_TIME_INTERVAL = 0.4
        self.rq_count = 0
        self.login_event_loop = None
        self.tr_event_loop = None
        self.remained_data = True

        # 계좌 정보
        self.account_number = None

        # 데이터 저장 변수
        self.ohlcv = None
        self.investor_buy_price = None
        self.investor_buy_volume = None
        self.investor_sell_price = None
        self.investor_sell_volume = None

        # Kiwoom Connect and Login
        self._create_open_api_instance()
        self._set_signal_slots()
        self.comm_connect()
        self.account_info()

    # ############################################### API 필수 기능 ###############################################
    def _create_open_api_instance(self):
        # Open API 실행
        try:
            self.setControl("KHOPENAPI.KHOpenAPICtrl.1")
        except Exception as e:
            self.net.Exception(e)

    def _set_signal_slots(self):
        # 이벤트 연결
        try:
            self.OnEventConnect.connect(self._event_connect)
            self.OnReceiveTrData.connect(self._receive_tr_data)
            self.OnReceiveMsg.connect(self._receive_msg)

        except Exception as e:
            env_is_64bits = sys.maxsize > 2 ** 32
            if env_is_64bits:
                self.net.Exception("Current Anaconda is 64bit. Run in a 32bit env")
            else:
                self.net.Exception(e)

    def _event_connect(self, err_code):
        # 접속 성공여부 확인
        try:
            if err_code == 0:
                self.net.Log("API connected")
            else:
                self.net.Exception(f"disconnected. err_code : {err_code}")
                sys.exit()
            self.login_event_loop.exit()
        except Exception as e:
            self.net.Exception(e)

    def _receive_msg(self, sscrno, srqname, strcode, smsg):
        print(smsg)

    def comm_connect(self):
        # API 접속
        try:
            self.dynamicCall("CommConnect()")
            time.sleep(self.TR_REQ_TIME_INTERVAL)
            self.login_event_loop = QEventLoop()
            self.login_event_loop.exec_()
        except Exception as e:
            self.net.Exception(e)

    def account_info(self):
        # 계좌번호 가져오기
        account_number = self.get_login_info("ACCNO")
        self.account_number = account_number.split(';')[0]
        self.account_number = str(self.account_number).strip()
        if len(self.account_number) == 0:
            self.net.Exception("Failed to get account information")
            sys.exit()
        else:
            self.net.Log("Account : " + self.account_number)

    def get_login_info(self, tag):
        # 로그인 정보 가져오기
        try:
            ret = self.dynamicCall("GetLoginInfo(QString)", tag)
            time.sleep(self.TR_REQ_TIME_INTERVAL)
            return ret
        except Exception as e:
            self.net.Exception(e)

    def get_connect_state(self):
        # 연결 정보 가져오기
        try:
            ret = self.dynamicCall("GetConnectState()")
            time.sleep(self.TR_REQ_TIME_INTERVAL)
            return ret
        except Exception as e:
            self.net.Exception(e)

    def set_input_value(self, req_id, value):
        # 데이터 입력
        try:
            self.dynamicCall("SetInputValue(QString, QString)", req_id, value)
        except Exception as e:
            self.net.Exception(e)

    def comm_rq_data(self, rqname, trcode, prev_next, screen_no):
        # 데이터 요청하기
        self.dynamicCall("CommRqData(QString, QString, int, QString", rqname, trcode, prev_next, screen_no)
        time.sleep(self.TR_REQ_TIME_INTERVAL)
        self.tr_event_loop = QEventLoop()
        self.tr_event_loop.exec_()

    def _get_comm_data(self, code, field_name, index, item_name):
        # 값 가져오기
        ret = self.dynamicCall("GetCommData(QString, QString, int, QString", code, field_name, index, item_name)
        return ret.strip()

    def _get_repeat_cnt(self, trcode, rqname):
        # 반복 횟수 가져오기
        try:
            ret = self.dynamicCall("GetRepeatCnt(QString, QString)", trcode, rqname)
            return ret
        except Exception as e:
            self.net.Exception(e)

    # ############################################### 데이터 수신 메서드 ###############################################

    def _receive_tr_data(self, screen_no, rqname, trcode, record_name, next, unused1, unused2, unused3, unused4):
        # 데이터 가져오기

        if next == '2':
            self.remained_data = True
        else:
            self.remained_data = False

        if rqname == "DailyChartRequests":
            self.DailyChartRequests(rqname, trcode)
        elif rqname == "MinChartRequests":
            self.MinChartRequests(rqname, trcode)
        elif rqname == "InvestorBuyPriceRequests":
            self.InvestorBuyPriceRequests(rqname, trcode)
        elif rqname == "InvestorBuyVolumeRequests":
            self.InvestorBuyVolumeRequests(rqname, trcode)
        elif rqname == "InvestorSellPriceRequests":
            self.InvestorSellPriceRequests(rqname, trcode)
        elif rqname == "InvestorSellVolumeRequests":
            self.InvestorSellVolumeRequests(rqname, trcode)

        try:
            self.tr_event_loop.exit()
        except AttributeError:
            pass

    def DailyChartRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "일자")
            chart_open = self._get_comm_data(trcode, rqname, i, "시가")
            chart_high = self._get_comm_data(trcode, rqname, i, "고가")
            chart_low = self._get_comm_data(trcode, rqname, i, "저가")
            chart_close = self._get_comm_data(trcode, rqname, i, "현재가")
            chart_volume = self._get_comm_data(trcode, rqname, i, "거래량")

            self.ohlcv['date'].append(date)
            self.ohlcv['open'].append(int(chart_open))
            self.ohlcv['high'].append(int(chart_high))
            self.ohlcv['low'].append(int(chart_low))
            self.ohlcv['close'].append(int(chart_close))
            self.ohlcv['volume'].append(int(chart_volume))

            if date <= self.last_date:
                self.remained_data = False
                break

    def MinChartRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "체결시간")
            chart_open = self._get_comm_data(trcode, rqname, i, "시가")
            chart_high = self._get_comm_data(trcode, rqname, i, "고가")
            chart_low = self._get_comm_data(trcode, rqname, i, "저가")
            chart_close = self._get_comm_data(trcode, rqname, i, "현재가")
            chart_volume = self._get_comm_data(trcode, rqname, i, "거래량")

            self.ohlcv['date'].append(date[:-2])
            self.ohlcv['open'].append(abs(int(chart_open)))
            self.ohlcv['high'].append(abs(int(chart_high)))
            self.ohlcv['low'].append(abs(int(chart_low)))
            self.ohlcv['close'].append(abs(int(chart_close)))
            self.ohlcv['volume'].append(int(chart_volume))

            if date <= self.last_date:
                self.remained_data = False
                break

    def InvestorBuyPriceRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "일자")
            indivisual = self._get_comm_data(trcode, rqname, i, "개인투자자")
            foreigner = self._get_comm_data(trcode, rqname, i, "외국인투자자")
            institution = self._get_comm_data(trcode, rqname, i, "기관계")
            finance = self._get_comm_data(trcode, rqname, i, "금융투자")
            insurance = self._get_comm_data(trcode, rqname, i, "보험")
            tusin = self._get_comm_data(trcode, rqname, i, "투신")
            other = self._get_comm_data(trcode, rqname, i, "기타금융")
            bank = self._get_comm_data(trcode, rqname, i, "은행")
            pension = self._get_comm_data(trcode, rqname, i, "연기금등")
            private_equity = self._get_comm_data(trcode, rqname, i, "사모펀드")
            nation = self._get_comm_data(trcode, rqname, i, "국가")
            other_corporations = self._get_comm_data(trcode, rqname, i, "기타법인")
            domestic_foreign = self._get_comm_data(trcode, rqname, i, "내외국인")

            self.investor_buy_price['date'].append(date)
            self.investor_buy_price['개인투자자_매수금액'].append(indivisual)
            self.investor_buy_price['외국인투자자_매수금액'].append(foreigner)
            self.investor_buy_price['기관투자_매수금액'].append(institution)
            self.investor_buy_price['금융투자_매수금액'].append(finance)
            self.investor_buy_price['보험_매수금액'].append(insurance)
            self.investor_buy_price['투신_매수금액'].append(tusin)
            self.investor_buy_price['기타금융_매수금액'].append(other)
            self.investor_buy_price['은행_매수금액'].append(bank)
            self.investor_buy_price['연기금등_매수금액'].append(pension)
            self.investor_buy_price['사모펀드_매수금액'].append(private_equity)
            self.investor_buy_price['국가_매수금액'].append(nation)
            self.investor_buy_price['기타법인_매수금액'].append(other_corporations)
            self.investor_buy_price['내외국인_매수금액'].append(domestic_foreign)

            if date <= self.last_date:
                self.remained_data = False
                break

    def InvestorBuyVolumeRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "일자")
            indivisual = self._get_comm_data(trcode, rqname, i, "개인투자자")
            foreigner = self._get_comm_data(trcode, rqname, i, "외국인투자자")
            institution = self._get_comm_data(trcode, rqname, i, "기관계")
            finance = self._get_comm_data(trcode, rqname, i, "금융투자")
            insurance = self._get_comm_data(trcode, rqname, i, "보험")
            tusin = self._get_comm_data(trcode, rqname, i, "투신")
            other = self._get_comm_data(trcode, rqname, i, "기타금융")
            bank = self._get_comm_data(trcode, rqname, i, "은행")
            pension = self._get_comm_data(trcode, rqname, i, "연기금등")
            private_equity = self._get_comm_data(trcode, rqname, i, "사모펀드")
            nation = self._get_comm_data(trcode, rqname, i, "국가")
            other_corporations = self._get_comm_data(trcode, rqname, i, "기타법인")
            domestic_foreign = self._get_comm_data(trcode, rqname, i, "내외국인")

            self.investor_buy_volume['date'].append(date)
            self.investor_buy_volume['개인투자자_매수수량'].append(indivisual)
            self.investor_buy_volume['외국인투자자_매수수량'].append(foreigner)
            self.investor_buy_volume['기관투자_매수수량'].append(institution)
            self.investor_buy_volume['금융투자_매수수량'].append(finance)
            self.investor_buy_volume['보험_매수수량'].append(insurance)
            self.investor_buy_volume['투신_매수수량'].append(tusin)
            self.investor_buy_volume['기타금융_매수수량'].append(other)
            self.investor_buy_volume['은행_매수수량'].append(bank)
            self.investor_buy_volume['연기금등_매수수량'].append(pension)
            self.investor_buy_volume['사모펀드_매수수량'].append(private_equity)
            self.investor_buy_volume['국가_매수수량'].append(nation)
            self.investor_buy_volume['기타법인_매수수량'].append(other_corporations)
            self.investor_buy_volume['내외국인_매수수량'].append(domestic_foreign)

            if date <= self.last_date:
                self.remained_data = False
                break

    def InvestorSellPriceRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "일자")
            indivisual = self._get_comm_data(trcode, rqname, i, "개인투자자")
            foreigner = self._get_comm_data(trcode, rqname, i, "외국인투자자")
            institution = self._get_comm_data(trcode, rqname, i, "기관계")
            finance = self._get_comm_data(trcode, rqname, i, "금융투자")
            insurance = self._get_comm_data(trcode, rqname, i, "보험")
            tusin = self._get_comm_data(trcode, rqname, i, "투신")
            other = self._get_comm_data(trcode, rqname, i, "기타금융")
            bank = self._get_comm_data(trcode, rqname, i, "은행")
            pension = self._get_comm_data(trcode, rqname, i, "연기금등")
            private_equity = self._get_comm_data(trcode, rqname, i, "사모펀드")
            nation = self._get_comm_data(trcode, rqname, i, "국가")
            other_corporations = self._get_comm_data(trcode, rqname, i, "기타법인")
            domestic_foreign = self._get_comm_data(trcode, rqname, i, "내외국인")

            self.investor_sell_price['date'].append(date)
            self.investor_sell_price['개인투자자_매도금액'].append(indivisual)
            self.investor_sell_price['외국인투자자_매도금액'].append(foreigner)
            self.investor_sell_price['기관투자_매도금액'].append(institution)
            self.investor_sell_price['금융투자_매도금액'].append(finance)
            self.investor_sell_price['보험_매도금액'].append(insurance)
            self.investor_sell_price['투신_매도금액'].append(tusin)
            self.investor_sell_price['기타금융_매도금액'].append(other)
            self.investor_sell_price['은행_매도금액'].append(bank)
            self.investor_sell_price['연기금등_매도금액'].append(pension)
            self.investor_sell_price['사모펀드_매도금액'].append(private_equity)
            self.investor_sell_price['국가_매도금액'].append(nation)
            self.investor_sell_price['기타법인_매도금액'].append(other_corporations)
            self.investor_sell_price['내외국인_매도금액'].append(domestic_foreign)

            if date <= self.last_date:
                self.remained_data = False
                break

    def InvestorSellVolumeRequests(self, rqname, trcode):
        # 반복 횟수 구하기
        repeat_cnt = self._get_repeat_cnt(trcode, rqname)

        for i in range(repeat_cnt):
            date = self._get_comm_data(trcode, rqname, i, "일자")
            indivisual = self._get_comm_data(trcode, rqname, i, "개인투자자")
            foreigner = self._get_comm_data(trcode, rqname, i, "외국인투자자")
            institution = self._get_comm_data(trcode, rqname, i, "기관계")
            finance = self._get_comm_data(trcode, rqname, i, "금융투자")
            insurance = self._get_comm_data(trcode, rqname, i, "보험")
            tusin = self._get_comm_data(trcode, rqname, i, "투신")
            other = self._get_comm_data(trcode, rqname, i, "기타금융")
            bank = self._get_comm_data(trcode, rqname, i, "은행")
            pension = self._get_comm_data(trcode, rqname, i, "연기금등")
            private_equity = self._get_comm_data(trcode, rqname, i, "사모펀드")
            nation = self._get_comm_data(trcode, rqname, i, "국가")
            other_corporations = self._get_comm_data(trcode, rqname, i, "기타법인")
            domestic_foreign = self._get_comm_data(trcode, rqname, i, "내외국인")

            self.investor_sell_volume['date'].append(date)
            self.investor_sell_volume['개인투자자_매도수량'].append(indivisual)
            self.investor_sell_volume['외국인투자자_매도수량'].append(foreigner)
            self.investor_sell_volume['기관투자_매도수량'].append(institution)
            self.investor_sell_volume['금융투자_매도수량'].append(finance)
            self.investor_sell_volume['보험_매도수량'].append(insurance)
            self.investor_sell_volume['투신_매도수량'].append(tusin)
            self.investor_sell_volume['기타금융_매도수량'].append(other)
            self.investor_sell_volume['은행_매도수량'].append(bank)
            self.investor_sell_volume['연기금등_매도수량'].append(pension)
            self.investor_sell_volume['사모펀드_매도수량'].append(private_equity)
            self.investor_sell_volume['국가_매도수량'].append(nation)
            self.investor_sell_volume['기타법인_매도수량'].append(other_corporations)
            self.investor_sell_volume['내외국인_매도수량'].append(domestic_foreign)

            if date <= self.last_date:
                self.remained_data = False
                break

    # ############################################### 종목 호출 메서드 ###############################################

    def GetDailyData(self, code, date="0"):

        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d")

        self.rq_count += 1
        self.net.RqCount(self.rq_count)
        self.ohlcv = {'date': [], 'open': [], 'high': [], 'low': [], 'close': [], 'volume': []}
        self.set_input_value("종목코드", code)
        self.set_input_value("기준일자", today)
        self.set_input_value("수정주가구분", 1)
        self.comm_rq_data("DailyChartRequests", "opt10081", 0, "0101")
        time.sleep(self.TR_REQ_TIME_INTERVAL)
        while self.remained_data:
            self.rq_count += 1
            self.net.RqCount(self.rq_count)
            self.set_input_value("종목코드", code)
            self.set_input_value("기준일자", today)
            self.set_input_value("수정주가구분", 1)
            self.comm_rq_data("DailyChartRequests", "opt10081", 2, "0101")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        # data 비어있는 경우
        if len(self.ohlcv) == 0:
            return []

        if self.ohlcv['date'] == '':
            return []

        df = pd.DataFrame(self.ohlcv, columns=['date', 'open', 'high', 'low', 'close', 'volume'])

        return df.sort_values(by="date").reset_index(drop=True)

    def GetMinData(self, code, date="0"):

        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        self.ohlcv = {'date': [], 'open': [], 'high': [], 'low': [], 'close': [], 'volume': []}


        self.rq_count += 1
        self.net.RqCount(self.rq_count)
        self.set_input_value("종목코드", code)
        self.set_input_value("틱범위", 1)
        self.set_input_value("수정주가구분", 1)
        self.comm_rq_data("MinChartRequests", "opt10080", 0, "1999")
        time.sleep(self.TR_REQ_TIME_INTERVAL)
        while self.remained_data:

            self.rq_count += 1
            self.net.RqCount(self.rq_count)
            self.set_input_value("종목코드", code)
            self.set_input_value("틱범위", 1)
            self.set_input_value("수정주가구분", 1)
            self.comm_rq_data("MinChartRequests", "opt10080", 2, "1999")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        # data 비어있는 경우
        if len(self.ohlcv) == 0:
            return []

        if self.ohlcv['date'] == '':
            return []

        df = pd.DataFrame(self.ohlcv, columns=['date', 'open', 'high', 'low', 'close', 'volume'])

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d2359")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d2359")

        df = df.loc[df["date"] < today]


        return df.sort_values(by="date").reset_index(drop=True)

    def GetInvestorBuyPrice(self, code, date="0"):
        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d")

        self.investor_buy_price = {'date': [], '개인투자자_매수금액': [], '외국인투자자_매수금액': [], '기관투자_매수금액': [], '금융투자_매수금액': [], '보험_매수금액': [], '투신_매수금액': [], '기타금융_매수금액': [], '은행_매수금액': [], '연기금등_매수금액': [], '사모펀드_매수금액': [], '국가_매수금액': [], '기타법인_매수금액': [], '내외국인_매수금액': []}

        # 매수 금액
        self.rq_count += 1

        self.net.RqCount(self.rq_count)
        self.set_input_value("일자", today)
        self.set_input_value("종목코드", code)
        self.set_input_value("금액수량구분", 1)
        self.set_input_value("매매구분", 1)
        self.set_input_value("단위구분", 1)
        self.comm_rq_data("InvestorBuyPriceRequests", "opt10060", 0, "0102")
        time.sleep(self.TR_REQ_TIME_INTERVAL)
        while self.remained_data:

            self.rq_count += 1
            self.net.RqCount(self.rq_count)
            self.set_input_value("일자", today)
            self.set_input_value("종목코드", code)
            self.set_input_value("금액수량구분", 1)
            self.set_input_value("매매구분", 1)
            self.set_input_value("단위구분", 1)
            self.comm_rq_data("InvestorBuyPriceRequests", "opt10060", 2, "0102")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        if len(self.investor_buy_price) == 0:
            return []

        if self.investor_buy_price['date'] == '':
            return []

        df = pd.DataFrame(self.investor_buy_price, columns=['date', '개인투자자_매수금액', '외국인투자자_매수금액', '기관투자_매수금액', '금융투자_매수금액', '보험_매수금액', '투신_매수금액', '기타금융_매수금액', '은행_매수금액', '연기금등_매수금액', '사모펀드_매수금액', '국가_매수금액', '기타법인_매수금액', '내외국인_매수금액'])


        return df

    def GetInvestorBuyVolume(self, code, date="0"):
        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d")

        self.investor_buy_volume = {'date': [], '개인투자자_매수수량': [], '외국인투자자_매수수량': [], '기관투자_매수수량': [], '금융투자_매수수량': [], '보험_매수수량': [], '투신_매수수량': [], '기타금융_매수수량': [], '은행_매수수량': [], '연기금등_매수수량': [], '사모펀드_매수수량': [], '국가_매수수량': [], '기타법인_매수수량': [], '내외국인_매수수량': []}

        # 매수 수량

        self.rq_count += 1
        self.net.RqCount(self.rq_count)
        self.set_input_value("일자", today)
        self.set_input_value("종목코드", code)
        self.set_input_value("금액수량구분", 2)
        self.set_input_value("매매구분", 1)
        self.set_input_value("단위구분", 1)
        self.comm_rq_data("InvestorBuyVolumeRequests", "opt10060", 0, "0102")
        time.sleep(self.TR_REQ_TIME_INTERVAL)

        while self.remained_data:

            self.rq_count += 1
            self.net.RqCount(self.rq_count)

            self.set_input_value("일자", today)
            self.set_input_value("종목코드", code)
            self.set_input_value("금액수량구분", 2)
            self.set_input_value("매매구분", 1)
            self.set_input_value("단위구분", 1)
            self.comm_rq_data("InvestorBuyVolumeRequests", "opt10060", 2, "0102")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        if len(self.investor_buy_volume) == 0:
            return []

        if self.investor_buy_volume['date'] == '':
            return []

        df = pd.DataFrame(self.investor_buy_volume, columns=['date', '개인투자자_매수수량', '외국인투자자_매수수량', '기관투자_매수수량', '금융투자_매수수량', '보험_매수수량', '투신_매수수량', '기타금융_매수수량', '은행_매수수량', '연기금등_매수수량', '사모펀드_매수수량', '국가_매수수량', '기타법인_매수수량', '내외국인_매수수량'])


        return df

    def GetInvestorSellPrice(self, code, date="0"):
        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d")

        self.investor_sell_price = {'date': [], '개인투자자_매도금액': [], '외국인투자자_매도금액': [], '기관투자_매도금액': [], '금융투자_매도금액': [], '보험_매도금액': [], '투신_매도금액': [], '기타금융_매도금액': [], '은행_매도금액': [], '연기금등_매도금액': [], '사모펀드_매도금액': [], '국가_매도금액': [], '기타법인_매도금액': [], '내외국인_매도금액': []}

        # 매도 금액
        self.rq_count += 1
        self.net.RqCount(self.rq_count)
        self.set_input_value("일자", today)
        self.set_input_value("종목코드", code)
        self.set_input_value("금액수량구분", 1)
        self.set_input_value("매매구분", 2)
        self.set_input_value("단위구분", 1)
        self.comm_rq_data("InvestorSellPriceRequests", "opt10060", 0, "0102")
        time.sleep(self.TR_REQ_TIME_INTERVAL)

        while self.remained_data:

            self.rq_count += 1
            self.net.RqCount(self.rq_count)
            self.set_input_value("일자", today)
            self.set_input_value("종목코드", code)
            self.set_input_value("금액수량구분", 1)
            self.set_input_value("매매구분", 2)
            self.set_input_value("단위구분", 1)
            self.comm_rq_data("InvestorSellPriceRequests", "opt10060", 2, "0102")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        if len(self.investor_sell_price) == 0:
            return []

        if self.investor_sell_price['date'] == '':
            return []

        df = pd.DataFrame(self.investor_sell_price, columns=['date', '개인투자자_매도금액', '외국인투자자_매도금액', '기관투자_매도금액', '금융투자_매도금액', '보험_매도금액', '투신_매도금액', '기타금융_매도금액', '은행_매도금액', '연기금등_매도금액', '사모펀드_매도금액', '국가_매도금액', '기타법인_매도금액', '내외국인_매도금액'])

        return df

    def GetInvestorSellVolume(self, code, date="0"):
        self.last_date = date

        current_time = datetime.datetime.today().strftime("%H%M")

        if self.close_time >= current_time:
            today = (datetime.datetime.today() - datetime.timedelta(days=1)).strftime("%Y%m%d")
        else:
            today = datetime.datetime.today().strftime("%Y%m%d")

        self.investor_sell_volume = {'date': [], '개인투자자_매도수량': [], '외국인투자자_매도수량': [], '기관투자_매도수량': [], '금융투자_매도수량': [], '보험_매도수량': [], '투신_매도수량': [], '기타금융_매도수량': [], '은행_매도수량': [], '연기금등_매도수량': [], '사모펀드_매도수량': [], '국가_매도수량': [], '기타법인_매도수량': [], '내외국인_매도수량': []}

        # 매도 수량
        self.rq_count += 1
        self.net.RqCount(self.rq_count)
        self.set_input_value("일자", today)
        self.set_input_value("종목코드", code)
        self.set_input_value("금액수량구분", 2)
        self.set_input_value("매매구분", 2)
        self.set_input_value("단위구분", 1)
        self.comm_rq_data("InvestorSellVolumeRequests", "opt10060", 0, "0102")
        time.sleep(self.TR_REQ_TIME_INTERVAL)

        while self.remained_data:

            self.rq_count += 1
            self.net.RqCount(self.rq_count)
            self.set_input_value("일자", today)
            self.set_input_value("종목코드", code)
            self.set_input_value("금액수량구분", 2)
            self.set_input_value("매매구분", 2)
            self.set_input_value("단위구분", 1)
            self.comm_rq_data("InvestorSellVolumeRequests", "opt10060", 2, "0102")
            time.sleep(self.TR_REQ_TIME_INTERVAL)

        if len(self.investor_sell_volume) == 0:
            return []

        if self.investor_sell_volume['date'] == '':
            return []

        df = pd.DataFrame(self.investor_sell_volume, columns=['date', '개인투자자_매도수량', '외국인투자자_매도수량', '기관투자_매도수량', '금융투자_매도수량', '보험_매도수량', '투신_매도수량', '기타금융_매도수량', '은행_매도수량', '연기금등_매도수량', '사모펀드_매도수량', '국가_매도수량', '기타법인_매도수량', '내외국인_매도수량'])

        return df




if __name__ == "__main__":
    app = QApplication(sys.argv)

    api = OpenApi()

    print(api.GetInvestorBuyVolume("005930"))
    print(api.GetInvestorSellPrice("005930"))
    print(api.GetInvestorSellVolume("005930"))

    app.exec_()
