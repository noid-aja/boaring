namespace WinFormsApp1  // ← sama kayak FormRegister.cs
{
    partial class FormRegister  // ← nama class harus sama
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtnamapanjang = new TextBox();
            txtpassword = new TextBox();
            txtcpassword = new TextBox();
            Register = new Button();
            txtnotelp = new TextBox();
            txtrole = new ComboBox();
            txtusername = new TextBox();
            btnback = new Button();
            SuspendLayout();
            // 
            // txtnamapanjang
            // 
            txtnamapanjang.BackColor = Color.FromArgb(17, 37, 0);
            txtnamapanjang.BorderStyle = BorderStyle.None;
            txtnamapanjang.ForeColor = Color.WhiteSmoke;
            txtnamapanjang.Location = new Point(178, 141);
            txtnamapanjang.Margin = new Padding(2);
            txtnamapanjang.Name = "txtnamapanjang";
            txtnamapanjang.PlaceholderText = "Masukan Nama";
            txtnamapanjang.Size = new Size(198, 20);
            txtnamapanjang.TabIndex = 0;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(17, 37, 0);
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.ForeColor = Color.WhiteSmoke;
            txtpassword.Location = new Point(426, 208);
            txtpassword.Margin = new Padding(2);
            txtpassword.Name = "txtpassword";
            txtpassword.PlaceholderText = "Masukan Password";
            txtpassword.Size = new Size(200, 20);
            txtpassword.TabIndex = 4;
            txtpassword.UseSystemPasswordChar = true;
            txtpassword.TextChanged += txtpassword_TextChanged;
            // 
            // txtcpassword
            // 
            txtcpassword.BackColor = Color.FromArgb(17, 37, 0);
            txtcpassword.BorderStyle = BorderStyle.None;
            txtcpassword.ForeColor = Color.WhiteSmoke;
            txtcpassword.Location = new Point(426, 274);
            txtcpassword.Margin = new Padding(2);
            txtcpassword.Name = "txtcpassword";
            txtcpassword.PlaceholderText = "Ulangi Password";
            txtcpassword.Size = new Size(200, 20);
            txtcpassword.TabIndex = 6;
            txtcpassword.UseSystemPasswordChar = true;
            // 
            // Register
            // 
            Register.BackColor = Color.Transparent;
            Register.FlatAppearance.BorderSize = 0;
            Register.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Register.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Register.FlatStyle = FlatStyle.Flat;
            Register.Location = new Point(273, 331);
            Register.Margin = new Padding(2);
            Register.Name = "Register";
            Register.Size = new Size(254, 40);
            Register.TabIndex = 8;
            Register.UseVisualStyleBackColor = false;
            Register.Click += Register_Click;
            // 
            // txtnotelp
            // 
            txtnotelp.BackColor = Color.FromArgb(17, 37, 0);
            txtnotelp.BorderStyle = BorderStyle.None;
            txtnotelp.ForeColor = Color.WhiteSmoke;
            txtnotelp.Location = new Point(178, 273);
            txtnotelp.Margin = new Padding(2);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.PlaceholderText = "Masukan No.Telp";
            txtnotelp.Size = new Size(198, 20);
            txtnotelp.TabIndex = 12;
            // 
            // txtrole
            // 
            txtrole.AllowDrop = true;
            txtrole.BackColor = Color.FromArgb(17, 37, 0);
            txtrole.FlatStyle = FlatStyle.Flat;
            txtrole.ForeColor = SystemColors.WindowFrame;
            txtrole.FormattingEnabled = true;
            txtrole.Items.AddRange(new object[] { "Petani", "Pembeli" });
            txtrole.Location = new Point(424, 141);
            txtrole.Margin = new Padding(2);
            txtrole.MaxDropDownItems = 2;
            txtrole.Name = "txtrole";
            txtrole.Size = new Size(200, 28);
            txtrole.TabIndex = 14;
            txtrole.Tag = "";
            txtrole.Text = "Pilih Role";
            txtrole.SelectedIndexChanged += txtrole_SelectedIndexChanged;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(17, 37, 0);
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.ForeColor = Color.WhiteSmoke;
            txtusername.Location = new Point(178, 207);
            txtusername.Margin = new Padding(2);
            txtusername.Name = "txtusername";
            txtusername.PlaceholderText = "Masukan Username";
            txtusername.Size = new Size(198, 20);
            txtusername.TabIndex = 16;
            // 
            // btnback
            // 
            btnback.BackColor = Color.Transparent;
            btnback.FlatAppearance.BorderSize = 0;
            btnback.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnback.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnback.FlatStyle = FlatStyle.Flat;
            btnback.Location = new Point(154, 69);
            btnback.Name = "btnback";
            btnback.Size = new Size(72, 25);
            btnback.TabIndex = 17;
            btnback.UseVisualStyleBackColor = false;
            btnback.Click += button1_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.register__1_;
            ClientSize = new Size(799, 450);
            Controls.Add(btnback);
            Controls.Add(txtrole);
            Controls.Add(txtusername);
            Controls.Add(txtnotelp);
            Controls.Add(Register);
            Controls.Add(txtcpassword);
            Controls.Add(txtpassword);
            Controls.Add(txtnamapanjang);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "FormRegister";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtnamapanjang;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtcpassword;
        private System.Windows.Forms.Button Register;
        private TextBox txtnotelp;
        private ComboBox txtrole;
        private TextBox txtusername;
        private Button btnback;
    }
}
