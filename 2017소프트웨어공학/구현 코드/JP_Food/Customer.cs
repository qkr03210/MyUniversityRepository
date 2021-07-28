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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        //이전
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        //회원등록
        private void button2_Click(object sender, EventArgs e)
        {
        }
        //회원탈퇴
        private void button3_Click(object sender, EventArgs e)
        {
        }
        //상세조회
        private void button5_Click(object sender, EventArgs e)
        {
        }
        //검색
        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
    }
}
