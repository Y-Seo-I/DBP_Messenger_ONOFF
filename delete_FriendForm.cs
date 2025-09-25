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
    public partial class delete_FriendForm : Form
    {
        public string login_id { get; set; }
        string Friend_ID;

        public delete_FriendForm(object sender, string login_id)
        {
            InitializeComponent();
            UserControl1 user = sender as UserControl1;
            pictureBox_image.Image = user.Icon;
            label_ID.Text = user.Id;
            label_Name.Text = user.Uname;
            label_Nickname.Text = user.nick;
            this.login_id = login_id;
            Friend_ID = user.Id;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            Friend.Friend_delete(login_id, Friend_ID);
            this.Close();
        }

        private void EnterChatroomButton_Click(object sender, EventArgs e)
        {
            string query = "select exists(select roomId from DBP.Chat_list where userId ='" + login_id + "," + Friend_ID +"' or userId = '" + Friend_ID +"," +login_id +"') as success";
            string whereLike = "select * from DBP.Chat_list where userId ='" + login_id + "," + Friend_ID + "' or userId = '" + Friend_ID + "," + login_id + "'";
            int check = DBManager.GetInstance().exists(query);
            if (check == 1)
            {
                DataTable chatList = DBManager.GetInstance().select(whereLike);
                int room = Convert.ToInt32(chatList.Rows[0]["roomId"].ToString());
                string[] info = chatList.Rows[0]["userId"].ToString().Split(',');
                for (int i = 0; i < 2; i++)
                {
                    if (info[i] != login_id)
                    {
                        
                        string chatName = room.ToString() + "," + label_Nickname.Text;
                        chattingRoom chat = new chattingRoom(chatName,0);
                        this.Close();
                        chat.ShowDialog();
                    }
                }
                query = "update DBP.CheckReceive set checkRead = 1,timeStamp = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where roomId = " + room;
                DBManager.GetInstance().insert(query);
            }
            else
            {
                DataTable max = DBManager.GetInstance().select("select max(roomId) from DBP.Chat_list ORDER BY roomId;");
                int maxId;
                if (max.Rows[0]["max(roomId)"].ToString() == "")
                {
                    maxId = 0;
                }
                else
                {
                    maxId = Convert.ToInt32(max.Rows[0]["max(roomId)"].ToString());
                }
                maxId++;
                query = "insert into  DBP.Chat_list Values (" + maxId + ", '" + login_id + "," + Friend_ID + "')";
                DBManager.GetInstance().insert(query);
                query = "insert into DBP.CheckReceive Values('" + login_id + "'," + maxId + ",1" + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                DBManager.GetInstance().insert(query);
                query = "insert into DBP.CheckReceive Values('" + Friend_ID + "'," + maxId + ",0" + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                DBManager.GetInstance().insert(query);
                string info_ = maxId.ToString() + "," + label_Nickname.Text;
                chattingRoom chat = new chattingRoom(info_,0);
                this.Close();
                chat.ShowDialog();
            }
            
        }
    }
}
