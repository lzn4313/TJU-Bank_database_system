﻿namespace Bank_database_system
{
    partial class 操作记录a
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            button9 = new Button();
            button8 = new Button();
            label7 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            label10 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            button13 = new Button();
            button12 = new Button();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label8.Location = new Point(80, 275);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(614, 30);
            label8.TabIndex = 57;
            label8.Text = "操作ID    操作员工ID    操作类型        操作时间    操作IP地址";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(342, 204);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(31, 25);
            label6.TabIndex = 53;
            label6.Text = "到";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Font = new Font("楷体", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label5.Location = new Point(29, 199);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(107, 30);
            label5.TabIndex = 52;
            label5.Text = " 时间 ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("楷体", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(360, 114);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 30);
            label4.TabIndex = 51;
            label4.Text = "操作类型";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(140, 106);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 45);
            textBox1.TabIndex = 50;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("楷体", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(29, 114);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 30);
            label3.TabIndex = 49;
            label3.Text = "员工ID";
            // 
            // button9
            // 
            button9.BackColor = SystemColors.ActiveCaption;
            button9.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.Location = new Point(568, 39);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(105, 48);
            button9.TabIndex = 48;
            button9.Text = "筛选";
            button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button8.Location = new Point(432, 39);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(105, 48);
            button8.TabIndex = 47;
            button8.Text = "重置";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("黑体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label7.Location = new Point(50, 46);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(137, 29);
            label7.TabIndex = 46;
            label7.Text = "筛选条件";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(50, 117);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 22);
            label1.TabIndex = 45;
            label1.Text = "ID：";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Info;
            textBox3.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox3.Location = new Point(140, 190);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(198, 45);
            textBox3.TabIndex = 60;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Info;
            textBox4.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox4.Location = new Point(377, 191);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(198, 45);
            textBox4.TabIndex = 61;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Info;
            comboBox1.Font = new Font("Microsoft YaHei UI", 22.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "添加员工信息", "删除员工信息", "改动员工信息", "查询员工信息" });
            comboBox1.Location = new Point(517, 105);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 46);
            comboBox1.TabIndex = 62;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(65, 329);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(662, 310);
            dataGridView1.TabIndex = 58;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 14.25F);
            label10.Location = new Point(597, 645);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(31, 25);
            label10.TabIndex = 169;
            label10.Text = "页";
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Info;
            textBox6.Location = new Point(548, 645);
            textBox6.Margin = new Padding(2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(35, 23);
            textBox6.TabIndex = 168;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 14.25F);
            label9.Location = new Point(456, 645);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(88, 25);
            label9.TabIndex = 167;
            label9.Text = "跳转至第";
            // 
            // button13
            // 
            button13.Font = new Font("Microsoft YaHei UI", 14.25F);
            button13.Location = new Point(348, 638);
            button13.Margin = new Padding(2);
            button13.Name = "button13";
            button13.Size = new Size(79, 42);
            button13.TabIndex = 166;
            button13.Text = "下一页";
            button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Font = new Font("Microsoft YaHei UI", 14.25F);
            button12.Location = new Point(248, 638);
            button12.Margin = new Padding(2);
            button12.Name = "button12";
            button12.Size = new Size(78, 42);
            button12.TabIndex = 165;
            button12.Text = "上一页";
            button12.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft YaHei UI", 14.25F);
            label11.Location = new Point(155, 645);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(69, 25);
            label11.TabIndex = 164;
            label11.Text = "条记录";
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Info;
            textBox7.Location = new Point(115, 647);
            textBox7.Margin = new Padding(2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(36, 23);
            textBox7.TabIndex = 163;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft YaHei UI", 14.25F);
            label12.Location = new Point(61, 645);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(50, 25);
            label12.TabIndex = 162;
            label12.Text = "每页";
            // 
            // 操作记录a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(label10);
            Controls.Add(textBox6);
            Controls.Add(label9);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(label11);
            Controls.Add(textBox7);
            Controls.Add(label12);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(dataGridView1);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "操作记录a";
            Size = new Size(779, 750);
            Load += 操作记录a_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Button button9;
        private Button button8;
        private Label label7;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Label label10;
        private TextBox textBox6;
        private Label label9;
        private Button button13;
        private Button button12;
        private Label label11;
        private TextBox textBox7;
        private Label label12;
    }
}
