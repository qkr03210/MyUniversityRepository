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
    public partial class Menu_delete : Form
    {
        string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system";
        MySqlConnection conn = null;
        DataSet DS = null;
        public Menu_delete()
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_delete_Load(object sender, EventArgs e)
        {
            string sql = "SELECT 메뉴이름,카테고리 FROM 메뉴 WHERE is_delete is null ORDER By 카테고리";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                listView1.Items.Add(rdr[0].ToString()).SubItems.Add(rdr[1].ToString());
            }
            

            rdr.Close();
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand updateCommand = new MySqlCommand();
            string select = listView1.FocusedItem.SubItems[0].Text.ToString();

            updateCommand.Connection = conn;
            updateCommand.CommandText = "UPDATE 메뉴 SET is_delete=@is_delete WHERE 메뉴이름 = \"" + select + "\"";

            updateCommand.Parameters.Add("@is_delete", MySqlDbType.VarChar, 50);

            updateCommand.Parameters[0].Value = "Yes";
            updateCommand.ExecuteNonQuery();

            MessageBox.Show("삭제 성공");

            listView1.Items.Clear();
            string sql = "SELECT 메뉴이름,카테고리 FROM 메뉴 WHERE is_delete is null";
            updateCommand = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = updateCommand.ExecuteReader();

            while (rdr.Read())
            {
                listView1.Items.Add(rdr[0].ToString()).SubItems.Add(rdr[1].ToString());
            }
            rdr.Close();
        }
    }
}
