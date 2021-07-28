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
    public partial class Menu_detail_diplay : Form
    {
       // Menu_display md = new Menu_display();
        
        string image;
        string recipe;
        public Menu_detail_diplay(string image,string name,string price,string organization,string kcal,string recipe,bool flag)
        {
            InitializeComponent();

            this.image = image;
            label5.Text = name;
            label6.Text = price;
            label7.Text = organization;
            label8.Text = kcal;
            this.recipe = recipe;
            if (flag)
                button2.Enabled = true;
            else
                button2.Enabled = false ;
            System.Drawing.Bitmap bitmap = new Bitmap(this.image);
            pictureBox1.Image = bitmap;
        }

        private void Menu_detail_diplay_Load(object sender, EventArgs e)
        {
           
        }

        //확인
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
         //레시피 보기
        private void button2_Click(object sender, EventArgs e)
        {
            Menu_recipe_search mcs = new Menu_recipe_search(recipe);
            mcs.Show();
        }

    }
}
