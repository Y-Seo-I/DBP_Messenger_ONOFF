
namespace on_off_proj
{
    partial class add_FriendForm
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
            this.textBox_FriendID = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_FriendID
            // 
            this.textBox_FriendID.Location = new System.Drawing.Point(37, 42);
            this.textBox_FriendID.Name = "textBox_FriendID";
            this.textBox_FriendID.Size = new System.Drawing.Size(100, 25);
            this.textBox_FriendID.TabIndex = 0;
            this.textBox_FriendID.Text = "친구메신저ID";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(159, 41);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(62, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "추가";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // add_FriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 109);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_FriendID);
            this.Name = "add_FriendForm";
            this.Text = "친구추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_FriendID;
        private System.Windows.Forms.Button button_add;
    }
}