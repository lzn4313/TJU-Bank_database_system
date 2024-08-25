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
    public partial class 支行信息c : UserControl
    {
        public event EventHandler ButtonBack;
        public 支行信息c()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 触发事件，通知父控件
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void 支行信息c_Load(object sender, EventArgs e)
        {
            
        }
    }
}
