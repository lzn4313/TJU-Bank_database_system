namespace Bank_database_system.业务部
{
    partial class 操作确认
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
            label1 = new Label();
            button1 = new Button();
            button9 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("楷体", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(82, 30);
            label1.Name = "label1";
            label1.Size = new Size(198, 19);
            label1.TabIndex = 178;
            label1.Text = "确认执行某某操作？";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(206, 75);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(108, 54);
            button1.TabIndex = 180;
            button1.Text = "取消";
            button1.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(66, 75);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(108, 54);
            button9.TabIndex = 179;
            button9.Text = "确认";
            button9.UseVisualStyleBackColor = false;
            // 
            // 操作确认
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(384, 161);
            Controls.Add(button1);
            Controls.Add(button9);
            Controls.Add(label1);
            Name = "操作确认";
            Text = "操作确认";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button9;
    }
}