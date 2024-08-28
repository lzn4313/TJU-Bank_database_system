namespace Bank_database_system
{
    partial class 登录界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(登录界面));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(831, 759);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlDarkDark;
            pictureBox2.Location = new Point(827, 3);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(355, 757);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("楷体", 16F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(878, 146);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 22);
            label1.TabIndex = 4;
            label1.Text = "账号：";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(894, 192);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 32);
            textBox1.TabIndex = 5;
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("楷体", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(878, 268);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 22);
            label2.TabIndex = 6;
            label2.Text = "密码：";
            // 
            // textBox2
            // 
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(894, 311);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(223, 32);
            textBox2.TabIndex = 7;
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDarkDark;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlDarkDark;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(878, 402);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(248, 89);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // 登录界面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "登录界面";
            Text = "登录界面";
            Load += 登录界面_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button button1;
    }
}