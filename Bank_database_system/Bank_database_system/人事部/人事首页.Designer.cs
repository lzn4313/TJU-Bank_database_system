﻿namespace Bank_database_system
{
    partial class 人事首页
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(人事首页));
            label1 = new Label();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button8 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(26, 128);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 22);
            label1.TabIndex = 17;
            label1.Text = "ID：";
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(372, 96);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(18, 580);
            button7.TabIndex = 15;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(-22, 615);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(162, 170);
            button6.TabIndex = 14;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(26, 11);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(128, 135);
            button5.TabIndex = 13;
            button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(26, 155);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(144, 483);
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(192, 146);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(176, 167);
            button2.TabIndex = 19;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(182, 310);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(197, 184);
            button3.TabIndex = 20;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(167, 492);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(225, 165);
            button4.TabIndex = 21;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(398, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 750);
            panel1.TabIndex = 32;
            panel1.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(159, 688);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 36;
            label3.Text = "当前时间：";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(159, 52);
            label2.Name = "label2";
            label2.Size = new Size(90, 42);
            label2.TabIndex = 35;
            label2.Text = "姓名：\r\n支行名称：";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button8
            // 
            button8.ForeColor = SystemColors.ControlText;
            button8.Location = new Point(12, 11);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 37;
            button8.Text = "注销";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // 人事首页
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1184, 761);
            Controls.Add(button8);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(2);
            Name = "人事首页";
            Text = "人事首页";
            Load += 人事首页_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button button8;
    }
}