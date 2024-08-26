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

namespace Bank_database_system.业务部
{
    public partial class 交易记录查询a : UserControl
    {
        public event EventHandler ButtonBack;
        交易记录查询b query_records2 = new 交易记录查询b();
        public 交易记录查询a()
        {
            InitializeComponent();
            query_records2.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            // 修改交易记录查询a中的控件状态
            textBox5.Text = "";
            panel1.Visible = false;
            panel1.Controls.Clear();
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
        public void CardID_Set(string text)
        {
            textBox5.Text = text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //密码输入界面
            //密码正确后
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            query_records2.CardID_Set(textBox5.Text);
            panel1.Controls.Add(query_records2);
            panel1.BringToFront();//显示置顶
            //密码错误
        }
    }
}
