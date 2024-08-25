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
    public partial class 修改员工c : UserControl
    {
        public event EventHandler ButtonBack;
        
        public 修改员工c()
        {
            InitializeComponent();
        }

        private void 修改员工c_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
