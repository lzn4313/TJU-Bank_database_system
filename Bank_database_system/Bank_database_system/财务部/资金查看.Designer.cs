namespace Bank_database_system.财务部
{
    partial class 资金查看
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(60, 46);
            label1.Name = "label1";
            label1.Size = new Size(130, 24);
            label1.TabIndex = 0;
            label1.Text = "当前银行：";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("黑体", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(212, 90);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 1;
            label2.Text = "存款类型";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("黑体", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(350, 90);
            label3.Name = "label3";
            label3.Size = new Size(54, 22);
            label3.TabIndex = 2;
            label3.Text = "金额";
            label3.Click += label3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.MenuText;
            dataGridView1.Location = new Point(196, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(292, 181);
            dataGridView1.TabIndex = 3;
            // 
            // 资金查看
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "资金查看";
            Size = new Size(779, 750);
            Load += 资金查看_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
    }
}
