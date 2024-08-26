namespace Bank_database_system.业务部.贷款业务
{
    partial class 贷款办理a
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
            textBox5 = new TextBox();
            label8 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button9 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Info;
            textBox5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox5.Location = new Point(324, 131);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(213, 31);
            textBox5.TabIndex = 184;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ActiveCaption;
            label8.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.Location = new Point(213, 131);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(138, 29);
            label8.TabIndex = 183;
            label8.Text = " 卡号： ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Yellow;
            label2.Font = new Font("楷体", 42F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(264, 37);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(252, 56);
            label2.TabIndex = 181;
            label2.Text = "贷款办理";
            label2.TextAlign = ContentAlignment.BottomRight;
            label2.UseMnemonic = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(324, 187);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(213, 31);
            textBox1.TabIndex = 186;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(213, 187);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 29);
            label1.TabIndex = 185;
            label1.Text = " 密码： ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(404, 263);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(108, 54);
            button1.TabIndex = 188;
            button1.Text = "取消";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(264, 263);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(108, 54);
            button9.TabIndex = 187;
            button9.Text = "确认";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 750);
            panel1.TabIndex = 189;
            panel1.Visible = false;
            // 
            // 贷款办理a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button1);
            Controls.Add(button9);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "贷款办理a";
            Size = new Size(779, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox5;
        private Label label8;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button9;
        private Panel panel1;
    }
}
