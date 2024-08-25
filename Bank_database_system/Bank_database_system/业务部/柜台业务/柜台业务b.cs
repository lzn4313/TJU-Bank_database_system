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
    public partial class 柜台业务b : UserControl
    {
        存款a deposit_money = new 存款a();
        取款a withdraw_money = new 取款a();
        转账a transfer_accounts = new 转账a();
        保险箱租用a rent_safebox = new 保险箱租用a();
        交易记录查询a query_records = new 交易记录查询a();
        定期存款a time_deposit = new 定期存款a();
        public event EventHandler ButtonBack;
        public 柜台业务b()
        {
            InitializeComponent();
            deposit_money.ButtonBack += BackToB;
            withdraw_money.ButtonBack += BackToB;
            transfer_accounts.ButtonBack += BackToB;
            rent_safebox.ButtonBack += BackToB;
            query_records.ButtonBack += BackToB;
            time_deposit.ButtonBack += BackToB;
        }
        private void BackToB(object sender, EventArgs e)
        {
            // 修改柜台业务B中的控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
        
        public void CardID_Set(string text)
        {
            textBox2.Text = text;
            //textBox1.Text = 余额;
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            deposit_money.CardID_Set(textBox2.Text);
            panel1.Controls.Add(deposit_money);
            panel1.BringToFront();//显示置顶
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            withdraw_money.CardID_Set(textBox2.Text);
            panel1.Controls.Add(withdraw_money);
            panel1.BringToFront();//显示置顶
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            transfer_accounts.CardID_Set(textBox2.Text);
            panel1.Controls.Add(transfer_accounts);
            panel1.BringToFront();//显示置顶
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            rent_safebox.CardID_Set(textBox2.Text);
            panel1.Controls.Add(rent_safebox);
            panel1.BringToFront();//显示置顶
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            query_records.CardID_Set(textBox2.Text);
            panel1.Controls.Add(query_records);
            panel1.BringToFront();//显示置顶
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            time_deposit.CardID_Set(textBox2.Text);
            panel1.Controls.Add(time_deposit);
            panel1.BringToFront();//显示置顶
        }
    }
   
}
