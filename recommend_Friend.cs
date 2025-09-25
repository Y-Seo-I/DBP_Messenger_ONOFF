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
    public partial class recommend_Friend : Form
    {
        public string login_id = ClientData.ID;

        public recommend_Friend()
        {
            InitializeComponent();
        }

        private void recommend_Friend_Load(object sender, EventArgs e)
        {
            createFriendItems();
        }

        private void createFriendItems()
        {
            string[] temp = null;
            int count = Friend.check_Friend_count(login_id);
            string[] Friend_info = Friend.Friend_info(count, login_id);
            for (int i = 0; i < count; i++)
            {
                //string[] temp2;
                int count2 = Friend.check_Friend_count(Friend_info[i]);
                string[] Friend_info2 = Friend.Friend_info(count2, Friend_info[i]);
                if(i == 0)
                {
                    temp = (string[])Friend_info2.Clone();
                }
                else
                {
                    string[] temp2 = (string[])temp.Clone();
                    Array.Resize(ref temp, temp2.Length + Friend_info2.Length);
                    Array.Copy(Friend_info2, 0, temp, temp2.Length, Friend_info2.Length);
                    temp2 = null;
                }
            }

            List<string> tmp = new List<string>();
            for(int i = 0; i<temp.Length; i++)
            {
                
                if (tmp.Contains(temp[i]))
                {
                    continue;
                }
                
                if (temp[i] == login_id)
                {
                    continue;
                }
                
                if (Friend_info.Contains(temp[i]))
                {
                    continue;
                }
                tmp.Add(temp[i]);
            }

            string[] re = new string[] { };
            re = tmp.ToArray();

            UserControl1[] listItems = new UserControl1[re.Length];

            for (int i = 0; i < re.Length; i++)
            {
                listItems[i] = new UserControl1();

                string id = re[i];
                listItems[i].Id = id;

                byte[] img = Friend.image(re[i]);
                if (img == null)
                {
                    listItems[i].Icon = Properties.Resources.imoji1;
                }
                else
                {
                    listItems[i].Icon = imageBt.read_imagebyte(img);
                }

                
                listItems[i].nick = Friend.Friend_search(id, "별명");
                listItems[i].Uname = Friend.Friend_search(id, "이름");
                listItems[i].state = Friend.Friend_search(id, "상태메세지");

                Panel1.Controls.Add(listItems[i]);
                listItems[i].Cursor = Cursors.Hand;
                listItems[i].Click += new EventHandler(view_detail);
            }
        }
        public void view_detail(object sender, EventArgs e)
        {
            insert_FriendForm Friend_detail = new insert_FriendForm(sender);
            Friend_detail.ShowDialog();
            Panel1.Controls.Clear();
            createFriendItems();
        }
    }
}
