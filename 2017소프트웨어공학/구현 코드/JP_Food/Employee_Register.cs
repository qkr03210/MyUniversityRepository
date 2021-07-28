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
    public partial class Employee_Register : Form
    {
        private string name = null;
        private string jumin = null;
        private string address = null;
        private string phone = null;

        public Employee_Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            jumin = textBox2.Text;
            phone = textBox3.Text;
            address = textBox4.Text;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getName() { return name; }
        public string getJumin() { return jumin; }
        public string getAddress() { return address; }
        public string getPhone() { return phone; }

        private void Employee_Register_Load(object sender, EventArgs e)
        {

        }
    }
}
