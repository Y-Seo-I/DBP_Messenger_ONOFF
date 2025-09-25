namespace on_off_proj
{
    partial class saveFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.OpenPathButton = new on_off_proj.CircleButton();
            this.cancelButton = new on_off_proj.CircleButton();
            this.saveFileButton = new on_off_proj.CircleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(146, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "저장할 파일의 경로를 설정해주세요.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxFilePath.Location = new System.Drawing.Point(10, 105);
            this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(462, 23);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // OpenPathButton
            // 
            this.OpenPathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.OpenPathButton.FlatAppearance.BorderSize = 0;
            this.OpenPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenPathButton.Location = new System.Drawing.Point(482, 92);
            this.OpenPathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenPathButton.Name = "OpenPathButton";
            this.OpenPathButton.Size = new System.Drawing.Size(52, 37);
            this.OpenPathButton.TabIndex = 7;
            this.OpenPathButton.TabStop = false;
            this.OpenPathButton.Text = "열기";
            this.OpenPathButton.UseVisualStyleBackColor = false;
            this.OpenPathButton.Click += new System.EventHandler(this.OpenPathButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(271, 157);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(74, 27);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.saveFileButton.FlatAppearance.BorderSize = 0;
            this.saveFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveFileButton.Location = new System.Drawing.Point(157, 157);
            this.saveFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(74, 27);
            this.saveFileButton.TabIndex = 5;
            this.saveFileButton.TabStop = false;
            this.saveFileButton.Text = "저장";
            this.saveFileButton.UseVisualStyleBackColor = false;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // saveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(543, 233);
            this.Controls.Add(this.OpenPathButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "saveFile";
            this.Text = "saveFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private CircleButton saveFileButton;
        private CircleButton cancelButton;
        private CircleButton OpenPathButton;
    }
}