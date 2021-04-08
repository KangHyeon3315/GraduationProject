import time
import datetime
import pandas as pd
import dart_fss as dart
from dart_fss.errors import NoDataReceived
from pykrx import stock

from DB import DataBase
from Network import Network


class Statement:
    def __init__(self):
        self.net = Network()
        self.net.Company("None")
        self.net.RqCount("0")
        self.net.CompleteCount("0000")
        self.net.Work("Financial Statement Collecting")
        self.net.Log("Collect Start Financial Statement")

        self.today = datetime.datetime.today().strftime("%Y%m%d")

        self.DB = DataBase()
        self.corp_info = self.DB.GetCompanyInfoTotalTable()
        # self.net.Requests("RequestsDartKey")

if __name__ == "__main__":

    statement = Statement()