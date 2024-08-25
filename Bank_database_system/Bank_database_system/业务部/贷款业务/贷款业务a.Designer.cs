namespace Bank_database_system.业务部.贷款业务
{
    partial class 贷款业务a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(贷款业务a));
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(163, 258);
            button2.Name = "button2";
            button2.Size = new Size(162, 162);
            button2.TabIndex = 187;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(430, 258);
            button1.Name = "button1";
            button1.Size = new Size(180, 162);
            button1.TabIndex = 188;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 750);
            panel1.TabIndex = 189;
            panel1.Visible = false;
            // 
            // 贷款业务a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(panel1);
            Name = "贷款业务a";
            Size = new Size(779, 750);
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
        private Panel panel1;
    }
}
