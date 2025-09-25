using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace on_off_proj
{
    public partial class changeData : Form
    {

        public string login_id = ClientData.ID;

        public changeData()
        {
            InitializeComponent();
            
            SetForm();

        }
        string myConnection = connection.connect();


        public void SetForm()
        {
            textBox_cgnickname.Text = Friend.Friend_search(login_id, "별명");
            textBox_statemessage.Text = Friend.Friend_search(login_id, "상태메세지");
            byte[] img = Friend.image(login_id);
            if (img == null)
            {
                ProfilePicture.Image = Properties.Resources.imoji1;
            }
            else
            {
                ProfilePicture.Image = imageBt.read_imagebyte(img);
            }
        }

        //패스워드,이름,주소,별명을 저장하는 버튼 이벤트
        private void button_cgsave_Click(object sender, EventArgs e)
        {
            string query = "UPDATE on_off SET 별명 = '" + textBox_cgnickname.Text + "', 상태메세지 = '" + textBox_statemessage.Text +"' WHERE ID = '" + login_id + "';";
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
            this.Close();
        }

        //버튼 클릭시 이미지 표시, DB 저장
        private void button_change_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog pFileDlg = new OpenFileDialog();
            pFileDlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            pFileDlg.Title = "편집할 파일을 선택하여 주세요.";
            string picloc = "";
            if (pFileDlg.ShowDialog() == DialogResult.OK)
            {
                picloc = pFileDlg.FileName.ToString();
                ProfilePicture.ImageLocation = picloc;
            }

            byte[] IMG = null;
            if (picloc != "")
            {
                IMG = imageBt.insert_imagebyte(picloc);
            }
            string query = "UPDATE on_off SET 프로필사진 = @IMG WHERE (`ID` = '" + login_id + "');";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(myConnection))
                {
                    
                    connection.Open();

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                    mySqlCommand.Parameters.Add(new MySqlParameter("@IMG", IMG));
                    mySqlCommand.Connection = connection;
                    mySqlCommand.CommandText = query;
                    mySqlCommand.ExecuteNonQuery();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
