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
    public partial class 修改员工a : UserControl
    {
        修改员工c cha_emplyinf_c = new 修改员工c();

        public 修改员工a()
        {
            InitializeComponent();
            cha_emplyinf_c.ButtonBack += BackToA;
        }
        private void BackToA(object sender, EventArgs e)
        {
            // 修改支行信息a中的控件状态
            panel1.Visible = false;
            panel1.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(cha_emplyinf_c);
        }

        private void 修改员工a_Load(object sender, EventArgs e)
        {

        }
        
    }
}
