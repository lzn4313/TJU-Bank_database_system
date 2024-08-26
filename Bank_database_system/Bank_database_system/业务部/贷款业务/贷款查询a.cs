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
    public partial class 贷款查询a : UserControl
    {
        public event EventHandler ButtonBack;
        贷款查询c loanSearching = new 贷款查询c();
        public 贷款查询a()
        {
            InitializeComponent();
            loanSearching.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox1.Text = "";
            // 修改控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox1.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.TextLength == 6)
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

        //private void textBox5_KeyPress(object sender, KeyPressEventArgs e)银行卡号输入优化

        private void button9_Click(object sender, EventArgs e)
        {
            //卡号验证
            //密码验证

            if (true)//密码正确
            {
                panel1.Visible = true;
                panel1.Controls.Clear();
                loanSearching.CardID_Set(textBox5.Text);
                panel1.Controls.Add(loanSearching);
                panel1.BringToFront();//显示置顶
            }
            else
            {
                MessageBox.Show("密码或卡号错误！");
                textBox1.Text = "";
            }

        }
    }
}
