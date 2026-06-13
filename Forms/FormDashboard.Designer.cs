namespace WinFormsApp1.Forms.AdminForm
{
    partial class FormDashboard
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
            lblSidebarTitle = new Label();
            panel4 = new Panel();
            lblCardValue1 = new Label();
            lblCardTitle1 = new Label();
            panel5 = new Panel();
            lblCardValue2 = new Label();
            lblCardTitle2 = new Label();
            panel6 = new Panel();
            lblCardValue3 = new Label();
            lblCardTitle3 = new Label();
            panel7 = new Panel();
            lblCardValue4 = new Label();
            lblCardTitle4 = new Label();
            lblTableTitle = new Label();
            dgvDashboard = new DataGridView();
            panel8 = new Panel();
            btnMenu1 = new Button();
            btnMenu2 = new Button();
            btnMenujeniskopi = new Button();
            btnMenu4 = new Button();
            btnMenu5 = new Button();
            btnLogout = new Button();
            btnMenu6 = new Button();
            btnMenu7 = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblSidebarTitle
            // 
            lblSidebarTitle.AutoSize = true;
            lblSidebarTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSidebarTitle.ForeColor = Color.White;
            lblSidebarTitle.Location = new Point(36, 185);
            lblSidebarTitle.Margin = new Padding(2, 0, 2, 0);
            lblSidebarTitle.Name = "lblSidebarTitle";
            lblSidebarTitle.Size = new Size(184, 28);
            lblSidebarTitle.TabIndex = 3;
            lblSidebarTitle.Text = "Dashboard Admin";
            lblSidebarTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSidebarTitle.Click += lblSidebarTitle_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(253, 253, 253);
            panel4.Controls.Add(lblCardValue1);
            panel4.Controls.Add(lblCardTitle1);
            panel4.Location = new Point(268, 204);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(216, 141);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // lblCardValue1
            // 
            lblCardValue1.AutoSize = true;
            lblCardValue1.BackColor = Color.Transparent;
            lblCardValue1.Dock = DockStyle.Top;
            lblCardValue1.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue1.Location = new Point(0, 0);
            lblCardValue1.Margin = new Padding(2, 0, 2, 0);
            lblCardValue1.Name = "lblCardValue1";
            lblCardValue1.Size = new Size(117, 46);
            lblCardValue1.TabIndex = 1;
            lblCardValue1.Text = "label1";
            lblCardValue1.TextAlign = ContentAlignment.MiddleCenter;
            lblCardValue1.Click += lblCardValue1_Click;
            // 
            // lblCardTitle1
            // 
            lblCardTitle1.AutoSize = true;
            lblCardTitle1.Dock = DockStyle.Bottom;
            lblCardTitle1.Location = new Point(0, 121);
            lblCardTitle1.Margin = new Padding(2, 0, 2, 0);
            lblCardTitle1.Name = "lblCardTitle1";
            lblCardTitle1.Size = new Size(50, 20);
            lblCardTitle1.TabIndex = 0;
            lblCardTitle1.Text = "label3";
            lblCardTitle1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(253, 253, 253);
            panel5.Controls.Add(lblCardValue2);
            panel5.Controls.Add(lblCardTitle2);
            panel5.Location = new Point(522, 204);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(217, 141);
            panel5.TabIndex = 5;
            panel5.Paint += panel5_Paint;
            // 
            // lblCardValue2
            // 
            lblCardValue2.AutoSize = true;
            lblCardValue2.Dock = DockStyle.Top;
            lblCardValue2.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue2.Location = new Point(0, 0);
            lblCardValue2.Margin = new Padding(2, 0, 2, 0);
            lblCardValue2.Name = "lblCardValue2";
            lblCardValue2.Size = new Size(117, 46);
            lblCardValue2.TabIndex = 2;
            lblCardValue2.Text = "label2";
            // 
            // lblCardTitle2
            // 
            lblCardTitle2.AutoSize = true;
            lblCardTitle2.Dock = DockStyle.Bottom;
            lblCardTitle2.Location = new Point(0, 121);
            lblCardTitle2.Margin = new Padding(2, 0, 2, 0);
            lblCardTitle2.Name = "lblCardTitle2";
            lblCardTitle2.Size = new Size(50, 20);
            lblCardTitle2.TabIndex = 1;
            lblCardTitle2.Text = "label4";
            lblCardTitle2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(253, 253, 253);
            panel6.Controls.Add(lblCardValue3);
            panel6.Controls.Add(lblCardTitle3);
            panel6.Location = new Point(775, 204);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(217, 141);
            panel6.TabIndex = 5;
            panel6.Paint += panel6_Paint;
            // 
            // lblCardValue3
            // 
            lblCardValue3.AutoSize = true;
            lblCardValue3.Dock = DockStyle.Top;
            lblCardValue3.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue3.Location = new Point(0, 0);
            lblCardValue3.Margin = new Padding(2, 0, 2, 0);
            lblCardValue3.Name = "lblCardValue3";
            lblCardValue3.Size = new Size(117, 46);
            lblCardValue3.TabIndex = 3;
            lblCardValue3.Text = "label7";
            // 
            // lblCardTitle3
            // 
            lblCardTitle3.AutoSize = true;
            lblCardTitle3.Dock = DockStyle.Bottom;
            lblCardTitle3.Location = new Point(0, 121);
            lblCardTitle3.Margin = new Padding(2, 0, 2, 0);
            lblCardTitle3.Name = "lblCardTitle3";
            lblCardTitle3.Size = new Size(50, 20);
            lblCardTitle3.TabIndex = 2;
            lblCardTitle3.Text = "label5";
            lblCardTitle3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(253, 253, 253);
            panel7.Controls.Add(lblCardValue4);
            panel7.Controls.Add(lblCardTitle4);
            panel7.Location = new Point(1028, 204);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Size = new Size(217, 141);
            panel7.TabIndex = 5;
            // 
            // lblCardValue4
            // 
            lblCardValue4.AutoSize = true;
            lblCardValue4.Dock = DockStyle.Top;
            lblCardValue4.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue4.Location = new Point(0, 0);
            lblCardValue4.Margin = new Padding(2, 0, 2, 0);
            lblCardValue4.Name = "lblCardValue4";
            lblCardValue4.Size = new Size(117, 46);
            lblCardValue4.TabIndex = 4;
            lblCardValue4.Text = "label8";
            // 
            // lblCardTitle4
            // 
            lblCardTitle4.AutoSize = true;
            lblCardTitle4.Dock = DockStyle.Bottom;
            lblCardTitle4.Location = new Point(0, 121);
            lblCardTitle4.Margin = new Padding(2, 0, 2, 0);
            lblCardTitle4.Name = "lblCardTitle4";
            lblCardTitle4.Size = new Size(50, 20);
            lblCardTitle4.TabIndex = 3;
            lblCardTitle4.Text = "label6";
            lblCardTitle4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Location = new Point(2, 6);
            lblTableTitle.Margin = new Padding(2, 0, 2, 0);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new Size(126, 20);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "Data Produk Kopi";
            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboard.BackgroundColor = Color.White;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(0, 28);
            dgvDashboard.Margin = new Padding(2);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersWidth = 82;
            dgvDashboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashboard.Size = new Size(980, 481);
            dgvDashboard.TabIndex = 1;
            dgvDashboard.CellContentClick += dgvDashboard_CellContentClick;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(dgvDashboard);
            panel8.Controls.Add(lblTableTitle);
            panel8.Location = new Point(268, 392);
            panel8.Margin = new Padding(2);
            panel8.Name = "panel8";
            panel8.Size = new Size(982, 509);
            panel8.TabIndex = 6;
            panel8.Paint += panel8_Paint;
            // 
            // btnMenu1
            // 
            btnMenu1.BackColor = Color.DarkGreen;
            btnMenu1.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu1.ForeColor = Color.White;
            btnMenu1.Location = new Point(31, 237);
            btnMenu1.Margin = new Padding(2);
            btnMenu1.Name = "btnMenu1";
            btnMenu1.Size = new Size(194, 42);
            btnMenu1.TabIndex = 3;
            btnMenu1.Text = "Beranda";
            btnMenu1.UseVisualStyleBackColor = false;
            // 
            // btnMenu2
            // 
            btnMenu2.BackColor = Color.DarkGreen;
            btnMenu2.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu2.ForeColor = Color.White;
            btnMenu2.Location = new Point(31, 283);
            btnMenu2.Margin = new Padding(2);
            btnMenu2.Name = "btnMenu2";
            btnMenu2.Size = new Size(194, 42);
            btnMenu2.TabIndex = 4;
            btnMenu2.Text = "Kelola User";
            btnMenu2.UseVisualStyleBackColor = false;
            btnMenu2.Click += btnMenu2_Click;
            // 
            // btnMenujeniskopi
            // 
            btnMenujeniskopi.BackColor = Color.DarkGreen;
            btnMenujeniskopi.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenujeniskopi.ForeColor = Color.White;
            btnMenujeniskopi.Location = new Point(31, 328);
            btnMenujeniskopi.Margin = new Padding(2);
            btnMenujeniskopi.Name = "btnMenujeniskopi";
            btnMenujeniskopi.Size = new Size(194, 42);
            btnMenujeniskopi.TabIndex = 5;
            btnMenujeniskopi.Text = "Jenis Kopi";
            btnMenujeniskopi.UseVisualStyleBackColor = false;
            btnMenujeniskopi.Click += btnMenu3_Click;
            // 
            // btnMenu4
            // 
            btnMenu4.BackColor = Color.DarkGreen;
            btnMenu4.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu4.ForeColor = Color.White;
            btnMenu4.Location = new Point(31, 374);
            btnMenu4.Margin = new Padding(2);
            btnMenu4.Name = "btnMenu4";
            btnMenu4.Size = new Size(194, 42);
            btnMenu4.TabIndex = 6;
            btnMenu4.Text = "Produk Kopi";
            btnMenu4.UseVisualStyleBackColor = false;
            // 
            // btnMenu5
            // 
            btnMenu5.BackColor = Color.DarkGreen;
            btnMenu5.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu5.ForeColor = Color.White;
            btnMenu5.Location = new Point(31, 420);
            btnMenu5.Margin = new Padding(2);
            btnMenu5.Name = "btnMenu5";
            btnMenu5.Size = new Size(194, 42);
            btnMenu5.TabIndex = 7;
            btnMenu5.Text = "Lelang";
            btnMenu5.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(36, 819);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(189, 47);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnMenu6
            // 
            btnMenu6.BackColor = Color.DarkGreen;
            btnMenu6.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu6.ForeColor = Color.White;
            btnMenu6.Location = new Point(31, 465);
            btnMenu6.Margin = new Padding(2);
            btnMenu6.Name = "btnMenu6";
            btnMenu6.Size = new Size(194, 42);
            btnMenu6.TabIndex = 9;
            btnMenu6.Text = "Transaksi";
            btnMenu6.UseVisualStyleBackColor = false;
            // 
            // btnMenu7
            // 
            btnMenu7.BackColor = Color.DarkGreen;
            btnMenu7.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu7.ForeColor = Color.White;
            btnMenu7.Location = new Point(31, 510);
            btnMenu7.Margin = new Padding(2);
            btnMenu7.Name = "btnMenu7";
            btnMenu7.Size = new Size(194, 42);
            btnMenu7.TabIndex = 10;
            btnMenu7.Text = "Laporan";
            btnMenu7.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.Group_11;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnMenu7);
            panel2.Controls.Add(lblSidebarTitle);
            panel2.Controls.Add(btnMenu6);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(btnMenu5);
            panel2.Controls.Add(btnMenu4);
            panel2.Controls.Add(btnMenujeniskopi);
            panel2.Controls.Add(btnMenu2);
            panel2.Controls.Add(btnMenu1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 932);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_kab6fikab6fikab6_1__1_;
            pictureBox1.Location = new Point(61, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 137);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Group_12;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(225, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1058, 932);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            ClientSize = new Size(1283, 932);
            Controls.Add(panel2);
            Controls.Add(panel8);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "FormDashboard";
            Text = "Dashboard Admin";
            Load += FormDashboard_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblSidebarTitle;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label lblCardTitle1;
        private Label lblCardTitle2;
        private Label lblCardTitle3;
        private Label lblCardTitle4;
        private Label lblCardValue1;
        private Label lblCardValue2;
        private Label lblCardValue3;
        private Label lblCardValue4;
        private Label lblTableTitle;
        private DataGridView dgvDashboard;
        private Panel panel8;
        private Button btnMenu1;
        private Button btnMenu2;
        private Button btnMenujeniskopi;
        private Button btnMenu4;
        private Button btnMenu5;
        private Button btnLogout;
        private Button btnMenu6;
        private Button btnMenu7;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}