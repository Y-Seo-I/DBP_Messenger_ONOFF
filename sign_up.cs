using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.IO;

namespace on_off_proj
{
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }

        private void button_sing_up_save_Click(object sender, EventArgs e)
        {
            string myConnection = connection.connect();
            using (MySqlConnection connection = new MySqlConnection(myConnection))
            {
                connection.Open();
                int count = 1; // 비밀키

                //아이디 중복확인 처리
                Boolean ID_check = true;

                try//예외 처리
                {
                    string Query = "SELECT * FROM DBP.on_off";

                    MySqlCommand mySqlCommand = new MySqlCommand(Query, connection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    if (mySqlDataReader.HasRows == true) //db에 1개 이상의 값이 있다면 실행
                    {
                        while (mySqlDataReader.Read())
                        {
                            if (textBox_sign_up_ID.Text == mySqlDataReader["ID"].ToString())
                            {
                                MessageBox.Show("아이디가 중복됩니다.");
                                ID_check = false;
                            }
                        }
                        count = Convert.ToInt32(mySqlDataReader["count"].ToString()) + 1;
                    }
                    mySqlDataReader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //비밀번호 암호화
                string pw = AES.Encryption(textBox_sign_up_PW.Text, count.ToString());

                Console.WriteLine(count);
                //이미지파일 바이트단위저장
                byte[] IMG = null;
                if (textBox_sign_up_image_path.Text != "")
                {
                    IMG = imageBt.insert_imagebyte(this.textBox_sign_up_image_path.Text);
                }



                //회원가입
                string insertQuery = "INSERT INTO DBP.on_off(ID, PW, 이름, 우편번호, 주소, 상세주소, 별명, 프로필사진)" +
                   "VALUES('" + this.textBox_sign_up_ID.Text + "','" + pw + "','" + this.textBox_sign_up_Name.Text + "','"
                   + this.textBox_sign_up_Address_1.Text + "','" + this.textBox_sign_up_Address_2.Text + "','" + this.textBox_sign_up_Address_3.Text + "','"
                   + this.textBox_sign_up_Nickname.Text + "',@IMG)";
                try
                {
                    MySqlCommand mySqlInsertCommand = new MySqlCommand(insertQuery, connection);

                    mySqlInsertCommand.Parameters.Add(new MySqlParameter("@IMG", IMG));


                    if (ID_check == true)
                    {
                        mySqlInsertCommand.ExecuteNonQuery();

                    }
                    else return;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            this.Close();
        }

        private void button_Address_Click(object sender, EventArgs e)
        {
            address frm = new address();
            frm.ShowDialog();

            // 창이 닫히면 반환값을 반환한다.
            if (frm.gstrZipCode != "")
            {
                textBox_sign_up_Address_1.Text = frm.gstrZipCode;
                textBox_sign_up_Address_2.Text = frm.gstrAddress1;
            }
        }

        private void pictureBox_sign_up_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dig.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dig.FileName.ToString();
                textBox_sign_up_image_path.Text = picLoc;
                pictureBox_sign_up.ImageLocation = picLoc;


            }
        }
    }
}
