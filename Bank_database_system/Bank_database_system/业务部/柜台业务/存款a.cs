using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Bank_database_system.业务部
{
    public partial class 存款a : UserControl
    {
        public event EventHandler ButtonBack;
        public 存款a()
        {
            InitializeComponent();
        }

        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;
            //textBox1.Text = 余额;要进行查询
            textBox1.Text = "0";
        }

       private void button8_Click(object sender, EventArgs e)
       {
            textBox2.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
       }

       private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                DialogResult result = MessageBox.Show("请确认是否向账户 " + textBox5.Text + " 内存入金额 " + textBox2.Text + " (CNY) 。", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //存款过程
                    MessageBox.Show("成功向账户 " + textBox5.Text + " 内存入金额 " + textBox2.Text + " (CNY) ！");
                    textBox2.Text = "";//成功后清空
                    CardID_Set(textBox5.Text);//更新余额
                }
            }
            else
            {
                MessageBox.Show("请输入存款金额！");
            }
        }
        
       private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //对输入内容做限制
            bool flag = true;
            if (textBox2.Text != "") 
            {
                if (textBox2.Text.Contains('.'))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
             
            if(flag==false&& (e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != '\b')
            {
                e.Handled = true; // 不为空且有小数点时时拒绝输入非数字和退格的字符
            }
            else if (((e.KeyChar>'9'||e.KeyChar<'0')&&(e.KeyChar!='.'&&e.KeyChar!='\b')))
            {
                e.Handled = true; // 无小数点时时拒绝输入非数字、小数点、退格的字符
            }

        }
       private void textBox2_leave(object sender, EventArgs e)
        {
            //整理内容,消除首位0，清除末尾.和.后末尾0，给.开头添加0
            if (textBox2.Text[0] == '0')
            {
                textBox2.Text = textBox2.Text.TrimStart('0');
                if (textBox2.Text[0] == '.')
                    textBox2.Text = "0" + textBox2.Text;
            }
            else if (textBox2.Text[0] == '.')
            {
                textBox2.Text = "0" + textBox2.Text;
            }
            if (textBox2.Text.Contains('.'))
            {
                textBox2.Text = textBox2.Text.TrimEnd('0');
                if (textBox2.Text.EndsWith("."))
                    textBox2.Text = textBox2.Text.TrimEnd('.');
            }
        }

    }
}
