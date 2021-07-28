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
    public partial class password_update : Form
    {
        private string first_pw;
        private string update_pw;
        public password_update()
        {
            InitializeComponent();
        }

        private void cancle_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            string firstPw = firstpw_textBox.Text;
            string upgradePw = updatepw_textBox.Text;
            

            if (firstPw == first_pw && !upgradePw.Contains(" ") && !upgradePw.Equals(""))
            {
                update_pw = upgradePw;
                MessageBox.Show("비밀번호가 변경되었습니다");
                DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호 변경이 실패했습니다");
            }
        }

        public void input_first_password(string password)
        {
            first_pw = password;
        }

        public string getUpdatePassword() { return update_pw; }

        private void password_update_Load(object sender, EventArgs e)
        {

        }
    }
}
