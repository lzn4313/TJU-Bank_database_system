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
    public partial class 交易记录查询b : UserControl
    {
        public event EventHandler ButtonBack;
        交易记录查询c query_records3 = new 交易记录查询c();
        public 交易记录查询b()
        {
            InitializeComponent();
            query_records3.ButtonBack += BackToB;
        }

        private void BackToB(object sender, EventArgs e)
        {
            // 修改交易记录查询B中的控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        public void CardID_Set(string text)
        {
            textBox5.Text = text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            //调用筛选以重置
            MessageBox.Show("重置(未完成)!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //筛选作用
            MessageBox.Show("筛选(未完成)!");
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
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            query_records3.CardID_Set(textBox5.Text);
            panel1.Controls.Add(query_records3);
            panel1.BringToFront();//显示置顶
        }
    }
}
