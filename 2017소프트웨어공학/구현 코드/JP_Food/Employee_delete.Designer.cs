namespace JP_Food
{
    partial class Employee_delete
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
            this.name_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.jumin_textBox = new System.Windows.Forms.TextBox();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.phone_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(25, 26);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(29, 12);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "주민번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "전화번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "주소";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(90, 23);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(135, 21);
            this.name_textBox.TabIndex = 4;
            // 
            // jumin_textBox
            // 
            this.jumin_textBox.Location = new System.Drawing.Point(90, 62);
            this.jumin_textBox.Name = "jumin_textBox";
            this.jumin_textBox.Size = new System.Drawing.Size(135, 21);
            this.jumin_textBox.TabIndex = 5;
            // 
            // address_textBox
            // 
            this.address_textBox.Location = new System.Drawing.Point(300, 62);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(135, 21);
            this.address_textBox.TabIndex = 6;
            // 
            // phone_textBox
            // 
            this.phone_textBox.Location = new System.Drawing.Point(300, 23);
            this.phone_textBox.Name = "phone_textBox";
            this.phone_textBox.Size = new System.Drawing.Size(135, 21);
            this.phone_textBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "정말 삭제하시겠습니까?";
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(191, 122);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 9;
            this.ok_button.Text = "확인";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // Employee_delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 157);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone_textBox);
            this.Controls.Add(this.address_textBox);
            this.Controls.Add(this.jumin_textBox);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name_label);
            this.Name = "Employee_delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee_delete";
            this.Load += new System.EventHandler(this.Employee_delete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.TextBox jumin_textBox;
        private System.Windows.Forms.TextBox address_textBox;
        private System.Windows.Forms.TextBox phone_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ok_button;
    }
}