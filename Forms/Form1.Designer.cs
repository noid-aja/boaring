namespace WinFormsApp1
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
            tbusr = new TextBox();
            tbpw = new TextBox();
            btnlogin = new Button();
            linkregister = new LinkLabel();
            SuspendLayout();
            // 
            // tbusr
            // 
            tbusr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbusr.BackColor = Color.FromArgb(17, 37, 0);
            tbusr.BorderStyle = BorderStyle.None;
            tbusr.Font = new Font("Segoe UI", 9F);
            tbusr.ForeColor = Color.WhiteSmoke;
            tbusr.Location = new Point(276, 145);
            tbusr.Margin = new Padding(4);
            tbusr.Name = "tbusr";
            tbusr.PlaceholderText = "Masukan Username";
            tbusr.Size = new Size(254, 20);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // tbpw
            // 
            tbpw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbpw.BackColor = Color.FromArgb(17, 37, 0);
            tbpw.BorderStyle = BorderStyle.None;
            tbpw.Font = new Font("Segoe UI", 9F);
            tbpw.ForeColor = Color.WhiteSmoke;
            tbpw.Location = new Point(276, 211);
            tbpw.Margin = new Padding(4);
            tbpw.Name = "tbpw";
            tbpw.PasswordChar = '*';
            tbpw.PlaceholderText = "Masukan Password";
            tbpw.Size = new Size(254, 20);
            tbpw.TabIndex = 1;
            tbpw.UseSystemPasswordChar = true;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnlogin.BackColor = Color.Transparent;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnlogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Location = new Point(273, 301);
            btnlogin.Margin = new Padding(4);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(254, 38);
            btnlogin.TabIndex = 0;
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // linkregister
            // 
            linkregister.ActiveLinkColor = Color.ForestGreen;
            linkregister.AutoSize = true;
            linkregister.BackColor = Color.Transparent;
            linkregister.Font = new Font("Segoe UI", 7F);
            linkregister.LinkColor = Color.White;
            linkregister.Location = new Point(439, 345);
            linkregister.Name = "linkregister";
            linkregister.Size = new Size(90, 15);
            linkregister.TabIndex = 6;
            linkregister.TabStop = true;
            linkregister.Text = "Daftar Sekarang";
            linkregister.LinkClicked += linkregister_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginnnn__1_;
            ClientSize = new Size(799, 450);
            Controls.Add(linkregister);
            Controls.Add(btnlogin);
            Controls.Add(tbpw);
            Controls.Add(tbusr);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbusr;
        private TextBox tbpw;
        private Button btnlogin;
        private LinkLabel linkregister;
    }
}
