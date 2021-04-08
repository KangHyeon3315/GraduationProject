from sqlalchemy import create_engine
import pandas as pd
import pymysql
import datetime

class DataBase:
    def __init__(self):
        self.conn = pymysql.connect(host="127.0.0.1", port=3306, user="bot", password="kanghyeon#3315", charset='utf8', cursorclass=pymysql.cursors.DictCursor)
        self.engine_conn = create_engine('mysql+pymysql://{}:{}@{}'.format("bot", "kanghyeon#3315", "127.0.0.1"))

    def IsTableExists(self, schema, table):
        cursor = self.conn.cursor(pymysql.cursors.DictCursor)
        sql = "SELECT TABLE_NAME FROM information_schema.TABLES where TABLE_SCHEMA='{}' and TABLE_NAME='{}' LIMIT 1".format(schema, table)
        cursor.execute(sql)
        result = cursor.fetchone()

        if result is not None:
            return True
        else:
            return False

    def IsSchemaExists(self, schema):
        cursor = self.conn.cursor(pymysql.cursors.DictCursor)
        sql = "select * from information_schema.SCHEMATA where SCHEMA_NAME='{}';".format(schema)
        cursor.execute(sql)
        result = cursor.fetchone()

        if result is not None:
            return True
        else:
            return False

    def CreateSchema(self, schema):
        cursor = self.conn.cursor(pymysql.cursors.DictCursor)
        sql = "create schema {};".format(schema)

        cursor.execute(sql)
        self.conn.commit()

    def UpdateTable(self, schema, table, data):
        if len(data) != 0:
            data.to_sql(schema=schema, con=self.engine_conn, name=table, if_exists='append', index=False)

    def GetLatestData(self, schema, table, offset=-1):
        sql = "select * from {}.`{}` ORDER BY date DESC limit {}".format(schema, table, abs(offset))
        result = pd.read_sql(sql=sql, con=self.conn)

        if len(result) == abs(offset):
            return result.iloc[-1]  # return Series
        else:
            return None

    def GetCollectinginfo(self, collecting, code):
        sql = "select {} from collector.`company_info` where code='{}' limit 1".format(collecting, code)
        result = pd.read_sql(sql=sql, con=self.conn)

        return result.iloc[0, 0]

    def DropTable(self, schema, table):
        if self.IsTableExists(schema, table):
            sql = "drop table {}.`{}`".format(schema, table)
            cursor = self.conn.cursor()
            cursor.execute(sql)
            self.conn.commit()

    def IsDataExists(self, schema, table, option):
        if self.IsTableExists(schema, table):
            sql = "SELECT * FROM {}.`{}` WHERE {}".format(schema, table, option)
            cursor = self.conn.cursor(pymysql.cursors.DictCursor)
            cursor.execute(sql)
            rows = cursor.fetchall()
            if rows:
                return True
            else:
                return False
            # table 자체가 없으면 False 반환
        else:
            return False

    def SetScheduleInfo(self, code, collecting, data):
        cursor = self.conn.cursor()
        sql = "update collector.company_info set `{}`='{}' where code='{}'".format(collecting, data, code)
        cursor.execute(sql)
        self.conn.commit()

    def GetTotalTable(self, schema, table, option=None):
        if option is None:
            result = pd.read_sql(sql="SELECT * FROM {}.`{}` order by date ".format(schema, table), con=self.conn, index_col='date')
        else:
            result = pd.read_sql(sql="SELECT * FROM {}.`{}` where {} order by date".format(schema, table, option), con=self.conn, index_col='date')

        return result.reset_index()

    def GetCompanyInfoTotalTable(self):
        result = pd.read_sql(sql="SELECT * FROM collector.`company_info`", con=self.conn)

        return result.reset_index()

if __name__ == "__main__":
    db = DataBase()
    db.SetScheduleInfo("155660", "daily_collecting", "20210327")