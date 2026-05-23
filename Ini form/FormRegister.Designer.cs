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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            txtname = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtpassword = new TextBox();
            label3 = new Label();
            txtcpassword = new TextBox();
            Register = new Button();
            label4 = new Label();
            label10 = new Label();
            txtemail = new TextBox();
            SuspendLayout();
            // 
            // txtname
            // 
            txtname.Location = new Point(415, 352);
            txtname.Name = "txtname";
            txtname.Size = new Size(339, 39);
            txtname.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(415, 303);
            label1.Name = "label1";
            label1.Size = new Size(119, 32);
            label1.TabIndex = 3;
            label1.Text = "username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 555);
            label2.Name = "label2";
            label2.Size = new Size(113, 32);
            label2.TabIndex = 5;
            label2.Text = "password";
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(415, 603);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(339, 39);
            txtpassword.TabIndex = 4;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(415, 672);
            label3.Name = "label3";
            label3.Size = new Size(202, 32);
            label3.TabIndex = 7;
            label3.Text = "confirm password";
            // 
            // txtcpassword
            // 
            txtcpassword.Location = new Point(415, 723);
            txtcpassword.Name = "txtcpassword";
            txtcpassword.PasswordChar = '*';
            txtcpassword.Size = new Size(339, 39);
            txtcpassword.TabIndex = 6;
            txtcpassword.UseSystemPasswordChar = true;
            // 
            // Register
            // 
            Register.BackColor = Color.Lime;
            Register.Location = new Point(498, 1020);
            Register.Name = "Register";
            Register.Size = new Size(150, 46);
            Register.TabIndex = 8;
            Register.Text = "register";
            Register.UseVisualStyleBackColor = false;
            Register.Click += Register_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = Color.DarkViolet;
            label4.Location = new Point(299, 70);
            label4.Name = "label4";
            label4.Size = new Size(522, 65);
            label4.TabIndex = 9;
            label4.Text = "Register Petani Form";
            label4.Click += label4_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(415, 434);
            label10.Name = "label10";
            label10.Size = new Size(72, 32);
            label10.TabIndex = 11;
            label10.Text = "email";
            // 
            // txtemail
            // 
            txtemail.Location = new Point(415, 483);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(339, 39);
            txtemail.TabIndex = 10;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1176, 1146);
            Controls.Add(label10);
            Controls.Add(txtemail);
            Controls.Add(label4);
            Controls.Add(Register);
            Controls.Add(label3);
            Controls.Add(txtcpassword);
            Controls.Add(label2);
            Controls.Add(txtpassword);
            Controls.Add(label1);
            Controls.Add(txtname);
            DoubleBuffered = true;
            Name = "FormRegister";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcpassword;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtemail;
    }
}