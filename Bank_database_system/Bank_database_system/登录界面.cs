using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system
{
    public partial class 登录界面 : Form
    {
        public 登录界面()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string textBoxValue = textBox1.Text;

            if (textBoxValue == "1")//跳转到信息部门
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            if (textBoxValue == "2")//跳转到人事部门
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }
            if (textBoxValue == "3")//跳转到财务部门
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
            if (textBoxValue == "4")//跳转到业务部门
            {
                DialogResult = DialogResult.Continue;
                this.Close();
            }
        }

        private void 登录界面_Load(object sender, EventArgs e)
        {

        }
    }
}
