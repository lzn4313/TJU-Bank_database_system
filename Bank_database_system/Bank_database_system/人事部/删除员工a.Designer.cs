namespace Bank_database_system
{
    partial class 删除员工a
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
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button8
            // 
            button8.BackColor = Color.Blue;
            button8.Font = new Font("楷体", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(518, 49);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(108, 65);
            button8.TabIndex = 39;
            button8.Text = "搜索";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Font = new Font("Microsoft YaHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(267, 59);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 45);
            textBox1.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("楷体", 22F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(94, 66);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 30);
            label2.TabIndex = 37;
            label2.Text = "查询ID：";
            label2.TextAlign = ContentAlignment.BottomRight;
            label2.UseMnemonic = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 747);
            panel1.TabIndex = 40;
            panel1.Visible = false;
            // 
            // 删除员工a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel1);
            Controls.Add(button8);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "删除员工a";
            Size = new Size(779, 750);
            Load += 删除员工a_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button8;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
    }
}
