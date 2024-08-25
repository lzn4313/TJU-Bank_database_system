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
    public partial class 转账a : UserControl
    {
        public event EventHandler ButtonBack;
        public 转账a()
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
            textBox2.Text = "";
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
            if (textBox3.Text != ""&&textBox2.Text!="")
            {
                DialogResult result = MessageBox.Show("请确认是否从本账户 " + textBox1.Text + " 向账户 " + textBox2.Text + " 转入金额 "+textBox3.Text+" (CNY)。", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //密码验证
                    //转款过程
                    MessageBox.Show("成功本账户 " + textBox1.Text + " 向账户 " + textBox2.Text + " 转入金额 " + textBox3.Text + " (CNY)！");
                    textBox2.Text = "";textBox3.Text = "";//成功或失败后清空
                    CardID_Set(textBox1.Text);//更新余额
                }
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("请输入转入账户！");
            }
            else if(textBox3.Text =="")
            {
                MessageBox.Show("请输入转账金额！");
            }
        }
    }
}
