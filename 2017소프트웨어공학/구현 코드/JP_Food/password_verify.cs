using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JP_Food
{
    public partial class password_verify : Form
    {
        public string password;
        Authority authority;
        public password_verify(Authority authority)
        {
            this.authority = authority;
            InitializeComponent();
        }

        private void verify_button_Click(object sender, EventArgs e)
        {
            string pw = pw_textBox.Text;

            if(pw == password)
            {
                DialogResult = DialogResult.Yes;
                if (authority.getForm1().getModeFlag())
                    authority.getForm1().setModeFlag(false);
                else
                    authority.getForm1().setModeFlag(true);
                MessageBox.Show("권한이 변경되었습니다.");
            }
            else
            {
                MessageBox.Show("비밀번호가 잘못입력되엇습니다"); 
                DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void cancle_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void verify_password(string password)
        {
            this.password = password;
        }

        private void password_verify_Load(object sender, EventArgs e)
        {

        }
    }
}
