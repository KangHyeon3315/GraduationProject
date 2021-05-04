using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AutoTraderGUI.Library
{
    class DBController
    {
        private static string strConn = "Server=localhost;Database=mydb;Uid=root;Pwd=vmfhwprxm1";


        private static bool InsertData(string tableName, string date, int open, int high, int low, int close, int volume)
        {
            string command = "INSERT INTO " + tableName + "(date,open,high,low,close,volume) VALUES(" + date + "," + open.ToString() + "," + high.ToString() + "," + low.ToString() + "," + close.ToString() + "," + volume.ToString() + ")";
            System.Console.WriteLine(command);
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(strConn))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        private static string SelectData(string tableName, string date) //ex) SelectData(mydb, "2021-04-21"), 오류나 실패 시 null 반환
        {
            string result = null;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    string command = "SELECT * FROM" + tableName + "WHERE date = '" + date + "'";
                    System.Console.WriteLine(command);
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.GetString(0);
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

        private static bool AddTable(string tableName) //같은 이름의 테이블이 있는지 확인 후 없으면 생성, 생성 완료 시 true 실패 시 false 반환
        {
            string cmd = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    MySqlTransaction myTrans = conn.BeginTransaction();
                    command.Connection = conn;
                    command.Transaction = myTrans;
                    cmd = "SHOW TABLES LIKE '" + tableName + "'";
                    System.Console.WriteLine(cmd);
                    command.CommandText = cmd;
                    command.ExecuteNonQuery();
                    myTrans.Commit();
                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    try
                    {
                        conn.Open();
                        MySqlCommand command = conn.CreateCommand();
                        MySqlTransaction myTrans = conn.BeginTransaction();

                        command.Connection = conn;
                        command.Transaction = myTrans;

                        cmd = "CREATE TABLE " + tableName + "(date DATE, open INT, high INT, low INT, close INT, volume INT)";
                        System.Console.WriteLine(cmd);
                        command.CommandText = cmd;
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

        private static bool CheckColumn(string corporationName, string schemaName, string column_name) //Column 조회 성공 시 true 반환
        {
            string result = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string command = "SELECT null FROM information_schema.columns where table_name = '" + corporationName + "' and table_schema = '" + schemaName + "'and column_name = '" + column_name + "'";
                    System.Console.WriteLine(command);
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.GetString(0);
                    rdr.Close();
                    conn.Close(); conn.Open();
                    if (result != null) { return true; }
                    else { return false; }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        private static bool AddColumn(string tableName, string columnName, Type type, string defaultValue)
        {
            string cmd = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    MySqlTransaction myTrans = conn.BeginTransaction();

                    command.Connection = conn;
                    command.Transaction = myTrans;

                    cmd = "ALTER TABLE " + tableName + " ADD "+columnName+" "+type.Name+" default "+defaultValue;
                    System.Console.WriteLine(cmd);
                    command.CommandText = cmd;
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
