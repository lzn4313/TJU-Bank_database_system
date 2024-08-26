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
    public partial class 删除员工c : UserControl
    {
        public event EventHandler ButtonBack;
        public 删除员工c()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
