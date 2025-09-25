
using System.Drawing;

namespace on_off_proj
{
    partial class signIn
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_Remember = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.singUpButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_Remember
            // 
            this.checkBox_Remember.AutoSize = true;
            this.checkBox_Remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox_Remember.Location = new System.Drawing.Point(98, 507);
            this.checkBox_Remember.Name = "checkBox_Remember";
            this.checkBox_Remember.Size = new System.Drawing.Size(99, 22);
            this.checkBox_Remember.TabIndex = 3;
            this.checkBox_Remember.Text = "자동 로그인";
            this.checkBox_Remember.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "PASSWORD";
            // 
            // button_login
            // 
            this.button_login.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button_login.FlatAppearance.BorderSize = 2;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Location = new System.Drawing.Point(293, 613);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(95, 58);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "On";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // singUpButton
            // 
            this.singUpButton.BackColor = System.Drawing.Color.Transparent;
            this.singUpButton.FlatAppearance.BorderSize = 0;
            this.singUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singUpButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.singUpButton.Location = new System.Drawing.Point(293, 502);
            this.singUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.singUpButton.Name = "singUpButton";
            this.singUpButton.Size = new System.Drawing.Size(86, 29);
            this.singUpButton.TabIndex = 9;
            this.singUpButton.Text = "회원가입";
            this.singUpButton.UseVisualStyleBackColor = false;
            this.singUpButton.Click += new System.EventHandler(this.singUpButton_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::on_off_proj.Properties.Resources.ID_Pass6;
            this.panel3.Controls.Add(this.textBox_id);
            this.panel3.Controls.Add(this.textBox_pw);
            this.panel3.Location = new System.Drawing.Point(98, 373);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 117);
            this.panel3.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBox_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_id.Location = new System.Drawing.Point(44, 17);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(221, 18);
            this.textBox_id.TabIndex = 0;
            // 
            // textBox_pw
            // 
            this.textBox_pw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.textBox_pw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_pw.Location = new System.Drawing.Point(44, 84);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(221, 18);
            this.textBox_pw.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BackgroundImage = global::on_off_proj.Properties.Resources.사진;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 312);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::on_off_proj.Properties.Resources.온오프프1;
            this.panel2.Location = new System.Drawing.Point(202, 242);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 67);
            this.panel2.TabIndex = 0;
            // 
            // signIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(413, 703);
            this.Controls.Add(this.singUpButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Remember);
            this.Controls.Add(this.button_login);
            this.MaximumSize = new System.Drawing.Size(434, 1508);
            this.Name = "signIn";
            this.Text = "On-off";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.CheckBox checkBox_Remember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button singUpButton;
    }
}

