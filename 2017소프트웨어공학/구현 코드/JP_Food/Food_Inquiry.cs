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
    public partial class Food_Inquiry : Form
    {
        MySqlConnection conn = null;

        public Food_Inquiry()
        {
            InitializeComponent();

            try
            {
                string strConn = "Server=localhost;Port=3306;User=root;Password=wns1024;Database=j&p_food_system";
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
        
        private void Food_Inquiry_Load(object sender, EventArgs e)
        {

        }

        //이전
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        //입고조회
        private void button2_Click_1(object sender, EventArgs e)
        {
            label2.Text = "입고 조회";
            string sql = "SELECT 입고.입고일, 식자재.물품명, 식자재.단위, 입고.수량, 직원.직원명, 식자재.유통기한 FROM 입고 INNER JOIN 직원 ON 입고.Employee_id = 직원.Employee_id INNER JOIN 식자재 ON 입고.Groceries_id = 식자재.Groceries_id";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DataSet DS = new DataSet();
            DBAdapter.Fill(DS, "입고,직원,식자재");
            dataGridView1.DataSource = DS.Tables["입고,직원,식자재"].DefaultView;
        }

        //출고조회
        private void button3_Click_1(object sender, EventArgs e)
        {
            label2.Text = "출고 조회";
            string sql = "SELECT 출고.출고일, 식자재.물품명, 식자재.단위, 출고.수량, 직원.직원명 FROM 출고 INNER JOIN 직원 ON 출고.Employee_id = 직원.Employee_id INNER JOIN 식자재 ON 출고.Groceries_id = 식자재.Groceries_id";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DataSet DS = new DataSet();
            DBAdapter.Fill(DS, "출고,직원,식자재");
            dataGridView1.DataSource = DS.Tables["출고,직원,식자재"].DefaultView;
        }

        //폐기조회
        private void button4_Click_1(object sender, EventArgs e)
        {
            label2.Text = "폐기 조회";
            string sql = "SELECT 폐기.폐기일, 식자재.물품명, 식자재.단위, 폐기.수량, 직원.직원명, 식자재.유통기한, 폐기.폐기사유 FROM 폐기 INNER JOIN 직원 ON 폐기.Employee_id = 직원.Employee_id INNER JOIN 식자재 ON 폐기.Groceries_id = 식자재.Groceries_id";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DataSet DS = new DataSet();
            DBAdapter.Fill(DS, "폐기,직원,식자재");
            dataGridView1.DataSource = DS.Tables["폐기,직원,식자재"].DefaultView;
        }
    }
}
