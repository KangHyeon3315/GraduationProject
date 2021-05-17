using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace AutoTraderGUI.Library
{
    class DBController
    {
        string collectorStrConn;

        string DBIP;
        string DBID;
        string DBPW;


        public DBController(string ip, string id, string pw)
        {
            DBIP = ip;
            DBID = id;
            DBPW = pw;

            collectorStrConn = SchemaSelect("collector");

        }

        bool DBCheck()
        {
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    string command = string.Format("SELECT null FROM information_schema.SCHEMATA where SCHEMA_NAME = '{0}'", "collector");

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    
                    rdr.Close();
                    conn.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool WaitAdapt(MySqlDataAdapter adpt)
        {
            int count = 0;
            while (adpt.AcceptChangesDuringFill)
            {
                Thread.Sleep(50);
                count++;

                if (count > 20)
                {
                    return false;
                }
            }
            return true;
        }

        string SchemaSelect(string schema)
        {
            return string.Format("Server={0};Database={3};Uid={1};Pwd={2}", DBIP, DBID, DBPW, schema);
        }

        // DB의 CompanyInfo Table을 받아와 DataTable 형식으로 반환하는 기능
        public DataTable SelectCompanyInfo()
        {
            DataSet ds = new DataSet();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command = "SELECT * FROM company_info";

                    MySqlDataAdapter adpt = new MySqlDataAdapter(command, collectorStrConn);
                    adpt.Fill(ds, "result");
                    //WaitAdapt(adpt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return ds.Tables["result"];
        }

        public List<string> SelectColumnList(string schema, string table)
        {
            List<string> result = new List<string>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command = string.Format("SELECT COLUMN_NAME FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='{0}' and TABLE_NAME='{1}';", schema, table);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        result.Add(rdr["COLUMN_NAME"].ToString());
                    }
                    rdr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return result;
        }
        
        public List<string> SelectTableList(string schema)
        {
            List<string> result = new List<string>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command = string.Format("SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_SCHEMA='{0}';", schema);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        result.Add(rdr["TABLE_NAME"].ToString());
                    }
                    rdr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return result;
        }

        public List<string> SelectDateList(string schema, string table, int count=0)
        {
            List<string> result = new List<string>();

            if(!TableCheck(table, schema))
            {
                return result;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();

                    string command;
                    if (count == 0)
                        command = string.Format("SELECT date FROM {1}.`{0}` ORDER BY date DESC; ", table, schema);
                    else
                        command = string.Format("SELECT date FROM {2}.`{0}` ORDER BY date DESC LIMIT {1}; ", table, count, schema);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        result.Add(rdr["date"].ToString());
                    }
                    rdr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return result;
        }

        public DataTable SelectPriceData(string name, string option = "")
        {
            DataSet ds = new DataSet();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command;
                    if (option == "")
                        command = string.Format("SELECT date, open, high, low, close, volume FROM daily_chart.`{0}`", name);
                    else
                        command = string.Format("SELECT date, open, high, low, close, volume FROM daily_chart.`{0}` WHERE {1}", name, option);

                    MySqlDataAdapter adpt = new MySqlDataAdapter(command, collectorStrConn);
                    adpt.Fill(ds, "result");
                    //WaitAdapt(adpt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return ds.Tables["result"];
        }

        public DataTable SelectTableData(string schema, string table, string option = "")
        {
            DataSet ds = new DataSet();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command;
                    if (option == "")
                        command = string.Format("SELECT * FROM {0}.`{1}`", schema, table);
                    else
                        command = string.Format("SELECT * FROM {0}.`{1}` WHERE {2}", schema, table, option);

                    MySqlDataAdapter adpt = new MySqlDataAdapter(command, collectorStrConn);
                    adpt.Fill(ds, "result");
                    //WaitAdapt(adpt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return ds.Tables["result"];
        }

        public DataTable SelectSQLData(string schema, string sql)
        {
            DataSet ds = new DataSet();
            collectorStrConn = SchemaSelect(schema);
            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command;
                    command = sql;

                    MySqlDataAdapter adpt = new MySqlDataAdapter(command, collectorStrConn);
                    adpt.Fill(ds, "result");
                    //WaitAdapt(adpt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(sql);
                Console.WriteLine(ex.ToString());
                return null;
            }

            return ds.Tables["result"];
        }

        public bool ColumnCheck(string tableName, string schemaName, string columnName)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    string command = string.Format("SELECT null FROM information_schema.columns where table_name = '{0}' and table_schema = '{1}' and column_name = '{2}'", tableName, schemaName, columnName);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.Read();
                    rdr.Close();
                    conn.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool TableCheck(string tableName, string schemaName)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    string command = string.Format("SELECT null FROM information_schema.tables where table_name = '{0}' and table_schema = '{1}'", tableName, schemaName);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.Read();
                    rdr.Close();
                    conn.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public void UpdateCompanyInfo(string companyName, string columnName, string value)
        {
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    string command = string.Format("UPDATE collector.company_info SET {0}='{1}' WHERE name='{2}'", columnName, value, companyName);
                    
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public bool SchemaCheck(string schema)
        {
            bool result = false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    string command = string.Format("SELECT null FROM information_schema.SCHEMATA where SCHEMA_NAME = '{0}'", schema);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.Read();
                    rdr.Close();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public bool DataCheck(string schema, string table, string column, string data)
        {
            bool result = false;
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    string command = string.Format("SELECT null FROM {0}.`{1}` where {2} = '{3}'", schema, table, column, data);

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.Read();
                    rdr.Close();
                    conn.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool CreateSchema(string schema)
        {
            string SQL = string.Format("create schema {0};", schema);
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //MessageBox.Show(SQL);
                return false;
            }
        }

        public void UpdateRow(string schema, string table, DataColumnCollection columns, DataRow row, string key)
        {
            string SQL1 = string.Format("UPDATE {0}.`{1}` SET ", schema, table);
            string SQL2 = "";
            string SQL3 = string.Format(" WHERE name='{0}'", key);

            foreach (DataColumn column in columns)
            {
                if (SQL2 != "")
                    SQL2 += ", ";
                string value = row[column].ToString().Trim() == "" ? "null" : row[column].ToString();
                if (column.DataType.Name == "String")
                {
                    SQL2 += string.Format("{0}='{1}'", column.ColumnName, value);
                }
                else
                {
                    SQL2 += string.Format("{0}={1}", column.ColumnName, value);
                }
            }
            string SQL = SQL1 + SQL2 + SQL3;
            
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(SQL);
            }
        }
        public void InsertRow(string schema, string table, DataColumnCollection columns, DataRow row, DataColumn key=null)
        {
            // 해당 날짜 테이블에 해당 기업의 데이터가 없는 경우 Insert 아니면 업데이트
            // INSERT INTO collector.test (tt, tsts) VALUES (2, 1960) ON DUPLICATE KEY UPDATE tsts=12345;
            string SQL1 = string.Format("INSERT INTO {0}.`{1}` (", schema, table);
            string SQL2 = "";
            string SQL3 = ") VALUES (";
            string SQL4 = "";
            string SQL5 = ") ON DUPLICATE KEY UPDATE ";
            string SQL6 = "";

            foreach(DataColumn column in columns)
            {
                string value = row[column].ToString().Trim() == "" ? "null" : row[column].ToString();

                if (SQL2 != "")
                    SQL2 += ", ";
                if (SQL4 != "")
                    SQL4 += ", ";
                SQL2 += string.Format("{0}", column.ColumnName);

                //SQL4 += value;
                if (column.DataType.Name == "String")
                {
                    SQL4 += string.Format("'{1}'", column.ColumnName, value);
                }
                else
                {
                    SQL4 += string.Format("{1}", column.ColumnName, value);
                }

                if (key != null && column.ColumnName != key.ColumnName)
                {
                    if (SQL6 != "")
                        SQL6 += ", ";
                    if (column.DataType.Name == "String")
                    {
                        SQL6 += string.Format("{0}='{1}'", column.ColumnName, value);
                    }
                    else
                    {
                        SQL6 += string.Format("{0}={1}", column.ColumnName, value);
                    }
                }
            }

            string SQL = SQL1 + SQL2 + SQL3 + SQL4 + SQL5 + SQL6;
            
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(SQL);
            }
        }

        public void UpdateColumn(string schema, string table, string column, string Key, List<string> KeyList, List<string> ValueList)
        {
            if(KeyList.Count != ValueList.Count)
            {
                throw new ArgumentException("List Length is not equal");
            }

            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    for(int i = 0; i < KeyList.Count; i++)
                    {
                        string command = string.Format("UPDATE {0}.`{1}` SET {2}='{3}' WHERE {5}='{4}'", schema, table, column, ValueList[i], KeyList[i], Key);
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UpdateColumn(string schema, string table, List<string> columns, string Key, DataTable data)
        {
            
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        foreach(string column in columns)
                        {
                            string command = string.Format("UPDATE {0}.`{1}` SET {2}='{3}' WHERE {5}='{4}'", schema, table, column, data.Rows[i][column].ToString().Trim() == "" ? "NULL" : data.Rows[i][column], data.Rows[i][Key], Key);
                            cmd.CommandText = command;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateTable(string schema, string Name, DataColumnCollection columns, string key="")
        {
            if (TableCheck(Name, schema))
                return;
            string command = string.Format("CREATE TABLE `{0}` (", Name);
            string uniCommand = "";
            string keyCommand = "";
            for (int idx = 0; idx < columns.Count; idx++)
            {
                string column = columns[idx].ColumnName;
                Type dataType = columns[idx].DataType;

                switch (dataType.Name)
                {
                    case "String":
                        command += string.Format("{0} {1} null", column, "text");
                        break;
                    case "Int":
                    case "Int32":
                    case "Int64":
                        command += string.Format("{0} {1} null", column, "bigint");
                        break;
                    case "Single":
                        command += string.Format("{0} {1} null", column, "float");
                        break;
                    case "Double":
                        command += string.Format("{0} {1} null", column, "double");
                        break;

                }

                if (idx != columns.Count - 1)
                {
                    command += ", ";
                }
            }
            command += ") DEFAULT CHARSET=utf8;";

            if(key != "")
            {
                bool isContain = false;
                for (int idx = 0; idx < columns.Count; idx++)
                {
                    if(columns[idx].ColumnName == key)
                    {
                        isContain = true;
                        break;
                    }
                }

                if (isContain)
                {
                    uniCommand = string.Format("create unique index {0}_{1}_uindex on {0} ({1}); ", Name, key);
                    keyCommand = string.Format("alter table {2}.`{0}` add constraint `{0}_pk` primary key({1});", Name, key, schema);
                }
            }

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(SchemaSelect(schema)))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                //MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                if(uniCommand != "")
                {
                    cmd.CommandText = uniCommand;
                    cmd.ExecuteNonQuery();
                }
                if(keyCommand != "")
                {
                    cmd.CommandText = keyCommand;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                conn.Close();
                    
            }
        }

        public void UpdateTable(string schema, string table, DataTable data)
        {
            if(TableCheck(table, schema))
            {
                List<string> DBColumn = SelectColumnList(schema, table);

                foreach (DataColumn column in data.Columns)
                {
                    if (!DBColumn.Contains(column.ColumnName))
                    {
                        throw new ArgumentException("Data Column is not Equal with DB");
                    }
                }
            }
            else
            {
                CreateTable(schema, table, data.Columns);
            }

            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(collectorStrConn))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = conn.CreateCommand();

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        string command = string.Format("INSERT INTO {0}.`{1}` (", schema, table);
                        for(int idx = 0; idx < data.Columns.Count; idx++)
                        {
                            command += data.Columns[idx].ColumnName;

                            if(idx != data.Columns.Count - 1)
                            {
                                command += ", ";
                            }
                        }
                        command += ") VALUES (";
                        for (int idx = 0; idx < data.Columns.Count; idx++)
                        {
                            string column = data.Columns[idx].ColumnName;
                            Type dataType = data.Columns[idx].DataType;

                            switch (dataType.Name)
                            {
                                case "String":
                                    command += data.Rows[i][column] != null ? string.Format("'{0}'", data.Rows[i][column]) : "NULL";
                                    break;
                                default:
                                    command += string.Format("{0}", data.Rows[i][column].ToString().Trim() != "" ? data.Rows[i][column] : "NULL");
                                    break;
                            }
                            

                            if (idx != data.Columns.Count - 1)
                            {
                                command += ", ";
                            }
                        }
                        command += ");";
                        
                        cmd.CommandText = command;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public bool AddColumn(string schema, string tableName, string columnName, Type type, string defaultValue)
        {
            string cmd;
            using (MySqlConnection conn = new MySqlConnection(collectorStrConn))
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    MySqlTransaction myTrans = conn.BeginTransaction();

                    command.Connection = conn;
                    command.Transaction = myTrans;

                    if(defaultValue == null)
                    {
                        defaultValue = "NULL";
                    }

                    
                    switch (type.Name)
                    {
                        case "String":
                            cmd = string.Format("ALTER TABLE {0}.`{1}` ADD {2} {3} default {4}", schema, tableName, columnName, "text", defaultValue);
                            command.CommandText = cmd;
                            break;
                        case "Int":
                        case "Int32":
                        case "Int64":
                            cmd = string.Format("ALTER TABLE {0}.`{1}` ADD {2} {3} default {4}", schema, tableName, columnName, "int", defaultValue);
                            command.CommandText = cmd;
                            break;
                        case "Single":
                            cmd = string.Format("ALTER TABLE {0}.`{1}` ADD {2} {3} default {4}", schema, tableName, columnName, "float", defaultValue);
                            command.CommandText = cmd;
                            break;
                        case "Double":
                            cmd = string.Format("ALTER TABLE {0}.`{1}` ADD {2} {3} default {4}", schema, tableName, columnName, "double", defaultValue);
                            command.CommandText = cmd;
                            break;

                    }
                    command.ExecuteNonQuery();

                    myTrans.Commit();
                    conn.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}
