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
    public partial class 修改用户信息a : UserControl
    {
        修改用户信息b modifyB = new 修改用户信息b();
        public event EventHandler ButtonBack;
        public 修改用户信息a()
        {
            InitializeComponent();
            modifyB.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {
            // 修改柜台业务B中的控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("重置成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //筛选待完善
            MessageBox.Show("筛选成功！");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            modifyB.Information_Set(textBox1.Text);
            panel1.Controls.Add(modifyB);
            panel1.BringToFront();//显示置顶
        }
    }
}
