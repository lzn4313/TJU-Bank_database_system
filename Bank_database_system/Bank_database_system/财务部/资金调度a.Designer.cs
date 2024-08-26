namespace Bank_database_system
{
    partial class 资金调度a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(资金调度a));
            button9 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button9
            // 
            button9.FlatStyle = FlatStyle.Flat;
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(447, 286);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(226, 234);
            button9.TabIndex = 43;
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(129, 286);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(254, 234);
            button8.TabIndex = 42;
            button8.UseVisualStyleBackColor = true;
            // 
            // 资金调度a
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button9);
            Controls.Add(button8);
            Name = "资金调度a";
            Size = new Size(779, 750);
            Load += 资金调度a_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button9;
        private Button button8;
    }
}
