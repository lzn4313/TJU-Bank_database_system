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
    public partial class 人事首页 : Form
    {
        新建员工a add_emplyinf_a = new 新建员工a();
        修改员工a cha_emplyinf_a = new 修改员工a();
        删除员工a del_emolyinf_a = new 删除员工a();
        public 人事首页()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 更新 TextBox 的文本为当前时间
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void 人事首页_Load(object sender, EventArgs e)
        {
            // 启动定时器
            timer1.Start();
            label3.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p10;
            button3.Image = Properties.Resources.p8;
            button4.Image = Properties.Resources.p9;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(add_emplyinf_a);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p7;
            button3.Image = Properties.Resources.p11;
            button4.Image = Properties.Resources.p9;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(cha_emplyinf_a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 切换按钮图像
            button2.Image = Properties.Resources.p7;
            button3.Image = Properties.Resources.p8;
            button4.Image = Properties.Resources.p12;
            //在容器中添加新空间
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(del_emolyinf_a);
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
