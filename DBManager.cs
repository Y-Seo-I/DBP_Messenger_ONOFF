using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace on_off_proj
{
    public class DBManager
    {
        private static DBManager instance_ = new DBManager();
        private string strconn = "Server=118.67.143.130;Port=3306;Database=DBP;Uid=root;Pwd=B3J5RmHYibc;Charset=utf8";
        private int check;
        private string userId = "";

        public static DBManager GetInstance()
        {
            return instance_;
        }

        public void setUserId(string uId)
        {
            this.userId = uId;
        }

        // 해당 테이블에 값 존재하는지 확인 또는 정수 반환하는 함수 사용할 떄
        public int exists(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                check = Convert.ToInt32(cmd.ExecuteScalar());

                return check;
            }
        }

        public DataTable select(string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strconn))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);

                    return dt;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public void insert(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void insertFile(string query, byte[] data)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@zipFile", data);
                cmd.ExecuteNonQuery();
            }
        }

        public string getUserId()
        {
            return userId;
        }
    }
}