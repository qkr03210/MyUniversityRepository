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
    public partial class Food_Material : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        List<string> employee_name = new List<string>();
        string sql, employee_id, groceries_id;
        Food_Inquiry fi = null;
        //int stock;

        public Food_Material()
        {
            InitializeComponent();
            try
            {
                string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system";
                conn = new MySqlConnection(strConn);
                conn.Open();
                // MessageBox.Show("연결성공");
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

            print();

            sql = "SELECT 직원명 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
            db(sql);

            while (rdr.Read())
                employee_name.Add(rdr["직원명"].ToString());
            rdr.Close();
        }
        
        private void food_Paint(object sender, PaintEventArgs e)
        {

        }

        private void db(string sql)
        {
            cmd = new MySqlCommand(sql, conn);
            cmd.Connection = conn;
            rdr = cmd.ExecuteReader();
        }

        //식자재 입고
        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            Food_Warehousing fw = new Food_Warehousing(name, employee_name);
            if (fw.ShowDialog() == DialogResult.Yes)
            {
                sql = "SELECT Groceries_id FROM 식자재 WHERE 물품명 = \"" + fw.name + "\"";
                db(sql);
                rdr.Read();
                groceries_id = rdr["Groceries_id"].ToString();
                rdr.Close();

                sql = "SELECT Employee_id FROM 직원 WHERE 직원명 = \"" + fw.employee_name + "\"";
                db(sql);
                rdr.Read();
                employee_id = rdr["Employee_id"].ToString();
                rdr.Close();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO 입고(Employee_id,Groceries_id,수량,입고일) VALUES(@Employee_id,@Groceries_id,@수량,@입고일)";

                cmd.Parameters.Add("@Employee_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@수량", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@입고일", MySqlDbType.VarChar, 20);

                cmd.Parameters[0].Value = employee_id;
                cmd.Parameters[1].Value = groceries_id;
                cmd.Parameters[2].Value = fw.amount;
                cmd.Parameters[3].Value = DateTime.Now.ToLongDateString();

                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE 식자재 SET 수량=수량+\"" + fw.amount + "\" WHERE Groceries_id=@Groceries_id";
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters[0].Value = groceries_id;
                cmd.ExecuteNonQuery();
                print();
            }
        }

        //식자재 출고
        private void button2_Click_1(object sender, EventArgs e)
        {
            string name = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            Food_Release fr = new Food_Release(name, employee_name);
            fr.amount = dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            if (fr.ShowDialog() == DialogResult.Yes)
            {
                sql = "SELECT Groceries_id FROM 식자재 WHERE 물품명 = \"" + fr.name + "\"";
                db(sql);
                rdr.Read();
                groceries_id = rdr["Groceries_id"].ToString();
                rdr.Close();

                sql = "SELECT Employee_id FROM 직원 WHERE 직원명 = \"" + fr.employee_name + "\"";
                db(sql);
                rdr.Read();
                employee_id = rdr["Employee_id"].ToString();
                rdr.Close();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO 출고(Employee_id,Groceries_id,수량,출고일) VALUES(@Employee_id,@Groceries_id,@수량,@출고일)";

                cmd.Parameters.Add("@Employee_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@수량", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@출고일", MySqlDbType.VarChar, 20);

                cmd.Parameters[0].Value = employee_id;
                cmd.Parameters[1].Value = groceries_id;
                cmd.Parameters[2].Value = fr.amount;
                cmd.Parameters[3].Value = DateTime.Now.ToLongDateString();

                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE 식자재 SET 수량=수량-\"" + fr.amount + "\" WHERE Groceries_id=@Groceries_id";
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters[0].Value = groceries_id;
                cmd.ExecuteNonQuery();

                print();
            }
        }

        //식자재 폐기
        private void button3_Click_1(object sender, EventArgs e)
        {
            string name = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            Food_Disuse fd = new Food_Disuse(name, employee_name);
            fd.amount = dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            if (fd.ShowDialog() == DialogResult.Yes)
            {
                sql = "SELECT Groceries_id FROM 식자재 WHERE 물품명 = \"" + fd.name + "\"";
                db(sql);
                rdr.Read();
                groceries_id = rdr["Groceries_id"].ToString();
                rdr.Close();

                sql = "SELECT Employee_id FROM 직원 WHERE 직원명 = \"" + fd.employee_name + "\"";
                db(sql);
                rdr.Read();
                employee_id = rdr["Employee_id"].ToString();
                rdr.Close();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO 폐기(Employee_id,Groceries_id,수량,폐기일,폐기사유) VALUES(@Employee_id,@Groceries_id,@수량,@폐기일,@폐기사유)";

                cmd.Parameters.Add("@Employee_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@수량", MySqlDbType.Int16, 11);
                cmd.Parameters.Add("@폐기일", MySqlDbType.VarChar, 20);
                cmd.Parameters.Add("@폐기사유", MySqlDbType.VarChar, 20);

                cmd.Parameters[0].Value = employee_id;
                cmd.Parameters[1].Value = groceries_id;
                cmd.Parameters[2].Value = fd.amount;
                cmd.Parameters[3].Value = DateTime.Now.ToLongDateString();
                cmd.Parameters[4].Value = fd.reason;

                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE 식자재 SET 수량=수량-\"" + fd.amount + "\" WHERE Groceries_id=@Groceries_id";
                cmd.Parameters.Add("@Groceries_id", MySqlDbType.Int16, 11);
                cmd.Parameters[0].Value = groceries_id;
                cmd.ExecuteNonQuery();

                print();
            }
        }

        //식자재 조회
        private void button4_Click_1(object sender, EventArgs e)
        {
            fi = new Food_Inquiry();
            fi.TopLevel = false;
            fi.FormBorderStyle = FormBorderStyle.None;
            food.Visible = false;
            Controls.Add(fi);
            fi.Show();
        }


        //이전
        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fi != null && fi.DialogResult == DialogResult.Yes)
                food.Visible = true;
        }

        private void print()
        {
            string sql = "SELECT 물품명, 단위, 수량 FROM 식자재";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);
            DataSet DS = new DataSet();
            DBAdapter.Fill(DS, "식자재");
            dataGridView1.DataSource = DS.Tables["식자재"].DefaultView;
        }
        private void Food_Material_Load(object sender, EventArgs e)
        {

        }
    }
}


