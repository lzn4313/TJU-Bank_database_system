namespace Bank_database_system.业务部
{
    partial class 输入密码
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
            textBox5 = new TextBox();
            label8 = new Label();
            label1 = new Label();
            button9 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Info;
            textBox5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox5.Location = new Point(136, 75);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(213, 31);
            textBox5.TabIndex = 173;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ActiveCaption;
            label8.Font = new Font("楷体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.Location = new Point(25, 75);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(138, 29);
            label8.TabIndex = 172;
            label8.Text = " 密码： ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 304);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 174;
            label1.Text = "操作时限：";
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(55, 175);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(108, 54);
            button9.TabIndex = 175;
            button9.Text = "确认";
            button9.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("楷体", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(195, 175);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(108, 54);
            button1.TabIndex = 176;
            button1.Text = "取消";
            button1.UseVisualStyleBackColor = false;
            // 
            // 取款b
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(button1);
            Controls.Add(button9);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Name = "取款b";
            Text = "取款b";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox5;
        private Label label8;
        private Label label1;
        private Button button9;
        private Button button1;
    }
}