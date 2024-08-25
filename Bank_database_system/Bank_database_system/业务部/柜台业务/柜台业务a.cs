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
    public partial class 柜台业务a : UserControl
    {
        柜台业务b counter_business2 = new 柜台业务b();
        public 柜台业务a()
        {
            InitializeComponent();
            counter_business2.ButtonBack += BackToA;
        }
        private void BackToA(object sender, EventArgs e)
        {
            // 修改柜台业务a中的控件状态
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("查询失败，请检查卡号正确与否", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //切换到下一页面
                panel1.Visible = true;
                panel1.Controls.Clear();
                counter_business2.CardID_Set(textBox2.Text);
                textBox2.Text = "";
                panel1.Controls.Add(counter_business2);
                panel1.BringToFront();//显示置顶
            }
        }
    }
}
