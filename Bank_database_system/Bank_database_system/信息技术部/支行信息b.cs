using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Bank_database_system
{
    public partial class 支行信息b : UserControl
    {
        // 定义一个事件，用于通知父控件
        public event EventHandler ButtonBack;
        
        public 支行信息b()
        {
            InitializeComponent();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            // 触发事件，通知父控件
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }

        private void 支行信息b_Load(object sender, EventArgs e)
        {

        }
    }
}
