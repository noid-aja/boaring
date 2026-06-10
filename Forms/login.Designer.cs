namespace WinFormsApp1
{
    partial class login
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
            tbusr = new TextBox();
            tbpw = new TextBox();
            btnlogin = new Button();
            label1 = new Label();
            label2 = new Label();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            npgsqlCommandBuilder2 = new Npgsql.NpgsqlCommandBuilder();
            label3 = new Label();
            label4 = new Label();
            btnregisterr = new LinkLabel();
            SuspendLayout();
            // 
            // tbusr
            // 
            tbusr.BackColor = Color.White;
            tbusr.BorderStyle = BorderStyle.None;
            tbusr.Dock = DockStyle.Fill;
            tbusr.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbusr.Location = new Point(0, 0);
            tbusr.Margin = new Padding(4);
            tbusr.Name = "tbusr";
            tbusr.RightToLeft = RightToLeft.No;
            tbusr.Size = new Size(782, 27);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // tbpw
            // 
            tbpw.BackColor = Color.White;
            tbpw.BorderStyle = BorderStyle.None;
            tbpw.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbpw.Location = new Point(273, 213);
            tbpw.Margin = new Padding(4);
            tbpw.Name = "tbpw";
            tbpw.RightToLeft = RightToLeft.No;
            tbpw.Size = new Size(253, 27);
            tbpw.TabIndex = 1;
            tbpw.UseSystemPasswordChar = true;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.Transparent;
            btnlogin.BackgroundImageLayout = ImageLayout.None;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnlogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.Transparent;
            btnlogin.Location = new Point(277, 292);
            btnlogin.Margin = new Padding(4);
            btnlogin.Name = "btnlogin";
            btnlogin.RightToLeft = RightToLeft.No;
            btnlogin.Size = new Size(247, 31);
            btnlogin.TabIndex = 0;
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(447, 135);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 200);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(0, 20);
            label2.TabIndex = 3;
            label2.Click += label2_Click;
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // npgsqlCommandBuilder2
            // 
            npgsqlCommandBuilder2.QuotePrefix = "\"";
            npgsqlCommandBuilder2.QuoteSuffix = "\"";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(452, 337);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(0, 20);
            label3.TabIndex = 7;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(505, 109);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(0, 20);
            label4.TabIndex = 11;
            label4.Click += label4_Click;
            // 
            // btnregisterr
            // 
            btnregisterr.ActiveLinkColor = Color.FromArgb(0, 192, 0);
            btnregisterr.AutoSize = true;
            btnregisterr.BackColor = Color.Transparent;
            btnregisterr.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnregisterr.LinkColor = Color.White;
            btnregisterr.Location = new Point(423, 329);
            btnregisterr.Name = "btnregisterr";
            btnregisterr.Size = new Size(105, 17);
            btnregisterr.TabIndex = 12;
            btnregisterr.TabStop = true;
            btnregisterr.Text = "Daftar Sekarang";
            btnregisterr.LinkClicked += linkLabel1_LinkClicked;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = Properties.Resources.loginnnn__2_;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(782, 448);
            Controls.Add(btnregisterr);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(tbusr);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbpw);
            Controls.Add(btnlogin);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "login";
            RightToLeft = RightToLeft.No;
            Text = "Halaman Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbusr;
        private TextBox tbpw;
        private Button btnlogin;
        private Label label1;
        private Label label2;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder2;
        private Label label3;
        private Label label4;
        private LinkLabel btnregisterr;
    }
}
