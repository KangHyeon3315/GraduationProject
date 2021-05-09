from DB import DataBase
import pandas

DB = DataBase("127.0.0.1", 3306, "bot", "kanghyeon#3315")

comp_info = DB.GetCompanyInfoTotalTable()

for idx in range(len(comp_info)):


    name = comp_info.loc[idx, "name"]
    if idx > 2317 and DB.IsTableExists("daily_chart", name) and DB.IsTableExists("indicator", name):
        print("{}/{}".format(idx, len(comp_info)))
        price = DB.GetLatestData("daily_chart", name)
        indi = DB.GetLatestData("indicator", name)
        for column in price.index:
            if str(column) == "index":
                #칼럼 삭제
                print("{}'s Price Column Drop".format(name))
                SQL = "ALTER TABLE daily_chart.`{}` DROP `{}`;".format(name, "index")
                cursor = DB.conn.cursor()
                cursor.execute(SQL)
                DB.conn.commit()

        for column in indi.index:
            if str(column) == "index":
                print("{}'s indicator Column Drop".format(name))
                SQL = "ALTER TABLE indicator.`{}` DROP `{}`;".format(name, "index")
                cursor = DB.conn.cursor()
                cursor.execute(SQL)
                DB.conn.commit()
                
