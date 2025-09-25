
namespace on_off_proj
{
    partial class insert_FriendForm
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
            this.label_nickname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.Location = new System.Drawing.Point(72, 22);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(150, 150);
            this.pictureBox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_image.TabIndex = 0;
            this.pictureBox_image.TabStop = false;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(158, 205);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(20, 15);
            this.label_ID.TabIndex = 3;
            this.label_ID.Text = "ID";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(158, 240);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(37, 15);
            this.label_Name.TabIndex = 4;
            this.label_Name.Text = "이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "이름";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(103, 306);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 7;
            this.button_delete.Text = "친구추가";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label_nickname
            // 
            this.label_nickname.AutoSize = true;
            this.label_nickname.Location = new System.Drawing.Point(158, 272);
            this.label_nickname.Name = "label_nickname";
            this.label_nickname.Size = new System.Drawing.Size(37, 15);
            this.label_nickname.TabIndex = 8;
            this.label_nickname.Text = "별명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "별명";
            // 
            // insert_FriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 387);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_nickname);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.pictureBox_image);
            this.Name = "insert_FriendForm";
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
        private System.Windows.Forms.Label label_nickname;
        private System.Windows.Forms.Label label4;
    }
}