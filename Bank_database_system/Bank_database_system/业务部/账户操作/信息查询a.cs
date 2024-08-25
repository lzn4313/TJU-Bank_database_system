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
    public partial class 信息查询a : UserControl
    {
        public event EventHandler ButtonBack;
        信息查询b lose = new 信息查询b();
        信息查询c success = new 信息查询c();
        public 信息查询a()
        {
            InitializeComponent();
            lose.ButtonBack += BackToA;
            success.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            textBox5.Text = "";
            // 修改柜台业务B中的控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //密码
            if (true)
            {
                panel1.Visible = true;
                panel1.Controls.Clear();
                success.CardID_Set(textBox5.Text);
                panel1.Controls.Add(success);
                panel1.BringToFront();//显示置顶
            }
            else//密码错误或查无此卡,可能会换成MessageBox
            {
                panel1.Visible = true;
                panel1.Controls.Clear();
                lose.CardID_Set(textBox5.Text);
                panel1.Controls.Add(lose);
                panel1.BringToFront();//显示置顶
            }
        }
    }
}
