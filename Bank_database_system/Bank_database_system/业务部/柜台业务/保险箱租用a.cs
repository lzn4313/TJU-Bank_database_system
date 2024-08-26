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
    public partial class 保险箱租用a : UserControl
    {
        保险箱租用b rent_safebox2=new 保险箱租用b();
        保险箱租用c rent_safebox3=new 保险箱租用c();
        public event EventHandler ButtonBack;
        public 保险箱租用a()
        {
            InitializeComponent();
            rent_safebox2.ButtonBack += BackToA;
            rent_safebox3.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            // 修改柜台业务a中的控件状态
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;
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

        private void checkButton_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            rent_safebox2.CardID_Set(textBox5.Text);
            panel1.Controls.Add(rent_safebox2);
            panel1.BringToFront();//显示置顶
        }

        private void button0_Click(object sender, EventArgs e)
        {
            //切换到下一页面
            panel1.Visible = true;
            panel1.Controls.Clear();
            //rent_safebox3.CardID_Set(textBox5.Text);
            panel1.Controls.Add(rent_safebox3);
            panel1.BringToFront();//显示置顶
        }


    }
}