using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // 참조에 참조추가에 MySql.data 를 추가하고 이렇게 써준다.

namespace JP_Food
{
    public partial class Employee : Form
    {
        string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system";
        MySqlConnection conn = null;
        DataSet DS = null;

        string name;
        string jumin;
        string address;
        string phone;
        int id;

        public Employee()
        {
            InitializeComponent();

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
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

            // GridView에 DB 데이터 출력
            string sql = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DS = new DataSet();
            DBAdapter.Fill(DS, "직원");
            dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
           
        }

        //이전
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        //직원등록
        private void button2_Click(object sender, EventArgs e)
        {
            Employee_Register rg = new Employee_Register();
            bool error = false;      // 잘못된 입력 유무를 알기위한 bool 형 변수

            string str = "SELECT 연락처,주민번호 FROM 직원 WHERE 탈퇴일 is null";
            MySqlCommand cmd = new MySqlCommand(str, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();

            // 직원등록 폼으로 
            if (rg.ShowDialog() == DialogResult.Yes)
            {
                // 잘못된 입력의 예외처리
                while (rdr.Read())
                {
                    if (rg.getPhone() == rdr["연락처"].ToString() | rg.getJumin() == rdr["주민번호"].ToString())
                    {
                        MessageBox.Show("중복된 직원정보가 존재합니다.");
                        error = true;
                    }
                }
                rdr.Close();
                // 잘못된 입력의 예외처리
                if (rg.getName() == "" | rg.getJumin() == "" | rg.getPhone() == "" | rg.getAddress() == "")
                {
                    MessageBox.Show("필수정보가 입력되지 않았습니다");
                    error = true;
                }

                // 잘못된 입력이 없을경우 데이터를 DB에 저장
                if (error == false)
                {
                    MySqlCommand insertCommand = new MySqlCommand();
                    insertCommand.Connection = conn;
                    insertCommand.CommandText = "INSERT INTO 직원(직원명, 주민번호, 연락처, 주소) VALUES(@직원명, @주민번호, @주소, @연락처)";

                    insertCommand.Parameters.Add("@직원명", MySqlDbType.VarChar, 50);
                    insertCommand.Parameters.Add("@주민번호", MySqlDbType.VarChar, 50);
                    insertCommand.Parameters.Add("@연락처", MySqlDbType.VarChar, 50);
                    insertCommand.Parameters.Add("@주소", MySqlDbType.VarChar, 50);

                    insertCommand.Parameters[0].Value = rg.getName();
                    insertCommand.Parameters[1].Value = rg.getJumin();
                    insertCommand.Parameters[2].Value = rg.getAddress();
                    insertCommand.Parameters[3].Value = rg.getPhone();

                    insertCommand.ExecuteNonQuery();
                }

                // GridView에 DB 데이터 출력
                string sql = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
                MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

                DS = new DataSet();
                DBAdapter.Fill(DS, "직원");
                dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
            }
        }

        //직원삭제
        private void button3_Click(object sender, EventArgs e)
        {
            Employee_delete ed = new Employee_delete();

            // GridView 내에 선택된 직원명을 가지고와서 Employee_name 변수에 담는다
            string Employee_name = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            // 직원삭제를 누르는 시점의 시간을 withdrawal 변수에 담는다
            string withdrawal_day = DateTime.Now.ToLongDateString();
            string name = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();

            MySqlCommand updateCommand = new MySqlCommand();

            string str = "SELECT * FROM 직원 WHERE 탈퇴일 is null AND 연락처 = \"" + Employee_name + "\"";

            updateCommand = new MySqlCommand(str, conn);
            updateCommand.Connection = conn;
            MySqlDataReader rdr = updateCommand.ExecuteReader();
            rdr.Read();

            name = rdr["직원명"].ToString();
            jumin = rdr["주민번호"].ToString();
            address = rdr["주소"].ToString();
            phone = rdr["연락처"].ToString();
            ed.inputData(name, phone, jumin, address);
            rdr.Close();

            if (ed.ShowDialog() == DialogResult.Yes)
            {
                // "정말 삭제하시겠습니까?" 에 '확인'버튼을 누르면 탈퇴일을 현재삭제시간으로 uodate
                if (ed.getIsCheck() == true)
                {
                    updateCommand.CommandText = "UPDATE 직원 SET 탈퇴일=@탈퇴일 WHERE 직원명=@직원명";

                    updateCommand.Parameters.Add("@탈퇴일", MySqlDbType.VarChar, 50);
                    updateCommand.Parameters.Add("@직원명", MySqlDbType.VarChar, 50);

                    updateCommand.Parameters[0].Value = withdrawal_day;
                    updateCommand.Parameters[1].Value = name;
                    updateCommand.ExecuteNonQuery();
                }

                // GridView에 DB 데이터 출력
                string sql = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
                MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

                DS = new DataSet();
                DBAdapter.Fill(DS, "직원");
                dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
            }
        }

        //상세조회
        private void button5_Click(object sender, EventArgs e)
        {
            Employee_Update ud = new Employee_Update();

            // 선택된 item의 연락처를 가지고와 Db와 비교하여 직원을 판별한다
            string selectPhone = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            string sql = "SELECT * FROM 직원 WHERE 탈퇴일 is null AND 연락처 = \"" + selectPhone + "\"";
            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            id = Convert.ToInt32(rdr["Employee_id"].ToString());
            name = rdr["직원명"].ToString();
            jumin = rdr["주민번호"].ToString();
            address = rdr["주소"].ToString();
            phone = rdr["연락처"].ToString();

            rdr.Close();
            // Employee_Update 폼을 띄우주기전 그 폼에 필요한 보여줄 데이터들을 넣어준다.
            ud.inputData(name, jumin, address, phone);

            // 상세정보 안 수정버튼으로 상제정보를 수정했다면 주민번호를 제외한 모든 정보들이 Update 되어 DB에 저장된다
            if (ud.ShowDialog() == DialogResult.Yes)
            {
                cmd.CommandText = "UPDATE 직원 SET 직원명=@직원명,주소=@주소,연락처=@연락처 WHERE 탈퇴일 is null AND Employee_id = \"" + id + "\"";
                cmd.Parameters.Add("@직원명", MySqlDbType.VarChar, 10);
                cmd.Parameters.Add("@주소", MySqlDbType.VarChar, 50);
                cmd.Parameters.Add("@연락처", MySqlDbType.VarChar, 20);
                cmd.Parameters.Add("@직원번호", MySqlDbType.Int32, 11);

                cmd.Parameters[0].Value = ud.getName();
                cmd.Parameters[1].Value = ud.getAddress();
                cmd.Parameters[2].Value = ud.getPhone();
                cmd.Parameters[3].Value = id;

                cmd.ExecuteNonQuery();

                MessageBox.Show("직원정보 수정이 성공적으로 완료되었습니다");

                // GridView에 DB 데이터 출력
                string sql2 = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
                MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql2, conn);

                DS = new DataSet();
                DBAdapter.Fill(DS, "직원");
                dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
            }
        }

        //검색
        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            // 검색란에 있는 이름정보와 DB 안의 이름정보를 비교하여 GridView에 출력해준다  
            string sql = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null AND 직원명 = \"" + name + "\"";

            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DS = new DataSet();
            DBAdapter.Fill(DS, "직원");
            dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
        }

        //전체조회
        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 직원명,연락처 FROM 직원 WHERE 탈퇴일 is null ORDER BY 직원명";
            MySqlDataAdapter DBAdapter = new MySqlDataAdapter(sql, conn);

            DS = new DataSet();
            DBAdapter.Fill(DS, "직원");
            dataGridView1.DataSource = DS.Tables["직원"].DefaultView;
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
