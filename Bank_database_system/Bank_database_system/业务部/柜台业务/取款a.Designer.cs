namespace Bank_database_system.业务部
{
    partial class 取款a
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
            label2 = new Label();
            button8 = new Button();
            button9 = new Button();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Yellow;
            label2.Font = new Font("楷体", 42F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(321, 44);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 56);
            label2.TabIndex = 38;
            label2.Text = "取款";
            label2.TextAlign = ContentAlignment.BottomRight;
            label2.UseMnemonic = false;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(128, 128, 255);
            button8.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(43, 31);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(120, 69);
            button8.TabIndex = 168;
            button8.Text = "返回";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(321, 468);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(138, 66);
            button9.TabIndex = 169;
            button9.Text = "确认";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Info;
            textBox5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox5.Location = new Point(321, 194);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(213, 31);
            textBox5.TabIndex = 171;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ActiveCaption;
            label8.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.Location = new Point(210, 194);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(138, 29);
            label8.TabIndex = 170;
            label8.Text = " 卡号： ";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(321, 280);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 31);
            textBox1.TabIndex = 173;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(210, 280);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 29);
            label1.TabIndex = 172;
            label1.Text = " 余额： ";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Info;
            textBox2.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox2.Location = new Point(321, 371);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 31);
            textBox2.TabIndex = 175;
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            textBox2.Leave += textBox2_leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(164, 371);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 29);
            label3.TabIndex = 174;
            label3.Text = "取款金额:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.Location = new Point(534, 371);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 25);
            label4.TabIndex = 175;
            label4.Text = "(CNY)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.Location = new Point(534, 280);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 25);
            label5.TabIndex = 174;
            label5.Text = "(CNY)";
            // 
            // 取款a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Name = "取款a";
            Size = new Size(779, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button8;
        private Button button9;
        private TextBox textBox5;
        private Label label8;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
