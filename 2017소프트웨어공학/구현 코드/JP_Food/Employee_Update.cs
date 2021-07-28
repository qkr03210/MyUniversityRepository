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
    public partial class Employee_Update : Form
    {
        private string name;
        private string jumin;
        private string address;
        private string phone;

        public Employee_Update()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            address = textBox3.Text;
            phone = textBox2.Text;
            
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public void inputData(string name, string jumin, string address, string phone)
        {
            textBox1.Text = name;
            textBox2.Text = phone;
            textBox3.Text = address;
            textBox4.Text = jumin;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        public string getName() { return name; }
        public string getJumin() { return jumin; }
        public string getPhone() { return phone; }
        public string getAddress() { return address; }

        private void Employee_Update_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
