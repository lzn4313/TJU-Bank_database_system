using Bank_database_system.业务部;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system
{
    public partial class 信息首页 : Form
    {
        账号管理a account_manage_a = new 账号管理a();
        操作记录a action_logging = new 操作记录a();
        支行信息a branch_inf_a = new 支行信息a();

        public 信息首页()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button1.Image = Properties.Resources.p4;
            button2.Image = Properties.Resources.p2;
            button3.Image = Properties.Resources.p3;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(account_manage_a);
        }

        private void 信息首页_Load(object sender, EventArgs e)
        {
            // 启动定时器
            timer1.Start();
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // 切换按钮图像
            button1.Image = Properties.Resources.p1;
            button2.Image = Properties.Resources.p5;
            button3.Image = Properties.Resources.p3;

            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(action_logging);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button1.Image = Properties.Resources.p1;
            button2.Image = Properties.Resources.p2;
            button3.Image = Properties.Resources.p6;

            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(branch_inf_a);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 更新 TextBox 的文本为当前时间
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否注销当前账号？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //将窗体返回结果设置为Cancel,但并不退出系统
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
