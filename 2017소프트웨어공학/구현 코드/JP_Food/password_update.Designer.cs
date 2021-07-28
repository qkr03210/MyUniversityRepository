namespace JP_Food
{
    partial class password_update
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
            this.label2 = new System.Windows.Forms.Label();
            this.firstpw_textBox = new System.Windows.Forms.TextBox();
            this.updatepw_textBox = new System.Windows.Forms.TextBox();
            this.update_button = new System.Windows.Forms.Button();
            this.cancle_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "기존 비밀번호 입력";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "새로운 비밀번호 입력";
            // 
            // firstpw_textBox
            // 
            this.firstpw_textBox.Location = new System.Drawing.Point(152, 26);
            this.firstpw_textBox.Name = "firstpw_textBox";
            this.firstpw_textBox.PasswordChar = '*';
            this.firstpw_textBox.Size = new System.Drawing.Size(186, 21);
            this.firstpw_textBox.TabIndex = 2;
            // 
            // updatepw_textBox
            // 
            this.updatepw_textBox.Location = new System.Drawing.Point(152, 53);
            this.updatepw_textBox.Name = "updatepw_textBox";
            this.updatepw_textBox.PasswordChar = '*';
            this.updatepw_textBox.Size = new System.Drawing.Size(186, 21);
            this.updatepw_textBox.TabIndex = 3;
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(178, 102);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(75, 23);
            this.update_button.TabIndex = 4;
            this.update_button.Text = "변경";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // cancle_button
            // 
            this.cancle_button.Location = new System.Drawing.Point(263, 102);
            this.cancle_button.Name = "cancle_button";
            this.cancle_button.Size = new System.Drawing.Size(75, 23);
            this.cancle_button.TabIndex = 5;
            this.cancle_button.Text = "취소";
            this.cancle_button.UseVisualStyleBackColor = true;
            this.cancle_button.Click += new System.EventHandler(this.cancle_button_Click);
            // 
            // password_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 137);
            this.Controls.Add(this.cancle_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.updatepw_textBox);
            this.Controls.Add(this.firstpw_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "password_update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "password_update";
            this.Load += new System.EventHandler(this.password_update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstpw_textBox;
        private System.Windows.Forms.TextBox updatepw_textBox;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button cancle_button;
    }
}