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
            label1.Location = new Point(59, 39);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Text = "Nama produk  :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 97);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 1;
            label2.Text = "Harga  :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 159);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 2;
            label3.Text = "Stok  :";
            // 
            // tbnp
            // 
            tbnp.Location = new Point(183, 39);
            tbnp.Margin = new Padding(3, 4, 3, 4);
            tbnp.Name = "tbnp";
            tbnp.Size = new Size(153, 27);
            tbnp.TabIndex = 3;
            tbnp.TextChanged += tbnp_TextChanged;
            // 
            // tbharga
            // 
            tbharga.Location = new Point(183, 97);
            tbharga.Margin = new Padding(3, 4, 3, 4);
            tbharga.Name = "tbharga";
            tbharga.Size = new Size(153, 27);
            tbharga.TabIndex = 4;
            tbharga.TextChanged += tbharga_TextChanged;
            // 
            // NUD
            // 
            NUD.Location = new Point(183, 156);
            NUD.Margin = new Padding(3, 4, 3, 4);
            NUD.Name = "NUD";
            NUD.Size = new Size(153, 27);
            NUD.TabIndex = 5;
            NUD.ValueChanged += NUD_ValueChanged;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(688, 39);
            btntambah.Margin = new Padding(3, 4, 3, 4);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(86, 31);
            btntambah.TabIndex = 6;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(815, 148);
            btnhapus.Margin = new Padding(3, 4, 3, 4);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(86, 31);
            btnhapus.TabIndex = 7;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(688, 97);
            btnedit.Margin = new Padding(3, 4, 3, 4);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(86, 31);
            btnedit.TabIndex = 8;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 242);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1235, 435);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
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
            Margin = new Padding(3, 4, 3, 4);
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