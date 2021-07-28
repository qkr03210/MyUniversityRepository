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
    //Employee, Authority, Menu, Order, Food_Material
    

    public partial class Form1 : Form
    {
        Form dlg = null;
        bool modeFlag = false; //false == 일반모드, true == 관리자모드

        float startAngle = 2;
        float sweepAngle;
        public bool getModeFlag() { return modeFlag; }
        public void setModeFlag(bool flag)
        {
            modeFlag = flag;
            if (modeFlag)
                modeLabel.Text = "[ 관리자 모드 ]";
            else
                modeLabel.Text = "[ 일반 모드 ]";
        }
        public Form1()
        {
            button1 = new JPButton();
            InitializeComponent();
            
            Point[] p = new Point[4];
            p[0] = new Point(0, 20);
            p[0] = new Point(20, 0);
            p[0] = new Point(0, 0);
            p[0] = new Point(20, 20);

            /*
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
           
            gp.AddArc(button1.DisplayRectangle,2,2);
           // gp.AddEllipse(button1.DisplayRectangle);

            button1.Region = new Region(gp);*/
            timer1.Start();
        }

        //회원
        private void button1_Click(object sender, EventArgs e)
        {
            dlg = new Customer();
            alterPage(dlg);
        }

        //직원
        private void button2_Click(object sender, EventArgs e)
        {
            dlg = new Employee();
            alterPage(dlg);
        }        

        //메뉴
        private void button3_Click(object sender, EventArgs e)
        {
            dlg = new Menu(this);
            alterPage(dlg);
        }

        //발주
        private void button4_Click(object sender, EventArgs e)
        {
        }

        //식자재
        private void button5_Click(object sender, EventArgs e)
        {
            dlg = new Food_Material();
            alterPage(dlg);
        }

        //권환
        private void button6_Click(object sender, EventArgs e)
        {
            dlg = new Authority(this);
            dlg.ShowDialog();
        }

        private void alterPage(Form dlg)
        {
            dlg.TopLevel = false;
            dlg.FormBorderStyle = FormBorderStyle.None;
            main.Visible = false;
            Controls.Add(dlg);
            dlg.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dlg!=null && dlg.DialogResult == DialogResult.Yes)
                main.Visible = true;
        }

        private void main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }

}

    public class JPButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color borderColor = Color.Blue;
            int borderWidth = 1;


            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle
                , borderColor, borderWidth, ButtonBorderStyle.Solid
                , borderColor, borderWidth, ButtonBorderStyle.Solid
                , borderColor, borderWidth, ButtonBorderStyle.Solid
                , borderColor, borderWidth, ButtonBorderStyle.Solid);


        }
    }
