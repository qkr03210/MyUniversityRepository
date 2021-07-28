namespace JP_Food
{
    partial class password_verify
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
            this.pw_textBox = new System.Windows.Forms.TextBox();
            this.verify_button = new System.Windows.Forms.Button();
            this.cancle_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "비밀번호 입력";
            // 
            // pw_textBox
            // 
            this.pw_textBox.Location = new System.Drawing.Point(99, 17);
            this.pw_textBox.Name = "pw_textBox";
            this.pw_textBox.PasswordChar = '*';
            this.pw_textBox.Size = new System.Drawing.Size(160, 21);
            this.pw_textBox.TabIndex = 1;
            // 
            // verify_button
            // 
            this.verify_button.Location = new System.Drawing.Point(109, 55);
            this.verify_button.Name = "verify_button";
            this.verify_button.Size = new System.Drawing.Size(75, 23);
            this.verify_button.TabIndex = 2;
            this.verify_button.Text = "확인";
            this.verify_button.UseVisualStyleBackColor = true;
            this.verify_button.Click += new System.EventHandler(this.verify_button_Click);
            // 
            // cancle_button
            // 
            this.cancle_button.Location = new System.Drawing.Point(190, 55);
            this.cancle_button.Name = "cancle_button";
            this.cancle_button.Size = new System.Drawing.Size(75, 23);
            this.cancle_button.TabIndex = 3;
            this.cancle_button.Text = "취소";
            this.cancle_button.UseVisualStyleBackColor = true;
            this.cancle_button.Click += new System.EventHandler(this.cancle_button_Click);
            // 
            // password_verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 90);
            this.Controls.Add(this.cancle_button);
            this.Controls.Add(this.verify_button);
            this.Controls.Add(this.pw_textBox);
            this.Controls.Add(this.label1);
            this.Name = "password_verify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "password_verify";
            this.Load += new System.EventHandler(this.password_verify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pw_textBox;
        private System.Windows.Forms.Button verify_button;
        private System.Windows.Forms.Button cancle_button;
    }
}