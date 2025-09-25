using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace on_off_proj
{
    public partial class chattingRoom : Form
    {
        private string filepath;
        DataTable roomHistory = new DataTable();
        DataTable roomcheck = new DataTable();
        UInt32 FileSize;
        byte[] rawData, saveData;
        FileStream fs;
        string filePath;
        string userId;
        int rowCount = 0;
        int open = 0;
        string name;
        int checkFriend;
        int allCount = 1;
        string namebuf = "";

        public chattingRoom()
        {
            receiveList();
            InitializeComponent();
            userId = DBManager.GetInstance().getUserId();
            setBgc(); //배경 색 설정
            initChatContents();
            Thread receive = new Thread(receiveList2);
            receive.IsBackground = true;
            receive.Start();
            this.Size = new Size(431, 700);

        }

        public chattingRoom(string info, int checkFriend_)
        {
            string[] infoList = info.Split(',');
            
            userId = DBManager.GetInstance().getUserId();
            open = Convert.ToInt32(infoList[0]);
            checkFriend = checkFriend_;
            
            receiveList();
            InitializeComponent();
            initChatContents();
            if (checkFriend == 1)
            {
                MessageBox.Show("친구가 아닌 사용자입니다. 채팅에 주의하세요.");
            }
            Thread receive = new Thread(receiveList2);
            receive.IsBackground = true;
            receive.Start();
            for (int i = 1; i < infoList.Length; i++)
            {
                if (i == infoList.Length - 1)
                    namebuf += infoList[i];
                else
                    namebuf += infoList[i] + ", ";
            }
            userName.Text = namebuf;
            //배경 색 설정
            setBgc();
            string query = "SELECT contents,userId,contentsType from DBP.Chat_History where userId like '%" + userId + "%' and roomId = " + open;
            roomHistory = DBManager.GetInstance().select(query);
            chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            this.Size = new Size(431, 700);
        }

        public void find(string findText)
        {
            if (findText != "")
            {
                for (int i = 1; i <= allCount; i++)
                {
                    foreach (Control p in this.Controls.Find("bubble" + i.ToString(), true))
                    {
                        Console.WriteLine(p.Name);
                        for (int j = 1; j <= allCount; j++)
                        {
                            foreach (Control ps in p.Controls)
                            {

                                foreach (Control pl in ps.Controls)
                                {
                                    if (pl.GetType() == typeof(Label))
                                    {
                                        if (!pl.Text.Contains(findText))
                                        {
                                            chatPanel.Controls.Remove(p);
                                        }
                                    }
                                }
                                if (ps.GetType() == typeof(PictureBox))
                                {
                                    chatPanel.Controls.Remove(p);
                                }

                            }
                        }

                    }
                }

            }
        }
        //배경색 전환
        public void setBgc()
        {
            string query = "Select bgColor From DBP.on_off where ID=\'" + userId + "\';";
            DataTable back = DBManager.GetInstance().select(query);
            string color = back.Rows[0]["bgColor"].ToString();

                    if (color == "#FAFAD2")
            {
                chatPanel.BackColor = Color.LightGoldenrodYellow;
            }
                        
                    else if (color.Contains("#FFE3EE"))
            {
                chatPanel.BackColor = Color.FromArgb(255, 227, 238);
            }
                        
                    else if (color == "C8FFFF")
            {
                chatPanel.BackColor = Color.FromArgb(200, 255, 255);
            }
            else
            {
                chatPanel.BackColor = Color.White;
            }
        }

        private void receiveList()
        {
            string query = "SELECT * FROM ";
            string queryHis = "SELECT contents,userId,contentsType FROM ";
            string whereLike = "WHERE (userId like '%" + userId + "%')";
            string where = "WHERE (userId = '" + userId + "')";
            //chatList = DBManager.GetInstance().select(query + "Chat_list " + whereLike + "ORDER BY roomId;");
            roomcheck = DBManager.GetInstance().select(query + "CheckReceive " + where);
            roomHistory = DBManager.GetInstance().select(queryHis + "DBP.Chat_History where roomId = " + open);
            //on_off_userList = DBManager.GetInstance().select(query + "on_off;");
            //checkReceive = DBManager.GetInstance().select(query + "Chat_list " + where);
        }
        private void receiveList2()
        {
            while (true)
            {
                receiveList();
                secondChatContents();
            }


        }

        private void initChatContents()
        {
            if (roomHistory != null)
            {
                int count = roomHistory.Rows.Count;
                rowCount = count;
                for (int i = 0; i < count; i++)
                {
                    int check = Convert.ToInt32(roomHistory.Rows[i]["contentsType"].ToString());
                    string contents = roomHistory.Rows[i]["contents"].ToString();
                    // 상대방한테 온거라면
                    if (roomHistory.Rows[i]["userId"].ToString() != userId)
                    {
                        //text라면
                        if (check == 0)
                            AddIncomming(contents, 0, 0);
                        //이모티콘 
                        else if (check == 1)
                        {
                            AddIncomming(contents, 0, 1);
                        }
                        //파일이라면
                        else if (check == 2)
                        {
                            AddIncomming(contents, 1, 0);
                            filepath = contents;
                            //saveData = (Byte[])(roomHistory.Rows[i]["zipFile"]);
                        }
                    }
                    // 내가 보낸 거라면
                    else
                    {
                        // txt 보낸 거였다면
                        if (check == 0)
                        {
                            AddOutGoing(contents, 0, 0);
                        }
                        else if (check == 1)
                        {
                            AddOutGoing(contents, 0, 1);
                        }
                        // 파일 보낸 거였다면
                        else if (check == 2)
                        {
                            AddOutGoing(contents, 1, 0);
                            filepath = contents;
                            //saveData = (Byte[])(roomHistory.Rows[i]["zipFile"]);
                        }

                    }


                }
            }
        }

        private void secondChatContents()
        {
            if (roomHistory != null)
            {
                int count = roomHistory.Rows.Count;
                for (int i = rowCount; i < count; i++)
                {
                    int check = Convert.ToInt32(roomHistory.Rows[i]["contentsType"].ToString());
                    string contents = roomHistory.Rows[i]["contents"].ToString();
                    // 상대방한테 온거라면
                    if (roomHistory.Rows[i]["userId"].ToString() != userId)
                    {
                        //text라면
                        if (check == 0)
                            AddIncomming(contents, 0, 0);
                        else if (check == 1)
                        {
                            AddIncomming(contents, 0, 1);
                        }
                        //파일이라면
                        else if (check == 2)
                        {
                            AddIncomming(contents, 1, 0);
                            filepath = contents;
                            //saveData = (Byte[])(roomHistory.Rows[i]["zipFile"]);
                        }
                    }
                    // 내가 보낸 거라면
                    else
                    {
                        // txt 보낸 거였다면
                        if (check == 0)
                            AddOutGoing(contents, 0, 0);
                        //emoji
                        if (check == 1)
                        {
                            AddOutGoing(contents, 0, 1);
                        }
                        // 파일 보낸 거였다면
                        if (check == 2)
                        {
                            AddOutGoing(contents, 1, 0);

                            filepath = contents;
                            //saveData = (Byte[])(roomHistory.Rows[i]["zipFile"]);
                        }
                    }

                }
                rowCount = count;
            }
        }

        private void sendMessege_Click(object sender, EventArgs e)
        {
            store();
            textBoxChatContents.Text = string.Empty;
            //Send();
        }

        int curTop = 10;

        void AddIncomming(string message, int check, int emo_check)
        {
            var bubble = new ChatItems.inComming();
            bubble.Name = "bubble" + allCount.ToString();
            allCount++;
            if (check == 0)
            {
                bubble.Enabled = false;
            }

            
            if (chatPanel.InvokeRequired == true)
            {
                chatPanel.Invoke((MethodInvoker)delegate
                {
                    //이모티콘 전송시 출력
                    if (emo_check == 1)
                    {
                        InemojiBubble(message);
                    } //일반 문자열 메시지 전송 시 실행
                    else
                    {
                        chatPanel.Controls.Add(bubble);
                        bubble.BringToFront();
                        bubble.Dock = DockStyle.Top;
                        bubble.message = message;

                        
                    }
                    curTop += bubble.Height;
                    chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
                });
            }
            else
            {
                if (emo_check == 1)
                {
                    InemojiBubble(message);

                } //일반 문자열 메세지 전송 시 실행
                else
                {
                    chatPanel.Controls.Add(bubble);
                    bubble.BringToFront();
                    bubble.Dock = DockStyle.Top;
                    bubble.message = message;

                    if (check == 1)
                    {
                        bubble.Click += new EventHandler(saveFiles);
                        //bubble.Click += saveFile;
                    }
                }

                curTop += bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            }
        }

        void InemojiBubble(string message)
        {
            var emo_bubble = new ChatItems.inCommImo(); //이모티콘
            emo_bubble.Name = "bubble" + allCount.ToString();
            allCount++;
            chatPanel.Controls.Add(emo_bubble);
            emo_bubble.BringToFront();
            emo_bubble.Dock = DockStyle.Top;
            if (message == "(emoji1)")
            {
                emo_bubble.emoji = Properties.Resources.imoji1;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            }
            else if (message == "(emoji2)")
            {
                emo_bubble.emoji = Properties.Resources.imoji2;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji3)")
            {
                emo_bubble.emoji = Properties.Resources.imoji3;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji4)")
            {
                emo_bubble.emoji = Properties.Resources.imoji4;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji5)")
            {
                emo_bubble.emoji = Properties.Resources.imoji5;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji6)")
            {
                emo_bubble.emoji = Properties.Resources.imoji6;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            }
        }

        void AddOutGoing(string message, int check, int emo_check)
        {
            var bubble = new ChatItems.outGoing();
            bubble.Name = "bubble" + allCount.ToString();
            allCount++;
            if (check == 0)
            {
                bubble.Enabled = false;
            }

            if (chatPanel.InvokeRequired == true)
            {

                chatPanel.Invoke((MethodInvoker)delegate
                {
                    //이모티콘 일 때
                    if (emo_check == 1)
                    {
                        outEmojiBubble(message);
                    }
                    else
                    {
                        chatPanel.Controls.Add(bubble);
                        bubble.BringToFront();
                        bubble.Dock = DockStyle.Top;
                        bubble.message = message;

                        curTop += bubble.Height;
                        chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
                    }
                });
            }
            else
            {
                if (emo_check == 1)
                {
                    outEmojiBubble(message);
                }
                else
                {
                    chatPanel.Controls.Add(bubble);
                    bubble.BringToFront();
                    bubble.Dock = DockStyle.Top;
                    bubble.message = message;

                    curTop += bubble.Height;
                    chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

                    if (check == 1)
                    {
                        bubble.Click += new EventHandler(saveFiles);
                       // bubble.Click += saveFiles;
                    }
                }
            }

        }

        void outEmojiBubble(string message)
        {
            var emo_bubble = new ChatItems.outGoImo(); //이모티콘 보내는 사람 메세지
            emo_bubble.Name = "bubble" + allCount.ToString();
            allCount++;
            chatPanel.Controls.Add(emo_bubble);
            emo_bubble.BringToFront();
            emo_bubble.Dock = DockStyle.Top;
            if (message == "(emoji1)")
            {
                emo_bubble.emoji = Properties.Resources.imoji1;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            }
            else if (message == "(emoji2)")
            {
                emo_bubble.emoji = Properties.Resources.imoji2;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji3)")
            {
                emo_bubble.emoji = Properties.Resources.imoji3;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji4)")
            {
                emo_bubble.emoji = Properties.Resources.imoji4;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji5)")
            {
                emo_bubble.emoji = Properties.Resources.imoji5;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;

            }
            else if (message == "(emoji6)")
            {
                emo_bubble.emoji = Properties.Resources.imoji6;
                curTop += emo_bubble.Height;
                chatPanel.VerticalScroll.Value = chatPanel.VerticalScroll.Maximum;
            }
        }

        void Send()
        {
            /*if (textBoxChatContents.Text.Trim().Length == 0) return;

            AddOutGoing(textBoxChatContents.Text);
            textBoxChatContents.Text = string.Empty;*/
        }

        public void Receive()
        {
            string query = "select contents, contentsType from DBP.Chat_History where roomId = " + open + "and userId not in('" + userId + "')";
            DataTable db = DBManager.GetInstance().select(query);
            int count = db.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int type = Convert.ToInt32(db.Rows[i]["contentsType"].ToString());
                if (type == 0)
                    AddIncomming(db.Rows[i]["contents"].ToString(), 0, 0);
                // 이모티콘
                else if (type == 1)
                {
                    AddOutGoing(db.Rows[i]["contents"].ToString(), 0, 1);
                }
                // 파일
                else
                {
                    AddIncomming(db.Rows[i]["contents"].ToString(), 0, 1);
                    filepath = db.Rows[i]["contents"].ToString();
                    //saveData = (Byte[])(db.Rows[i]["zipFile"]);
                    //AddIncomming(db.Rows[i]["zipFile"].ToString());
                }

            }
        }
        public void store()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string contents = textBoxChatContents.Text;
            string query = "insert into DBP.Chat_History(roomId, userId, timeStamp, contents, contentsType) VALUES (" + open + ",'" + userId + "','" + date + "','" + contents + "', 0)";
            DBManager.GetInstance().insert(query);
        }

        private void chattingRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("enter");
            string query = "update DBP.CheckReceive set checkRead = " + 0 + ", timeStamp = '" + DateTime.Now.ToString("yyyy-M-dd HH:mm:ss") +
                "' where userId = '" + userId + "' AND roomId = " + open + ";";
            DBManager.GetInstance().insert(query);
        }

        private void TabFriendsList_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
                MessageBox.Show(filePath);
            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string msg = filePath + "전송 완료";
           // AddOutGoing(msg, 1, 0);
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string contents = filePath;
            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileSize = (uint)fs.Length;
            rawData = new byte[FileSize];
            fs.Read(rawData, 0, (int)FileSize);
            fs.Close();

            string query = "insert into DBP.Chat_History VALUES (" + open + ",'" + userId + "','" + date + "','" + msg + "',@zipFile, 2)";
            DBManager.GetInstance().insertFile(query, rawData);

            /*fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileSize = (uint)fs.Length;
            rawData = new byte[FileSize];
            fs.Read(rawData, 0, (int)FileSize);
            fs.Close();*/
        }

        //이모티콘 버튼 클릭
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            //같은 폼이 2개이상 뜨지않도록 처리
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "emojiForm")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    openForm.Activate();
                    return;
                }
            }
            emojiForm emf = new emojiForm(open);
            emf.Show();

        }

        private void pictureBoxClick_Click(object sender, EventArgs e)
        {
            if(textBoxSearchText.Text == "")
            {
                    receiveList();
                    InitializeComponent();
                    setBgc();
                    userName.Text = namebuf;
                    initChatContents();
                    this.Size = new Size(431, 700);
            }
            else
            {
                find(textBoxSearchText.Text);
            }
        }

       
        private void textBoxSearchText_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void saveFiles(object sender, EventArgs e)

        {
            MessageBox.Show("파일 로딩 중입니다.(최대 1분)");
            string query = "select zipFile from DBP.Chat_History where contents = '" + filepath + "'";
            DataTable zip = DBManager.GetInstance().select(query);
            saveData = (Byte[])(zip.Rows[0]["zipFile"]);
            saveFile saveFile = new saveFile(saveData);
            saveFile.ShowDialog();

        }

    }
}