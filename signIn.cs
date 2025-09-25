using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace on_off_proj
{
    public partial class signIn : Form
    {
        public signIn()
        {
            InitializeComponent();
            setUp();
        }
        string myConnection = connection.connect();

        private void button_login_Click(object sender, EventArgs e)
        {   

            using (MySqlConnection connection = new MySqlConnection(myConnection))
            {
                connection.Open();
                
                string login_id = textBox_id.Text;
                string login_pw = textBox_pw.Text;

                DBManager.GetInstance().setUserId(login_id);

                string query = "SELECT * FROM on_off WHERE ID = '"+login_id+"'"; //아이디 기준으로 데이터를 가져옴
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                bool login = false;
                while (rdr.Read())
                {
                    string pw = AES.Decryption(rdr["PW"].ToString(), rdr["count"].ToString()); // 복호화 된 비밀번호
                    if (login_pw == pw) //현재 입력된 비밀번호와 db에서 가져온 복호화된 비밀번호가 같은가?
                    {
                        login = true;
                    }
                }
                rdr.Close();

                if (login)
                {
                    using (StreamWriter writer = new StreamWriter("setting.txt")) // 아이디를 암호키로 사용하여 암호화
                    {
                        if (checkBox_Remember.Checked)
                        {
                                writer.WriteLine("True");
                                writer.WriteLine(textBox_id.Text);
                                writer.WriteLine(AES.Encryption(textBox_pw.Text, textBox_id.Text));
                        }
                        else
                        {
                                writer.WriteLine("Fasle");
                                
                        }
                        writer.Close();
                    }
                    MessageBox.Show("LOGIN SUCCESS");
                    ClientData.ID = login_id;
                    this.Visible = false;

                    FriendList list = new FriendList();
                    list.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("LOGIN FAILED");
                }
            }
        }
        
        public void setUp()
        {
            string checkbox_checked = "";
            try
            {
                using (StreamReader file_read = new StreamReader("setting.txt"))
                {
                    checkbox_checked = file_read.ReadLine();
                    if (checkbox_checked == "True")
                    {
                        checkBox_Remember.Checked = true;
                        string id = file_read.ReadLine();
                        string pw = AES.Decryption(file_read.ReadLine(), id);

                        textBox_id.Text = id;
                        textBox_pw.Text = pw;
                        file_read.Close();
                    }
                    else
                    {
                        file_read.Close();
                    }
                }
            }
            catch(Exception e)
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void singUpButton_Click(object sender, EventArgs e)
        {

        }

        private void singUpButton_Click_1(object sender, EventArgs e)
        {
            sign_up signup = new sign_up();
            signup.ShowDialog();
        }
    }
}
