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
    public partial class 交易记录查询c : UserControl
    {
        public event EventHandler ButtonBack;
        public 交易记录查询c()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        public void CardID_Set(string text)
        {
            textBox5.Text = text;
            //textBox6.Text = "转账中";
            if (textBox6.Text == "转账中")
            {
                button9.Visible = true;
            }
            else
                button9.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "转账中")
                button9.Visible = true;
            else
                button9.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            if (textBox6.Text == "转账中")
            {
                DialogResult result = MessageBox.Show("请确认是否撤销转账。", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                update();
                if (result == DialogResult.Yes && textBox6.Text == "转账中")
                {
                    //撤销过程
                    MessageBox.Show("撤销成功！");
                    textBox6.Text = "已撤销";//成功后更新
                }
                else if(textBox6.Text =="已完成")
                    MessageBox.Show("撤销失败，该转账操作已完成！");
            }
            else
            {
                MessageBox.Show("撤销失败，该转账操作已完成！");
            }
        }

        private void update()
        {
            //用于更新信息
        }
    }
}
