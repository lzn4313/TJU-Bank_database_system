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
    public partial class 保险箱租用b : UserControl
    {
        public event EventHandler ButtonBack;
        public 保险箱租用b()
        {
            InitializeComponent();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "空闲中")
            {
                DialogResult result = MessageBox.Show("请确认是否租用支行 " + textBox2.Text + " 的保险箱 " + textBox1.Text+" 。", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //租用过程
                    MessageBox.Show("成功租用租用支行 " + textBox2.Text + " 的保险箱 " + textBox1.Text+" ！");
                    textBox6.Text = "被租用";//成功后更新
                }
            }
            else if(textBox6.Text == "被租用")
            {
                MessageBox.Show("支行 " + textBox2.Text + " 的保险箱 " + textBox1.Text + " 已被他人租用！");
            }
        }

    }
}
