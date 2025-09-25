using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace on_off_proj
{

    public partial class ChatList : Form
    {


        Thread thread;
        DataTable history = new DataTable();
        DataTable checkReceive = new DataTable();
        DataTable chatList, chatHistory, on_off_userList, Friends;
        private string uId = DBManager.GetInstance().getUserId();
        int roomId = 0;
        int noFriend = 0;
        string friendId;
        string userList;
        string[] users;
        List<string> nick = new List<string>();
        string chatRoomName;
        DataRow rIdRow;
        int check, count, upCount;
        string lastContents = "";
        int[] upCountList;
        int[] countNew;

        bool thread_run;

        public ChatList()
        {
            InitializeComponent();
            this.Size = new Size(431, 700);
            //groupBoxChat.Click += new EventHandler(groupBoxChat_Enter);
            //Thread receive = new Thread(receiveList2);
            //receive.IsBackground = true;
            //receive.Start();
        }

        private void receiveList()
        {
            string query = "SELECT * FROM ";
            string queryF = "select FRIENDID from DBP.FRIENDLIST where ID = '" + uId + "'";
            string whereLike = "WHERE userId like '" + uId + ",%' or userId like '%," + uId + "'";
            string where = "WHERE (userId = '" + uId + "')";

            chatList = DBManager.GetInstance().select(query + "Chat_list " + whereLike + "ORDER BY roomId;");
            checkReceive = DBManager.GetInstance().select(query + "CheckReceive " + where);
            chatHistory = DBManager.GetInstance().select(query + "Chat_History;");
            on_off_userList = DBManager.GetInstance().select(query + "on_off;");

        }


        private void getData(int i)
        {
            DataRow uIdRow = chatList.DefaultView.ToTable(false, "userId").Rows[i];
            userList = uIdRow[0].ToString();

            users = userList.Split(',');
            nick = new List<string>();

            for (int j = 0; j < users.Length; j++)
            {
                DataRow[] nickSearch = on_off_userList.Select("ID = '" + users[j] + "'");
                if (nickSearch[0]["별명"] == null)
                {
                    ChatList cl = new ChatList();
                    this.Close();
                    cl.ShowDialog();
                }
                else
                    nick.Add(nickSearch[0]["별명"].ToString());
            }

            chatRoomName = "";

            if (users.Length == 2)
            {
                if (users[0] == uId)
                    chatRoomName = nick[1];
                else
                    chatRoomName = nick[0];
            }
            else
            {
                for (int j = 0; j < users.Length; j++)
                {
                    chatRoomName += nick[j];
                    if (j != users.Length - 1)
                        chatRoomName += ", ";
                }
            }

            rIdRow = chatList.DefaultView.ToTable(false, "roomId").Rows[i];
            roomId = Convert.ToInt32(rIdRow[0].ToString());

            DataRow[] checkRow = checkReceive.Select("userId='" + uId + "' AND roomId = " + roomId + "");
            check = Convert.ToInt32(checkRow[0]["checkRead"].ToString());

            DataRow[] chatLog = chatHistory.Select("roomId = " + roomId + "");
            if (chatLog.Length > 0)
                lastContents = chatLog[chatLog.Length - 1]["contents"].ToString();
            else
                lastContents = " ";


            if (check == 0)
            {
                string timeString = checkRow[0]["timeStamp"].ToString();
                count = 0;
                for (int j = 0; j < chatLog.Count(); j++)
                {
                    DateTime checkTime = DateTime.Parse(timeString);
                    DateTime logTime = DateTime.Parse(chatLog[j]["timeStamp"].ToString());
                    if (checkTime < logTime)
                    {
                        count++;
                    }
                }
            }
            else
            {
                count = 0;
            }
        }

        private void receiveList2()
        {
            while (true)
            {
                receiveList();
            }

        }

        private void TabFriendsList_Click(object sender, EventArgs e)
        {

            try
            {
                this.Visible = false;
                thread.Abort();
                FriendList fl = new FriendList();
                fl.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void TabAddFriends_Click(object sender, EventArgs e)
        {
            add_FriendForm add_FriendForm = new add_FriendForm(uId);
            add_FriendForm.ShowDialog();

        }

        private void TabSetting_Click(object sender, EventArgs e)
        {
            bgcForm bf = new bgcForm();
            bf.ShowDialog();
        }

        private void groupBoxChat_Enter(object sender, EventArgs e)
        {
            GroupBox group = sender as GroupBox;
            string chatName = group.Tag.ToString();
            string[] list = chatName.Split(',');
            int rId = Convert.ToInt32(list[0]);
            string query = "select userId from DBP.Chat_list where roomId = " + rId;
            DataTable fr_list = DBManager.GetInstance().select(query);
            string[] fr = fr_list.Rows[0]["userId"].ToString().Split(',');
            for (int i = 0; i < 2; i++)
            {
                if (fr[i] != uId)
                {
                    friendId = fr[i];
                }
            }
            query = "select exists(select FRIENDID from DBP.FRIENDLIST where ID ='" + uId + "' and FRIENDID = '" + friendId + "')as success";
            int check = DBManager.GetInstance().exists(query);
            if (check == 0)
            {
                noFriend = 1;
            }
            DBManager.GetInstance().insert("UPDATE CheckReceive SET checkRead=1 WHERE(roomId = " + rId + " AND userId = '" + uId + "');");
            moveRoom(chatName, noFriend);
        }

        public void moveRoom(string chatName, int checkFriend)
        {
            chattingRoom room = new chattingRoom(chatName, checkFriend);
            //chattingRoom room = new chattingRoom();
            room.Show();

        }



        private void ChatList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                thread_run = false;
                thread.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChatList_Show(int start)
        {
            for (int i = start; i < chatList.Rows.Count; i++)
            {
                getData(i);

                groupBoxBorder.WATGroupBox groupBox = new groupBoxBorder.WATGroupBox();
                groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                groupBox.Location = new Point(-1, 50 + 101 * i);
                groupBox.Tag = roomId.ToString() + "," + chatRoomName;
                groupBox.Click += new EventHandler(groupBoxChat_Enter);
                groupBox.Size = new Size(422, 130);
                groupBox.BorderColor = Color.Transparent;
                groupBox.Padding = new Padding(0);

                Label receiveCount = new Label();
                receiveCount.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                receiveCount.Enabled = false;
                receiveCount.Font = new Font("배달의민족 주아", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                receiveCount.Location = new Point(groupBox.Location.X + 270, groupBox.Location.Y + 95);
                receiveCount.Name = roomId.ToString() + "," + chatRoomName + "count";
                receiveCount.Size = new System.Drawing.Size(30, 30);

                upCountList[i] = count;

                if (count != 0)
                {
                    if (count > 99)
                    {
                        receiveCount.Text = "99+";
                    }
                    else
                    {
                        receiveCount.Text = count.ToString();
                        receiveCount.Visible = true;
                    }
                }
                else
                {
                    receiveCount.Text = "";
                    receiveCount.Visible = false;
                }
                receiveCount.ForeColor = System.Drawing.Color.Red;


                Label chatName = new Label();
                chatName.Text = chatRoomName;
                chatName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                chatName.Location = new Point(groupBox.Location.X + 86, groupBox.Location.Y + 29);
                chatName.Size = new System.Drawing.Size(244, 23);
                chatName.Font = new System.Drawing.Font("배달의민족 도현", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

                TextBox lastCon = new TextBox();
                lastCon.Text = lastContents;
                lastCon.Location = new Point(groupBox.Location.X + 90, groupBox.Location.Y + 55);
                lastCon.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                lastCon.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                lastCon.Multiline = true;
                lastCon.Size = new System.Drawing.Size(293, 47);
                lastCon.ReadOnly = true;
                lastCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
                lastCon.ForeColor = System.Drawing.SystemColors.WindowFrame;
                lastCon.Enabled = false;
                lastCon.Name = roomId.ToString() + "," + chatRoomName + "tb";

                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new System.Drawing.Point(groupBox.Location.X + 5, groupBox.Location.Y + 27);
                pictureBox.Size = new System.Drawing.Size(70, 70);
                pictureBox.TabStop = false;
                pictureBox.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));


                this.Controls.Add(receiveCount);
                this.Controls.Add(pictureBox);
                this.Controls.Add(lastCon);
                this.Controls.Add(chatName);
                this.Controls.Add(groupBox);

            }
        }

        private void ChatList_Load(object sender, EventArgs e)
        {
            receiveList();
            upCountList = new int[chatList.Rows.Count];
            for (int i = 0; i < chatList.Rows.Count; i++)
            {
                getData(i);

                groupBoxBorder.WATGroupBox groupBox = new groupBoxBorder.WATGroupBox();
                groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                groupBox.Location = new Point(-1, 50 + 101 * i);
                groupBox.Tag = roomId.ToString() + "," + chatRoomName;
                groupBox.Click += new EventHandler(groupBoxChat_Enter);
                groupBox.Size = new Size(422, 130);
                groupBox.BorderColor = Color.Transparent;
                groupBox.Padding = new Padding(0);

                Label receiveCount = new Label();
                receiveCount.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                receiveCount.Enabled = false;
                receiveCount.Font = new Font("배달의민족 주아", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                receiveCount.Location = new Point(groupBox.Location.X + 270, groupBox.Location.Y + 95);
                receiveCount.Name = roomId.ToString() + "," + chatRoomName + "count";
                receiveCount.Size = new System.Drawing.Size(30, 30);

                upCountList[i] = count;

                if (count != 0)
                {
                    if (count > 99)
                    {
                        receiveCount.Text = "99+";
                    }
                    else
                    {
                        receiveCount.Text = count.ToString();
                        receiveCount.Visible = true;
                    }
                }
                else
                {
                    receiveCount.Text = "";
                    receiveCount.Visible = false;
                }
                receiveCount.ForeColor = System.Drawing.Color.Red;


                Label chatName = new Label();
                chatName.Text = chatRoomName;
                chatName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                chatName.Location = new Point(groupBox.Location.X + 86, groupBox.Location.Y + 29);
                chatName.Size = new System.Drawing.Size(244, 23);
                chatName.Font = new System.Drawing.Font("배달의민족 도현", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

                TextBox lastCon = new TextBox();
                lastCon.Text = lastContents;
                lastCon.Location = new Point(groupBox.Location.X + 90, groupBox.Location.Y + 55);
                lastCon.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
                lastCon.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                lastCon.Multiline = true;
                lastCon.Size = new System.Drawing.Size(293, 47);
                lastCon.ReadOnly = true;
                lastCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
                lastCon.ForeColor = System.Drawing.SystemColors.WindowFrame;
                lastCon.Enabled = false;
                lastCon.Name = roomId.ToString() + "," + chatRoomName + "tb";

                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new System.Drawing.Point(groupBox.Location.X + 5, groupBox.Location.Y + 27);
                pictureBox.Size = new System.Drawing.Size(70, 70);
                pictureBox.TabStop = false;
                pictureBox.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));


                this.Controls.Add(receiveCount);
                this.Controls.Add(pictureBox);
                this.Controls.Add(lastCon);
                this.Controls.Add(chatName);
                this.Controls.Add(groupBox);

            }
            thread_run = true;
            thread = new Thread(new ThreadStart(run));
            thread.IsBackground = true;
            thread.Start();
        }

        private void run()
        {
            while (true)
            {

                receiveList();

                if (chatList.Rows.Count != upCountList.Length)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        countNew = new int[upCountList.Length + 1];
                        for (int i = 0; i < upCountList.Length; i++)
                        {
                            countNew[i] = upCountList[i];
                        }
                        countNew[upCountList.Length] = 0;
                        upCountList = countNew;
                        ChatList_Show(upCountList.Length-1);
                    });
                }

                for (int i = 0; i < chatList.Rows.Count; i++)
                {
                    getData(i);
                    if (count != upCountList[i])
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (chatHistory != null)
                            {
                                PopupNotifier popup = new PopupNotifier();
                                popup.TitleText = "ON_OFF";
                                popup.ContentText = "메시지가 도착했습니다.";
                                popup.Popup();// show  
                            }
                        });
                    }
                    TextBox txt = null;
                    if (this.Controls.ContainsKey(roomId.ToString() + "," + chatRoomName + "tb"))
                    {
                        txt = this.Controls[roomId.ToString() + "," + chatRoomName + "tb"] as TextBox;

                        txt.Invoke((MethodInvoker)delegate
                        {
                            if (txt != null)
                                txt.Text = lastContents;
                        });

                    }
                    Label la = null;
                    if (this.Controls.ContainsKey(roomId.ToString() + "," + chatRoomName + "count"))
                    {
                        la = this.Controls[roomId.ToString() + "," + chatRoomName + "count"] as Label;
                        if (la.InvokeRequired == true)
                        {
                            la.Invoke((MethodInvoker)delegate
                            {
                                if (count == 0)
                                {
                                    la.Text = "";
                                    la.Visible = false;
                                }
                                else
                                {
                                    la.Text = count.ToString();
                                    la.Visible = true;
                                    if (count > 99)
                                    {
                                        la.Text = "99+";
                                    }
                                }

                            });
                        }
                    }
                    upCountList[i] = count;
                }

                Thread.Sleep(100);
            }

        }

    }
}