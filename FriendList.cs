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
    public partial class FriendList : Form
    {
        public string login_id = ClientData.ID;

        public FriendList()
        {
            InitializeComponent();
        }
        
        private void FriendList_Load_1(object sender, EventArgs e)
        {
            createFriendItems();
            createUserItem();
        }

        private void createUserItem()
        {
            UserControl1 listItem = new UserControl1();

            listItem.nick = Friend.Friend_search(login_id, "별명");
            listItem.state = Friend.Friend_search(login_id, "상태메세지");
            byte[] img = Friend.image(login_id);
            if(img == null)
            {
                listItem.Icon = Properties.Resources.imoji1;
            }
            else
            {
                listItem.Icon = imageBt.read_imagebyte(img);
            }
            

            panel1.Controls.Add(listItem);
            listItem.Click += new EventHandler(change_profile);
        }

        public void change_profile(object sender, EventArgs e)
        {
            changeData changeprofile = new changeData();
            changeprofile.ShowDialog();
            panel1.Controls.Clear();
            createUserItem();
        }

        private void createFriendItems()
        {
            int count = Friend.check_Friend_count(login_id);

            string[] Friend_info = Friend.Friend_info(count, login_id);
            UserControl1[] listItems = new UserControl1[count]; 
            
            for (int i = 0; i < count; i++)
            {

                listItems[i] = new UserControl1();

                string id = Friend_info[i];
                listItems[i].Id = id; 

                byte[] img = Friend.image(Friend_info[i]);
                if (img == null)
                {
                    listItems[i].Icon = Properties.Resources.imoji1;
                }
                else
                {
                    listItems[i].Icon = imageBt.read_imagebyte(img);
                }

                listItems[i].Uname = Friend.Friend_search(id, "이름");
                listItems[i].state = Friend.Friend_search(id, "상태메세지");
                listItems[i].nick = Friend.Friend_search(id, "별명");

                flowLayoutPanel1.Controls.Add(listItems[i]);
                listItems[i].Cursor = Cursors.Hand;
                listItems[i].Click += new EventHandler(view_detail);
            }
           
        }

        public void view_detail(object sender, EventArgs e)
        {
            delete_FriendForm Friend_detail = new delete_FriendForm(sender,login_id);
            Friend_detail.ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createFriendItems();
        }

        public void search_friend()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(UserControl1))
                {
                    UserControl1 targetf = (UserControl1)c;
                    if (!targetf.nick.Contains(textBoxSearchFriend.Text))
                    {
                        flowLayoutPanel1.Controls.Remove(c);
                    }
                }
            }
            
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(UserControl1))
                {
                    UserControl1 targetf = (UserControl1)c;
                    if (!targetf.nick.Contains(textBoxSearchFriend.Text))
                    {
                        flowLayoutPanel1.Controls.Remove(c);
                    }
                }
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(UserControl1))
                {
                    UserControl1 targetf = (UserControl1)c;
                    if (!targetf.nick.Contains(textBoxSearchFriend.Text))
                    {
                        flowLayoutPanel1.Controls.Remove(c);
                    }
                }
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(UserControl1))
                {
                    UserControl1 targetf = (UserControl1)c;
                    if (!targetf.nick.Contains(textBoxSearchFriend.Text))
                    {
                        flowLayoutPanel1.Controls.Remove(c);

                    }
                }
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(UserControl1))
                {
                    UserControl1 targetf = (UserControl1)c;
                    if (!targetf.nick.Contains(textBoxSearchFriend.Text))
                    {
                        flowLayoutPanel1.Controls.Remove(c);

                    }
                }
            }
            

        }
        private void pictureBoxClick_Click(object sender, EventArgs e)
        {
            search_friend();
        }

        private void serchTextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchFriend.Text == "")
            {
                flowLayoutPanel1.Controls.Clear();
                createFriendItems();
            }
        }
   
        private void button_addFriend_Click(object sender, EventArgs e)
        {
            
            add_FriendForm add_FriendForm = new add_FriendForm(login_id);
            add_FriendForm.ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createFriendItems();
        }

        private void FriendList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_option_Click(object sender, EventArgs e)
        {
            changeMemInfo changeMemInfo = new changeMemInfo();
            changeMemInfo.ShowDialog();
            panel1.Controls.Clear();
            createUserItem();
        }

        private void button__Click(object sender, EventArgs e)
        {
            int count = Friend.check_Friend_count(login_id);
            if(count == 0)
            {
                MessageBox.Show("등록된 친구가 없습니다");
            }
            else
            {
                recommend_Friend recommend_Friend = new recommend_Friend();
                recommend_Friend.ShowDialog();
            }
            flowLayoutPanel1.Controls.Clear();
            createFriendItems();
        }

        private void TabChatList_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ChatList cl = new ChatList();
            
            cl.Show();
        }

        private void TabAddFriends_Click(object sender, EventArgs e)
        {
            add_FriendForm add_FriendForm = new add_FriendForm(login_id);
            add_FriendForm.ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createFriendItems();
        }

        private void TabSetting_Click(object sender, EventArgs e)
        {
            bgcForm bf = new bgcForm();
            bf.ShowDialog();
        }
    }
}
