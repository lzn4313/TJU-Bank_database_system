namespace Bank_database_system
{
    partial class 资金调度c
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label5 = new Label();
            button9 = new Button();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            button8 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Info;
            textBox3.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox3.Location = new Point(333, 363);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(216, 34);
            textBox3.TabIndex = 92;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Info;
            textBox2.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox2.Location = new Point(333, 282);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(216, 34);
            textBox2.TabIndex = 91;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("黑体", 42F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label5.ForeColor = Color.FromArgb(128, 128, 255);
            label5.Location = new Point(283, 106);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(252, 56);
            label5.TabIndex = 90;
            label5.Text = "申请处理";
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(146, 471);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(196, 75);
            button9.TabIndex = 89;
            button9.Text = "同意申请";
            button9.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(176, 368);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 29);
            label4.TabIndex = 88;
            label4.Text = "申请金额";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(176, 287);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(138, 29);
            label3.TabIndex = 87;
            label3.Text = " 支行名 ";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(333, 208);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 34);
            textBox1.TabIndex = 86;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(176, 213);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 29);
            label2.TabIndex = 85;
            label2.Text = " 支行ID ";
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(128, 128, 255);
            button8.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(48, 35);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(120, 69);
            button8.TabIndex = 84;
            button8.Text = "返回";
            button8.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(391, 471);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(196, 75);
            button1.TabIndex = 93;
            button1.Text = "拒绝申请";
            button1.UseVisualStyleBackColor = false;
            // 
            // 资金调度c
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(button9);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button8);
            Name = "资金调度c";
            Size = new Size(779, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private Label label5;
        private Button button9;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Button button8;
        private Button button1;
    }
}
