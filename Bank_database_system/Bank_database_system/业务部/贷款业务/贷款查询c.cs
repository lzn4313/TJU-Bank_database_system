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

namespace Bank_database_system.业务部.贷款业务
{
    public partial class 贷款查询c : UserControl
    {
        public event EventHandler ButtonBack;
        贷款查询d loanSearching = new 贷款查询d();
        public 贷款查询c()
        {
            InitializeComponent();
            loanSearching.ButtonBack += BackToC;
        }

        private void BackToC(object sender, EventArgs e)
        {
            // 修改控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;
            //其它
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //上一页
            MessageBox.Show("上一页(未完成)!");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            //下一页
            MessageBox.Show("下一页(未完成)!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            loanSearching.CardID_Set(textBox5.Text);
            panel1.Controls.Add(loanSearching);
            panel1.BringToFront();//显示置顶
        }

    }
}
