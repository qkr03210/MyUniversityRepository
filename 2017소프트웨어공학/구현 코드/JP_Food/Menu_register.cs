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
    public partial class Menu_register : Form
    {
        string[] item = {"Burger", "Drink", "Side Menu", "Set Menu"};
        private string name;
        private string category;
        private string organization;
        private string price;
        private string single_kcal;
        private string set_kcal;
        private string sale_period;
        private string recipe;
        private string Path;
        private bool error = false;

        public Menu_register()
        {
            InitializeComponent();
        }

        private void Menu_register_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(item[0]);
            comboBox1.Items.Add(item[1]);
            comboBox1.Items.Add(item[2]);
            comboBox1.Items.Add(item[3]);
        }

        // 확인 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            error = errorMsg();
            if (error == false)
            {
                name = textBox1.Text;
                category = comboBox1.SelectedItem.ToString();
                organization = textBox2.Text;
                price = textBox3.Text;
                sale_period = textBox5.Text;
                recipe = richTextBox1.Text;

                if (category == "Set Menu")
                    set_kcal = textBox4.Text;
                else
                    single_kcal = textBox4.Text;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            Path = open.FileName;
            System.Drawing.Bitmap bitmap = new Bitmap(Path);
            pictureBox1.Image = bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calendar c = new Calendar();
            if (c.ShowDialog() == DialogResult.Yes)
            {
                textBox5.Text = c.date;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Set Menu")
                textBox2.Enabled = false;
            else if(comboBox1.Text == "Set Menu")
                textBox2.Enabled = true;
            
        }

        private bool errorMsg()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("필수항목(메뉴이름)을 입력하지 않았습니다");
                return true;
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("필수항목(카테고리)을 입력하지 않았습니다");
                return true;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("필수항목(가격)을 입력하지 않았습니다");
                return true;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("필수항목(칼로리)을 입력하지 않았습니다");
                return true;
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("필수항목(판매기간)을 입력하지 않았습니다");
                return true;
            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("필수항목(이미지)을 입력하지 않았습니다");
                return true;
            }
            else
                return false;

        }

        public string getName() { return name; }
        public string getCategory() { return category; }
        public string getOrganization() { return organization; }
        public string getPrice() { return price; }
        public string getSingle_kcal() { return single_kcal; }
        public string getSet_kcal() { return set_kcal; }
        public string getSale_period() { return sale_period; }
        public string getRecipe() { return recipe; }
        public string getPath() { return Path; }
        public bool getError() { return error; }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
