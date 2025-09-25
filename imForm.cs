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
    public partial class emojiForm : Form
    {
       
        string userId = DBManager.GetInstance().getUserId();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int open;
        public emojiForm()
        {
            InitializeComponent();
        }

        public emojiForm(int open)
        {
            this.open = open;
            InitializeComponent();
        }
        
   
   

        private void pictureBoximoji1_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji1)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }

        private void pictureBoximoji2_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji2)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }

        private void pictureBoximoji3_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji3)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }

        private void pictureBoximoji4_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji4)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }

        private void pictureBoximoji5_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji5)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }

        private void pictureBoximoji6_Click(object sender, EventArgs e)
        {
            chattingRoom cr = new chattingRoom();
            string contents = "(emoji6)";
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 1)";
            DBManager.GetInstance().insert(query);
        }
    }
}
