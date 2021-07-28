namespace JP_Food
{
    partial class Authority
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
            this.pw_update_button = new System.Windows.Forms.Button();
            this.Authority_update_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(63, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 28);
            this.label1.TabIndex = 52;
            this.label1.Text = "권 한 관 리";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pw_update_button
            // 
            this.pw_update_button.Location = new System.Drawing.Point(149, 92);
            this.pw_update_button.Name = "pw_update_button";
            this.pw_update_button.Size = new System.Drawing.Size(114, 133);
            this.pw_update_button.TabIndex = 54;
            this.pw_update_button.Text = "관리자 비밀번호 변경";
            this.pw_update_button.UseVisualStyleBackColor = true;
            this.pw_update_button.Click += new System.EventHandler(this.pw_update_button_Click);
            // 
            // Authority_update_button
            // 
            this.Authority_update_button.Location = new System.Drawing.Point(18, 92);
            this.Authority_update_button.Name = "Authority_update_button";
            this.Authority_update_button.Size = new System.Drawing.Size(114, 133);
            this.Authority_update_button.TabIndex = 53;
            this.Authority_update_button.Text = "권한 변경";
            this.Authority_update_button.UseVisualStyleBackColor = true;
            this.Authority_update_button.Click += new System.EventHandler(this.Authority_button_Click);
            // 
            // Authority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pw_update_button);
            this.Controls.Add(this.Authority_update_button);
            this.Controls.Add(this.label1);
            this.Name = "Authority";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authority";
            this.Load += new System.EventHandler(this.Authority_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pw_update_button;
        private System.Windows.Forms.Button Authority_update_button;
    }
}