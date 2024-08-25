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
    public partial class 定期存款a : UserControl
    {
        public event EventHandler ButtonBack;
        public 定期存款a()
        {
            InitializeComponent();
        }

        public void CardID_Set(string cardID)
        {
            textBox1.Text = cardID;
            //textBox1.Text = 余额;要进行查询
            textBox5.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //对输入内容做限制
            bool flag = true;
            if (textBox3.Text != "")
            {
                if (textBox3.Text.Contains('.'))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            if (flag == false && (e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != '\b')
            {
                e.Handled = true; // 不为空且有小数点时时拒绝输入非数字和退格的字符
            }
            else if (((e.KeyChar > '9' || e.KeyChar < '0') && (e.KeyChar != '.' && e.KeyChar != '\b')))
            {
                e.Handled = true; // 无小数点时时拒绝输入非数字、小数点、退格的字符
            }

        }
        private void textBox3_leave(object sender, EventArgs e)
        {
            //整理内容,消除首位0，清除末尾.和.后末尾0，给.开头添加0
            if (textBox3.Text[0] == '0')
            {
                textBox3.Text = textBox3.Text.TrimStart('0');
                if (textBox3.Text[0] == '.')
                    textBox3.Text = "0" + textBox3.Text;
            }
            else if (textBox3.Text[0] == '.')
            {
                textBox3.Text = "0" + textBox3.Text;
            }
            if (textBox3.Text.Contains('.'))
            {
                textBox3.Text = textBox3.Text.TrimEnd('0');
                if (textBox3.Text.EndsWith("."))
                    textBox3.Text = textBox3.Text.TrimEnd('.');
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                DialogResult result = MessageBox.Show("请确认是否以 " + textBox2.Text + " 的方式向账户 " + textBox1.Text + " 定期存入金额 " + textBox3.Text + " (CNY)。", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //密码验证
                    //定期存款过程
                    MessageBox.Show("成功向账户 " + textBox1.Text + " 以 " + textBox2.Text + " 的方式存入金额 "+ textBox3.Text + " (CNY)！");
                    textBox2.Text = ""; textBox3.Text = "";//成功或失败后清空
                    CardID_Set(textBox1.Text);//更新余额
                }
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请选择存款类型！");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("请输入存款金额！");
            }
        }

    }
}
