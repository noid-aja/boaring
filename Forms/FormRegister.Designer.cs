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
            txtname = new TextBox();
            txtpassword = new TextBox();
            label3 = new Label();
            txtcpassword = new TextBox();
            Register = new Button();
            txtemail = new TextBox();
            SuspendLayout();
            // 
            // txtname
            // 
            txtname.BackColor = Color.White;
            txtname.BorderStyle = BorderStyle.None;
            txtname.Font = new Font("Segoe UI", 10.8F);
            txtname.Location = new Point(275, 137);
            txtname.Margin = new Padding(2);
            txtname.Name = "txtname";
            txtname.Size = new Size(251, 24);
            txtname.TabIndex = 0;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.White;
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Segoe UI", 10.8F);
            txtpassword.Location = new Point(274, 234);
            txtpassword.Margin = new Padding(2);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(251, 24);
            txtpassword.TabIndex = 4;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(449, 288);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 7;
            label3.Click += label3_Click;
            // 
            // txtcpassword
            // 
            txtcpassword.BackColor = Color.White;
            txtcpassword.BorderStyle = BorderStyle.None;
            txtcpassword.Font = new Font("Segoe UI", 10.8F);
            txtcpassword.Location = new Point(273, 284);
            txtcpassword.Margin = new Padding(2);
            txtcpassword.Name = "txtcpassword";
            txtcpassword.PasswordChar = '*';
            txtcpassword.Size = new Size(253, 24);
            txtcpassword.TabIndex = 6;
            txtcpassword.UseSystemPasswordChar = true;
            txtcpassword.TextChanged += txtcpassword_TextChanged;
            // 
            // Register
            // 
            Register.BackColor = Color.Transparent;
            Register.FlatAppearance.BorderSize = 0;
            Register.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Register.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Register.FlatStyle = FlatStyle.Flat;
            Register.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Register.ForeColor = Color.White;
            Register.Location = new Point(273, 334);
            Register.Margin = new Padding(2);
            Register.Name = "Register";
            Register.Size = new Size(254, 35);
            Register.TabIndex = 8;
            Register.UseVisualStyleBackColor = false;
            Register.Click += Register_Click;
            // 
            // txtemail
            // 
            txtemail.BackColor = Color.White;
            txtemail.BorderStyle = BorderStyle.None;
            txtemail.Font = new Font("Segoe UI", 10.8F);
            txtemail.Location = new Point(274, 187);
            txtemail.Margin = new Padding(2);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(251, 24);
            txtemail.TabIndex = 10;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.registrasi;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(782, 448);
            Controls.Add(txtemail);
            Controls.Add(Register);
            Controls.Add(label3);
            Controls.Add(txtcpassword);
            Controls.Add(txtpassword);
            Controls.Add(txtname);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "FormRegister";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcpassword;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox txtemail;
    }
}