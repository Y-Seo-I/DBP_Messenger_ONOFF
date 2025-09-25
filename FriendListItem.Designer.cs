
namespace on_off_proj
{
    partial class UserControl1
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Nickname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_statemessage = new System.Windows.Forms.Label();
            this.roundPictureBox1 = new on_off_proj.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.Location = new System.Drawing.Point(82, 37);
            this.Nickname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(55, 18);
            this.Nickname.TabIndex = 1;
            this.Nickname.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1812, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label_statemessage
            // 
            this.label_statemessage.AutoSize = true;
            this.label_statemessage.Location = new System.Drawing.Point(181, 37);
            this.label_statemessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_statemessage.Name = "label_statemessage";
            this.label_statemessage.Size = new System.Drawing.Size(62, 18);
            this.label_statemessage.TabIndex = 3;
            this.label_statemessage.Text = "STATE";
            // 
            // roundPictureBox1
            // 
            this.roundPictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.roundPictureBox1.Location = new System.Drawing.Point(10, 12);
            this.roundPictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roundPictureBox1.Name = "roundPictureBox1";
            this.roundPictureBox1.Size = new System.Drawing.Size(64, 67);
            this.roundPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPictureBox1.TabIndex = 0;
            this.roundPictureBox1.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_statemessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.roundPictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(368, 89);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox roundPictureBox1;
        private System.Windows.Forms.Label Nickname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_statemessage;
    }
}
