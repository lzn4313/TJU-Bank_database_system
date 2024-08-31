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
        删除员工c del_emplyinf_c = new 删除员工c();
        public 删除员工a()
        {
            InitializeComponent();
            del_emplyinf_c.ButtonBack += BackToA;
        }
        private void BackToA(object sender, EventArgs e)
        {
            // 修改支行信息a中的控件状态
            //panel1.Visible = false;
            //panel1.Controls.Clear();
        }
        private void 删除员工a_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("当前输入为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();
            }
            else
            {
                HR.HRinfo info = HR.ReadHR(textBox1.Text);
                textBox3.Text = info.STAFF_ID;
                textBox4.Text = info.BRANCH_ID;
                textBox5.Text = info.NAME;
                textBox2.Text = info.ID;
                textBox9.Text = info.CARD;
                textBox8.Text = info.PHONE;
                textBox6.Text = info.ADDRESS;
                textBox7.Text = info.SALARY;
                comboBox1.Text = info.DEPARTMENT;
                comboBox2.Text = info.CONDITION;
                //panel1.Visible = true;
                //panel1.Controls.Clear();
                //panel1.Controls.Add(del_emplyinf_c);无用代码，以防要用先留着

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && 
                textBox2.Text != string.Empty && textBox9.Text != string.Empty && textBox8.Text != string.Empty && textBox6.Text != string.Empty && 
                textBox6.Text != string.Empty && textBox7.Text != string.Empty && comboBox1.Text != string.Empty && comboBox2.Text != string.Empty)
            {
                HR.UpdateHR(textBox3.Text, textBox4.Text, textBox2.Text, textBox5.Text, textBox6.Text, textBox8.Text, Convert.ToDouble(textBox7.Text), comboBox2.Text, comboBox1.Text, textBox9.Text);
            }
            else
            {
                MessageBox.Show("修改不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
           
    }
}
