namespace WinFormsApp1
{
    partial class Formmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formmenu));
            pnlmenu = new Panel();
            pnl1 = new Panel();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            btnmenu = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            pnlmenu.SuspendLayout();
            pnl1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlmenu
            // 
            pnlmenu.BackColor = SystemColors.ActiveCaption;
            pnlmenu.Controls.Add(pnl1);
            pnlmenu.Controls.Add(btnmenu);
            pnlmenu.Controls.Add(panel2);
            pnlmenu.Dock = DockStyle.Left;
            pnlmenu.Location = new Point(0, 0);
            pnlmenu.Name = "pnlmenu";
            pnlmenu.Size = new Size(200, 506);
            pnlmenu.TabIndex = 0;
            pnlmenu.Paint += pnlmenu_Paint;
            // 
            // pnl1
            // 
            pnl1.Controls.Add(btn4);
            pnl1.Controls.Add(btn3);
            pnl1.Controls.Add(btn2);
            pnl1.Controls.Add(btn1);
            pnl1.Dock = DockStyle.Top;
            pnl1.Location = new Point(0, 129);
            pnl1.Name = "pnl1";
            pnl1.Size = new Size(200, 166);
            pnl1.TabIndex = 2;
            // 
            // btn4
            // 
            btn4.Dock = DockStyle.Top;
            btn4.FlatStyle = FlatStyle.Flat;
            btn4.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic);
            btn4.ImageAlign = ContentAlignment.MiddleLeft;
            btn4.Location = new Point(0, 123);
            btn4.Name = "btn4";
            btn4.Padding = new Padding(25, 0, 0, 0);
            btn4.Size = new Size(200, 41);
            btn4.TabIndex = 3;
            btn4.Text = "Comming Soon";
            btn4.TextAlign = ContentAlignment.MiddleLeft;
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn3
            // 
            btn3.Dock = DockStyle.Top;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic);
            btn3.ImageAlign = ContentAlignment.MiddleLeft;
            btn3.Location = new Point(0, 82);
            btn3.Name = "btn3";
            btn3.Padding = new Padding(25, 0, 0, 0);
            btn3.Size = new Size(200, 41);
            btn3.TabIndex = 2;
            btn3.Text = "Comming Soon";
            btn3.TextAlign = ContentAlignment.MiddleLeft;
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.Dock = DockStyle.Top;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic);
            btn2.ImageAlign = ContentAlignment.MiddleLeft;
            btn2.Location = new Point(0, 41);
            btn2.Name = "btn2";
            btn2.Padding = new Padding(25, 0, 0, 0);
            btn2.Size = new Size(200, 41);
            btn2.TabIndex = 1;
            btn2.Text = "Comming Soon";
            btn2.TextAlign = ContentAlignment.MiddleLeft;
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Dock = DockStyle.Top;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic);
            btn1.ImageAlign = ContentAlignment.MiddleLeft;
            btn1.Location = new Point(0, 0);
            btn1.Name = "btn1";
            btn1.Padding = new Padding(25, 0, 0, 0);
            btn1.Size = new Size(200, 41);
            btn1.TabIndex = 0;
            btn1.Text = "Comming Soon";
            btn1.TextAlign = ContentAlignment.MiddleLeft;
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btnmenu
            // 
            btnmenu.Dock = DockStyle.Top;
            btnmenu.FlatStyle = FlatStyle.Flat;
            btnmenu.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnmenu.Location = new Point(0, 78);
            btnmenu.Margin = new Padding(0);
            btnmenu.Name = "btnmenu";
            btnmenu.Size = new Size(200, 51);
            btnmenu.TabIndex = 1;
            btnmenu.Text = "coming soon";
            btnmenu.TextAlign = ContentAlignment.MiddleLeft;
            btnmenu.UseVisualStyleBackColor = true;
            btnmenu.Click += btnmenu_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 78);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(510, 173);
            panel3.Name = "panel3";
            panel3.Size = new Size(8, 8);
            panel3.TabIndex = 1;
            // 
            // Formmenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1042, 506);
            Controls.Add(panel3);
            Controls.Add(pnlmenu);
            Name = "Formmenu";
            Text = "Formmenu";
            Load += Formmenu_Load;
            pnlmenu.ResumeLayout(false);
            pnl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlmenu;
        private Button btnmenu;
        private Panel panel2;
        private Panel panel3;
        private Panel pnl1;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button btn1;
    }
}