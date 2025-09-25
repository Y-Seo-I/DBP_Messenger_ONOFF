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
    public partial class add_FriendForm : Form
    {
        public string login_id { get; set; }
        public add_FriendForm(string login_id)
        {
            InitializeComponent();
            this.login_id = login_id;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            bool id_check = Friend.check_id(textBox_FriendID.Text);
            bool friend_check = false;
            
            if(textBox_FriendID.Text == login_id)
            {
                MessageBox.Show("본인은 추가할 수 없습니다.");
            }
            else
            {
                if (id_check == true)
                {
                    friend_check = Friend.check_Friend(login_id, textBox_FriendID.Text);
                }

                if (friend_check == true)
                {
                    Friend.add_Friend(login_id, textBox_FriendID.Text);
                }
            }
            
            this.Close();
        }
    }
}
