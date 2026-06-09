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
            label1.Location = new Point(52, 29);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Nama produk  :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 73);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Harga  :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 119);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Stok  :";
            // 
            // tbnp
            // 
            tbnp.Location = new Point(160, 29);
            tbnp.Name = "tbnp";
            tbnp.Size = new Size(134, 23);
            tbnp.TabIndex = 3;
            tbnp.TextChanged += tbnp_TextChanged;
            // 
            // tbharga
            // 
            tbharga.Location = new Point(160, 73);
            tbharga.Name = "tbharga";
            tbharga.Size = new Size(134, 23);
            tbharga.TabIndex = 4;
            tbharga.TextChanged += tbharga_TextChanged;
            // 
            // NUD
            // 
            NUD.Location = new Point(160, 117);
            NUD.Name = "NUD";
            NUD.Size = new Size(134, 23);
            NUD.TabIndex = 5;
            NUD.ValueChanged += NUD_ValueChanged;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(493, 25);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(75, 23);
            btntambah.TabIndex = 6;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(713, 111);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(75, 23);
            btnhapus.TabIndex = 7;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(602, 73);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(75, 23);
            btnedit.TabIndex = 8;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 182);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(775, 256);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
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
            Name = "Form2";
            Text = "Form2";
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