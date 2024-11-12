namespace AnonLeaks
{
    partial class Form4
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
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 51);
            label1.Name = "label1";
            label1.Size = new Size(117, 36);
            label1.TabIndex = 24;
            label1.Text = "Support";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Cyan;
            linkLabel1.Location = new Point(191, 124);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(77, 20);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "@forclogs";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.Cyan;
            linkLabel2.Location = new Point(190, 170);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(71, 20);
            linkLabel2.TabIndex = 26;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "@ivyfrost";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(190, 104);
            label2.Name = "label2";
            label2.Size = new Size(497, 20);
            label2.TabIndex = 27;
            label2.Text = "Need to acquire tokens? need to know the price? contact owner!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(190, 150);
            label3.Name = "label3";
            label3.Size = new Size(280, 20);
            label3.TabIndex = 28;
            label3.Text = "Found bugs? contact the developer!";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            ClientSize = new Size(800, 600);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Label label2;
        private Label label3;
    }
}