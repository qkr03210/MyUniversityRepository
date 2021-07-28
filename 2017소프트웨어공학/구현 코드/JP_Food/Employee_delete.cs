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
    public partial class Employee_delete : Form
    {
        private bool ischeck = false;

        public Employee_delete()
        {
            InitializeComponent();
        }

        private void Employee_delete_Load(object sender, EventArgs e)
        {
            name_textBox.Enabled = false;
            phone_textBox.Enabled = false;
            jumin_textBox.Enabled = false;
            address_textBox.Enabled = false;
        }
        public void inputData(string name,string phone,string jumin,string address)
        {
            name_textBox.Text = name;
            phone_textBox.Text = phone;
            jumin_textBox.Text = jumin;
            address_textBox.Text = address;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            ischeck = true;
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        public bool getIsCheck() { return ischeck; }
    }
}
