using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JP_Food
{
    public partial class Menu_display : Form
    {
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;

        int cnt1 = 9;
        int cnt2 = 6;
        int cnt3 = 6;
        int cnt4 = 6;

        string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system";
        MySqlConnection conn = null;
        DataSet DS = null;
        Form dlg = null;
        //PictureBox[] pb = null;
        //List<PictureBox> pb = new List<PictureBox>();

        public string image;
        public string price;
        public string name;
        public string organization;
        public string kcal;
        public string recipe;
        Menu menu;
        public Menu_display(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                // MessageBox.Show("연결성공");
            }
            catch (MySqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            if (conn == null || conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Not Connected");
                return;
            }
        }

        private void Menu_display_Load(object sender, EventArgs e)
        {
            string sql = "SELECT 이미지,메뉴이름,카테고리 FROM 메뉴 WHERE 이미지 is not null AND is_delete is null";
      
            PictureBox[] burgerPic ={ pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,pictureBox7, pictureBox8,pictureBox9};
            PictureBox[] drinkPic = {pictureBox10,pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15};
            PictureBox[] sidePic = {pictureBox16,pictureBox17,pictureBox18,pictureBox19,pictureBox20,pictureBox21 };
            PictureBox[] setPic = { pictureBox22,pictureBox23,pictureBox24,pictureBox25,pictureBox26,pictureBox27};

            Label[] burgerlb = { label2, label3, label4, label5, label6, label7, label8, label9, label10 };
            Label[] drinklb = { label11,label12,label13,label15,label16,label17};
            Label[] sidelb = { label18, label19, label20, label21, label22, label23 };
            Label[] setlb = { label25, label26, label27, label28, label29, label30 };

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read())
            {
                System.Drawing.Bitmap bitmap = new Bitmap(rdr.GetString(0));
                if(rdr["카테고리"].ToString() == "Burger")
                {
                    burgerPic[count1].Image = bitmap;
                    burgerPic[count1].Tag = rdr["메뉴이름"].ToString();

                    burgerlb[count1].Text = rdr["메뉴이름"].ToString();
                    count1++;
                }
                else if (rdr["카테고리"].ToString() == "Drink")
                {
                    drinkPic[count2].Image = bitmap;
                    drinkPic[count2].Tag = rdr["메뉴이름"].ToString();

                    drinklb[count2].Text = rdr["메뉴이름"].ToString();
                    count2++;
                }
                else if (rdr["카테고리"].ToString() == "Side Menu")
                {
                    sidePic[count3].Image = bitmap;
                    sidePic[count3].Tag = rdr["메뉴이름"].ToString();

                    sidelb[count3].Text = rdr["메뉴이름"].ToString();
                    count3++;
                }
                else if (rdr["카테고리"].ToString() == "Set Menu")
                {
                    setPic[count4].Image = bitmap;
                    setPic[count4].Tag = rdr["메뉴이름"].ToString();

                    setlb[count4].Text = rdr["메뉴이름"].ToString();
                    count4++;
                }
            }
            for (int i = count1; i < cnt1; i++)
                burgerlb[i].Text = "";
            for (int i = count2; i < cnt2; i++)
                drinklb[i].Text = "";
            for (int i = count3; i < cnt3; i++)
                sidelb[i].Text = "";
            for (int i = count4; i < cnt4; i++)
                setlb[i].Text = "";
            rdr.Close();
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        

        public void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
           
            string str = "SELECT * FROM 메뉴 WHERE is_delete is null AND 메뉴이름 = \"" + pic.Tag.ToString() + "\"";

            MySqlCommand cmd = new MySqlCommand(str, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            image = rdr["이미지"].ToString();
            price = rdr["가격"].ToString();
            name = rdr["메뉴이름"].ToString();
            organization = rdr["구성"].ToString();
            recipe = rdr["레시피"].ToString();
            if (rdr["카테고리"].ToString() == "Set Menu")
                kcal = rdr["세트칼로리"].ToString();
            else
                kcal = rdr["단품칼로리"].ToString();

            dlg = new Menu_detail_diplay(image,name,price,organization,kcal,recipe,menu.form.getModeFlag());
            dlg.Show();

            rdr.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
         //이전
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.visiblePanel();
            this.Visible = false;

            this.Close();
        }
    }
}


