import pandas as pd

data = pd.read_csv("./TestText.csv", encoding="euc-kr")
data["start_date"] = data["start_date"].astype(str)
data["end_date"] = data["end_date"].astype(str)

for idx in range(len(data)):
    report_type = data.loc[idx, 'report_type']
    rept_type = data.loc[idx, 'type']
    year = str(data.loc[idx, 'end_date'])[:4]

    if report_type == "사업":
        profit = data.loc[idx, "당기순이익"]
        sales = data.loc[idx, "매출액"]

        EPS = int(profit) / data.loc[idx, "주식수"]
        PER = data.loc[idx, "시가총액"] / int(profit)
        ROE = data.loc[idx, "자본총계"] / data.loc[idx, "주식수"]
        profitRatio = int(profit) / int(sales) * 100
        PBR = data.loc[idx, "시가총액"] / data.loc[idx, "자본총계"]
        worth = data.loc[idx, "시가총액"] / data.loc[idx, "주식수"]

        data.loc[idx, "EPS"] = EPS
        data.loc[idx, "PER"] = PER
        data.loc[idx, "주당순자산"] = worth
        data.loc[idx, "PBR"] = PBR
        data.loc[idx, "ROE"] = ROE
        data.loc[idx, "순이익률"] = profitRatio
    else:
        if data.loc[(data["start_date"].astype(str) == "{}0101".format(int(year) - 1)) & (data["report_type"] == report_type)].empty:
            profit = "None"
            sales = "None"
        else:
            # print("{} {} {}".format(year, rept_type, report_type))
            profit = data.loc[idx, "당기순이익"]
            tmp = data.loc[(data["report_type"] == "사업") & (data["end_date"] == "{}1231".format(int(year) - 1)) & (data["type"] == rept_type), "당기순이익"].iloc[0]
            tmp2 = data.loc[(data["report_type"] == report_type) & (data["start_date"] == "{}0101".format(int(year) - 1)) & (data["type"] == rept_type), "당기순이익"].iloc[0]
            profit += (tmp - tmp2)

            sales = data.loc[idx, "매출액"]
            tmp = data.loc[(data["report_type"] == "사업") & (data["end_date"] == "{}1231".format(int(year) - 1)) & (data["type"] == rept_type), "매출액"].iloc[0]
            tmp2 = data.loc[(data["report_type"] == report_type) & (data["start_date"] == "{}0101".format(int(year) - 1)) & (data["type"] == rept_type), "매출액"].iloc[0]
            sales += (tmp - tmp2)

        if profit == "None":
            EPS = 0
            PER = 0
            ROE = 0
            profitRatio = 0
            salesRatio = 0
        else:
            EPS = int(profit) / data.loc[idx, "주식수"]
            PER = data.loc[idx, "시가총액"] / int(profit)
            ROE = data.loc[idx, "자본총계"] / data.loc[idx, "주식수"]
            profitRatio = int(profit) / int(sales) * 100
        PBR = data.loc[idx, "시가총액"] / data.loc[idx, "자본총계"]
        worth = data.loc[idx, "시가총액"] / data.loc[idx, "주식수"]

        data.loc[idx, "EPS"] = EPS
        data.loc[idx, "PER"] = PER
        data.loc[idx, "주당순자산"] = worth
        data.loc[idx, "PBR"] = PBR
        data.loc[idx, "ROE"] = ROE
        data.loc[idx, "순이익률"] = profitRatio

data["EPS"] = data["EPS"].astype(int)
# data["PER"] = data["PER"].astype(int)
data["주당순자산"] = data["주당순자산"].astype(int)
# data["PBR"] = data["PBR"].astype(int)
data["ROE"] = data["ROE"].astype(int)
data["순이익률"] = data["순이익률"].astype(int)
print(data)

data.to_csv("TestTestTest.csv", encoding='euc-kr', index=False)