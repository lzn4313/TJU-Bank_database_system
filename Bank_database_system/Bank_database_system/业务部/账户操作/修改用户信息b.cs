using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank_database_system.业务部.账户操作
{
    public partial class 修改用户信息b : UserControl
    {
        public event EventHandler ButtonBack;
        public 修改用户信息b()
        {
            InitializeComponent();
        }

        public void Information_Set(string ID)
        {
            //传入信息
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.TextLength == 18)
            {
                if (e.KeyChar != '\b')
                    e.Handled = true;
            }
            else
            {
                if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != '\b' && e.KeyChar != 'X' && e.KeyChar != 'x')
                    e.Handled = true;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //身份证（等信息）判断
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("信息栏不能为空！");
                return;
            }
            else
            {
                
                if (textBox1.TextLength == 18)
                {
                    for (int i = 0; i < 18; i++)
                    {
                        if (i < 17)
                        {
                            if (textBox1.Text[i] < '0' || textBox1.Text[i] > '9')
                            {
                                MessageBox.Show("请输入合法身份证！");
                                textBox1.Text = "";
                                return;
                            }
                        }
                        else
                        {
                            if ((textBox1.Text[i] < '0' || textBox1.Text[i] > '9') && textBox1.Text[i] != 'X' && textBox1.Text[i] != 'x')
                            {
                                MessageBox.Show("请输入合法身份证！");
                                textBox1.Text = "";
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请输入合法身份证！");
                    textBox1.Text = "";
                    return;
                }
            }
            
            //密码
            if (true)//密码正确
            {
                //后端更新
                MessageBox.Show("信息修改完成！");
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！");
            }
        }
    }
}
