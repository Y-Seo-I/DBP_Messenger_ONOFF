
namespace on_off_proj
{
    partial class delete_FriendForm
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
            this.pictureBox_image = new on_off_proj.RoundPictureBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.EnterChatroomButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Nickname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.Location = new System.Drawing.Point(90, 27);
            this.pictureBox_image.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(187, 180);
            this.pictureBox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_image.TabIndex = 0;
            this.pictureBox_image.TabStop = false;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(197, 246);
            this.label_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(22, 18);
            this.label_ID.TabIndex = 3;
            this.label_ID.Text = "ID";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(197, 287);
            this.label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(44, 18);
            this.label_Name.TabIndex = 4;
            this.label_Name.Text = "이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 246);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 287);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "이름";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(223, 372);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(94, 27);
            this.button_delete.TabIndex = 7;
            this.button_delete.Text = "친구삭제";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // EnterChatroomButton
            // 
            this.EnterChatroomButton.Location = new System.Drawing.Point(73, 372);
            this.EnterChatroomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnterChatroomButton.Name = "EnterChatroomButton";
            this.EnterChatroomButton.Size = new System.Drawing.Size(94, 27);
            this.EnterChatroomButton.TabIndex = 8;
            this.EnterChatroomButton.Text = "채팅방 입장";
            this.EnterChatroomButton.UseVisualStyleBackColor = true;
            this.EnterChatroomButton.Click += new System.EventHandler(this.EnterChatroomButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 325);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "별명";
            // 
            // label_Nickname
            // 
            this.label_Nickname.AutoSize = true;
            this.label_Nickname.Location = new System.Drawing.Point(197, 325);
            this.label_Nickname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Nickname.Name = "label_Nickname";
            this.label_Nickname.Size = new System.Drawing.Size(44, 18);
            this.label_Nickname.TabIndex = 10;
            this.label_Nickname.Text = "별명";
            // 
            // delete_FriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 465);
            this.Controls.Add(this.label_Nickname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnterChatroomButton);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.pictureBox_image);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "delete_FriendForm";
            this.Text = "친구 상세정보";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox pictureBox_image;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button EnterChatroomButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Nickname;
    }
}
