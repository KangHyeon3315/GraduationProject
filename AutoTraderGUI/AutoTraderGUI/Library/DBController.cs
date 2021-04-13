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
        static string strConn = "Server=localhost;Database=mydb;Uid=root;Pwd=vmfhwprxm1";
        static void Main(string[] args)
        {

        }

        private static bool InsertData(string tableName, string date, int open, int high, int low, int close, int volume)
        {
            string command = "INSERT INTO " + tableName + "(date,open,high,low,close,volume) VALUES(" + date + "," + open.ToString() + "," + high.ToString() + "," + low.ToString() + "," + close.ToString() + "," + volume.ToString() + ")";

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

        private static void TableUpdate(string tableName)  ////////////////////////////////////////// 미완성 ////////////////////////////////
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

                    cmd = "CREATE TABLE " + tableName + "(date DATE, open INT, high INT, low INT, close INT, volume INT)";
                    command.CommandText = cmd;
                    command.ExecuteNonQuery();

                    myTrans.Commit();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static bool ColumnCheck(string corporationName, string schemaName, string column_name)
        {
            string result = null;
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string command = "SELECT null FROM information_schema.columns where table_name = '" + corporationName + "' and table_schema = '" + schemaName + "'and column_name = '" + column_name + "'";

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    result = rdr.GetString(0);
                    rdr.Close();
                    conn.Close(); conn.Open();
                    return true;
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
