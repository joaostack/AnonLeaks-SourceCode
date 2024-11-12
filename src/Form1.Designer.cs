namespace AnonLeaks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button2 = new Button();
            panel1 = new Panel();
            button1 = new Button();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            button5 = new Button();
            button4 = new Button();
            titleLabel = new Label();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            label3 = new Label();
            button6 = new Button();
            button7 = new Button();
            label5 = new Label();
            button8 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(3, 194);
            button2.Name = "button2";
            button2.Size = new Size(166, 74);
            button2.TabIndex = 10;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 15, 15);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(titleLabel);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 599);
            panel1.TabIndex = 13;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(3, 353);
            button1.Name = "button1";
            button1.Size = new Size(166, 74);
            button1.TabIndex = 18;
            button1.Text = "Support";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.Location = new Point(0, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 23);
            linkLabel2.TabIndex = 0;
            // 
            // linkLabel1
            // 
            linkLabel1.Location = new Point(0, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(100, 23);
            linkLabel1.TabIndex = 1;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(3, 114);
            button5.Name = "button5";
            button5.Size = new Size(166, 74);
            button5.TabIndex = 17;
            button5.Text = "Home";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(3, 273);
            button4.Name = "button4";
            button4.Size = new Size(166, 74);
            button4.TabIndex = 13;
            button4.Text = "Configuration";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(36, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(112, 26);
            titleLabel.TabIndex = 9;
            titleLabel.Text = "AnonLeaks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 51);
            label1.Name = "label1";
            label1.Size = new Size(168, 36);
            label1.TabIndex = 18;
            label1.Text = "Welcome to";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(264, 102);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 18;
            label4.Text = "Loading stats...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(350, 51);
            label2.Name = "label2";
            label2.Size = new Size(152, 36);
            label2.TabIndex = 19;
            label2.Text = "AnonLeaks";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(15, 15, 15);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Lime;
            textBox1.Location = new Point(190, 208);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "No logs...";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(598, 380);
            textBox1.TabIndex = 20;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(651, 169);
            button3.Name = "button3";
            button3.Size = new Size(137, 33);
            button3.TabIndex = 21;
            button3.Text = "Test API Connection";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(190, 180);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 22;
            label3.Text = "Output Log";
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(503, 169);
            button6.Name = "button6";
            button6.Size = new Size(142, 33);
            button6.TabIndex = 23;
            button6.Text = "Test Tor Connection";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(355, 169);
            button7.Name = "button7";
            button7.Size = new Size(142, 33);
            button7.TabIndex = 24;
            button7.Text = "Clear Output";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(264, 122);
            label5.Name = "label5";
            label5.Size = new Size(21, 20);
            label5.TabIndex = 25;
            label5.Text = "...";
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(189, 102);
            button8.Name = "button8";
            button8.Size = new Size(69, 40);
            button8.TabIndex = 26;
            button8.Text = "Refresh";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            ClientSize = new Size(800, 600);
            Controls.Add(button8);
            Controls.Add(label5);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "AnonLeaks";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Panel panel1;
        private Button button4;
        private Button button5;
        private Label label1;
        private Label label4;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Button button1;
        private Label label2;
        private Label titleLabel;
        public TextBox textBox1;
        private Button button3;
        private Label label3;
        private Button button6;
        private Button button7;
        private Label label5;
        private Button button8;
    }
}
