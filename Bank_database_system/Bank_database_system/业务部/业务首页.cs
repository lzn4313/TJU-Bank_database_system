using Bank_database_system.业务部.账户操作;
using Bank_database_system.业务部.贷款业务;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system.业务部
{
    public partial class 业务首页 : Form
    {
        柜台业务a counter_business = new 柜台业务a();
        贷款业务a loan_business = new 贷款业务a();
        账户操作a account_operations = new 账户操作a();
        public 业务首页()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p21;
            button3.Image = Properties.Resources.p23;
            button4.Image = Properties.Resources.p26;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(loan_business);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p21;
            button3.Image = Properties.Resources.p24;
            button4.Image = Properties.Resources.p25;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(account_operations);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p22;
            button3.Image = Properties.Resources.p23;
            button4.Image = Properties.Resources.p25;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(counter_business);
        }

        private void 业务首页_Load(object sender, EventArgs e)
        {
            // 启动定时器
            timer1.Start();
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
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
