using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace on_off_proj
{
    public partial class bgcForm : Form
    {


        private string strconn = "Server=118.67.143.130;Port=3306;Database=DBP;Uid=root;Pwd=B3J5RmHYibc;Charset=utf8";
        string userid = DBManager.GetInstance().getUserId();
        public bgcForm()
        {
            InitializeComponent();
            radioButtonC4.Checked = true;

        }

        private void roundedButtonChangeBG_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                
                conn.Open();
                if (radioButtonC1.Checked)
                {
                    String query = "UPDATE DBP.on_off SET bgColor =\'#FFE3EE\' WHERE ID =\'" + userid + "\';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (radioButtonC2.Checked)
                {
                    String query = "UPDATE on_off SET bgColor =\'#FAFAD2\' WHERE ID =\'" + userid + "\';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (radioButtonC3.Checked)
                {
                    String query = "UPDATE on_off SET bgColor =\'#C8FFFF\' WHERE ID =\'" + userid + "\';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (radioButtonC4.Checked)
                {
                    String query = "UPDATE on_off SET bgColor =\'#FFFFFF\' WHERE ID =\'" + userid + "\';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                //TestForm test = new TestForm();
                //test.Show();
                conn.Close();
            }

            MessageBox.Show("배경 수정완료");
            this.Close();
        }
    }
}
