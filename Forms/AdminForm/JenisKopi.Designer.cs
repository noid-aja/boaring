namespace WinFormsApp1.Forms.AdminForm
{
    partial class jeniskopi
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
            tbNama = new TextBox();
            tbDeskripsi = new TextBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            dgvJenis = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvJenis).BeginInit();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.BackColor = Color.FromArgb(235, 235, 235);
            tbNama.BorderStyle = BorderStyle.None;
            tbNama.Location = new Point(212, 108);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(483, 20);
            tbNama.TabIndex = 6;
            tbNama.TextChanged += tbNama_TextChanged;
            // 
            // tbDeskripsi
            // 
            tbDeskripsi.BackColor = Color.FromArgb(235, 235, 235);
            tbDeskripsi.BorderStyle = BorderStyle.None;
            tbDeskripsi.Location = new Point(209, 158);
            tbDeskripsi.Multiline = true;
            tbDeskripsi.Name = "tbDeskripsi";
            tbDeskripsi.Size = new Size(483, 108);
            tbDeskripsi.TabIndex = 4;
            tbDeskripsi.TextChanged += tbDeskripsi_TextChanged;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.Transparent;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTambah.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Location = new Point(738, 92);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(268, 96);
            btnTambah.TabIndex = 3;
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(738, 200);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(169, 68);
            btnEdit.TabIndex = 2;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.Transparent;
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHapus.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Location = new Point(919, 200);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(87, 68);
            btnHapus.TabIndex = 1;
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // dgvJenis
            // 
            dgvJenis.ColumnHeadersHeight = 29;
            dgvJenis.Location = new Point(54, 304);
            dgvJenis.Name = "dgvJenis";
            dgvJenis.ReadOnly = true;
            dgvJenis.RowHeadersWidth = 51;
            dgvJenis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJenis.Size = new Size(971, 596);
            dgvJenis.TabIndex = 0;
            dgvJenis.CellClick += dgvJenis_CellClick;
            dgvJenis.CellContentClick += dgvJenis_CellContentClick;
            // 
            // jeniskopi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.jenis_kopi;
            ClientSize = new Size(1059, 933);
            Controls.Add(dgvJenis);
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(btnTambah);
            Controls.Add(tbDeskripsi);
            Controls.Add(tbNama);
            Name = "jeniskopi";
            Text = "Jenis Kopi";
            Load += jeniskopi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJenis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.TextBox tbDeskripsi;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvJenis;
    }
}