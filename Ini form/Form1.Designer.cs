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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tbusr = new TextBox();
            tbpw = new TextBox();
            btnlogin = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // tbusr
            // 
            tbusr.Location = new Point(117, 84);
            tbusr.Name = "tbusr";
            tbusr.Size = new Size(130, 23);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // tbpw
            // 
            tbpw.Location = new Point(117, 205);
            tbpw.Name = "tbpw";
            tbpw.Size = new Size(130, 23);
            tbpw.TabIndex = 1;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(140, 268);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(75, 23);
            btnlogin.TabIndex = 0;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 52);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 2;
            label1.Text = "Masukkan username Anda";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 170);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 3;
            label2.Text = "Masukkan password Anda";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(346, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnlogin);
            Controls.Add(tbpw);
            Controls.Add(tbusr);
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
        private Label label1;
        private Label label2;
    }
}
