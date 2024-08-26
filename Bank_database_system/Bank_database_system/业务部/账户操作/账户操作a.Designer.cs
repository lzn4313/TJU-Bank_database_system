namespace Bank_database_system.业务部.账户操作
{
    partial class 账户操作a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(账户操作a));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(55, 207);
            button1.Name = "button1";
            button1.Size = new Size(177, 173);
            button1.TabIndex = 186;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(292, 212);
            button2.Name = "button2";
            button2.Size = new Size(189, 168);
            button2.TabIndex = 187;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(531, 207);
            button3.Name = "button3";
            button3.Size = new Size(200, 175);
            button3.TabIndex = 188;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 750);
            panel1.TabIndex = 189;
            panel1.Visible = false;
            // 
            // 账户操作a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "账户操作a";
            Size = new Size(779, 750);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
    }
}
