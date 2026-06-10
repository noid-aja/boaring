namespace WinFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbnp = new TextBox();
            tbharga = new TextBox();
            NUD = new NumericUpDown();
            btntambah = new Button();
            btnhapus = new Button();
            btnedit = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)NUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 62);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 0;
            label1.Text = "Nama produk  :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 156);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 32);
            label2.TabIndex = 1;
            label2.Text = "Harga  :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 254);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 32);
            label3.TabIndex = 2;
            label3.Text = "Stok  :";
            // 
            // tbnp
            // 
            tbnp.Location = new Point(297, 62);
            tbnp.Margin = new Padding(6, 6, 6, 6);
            tbnp.Name = "tbnp";
            tbnp.Size = new Size(245, 39);
            tbnp.TabIndex = 3;
            tbnp.TextChanged += tbnp_TextChanged;
            // 
            // tbharga
            // 
            tbharga.Location = new Point(297, 156);
            tbharga.Margin = new Padding(6, 6, 6, 6);
            tbharga.Name = "tbharga";
            tbharga.Size = new Size(245, 39);
            tbharga.TabIndex = 4;
            tbharga.TextChanged += tbharga_TextChanged;
            // 
            // NUD
            // 
            NUD.Location = new Point(297, 250);
            NUD.Margin = new Padding(6, 6, 6, 6);
            NUD.Name = "NUD";
            NUD.Size = new Size(249, 39);
            NUD.TabIndex = 5;
            NUD.ValueChanged += NUD_ValueChanged;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(916, 53);
            btntambah.Margin = new Padding(6, 6, 6, 6);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(139, 49);
            btntambah.TabIndex = 6;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(1324, 237);
            btnhapus.Margin = new Padding(6, 6, 6, 6);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(139, 49);
            btnhapus.TabIndex = 7;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(1118, 156);
            btnedit.Margin = new Padding(6, 6, 6, 6);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(139, 49);
            btnedit.TabIndex = 8;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 388);
            dataGridView1.Margin = new Padding(6, 6, 6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1439, 546);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1486, 960);
            Controls.Add(dataGridView1);
            Controls.Add(btnedit);
            Controls.Add(btnhapus);
            Controls.Add(btntambah);
            Controls.Add(NUD);
            Controls.Add(tbharga);
            Controls.Add(tbnp);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)NUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbnp;
        private TextBox tbharga;
        private NumericUpDown NUD;
        private Button btntambah;
        private Button btnhapus;
        private Button btnedit;
        private DataGridView dataGridView1;
    }
}