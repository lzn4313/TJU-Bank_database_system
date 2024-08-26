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
    
    public partial class 保险箱租用c : UserControl
    {
        public event EventHandler ButtonBack;
        public 保险箱租用c()
        {
            InitializeComponent();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
    }
}
