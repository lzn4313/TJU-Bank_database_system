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
    public partial class 银行卡办理a : UserControl
    {
        银行卡办理b bankcardB = new 银行卡办理b();
        public event EventHandler ButtonBack;
        public 银行卡办理a()
        {
            InitializeComponent();
            bankcardB.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            textBox5.Text = "";     
            // 修改控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (textBox5.TextLength == 18)
            {
                for (int i = 0; i < 18; i++)
                {
                    if (i < 17)
                    {
                        if (textBox5.Text[i] < '0' || textBox5.Text[i] > '9')
                        {
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        if ((textBox5.Text[i] < '0' || textBox5.Text[i] > '9') && textBox5.Text[i] != 'X' && textBox5.Text[i] != 'x')
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else { 
                flag = false; 
            }

            if (flag) {
                    //密码
                panel1.Visible = true;
                panel1.Controls.Clear();
                bankcardB.ID_Set(textBox5.Text);
                panel1.Controls.Add(bankcardB);
                panel1.BringToFront();//显示置顶
            }
            else
            {
                MessageBox.Show("请输入合法身份证！");
                textBox5.Text = "";
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox5.TextLength == 18)
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
    }
}
