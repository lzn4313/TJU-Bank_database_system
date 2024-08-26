namespace Bank_database_system.业务部
{
    partial class 操作成功失败提示
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button9 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(135, 96);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(108, 54);
            button9.TabIndex = 176;
            button9.Text = "确认";
            button9.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("楷体", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(76, 28);
            label1.Name = "label1";
            label1.Size = new Size(241, 19);
            label1.TabIndex = 177;
            label1.Text = "操作成功/失败+失败原因";
            // 
            // 操作成功失败提示
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(384, 161);
            Controls.Add(label1);
            Controls.Add(button9);
            Name = "操作成功失败提示";
            Text = "操作成功失败提示";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button9;
        private Label label1;
    }
}