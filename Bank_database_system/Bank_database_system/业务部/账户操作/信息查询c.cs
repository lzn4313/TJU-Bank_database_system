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

    public partial class 信息查询c : UserControl
    {
        public event EventHandler ButtonBack;
        public 信息查询c()
        {
            InitializeComponent();
        }
        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;
            textBox1.Text = cardID;
            //剩下的查询
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "未冻结") {
                //密码
                if (true)//密码正确
                {
                    //后端数据同步
                    MessageBox.Show("卡号" + textBox5.Text + "冻结成功！");
                    textBox3.Text = "冻结";
                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入！");
                }
            }
            else{
                MessageBox.Show("卡号" + textBox5.Text + "已经冻结，无须操作！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "冻结")
            {
                //密码
                if (true)//密码正确
                {
                    //后端数据同步
                    MessageBox.Show("卡号" + textBox5.Text + "解冻成功！");
                    textBox3.Text = "未冻结";
                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入！");
                }
            }
            else
            {
                MessageBox.Show("卡号" + textBox5.Text + "未冻结，无须操作！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //密码
            if (true)//密码正确
            {
                //后端数据同步
                MessageBox.Show("卡号" + textBox5.Text + "已销户！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                ButtonBack?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！");
            }

        }
    }
}
