namespace WinFormsApp1.Forms.AdminForm
{
    partial class Inspeksi
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
            dgvPending = new DataGridView();
            lblNilai = new Label();
            nudNilai = new NumericUpDown();
            lblHarga = new Label();
            tbHargaRekomendasi = new TextBox();
            lblCatatan = new Label();
            tbCatatan = new TextBox();
            btnSubmit = new Button();
            btnRefresh = new Button();
            // inspector id removed; use current user context
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNilai).BeginInit();
            SuspendLayout();
            // 
            // dgvPending
            // 
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPending.Location = new Point(12, 12);
            dgvPending.Name = "dgvPending";
            dgvPending.ReadOnly = true;
            dgvPending.RowHeadersWidth = 51;
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPending.Size = new Size(920, 300);
            dgvPending.TabIndex = 0;
            dgvPending.CellClick += dgvPending_CellClick;
            // 
            // lblNilai
            // 
            lblNilai.AutoSize = true;
            lblNilai.Location = new Point(150, 330);
            lblNilai.Name = "lblNilai";
            lblNilai.Size = new Size(40, 20);
            lblNilai.TabIndex = 3;
            lblNilai.Text = "Nilai";
            // 
            // nudNilai
            // 
            nudNilai.Location = new Point(150, 353);
            nudNilai.Name = "nudNilai";
            nudNilai.Size = new Size(80, 27);
            nudNilai.TabIndex = 4;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(250, 330);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(143, 20);
            lblHarga.TabIndex = 5;
            lblHarga.Text = "Harga Rekomendasi";
            // 
            // tbHargaRekomendasi
            // 
            tbHargaRekomendasi.Location = new Point(250, 353);
            tbHargaRekomendasi.Name = "tbHargaRekomendasi";
            tbHargaRekomendasi.PlaceholderText = "Harga (numeric)";
            tbHargaRekomendasi.Size = new Size(150, 27);
            tbHargaRekomendasi.TabIndex = 6;
            // 
            // lblCatatan
            // 
            lblCatatan.AutoSize = true;
            lblCatatan.Location = new Point(430, 330);
            lblCatatan.Name = "lblCatatan";
            lblCatatan.Size = new Size(60, 20);
            lblCatatan.TabIndex = 7;
            lblCatatan.Text = "Catatan";
            // 
            // tbCatatan
            // 
            tbCatatan.Location = new Point(430, 353);
            tbCatatan.Multiline = true;
            tbCatatan.Name = "tbCatatan";
            tbCatatan.Size = new Size(350, 80);
            tbCatatan.TabIndex = 8;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(800, 353);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Simpan";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(800, 393);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // inspector id removed; use current user context
            // 
            // Inspeksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 456);
            Controls.Add(btnRefresh);
            Controls.Add(btnSubmit);
            Controls.Add(tbCatatan);
            Controls.Add(lblCatatan);
            Controls.Add(tbHargaRekomendasi);
            Controls.Add(lblHarga);
            Controls.Add(nudNilai);
            Controls.Add(lblNilai);
            // inspector id controls removed
            Controls.Add(dgvPending);
            Name = "Inspeksi";
            Text = "Input Inspeksi";
            Load += Inspeksi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNilai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPending;
        private System.Windows.Forms.Label lblNilai;
        private System.Windows.Forms.NumericUpDown nudNilai;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.TextBox tbHargaRekomendasi;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.TextBox tbCatatan;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRefresh;
    }
}