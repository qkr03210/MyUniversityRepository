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
    public partial class Food_Release : Form
    {
        public string name;
        public string amount;//수량
        public string employee_name;//담담자명

        public Food_Release(string nameL, List<string> employee_nameL)
        {
            InitializeComponent();
            textBox1.Text = nameL;
            textBox1.Enabled = false;
            for (int i = 0; i < employee_nameL.Count; i++)
                comboBox2.Items.Add(employee_nameL[i]);
        }
        
        private void Food_Release_Load(object sender, EventArgs e)
        {

        }

        //등록
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || comboBox2.Text.Equals(""))
                MessageBox.Show("정보를 모두 입력하세요", "알림창", MessageBoxButtons.OK);
            else
            {
                int stock, cmp;
                stock = Convert.ToInt16(amount);
                cmp = Convert.ToInt16(textBox2.Text);

                if (cmp > stock)
                    MessageBox.Show("재고 수량을 초과하였습니다.", "알림창", MessageBoxButtons.OK);
                else
                {
                    name = textBox1.Text;
                    amount = textBox2.Text;
                    employee_name = comboBox2.Text;

                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";

                    DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }

        //취소
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
