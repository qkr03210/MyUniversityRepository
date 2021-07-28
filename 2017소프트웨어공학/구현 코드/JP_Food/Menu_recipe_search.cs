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
    public partial class Menu_recipe_search : Form
    {
        public Menu_recipe_search(string recipe)
        {
            InitializeComponent();
            label2.Text = recipe;
        }

        private void Menu_recipe_search_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
