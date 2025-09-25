namespace on_off_proj
{
    partial class chattingRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userName = new System.Windows.Forms.Label();
            this.textBoxChatContents = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxClick = new System.Windows.Forms.PictureBox();
            this.sendMessege = new on_off_proj.RoundPictureBox();
            this.textBoxSearchText = new System.Windows.Forms.TextBox();
            this.roundPictureBox1 = new on_off_proj.RoundPictureBox();
            this.TabFriendsList = new on_off_proj.RoundPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendMessege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabFriendsList)).BeginInit();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userName.Location = new System.Drawing.Point(96, 32);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(244, 42);
            this.userName.TabIndex = 4;
            this.userName.Text = "이름";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxChatContents
            // 
            this.textBoxChatContents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.textBoxChatContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChatContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxChatContents.Location = new System.Drawing.Point(-1, 58);
            this.textBoxChatContents.Margin = new System.Windows.Forms.Padding(40, 40, 0, 0);
            this.textBoxChatContents.Multiline = true;
            this.textBoxChatContents.Name = "textBoxChatContents";
            this.textBoxChatContents.Size = new System.Drawing.Size(517, 118);
            this.textBoxChatContents.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.pictureBoxUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 100);
            this.panel1.TabIndex = 19;
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUser.Location = new System.Drawing.Point(29, 22);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(61, 60);
            this.pictureBoxUser.TabIndex = 2;
            this.pictureBoxUser.TabStop = false;
            // 
            // chatPanel
            // 
            this.chatPanel.AutoScroll = true;
            this.chatPanel.BackColor = System.Drawing.Color.Transparent;
            this.chatPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatPanel.Location = new System.Drawing.Point(0, 100);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(513, 572);
            this.chatPanel.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.panel3.Controls.Add(this.pictureBoxClick);
            this.panel3.Controls.Add(this.sendMessege);
            this.panel3.Controls.Add(this.textBoxSearchText);
            this.panel3.Controls.Add(this.textBoxChatContents);
            this.panel3.Controls.Add(this.roundPictureBox1);
            this.panel3.Controls.Add(this.TabFriendsList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 672);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 176);
            this.panel3.TabIndex = 21;
            // 
            // pictureBoxClick
            // 
            this.pictureBoxClick.Image = global::on_off_proj.Properties.Resources.search_icon;
            this.pictureBoxClick.Location = new System.Drawing.Point(459, 12);
            this.pictureBoxClick.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxClick.Name = "pictureBoxClick";
            this.pictureBoxClick.Size = new System.Drawing.Size(47, 42);
            this.pictureBoxClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClick.TabIndex = 9;
            this.pictureBoxClick.TabStop = false;
            this.pictureBoxClick.Click += new System.EventHandler(this.pictureBoxClick_Click);
            // 
            // sendMessege
            // 
            this.sendMessege.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sendMessege.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.sendMessege.Image = global::on_off_proj.Properties.Resources.send;
            this.sendMessege.Location = new System.Drawing.Point(439, 112);
            this.sendMessege.Margin = new System.Windows.Forms.Padding(4);
            this.sendMessege.Name = "sendMessege";
            this.sendMessege.Size = new System.Drawing.Size(64, 50);
            this.sendMessege.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sendMessege.TabIndex = 17;
            this.sendMessege.TabStop = false;
            this.sendMessege.Click += new System.EventHandler(this.sendMessege_Click);
            // 
            // textBoxSearchText
            // 
            this.textBoxSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchText.Font = new System.Drawing.Font("굴림", 13F);
            this.textBoxSearchText.Location = new System.Drawing.Point(226, 18);
            this.textBoxSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearchText.Name = "textBoxSearchText";
            this.textBoxSearchText.Size = new System.Drawing.Size(220, 30);
            this.textBoxSearchText.TabIndex = 8;
            this.textBoxSearchText.TextChanged += new System.EventHandler(this.textBoxSearchText_TextChanged_1);
            // 
            // roundPictureBox1
            // 
            this.roundPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.roundPictureBox1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.roundPictureBox1.Image = global::on_off_proj.Properties.Resources.emoji;
            this.roundPictureBox1.Location = new System.Drawing.Point(74, 4);
            this.roundPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.roundPictureBox1.Name = "roundPictureBox1";
            this.roundPictureBox1.Size = new System.Drawing.Size(57, 50);
            this.roundPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox1.TabIndex = 16;
            this.roundPictureBox1.TabStop = false;
            this.roundPictureBox1.Click += new System.EventHandler(this.roundPictureBox1_Click);
            // 
            // TabFriendsList
            // 
            this.TabFriendsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabFriendsList.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.TabFriendsList.Image = global::on_off_proj.Properties.Resources.folder;
            this.TabFriendsList.Location = new System.Drawing.Point(1, 6);
            this.TabFriendsList.Margin = new System.Windows.Forms.Padding(4);
            this.TabFriendsList.Name = "TabFriendsList";
            this.TabFriendsList.Size = new System.Drawing.Size(64, 50);
            this.TabFriendsList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabFriendsList.TabIndex = 15;
            this.TabFriendsList.TabStop = false;
            this.TabFriendsList.Click += new System.EventHandler(this.TabFriendsList_Click);
            // 
            // chattingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 844);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chatPanel);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(535, 900);
            this.Name = "chattingRoom";
            this.Text = "chattingRoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chattingRoom_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendMessege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabFriendsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.TextBox textBoxChatContents;
        private RoundPictureBox TabFriendsList;
        private RoundPictureBox roundPictureBox1;
        private RoundPictureBox sendMessege;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxClick;
        private System.Windows.Forms.TextBox textBoxSearchText;
    }
}