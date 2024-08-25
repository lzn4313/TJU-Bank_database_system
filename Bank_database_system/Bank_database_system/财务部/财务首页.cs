using Bank_database_system.财务部;
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
    public partial class 财务首页 : Form
    {
        资金查看 fund_check = new 资金查看();
        工资发放a salary_pay = new 工资发放a();
        流水查询a branch_inf_a = new 流水查询a();
        public 财务首页()
        {
            InitializeComponent();
        }



        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void 财务首页_Load(object sender, EventArgs e)
        {
            // 启动定时器
            timer1.Start();
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p16;
            button3.Image = Properties.Resources.p14;
            button4.Image = Properties.Resources.p15;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(fund_check);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p13;
            button3.Image = Properties.Resources.p17;
            button4.Image = Properties.Resources.p15;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(salary_pay);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p13;
            button3.Image = Properties.Resources.p14;
            button4.Image = Properties.Resources.p18;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(branch_inf_a);
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
