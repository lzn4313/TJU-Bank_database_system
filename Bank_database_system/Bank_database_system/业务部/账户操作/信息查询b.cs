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
    public partial class 信息查询b : UserControl
    {
        public event EventHandler ButtonBack;
        public 信息查询b()
        {
            InitializeComponent();
        }

        public void CardID_Set(string cardID)
        {
            textBox5.Text = cardID;            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
