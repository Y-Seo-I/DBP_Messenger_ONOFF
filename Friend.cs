using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace on_off_proj
{
    class Friend
    {
        static string myConnection = connection.connect();

        static public void add_Friend(string login_id, string Friend_id)
        {
            string query = "INSERT INTO FRIENDLIST (ID, FRIENDID) VALUES ('" + login_id + "', '" + Friend_id + "');";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("친구 추가되었습니다.");
        }

        static public bool check_id(string id)
        {
            bool check = false;
            string query = "SELECT * FROM on_off Where ID = '" + id +"';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    if (mySqlDataReader.HasRows == true)
                    {
                        check = true;
                    }
                    mySqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if(check == false)
            {
                MessageBox.Show("해당 회원이 존재하지 않습니다.");
            }
            return check;
        }


        static public bool check_Friend(string login_id, string Friend_id)
        {
            bool check = false;
            string query = "SELECT * FROM FRIENDLIST WHERE ID = '" + login_id + "' AND FRIENDID = '" + Friend_id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    if(mySqlDataReader.HasRows != true)
                    {
                        check = true;
                    }
                    mySqlDataReader.Close();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(check == false)
            {
                MessageBox.Show("이미 친구입니다.");
            }
            return check;
        }

        static public string[] Friend_info(int count ,string login_id)
        {
            int i = 0;
            string[] info = new string[count];
            string query = "SELECT * FROM FRIENDLIST WHERE ID = '" + login_id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    if (mySqlDataReader.HasRows == true)
                    {
                        while (mySqlDataReader.Read())
                        {
                            info[i] = mySqlDataReader["FRIENDID"].ToString();
                            i++;
                        }
                    }
                    mySqlDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return info;
        }

        static public int check_Friend_count(string login_id)
        {
            int count = 0;
            string query = "SELECT * FROM FRIENDLIST WHERE ID = '" + login_id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    while(mySqlDataReader.Read())
                    {
                        count++;
                    }
                    mySqlDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }

        static public byte[] image(string id)
        {
            byte[] img = null;
            string query = "SELECT * FROM on_off WHERE ID = '" + id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        if(mySqlDataReader["프로필사진"].ToString() != "")
                        {
                            img = (byte[])(mySqlDataReader["프로필사진"]);
                        }
                        
                    }
                    mySqlDataReader.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return img;
        }

        static public string Friend_search(string id, string search)
        {
            string content = null;
            string query = "SELECT * FROM on_off Where ID = '" + id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    if (mySqlDataReader.HasRows == true)
                    {
                        while (mySqlDataReader.Read())
                        {
                            content = mySqlDataReader[search].ToString();
                        }
                    }
                    mySqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return content;
        }

        static public void Friend_delete(string login_id, string Friend_id)
        {
            string query = "DELETE FROM FRIENDLIST WHERE ID = '" + login_id +"' AND FRIENDID = '" + Friend_id + "';";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("친구가 삭제되었습니다.");
        }
    }
    
}
