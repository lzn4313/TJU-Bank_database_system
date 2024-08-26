namespace Bank_database_system.业务部.账户操作
{
    partial class 银行卡办理a
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
            button8 = new Button();
            label2 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            button9 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(128, 128, 255);
            button8.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(44, 33);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(120, 69);
            button8.TabIndex = 180;
            button8.Text = "返回";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Yellow;
            label2.Font = new Font("楷体", 42F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(230, 33);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(309, 56);
            label2.TabIndex = 179;
            label2.Text = "银行卡办理";
            label2.TextAlign = ContentAlignment.BottomRight;
            label2.UseMnemonic = false;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Info;
            textBox5.CharacterCasing = CharacterCasing.Upper;
            textBox5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox5.Location = new Point(259, 132);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(280, 31);
            textBox5.TabIndex = 182;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ActiveCaption;
            label8.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.Location = new Point(87, 134);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(168, 29);
            label8.TabIndex = 181;
            label8.Text = "身份证号：";
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(562, 122);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(97, 49);
            button9.TabIndex = 183;
            button9.Text = "办理";
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
            // 银行卡办理a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button9);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(button8);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "银行卡办理a";
            Size = new Size(779, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button8;
        private Label label2;
        private TextBox textBox5;
        private Label label8;
        private Button button9;
        private Panel panel1;
    }
}
