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
    public partial class Food_Warehousing : Form
    {
        public string name;
        public string amount;//수량
        public string employee_name;//담담자명

        public Food_Warehousing(string nameL, List<string> employee_nameL)
        {
            InitializeComponent();

            textBox1.Text = nameL;
            textBox1.Enabled = false;
            for (int i = 0; i < employee_nameL.Count; i++)
                comboBox2.Items.Add(employee_nameL[i]);
        }

        private void Food_Warehousing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            name = textBox1.Text;
            amount = textBox2.Text;
            employee_name = comboBox2.Text;

            if (name.Equals("") || amount.Equals("") || employee_name.Equals(""))
                MessageBox.Show("정보를 모두 입력하세요", "알림창", MessageBoxButtons.OK);
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";

                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
