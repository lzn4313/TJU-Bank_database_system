namespace Bank_database_system
{
    partial class 容器首页
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(容器首页));
            button8 = new Button();
            SuspendLayout();
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(-1, 151);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(765, 412);
            button8.TabIndex = 26;
            button8.UseVisualStyleBackColor = true;
            // 
            // 容器首页
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(763, 711);
            Controls.Add(button8);
            Name = "容器首页";
            Text = "容器首页";
            ResumeLayout(false);
        }

        #endregion

        private Button button8;
    }
}