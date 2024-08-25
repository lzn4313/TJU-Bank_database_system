using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system.业务部.贷款业务
{
    public partial class 贷款办理b : UserControl
    {
        public event EventHandler ButtonBack;
        public 贷款办理b()
        {
            InitializeComponent();
        }

        public void information_Set(string CardID)
        {
            //身份获取
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("贷款信息栏不能为空！");
            }
            else
            {
                DialogResult result = MessageBox.Show("请再次确认贷款信息无误！", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //密码界面
                    if (true)//密码正确
                    {
                        //后端录入
                        MessageBox.Show("办理成功！");
                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                    }
                }
            }
            
        }

    }
}
