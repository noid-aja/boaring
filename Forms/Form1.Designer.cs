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
            btnregister = new Button();
            SuspendLayout();
            // 
            // tbusr
            // 
            tbusr.Location = new Point(217, 179);
            tbusr.Margin = new Padding(6, 6, 6, 6);
            tbusr.Name = "tbusr";
            tbusr.Size = new Size(238, 39);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // tbpw
            // 
            tbpw.Location = new Point(217, 437);
            tbpw.Margin = new Padding(6, 6, 6, 6);
            tbpw.Name = "tbpw";
            tbpw.Size = new Size(238, 39);
            tbpw.TabIndex = 1;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(260, 572);
            btnlogin.Margin = new Padding(6, 6, 6, 6);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(139, 49);
            btnlogin.TabIndex = 0;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(186, 111);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(296, 32);
            label1.TabIndex = 2;
            label1.Text = "Masukkan username Anda";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 363);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(290, 32);
            label2.TabIndex = 3;
            label2.Text = "Masukkan password Anda";
            label2.Click += label2_Click;
            // 
            // btnregister
            // 
            btnregister.Location = new Point(260, 640);
            btnregister.Margin = new Padding(6, 6, 6, 6);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(139, 49);
            btnregister.TabIndex = 5;
            btnregister.Text = "Daftar";
            btnregister.UseVisualStyleBackColor = true;
            btnregister.Click += btnregister_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(643, 960);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnlogin);
            Controls.Add(tbpw);
            Controls.Add(tbusr);
            Controls.Add(btnregister);
            Margin = new Padding(6, 6, 6, 6);
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
        private Button btnregister;
    }
}
