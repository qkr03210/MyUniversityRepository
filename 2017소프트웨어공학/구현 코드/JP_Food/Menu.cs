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
    public partial class Menu : Form
    {
        string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system;allow user variables=true";
        MySqlConnection conn = null;
        DataSet DS = null;

        Form dlg;
        public Form1 form;
        public Menu(Form1 form1)
        {
            form = form1;
            InitializeComponent();
            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                timer1.Start();
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
        public void visiblePanel()
        {
            panel1.Visible = true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void alterPage(Form dlg)
        {
            dlg.TopLevel = false;
            dlg.FormBorderStyle = FormBorderStyle.None;
            panel1.Visible = false;
            Controls.Add(dlg);
            dlg.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (form.getModeFlag())
            {
                button1.Enabled = true;
                button2.Enabled = true;
                modeLabel.Text = "[ 관리자 모드 ]";

            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                modeLabel.Text = "[ 일반 모드 ]";
            }
        }

        // 메뉴 등록
        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu_register mr = new Menu_register();
            bool error = false;


            if (mr.ShowDialog() == DialogResult.Yes)
            {
                error = overlapCheck(mr.getName());
                if (error == false & mr.getError() == false)
                {
                    MySqlCommand insertCommand = new MySqlCommand();
                    insertCommand.Connection = conn;
                    if (mr.getCategory() == "Set Menu")
                    {
                        insertCommand.CommandText = "INSERT INTO 메뉴(메뉴이름, 구성, 가격, 세트칼로리, 판매기간, 카테고리, 레시피, 이미지) VALUES(@메뉴이름, @구성, @가격, @세트칼로리, @판매기간, @카테고리,@레시피, @이미지)";
                        insertCommand.Parameters.Add("@메뉴이름", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@구성", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@가격", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@세트칼로리", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@판매기간", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@레시피", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@카테고리", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@이미지", MySqlDbType.VarChar, 100);

                        insertCommand.Parameters[0].Value = mr.getName();
                        insertCommand.Parameters[1].Value = mr.getOrganization();
                        insertCommand.Parameters[2].Value = mr.getPrice();
                        insertCommand.Parameters[3].Value = mr.getSet_kcal();
                        insertCommand.Parameters[4].Value = mr.getSale_period();
                        insertCommand.Parameters[5].Value = mr.getRecipe();
                        insertCommand.Parameters[6].Value = mr.getCategory();
                        insertCommand.Parameters[7].Value = mr.getPath();
                    }
                    else
                    {
                        insertCommand.CommandText = "INSERT INTO 메뉴(메뉴이름, 가격, 단품칼로리, 판매기간, 카테고리, 레시피, 이미지    ) VALUES(@메뉴이름, @가격, @단품칼로리, @판매기간, @카테고리, @레시피, @이미지)";

                        insertCommand.Parameters.Add("@메뉴이름", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@가격", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@단품칼로리", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@판매기간", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@레시피", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@카테고리", MySqlDbType.VarChar, 50);
                        insertCommand.Parameters.Add("@이미지", MySqlDbType.VarChar, 100);

                        insertCommand.Parameters[0].Value = mr.getName();
                        insertCommand.Parameters[1].Value = mr.getPrice();
                        insertCommand.Parameters[2].Value = mr.getSingle_kcal();
                        insertCommand.Parameters[3].Value = mr.getSale_period();
                        insertCommand.Parameters[4].Value = mr.getRecipe();
                        insertCommand.Parameters[5].Value = mr.getCategory();
                        insertCommand.Parameters[6].Value = mr.getPath();
                    }
                    MessageBox.Show("등록완료");
                    insertCommand.ExecuteNonQuery();
                }
            }
            
        }
        // 메뉴 삭제
        private void button2_Click(object sender, EventArgs e)
        {
            Menu_delete md = new Menu_delete();
            md.Show();
        }
         // 메뉴 조회
        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu_display md = new Menu_display(this);
            alterPage(md);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dlg != null && dlg.DialogResult == DialogResult.Yes)
                this.Visible = true;
        }

        private bool overlapCheck(string menu_name)
        {
            MySqlCommand cmd = new MySqlCommand();

            string str = "SELECT 메뉴이름 FROM 메뉴 WHERE is_delete is null";

            cmd = new MySqlCommand(str, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (menu_name == rdr["메뉴이름"].ToString())
                {
                    MessageBox.Show("메뉴가 중복됩니다.");
                    rdr.Close();
                    return true;
                }
            }
            rdr.Close();
            return false;
        }
    }
}
