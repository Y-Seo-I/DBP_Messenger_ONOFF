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
    public partial class insert_FriendForm : Form
    {
        public string login_id = ClientData.ID;
        string Friend_ID;

        public insert_FriendForm(object sender)
        {
            InitializeComponent();
            UserControl1 user = sender as UserControl1;
            pictureBox_image.Image = user.Icon;
            label_ID.Text = user.Id;
            label_Name.Text = user.Uname;
            label_nickname.Text = user.nick;
            Friend_ID = user.Id;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Friend.add_Friend(login_id, Friend_ID);
            this.Close();
        }
    }
}
