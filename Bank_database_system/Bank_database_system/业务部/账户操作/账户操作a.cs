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
    public partial class 账户操作a : UserControl
    {
        银行卡办理a bankcard = new 银行卡办理a();
        信息查询a searchInformation = new 信息查询a();
        修改用户信息a modifyInformation = new 修改用户信息a();
        public 账户操作a()
        {
            InitializeComponent();
            bankcard.ButtonBack += BackToA;
            searchInformation.ButtonBack += BackToA;
            modifyInformation.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            // 修改柜台业务B中的控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(bankcard);
            panel1.BringToFront();//显示置顶
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(searchInformation);
            panel1.BringToFront();//显示置顶
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modifyInformation);
            panel1.BringToFront();//显示置顶
        }
    }
}
