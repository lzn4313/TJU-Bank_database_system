using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_database_system.业务部.贷款业务
{
    public partial class 贷款查询d : UserControl
    {
        public event EventHandler ButtonBack;
        public 贷款查询d()
        {
            InitializeComponent();
        }

        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;
            //其它
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
        private void button2_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("请再次确认是否提前还款！", "确认保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //密码
                if (true)//密码正确
                {
                    //后端
                    MessageBox.Show("提前还款成功！");
                    //前端显示调用需改变的部分
                }
            }

        }
    }
}
