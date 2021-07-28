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
    public partial class Authority : Form
    {
        string strConn = "Server=localhost;Port=3306;User=root;Password=zx963963;Database=j&p_food_system";
        MySqlConnection conn = null;
        DataSet DS = null;

        MySqlCommand cmd = new MySqlCommand();

        Form1 form;
        public Form1 getForm1() { return form; }

        private string password;
        public Authority(Form1 form1)
        {
            form = form1;
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
            
        }

        private void Authority_button_Click(object sender, EventArgs e)
        {
            string str = "SELECT 관리자비밀번호 FROM 비밀번호";
            cmd = new MySqlCommand(str, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            password = rdr["관리자비밀번호"].ToString();
            rdr.Close();

            password_verify pv = new password_verify(this);
            pv.verify_password(password);   // 비밀번호 변경 폼에도 같이 패스워드를 저장하여 나중에 확인한다.
            
            if (pv.ShowDialog() == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pw_update_button_Click(object sender, EventArgs e)
        {
            string str = "SELECT 관리자비밀번호 FROM 비밀번호";
            cmd = new MySqlCommand(str, conn);
            cmd.Connection = conn;
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            password = rdr["관리자비밀번호"].ToString();
            rdr.Close();

            password_update pu = new password_update();
            
            pu.input_first_password(password);

            if (pu.ShowDialog() == DialogResult.Yes)
            {
                cmd.CommandText = "UPDATE 비밀번호 SET 관리자비밀번호=@관리자비밀번호";
                cmd.Parameters.Add("@관리자비밀번호", MySqlDbType.VarChar, 50);

                cmd.Parameters[0].Value = pu.getUpdatePassword();

                cmd.ExecuteNonQuery();
                this.Close();
            }
        }
        private void Authority_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
