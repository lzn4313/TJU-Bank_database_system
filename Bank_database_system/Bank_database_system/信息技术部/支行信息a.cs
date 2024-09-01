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

namespace Bank_database_system
{
    public partial class 支行信息a : UserControl
    {
        支行信息b branch_inf_b = new 支行信息b();
        支行信息c branch_inf_c = new 支行信息c();
        public 支行信息a()
        {
            InitializeComponent();
            // 订阅支行信息b的返回事件
            branch_inf_b.ButtonBack += BackToA;
            branch_inf_c.ButtonBack += BackToA;
        }
        private void BackToA(object sender, EventArgs e)
        {
            // 修改支行信息a中的控件状态
            panel1.Visible = false;
            panel1.Controls.Clear();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(branch_inf_b);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void 支行信息a_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(branch_inf_c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox2.Text = null;
            dataGridView1.DataSource = null;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
