using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace on_off_proj
{
    public partial class changeMemInfo : Form
    {
        public string login_id = ClientData.ID;
        string myConnection = connection.connect();

        public changeMemInfo()
        {
            InitializeComponent();
            SetForm();
        }

        public void SetForm()
        {
            textBox_CMIname.Text = Friend.Friend_search(login_id, "이름");
            textBox_CMIaddress.Text = Friend.Friend_search(login_id, "주소");
            textBox_CMIdetail.Text = Friend.Friend_search(login_id, "상세주소");
            

            

            
        }

        private void button_cgsave_Click(object sender, System.EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE on_off SET 이름 = '" + textBox_CMIname.Text + "' WHERE ID = '" + login_id + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("변경되었습니다.");
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundedButton7_Click(object sender, System.EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE on_off SET 우편번호 = '" + postcode + "', 주소 = '" + textBox_CMIaddress.Text + "', 상세주소 = '" + textBox_CMIdetail.Text + "' WHERE ID = '" + login_id + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("변경되었습니다.");
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundedButton8_Click(object sender, System.EventArgs e)
        {
            string DB_pw = Friend.Friend_search(login_id, "PW");
            string enc = Friend.Friend_search(login_id, "count");
            string pw = AES.Decryption(DB_pw, enc);
            if(textBox_CMIpassword.Text == pw)
            {
                string new_pw = textBox_CMInewPsw.Text;
                if (new_pw == textBox_CMInewPswCer.Text)
                {
                    new_pw = AES.Encryption(new_pw, enc);
                    change_pw(new_pw);
                    MessageBox.Show("비밀번호가 변경 되었습니다.");
                }
                else
                {
                    MessageBox.Show("새로운 비밀번호 확인이 맞지 않습니다.");
                }
                
            }
            else
            {
                MessageBox.Show("현재 비밀번호가 틀립니다.");
            }
        }

        private void change_pw(string new_pw)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE on_off SET PW = '" + new_pw + "' WHERE ID = '" + login_id + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changeMemInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        string postcode = null;
        private void roundedButton2_Click(object sender, System.EventArgs e)
        {
            address frm = new address();
            frm.ShowDialog();

            // 창이 닫히면 반환값을 반환한다.
            if (frm.gstrZipCode != "")
            {
                postcode = frm.gstrZipCode;
                textBox_CMIaddress.Text = frm.gstrAddress1;
            }
        }
    }
}
