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
    public partial class 删除员工a : UserControl
    {
        删除员工c del_emplyinf_c= new 删除员工c();
        public 删除员工a()
        {
            InitializeComponent();
            del_emplyinf_c.ButtonBack += BackToA;
        }
        private void BackToA(object sender, EventArgs e)
        {
            // 修改支行信息a中的控件状态
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void 删除员工a_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("查询失败，请检查ID正确与否", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                panel1.Visible = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(del_emplyinf_c);
            }
        }
    }
}
