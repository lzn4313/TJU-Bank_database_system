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
    public partial class 修改员工a : UserControl
    {
        修改员工c cha_emplyinf_c = new 修改员工c();

        public 修改员工a()
        {
            InitializeComponent();
            cha_emplyinf_c.ButtonBack += BackToA;
            dataGridView1.DataSource = HR.HRtable(string.Empty, string.Empty, string.Empty, string.Empty);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            dataGridView1.DataSource = HR.HRtable(string.Empty, string.Empty, string.Empty, string.Empty);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(cha_emplyinf_c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = HR.HRtable(textBox5.Text, textBox2.Text, textBox1.Text, comboBox1.Text);
        }
    }
}
