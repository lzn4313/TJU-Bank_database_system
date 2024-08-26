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

namespace Bank_database_system.业务部.贷款业务
{
    public partial class 贷款业务a : UserControl
    {
        贷款办理a loanProcessing = new 贷款办理a();
        贷款查询a loanSearching = new 贷款查询a();

        public 贷款业务a()
        {
            InitializeComponent();
            loanProcessing.ButtonBack += BackToA;
            loanSearching.ButtonBack += BackToA;
        }

        private void BackToA(object sender, EventArgs e)
        {           
            // 修改控件状态      
            panel1.Visible = false;
            panel1.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(loanProcessing);
            panel1.BringToFront();//显示置顶
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(loanSearching);
            panel1.BringToFront();//显示置顶
        }

    }
}
