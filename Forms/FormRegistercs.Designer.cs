using WinFormsApp1.Controllers;

namespace WinFormsApp1.Forms
{
    partial class FormRegistercs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistercs));
            buttonkofirmasi = new Button();
            TBnama = new TextBox();
            SuspendLayout();
            // 
            // buttonkofirmasi
            // 
            buttonkofirmasi.BackColor = Color.Transparent;
            buttonkofirmasi.Cursor = Cursors.Hand;
            buttonkofirmasi.FlatAppearance.BorderSize = 0;
            buttonkofirmasi.FlatStyle = FlatStyle.Flat;
            buttonkofirmasi.ForeColor = Color.Transparent;
            buttonkofirmasi.Location = new Point(274, 332);
            buttonkofirmasi.Name = "buttonkofirmasi";
            buttonkofirmasi.Size = new Size(258, 38);
            buttonkofirmasi.TabIndex = 0;
            buttonkofirmasi.UseVisualStyleBackColor = false;
            buttonkofirmasi.Click += buttonkofirmasi_Click;
            // 
            // TBnama
            // 
            TBnama.BackColor = Color.Transparent;
            TBnama.BorderStyle = BorderStyle.None;
            TBnama.ForeColor = Color.Black;
            TBnama.Location = new Point(179, 151);
            TBnama.Name = "TBnama";
            TBnama.Size = new Size(196, 16);
            TBnama.TabIndex = 1;
            TBnama.TextChanged += TBnama_TextChanged;
            // 
            // FormRegistercs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(TBnama);
            Controls.Add(buttonkofirmasi);
            Name = "FormRegistercs";
            Text = "FormRegistercs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonkofirmasi;
        private TextBox TBnama;
    }
}