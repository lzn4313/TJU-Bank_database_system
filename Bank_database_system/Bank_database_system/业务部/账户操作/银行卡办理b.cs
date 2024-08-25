using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system.业务部.账户操作
{
    public partial class 银行卡办理b : UserControl
    {
        public event EventHandler ButtonBack;
        public 银行卡办理b()
        {
            InitializeComponent();
        }

        public void ID_Set(string ID)
        {
            textBox1.Text = ID;
            //textBox5.Text = ;//姓名
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.TextLength == 6)
            {
                if (e.KeyChar != '\b')
                    e.Handled = true;
            }
            else
            {
                if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != '\b')
                    e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.TextLength == 6)
            {
                if (e.KeyChar != '\b')
                    e.Handled = true;
            }
            else
            {
                if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != '\b')
                    e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("请输入合法姓名！");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入合法家庭住址！");
            }
            else if(textBox3.Text=="")
            {
                MessageBox.Show("请输入合法电话号码！");
            }
            else if(textBox4.Text=="")
            {
                MessageBox.Show("密码不能为空！");
            }
            else if(textBox4.Text!=textBox6.Text)
            {
                MessageBox.Show("两次密码不一致，请重新输入！");
                textBox4.Text = "";
                textBox6.Text = "";
            }
            else
            {
                DialogResult result = MessageBox.Show("请确认上述信息无误！", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //过程！！！
                    MessageBox.Show("创建成功！");
                }
            
            }
        }
    }
}
