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
            panel1 = new Panel();
            lblHeaderTitle = new Label();
            panel2 = new Panel();
            btnMenu7 = new Button();
            btnMenu6 = new Button();
            btnLogout = new Button();
            btnMenu5 = new Button();
            btnMenu4 = new Button();
            btnMenu3 = new Button();
            btnMenu2 = new Button();
            btnMenu1 = new Button();
            lblSidebarTitle = new Label();
            panel3 = new Panel();
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
            panel8 = new Panel();
            dgvDashboard = new DataGridView();
            lblTableTitle = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(lblHeaderTitle);
            panel1.Location = new Point(374, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1744, 159);
            panel1.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(53, 66);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(293, 45);
            lblHeaderTitle.TabIndex = 2;
            lblHeaderTitle.Text = "Dashboard Admin";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnMenu7);
            panel2.Controls.Add(btnMenu6);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(btnMenu5);
            panel2.Controls.Add(btnMenu4);
            panel2.Controls.Add(btnMenu3);
            panel2.Controls.Add(btnMenu2);
            panel2.Controls.Add(btnMenu1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 1134);
            panel2.TabIndex = 1;
            // 
            // btnMenu7
            // 
            btnMenu7.BackColor = Color.DarkGreen;
            btnMenu7.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu7.ForeColor = Color.White;
            btnMenu7.Location = new Point(50, 635);
            btnMenu7.Name = "btnMenu7";
            btnMenu7.Size = new Size(264, 67);
            btnMenu7.TabIndex = 10;
            btnMenu7.Text = "Laporan";
            btnMenu7.UseVisualStyleBackColor = false;
            // 
            // btnMenu6
            // 
            btnMenu6.BackColor = Color.DarkGreen;
            btnMenu6.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu6.ForeColor = Color.White;
            btnMenu6.Location = new Point(50, 562);
            btnMenu6.Name = "btnMenu6";
            btnMenu6.Size = new Size(264, 67);
            btnMenu6.TabIndex = 9;
            btnMenu6.Text = "Transaksi";
            btnMenu6.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGreen;
            btnLogout.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(50, 1043);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(264, 67);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnMenu5
            // 
            btnMenu5.BackColor = Color.DarkGreen;
            btnMenu5.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu5.ForeColor = Color.White;
            btnMenu5.Location = new Point(50, 489);
            btnMenu5.Name = "btnMenu5";
            btnMenu5.Size = new Size(264, 67);
            btnMenu5.TabIndex = 7;
            btnMenu5.Text = "Lelang";
            btnMenu5.UseVisualStyleBackColor = false;
            // 
            // btnMenu4
            // 
            btnMenu4.BackColor = Color.DarkGreen;
            btnMenu4.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu4.ForeColor = Color.White;
            btnMenu4.Location = new Point(50, 416);
            btnMenu4.Name = "btnMenu4";
            btnMenu4.Size = new Size(264, 67);
            btnMenu4.TabIndex = 6;
            btnMenu4.Text = "Produk Kopi";
            btnMenu4.UseVisualStyleBackColor = false;
            // 
            // btnMenu3
            // 
            btnMenu3.BackColor = Color.DarkGreen;
            btnMenu3.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu3.ForeColor = Color.White;
            btnMenu3.Location = new Point(50, 343);
            btnMenu3.Name = "btnMenu3";
            btnMenu3.Size = new Size(264, 67);
            btnMenu3.TabIndex = 5;
            btnMenu3.Text = "Jenis Kopi";
            btnMenu3.UseVisualStyleBackColor = false;
            // 
            // btnMenu2
            // 
            btnMenu2.BackColor = Color.DarkGreen;
            btnMenu2.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu2.ForeColor = Color.White;
            btnMenu2.Location = new Point(50, 270);
            btnMenu2.Name = "btnMenu2";
            btnMenu2.Size = new Size(264, 67);
            btnMenu2.TabIndex = 4;
            btnMenu2.Text = "Kelola User";
            btnMenu2.UseVisualStyleBackColor = false;
            // 
            // btnMenu1
            // 
            btnMenu1.BackColor = Color.DarkGreen;
            btnMenu1.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu1.ForeColor = Color.White;
            btnMenu1.Location = new Point(50, 197);
            btnMenu1.Name = "btnMenu1";
            btnMenu1.Size = new Size(264, 67);
            btnMenu1.TabIndex = 3;
            btnMenu1.Text = "Beranda";
            btnMenu1.UseVisualStyleBackColor = false;
            // 
            // lblSidebarTitle
            // 
            lblSidebarTitle.AutoSize = true;
            lblSidebarTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSidebarTitle.ForeColor = Color.White;
            lblSidebarTitle.Location = new Point(40, 66);
            lblSidebarTitle.Name = "lblSidebarTitle";
            lblSidebarTitle.Size = new Size(293, 45);
            lblSidebarTitle.TabIndex = 3;
            lblSidebarTitle.Text = "Dashboard Admin";
            // 
            // panel3
            // 
            panel3.BackColor = Color.ForestGreen;
            panel3.Controls.Add(lblSidebarTitle);
            panel3.Location = new Point(0, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(376, 159);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblCardValue1);
            panel4.Controls.Add(lblCardTitle1);
            panel4.Location = new Point(408, 210);
            panel4.Name = "panel4";
            panel4.Size = new Size(351, 200);
            panel4.TabIndex = 4;
            // 
            // lblCardValue1
            // 
            lblCardValue1.AutoSize = true;
            lblCardValue1.BackColor = Color.Transparent;
            lblCardValue1.Dock = DockStyle.Top;
            lblCardValue1.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue1.Location = new Point(0, 0);
            lblCardValue1.Name = "lblCardValue1";
            lblCardValue1.Size = new Size(181, 71);
            lblCardValue1.TabIndex = 1;
            lblCardValue1.Text = "label1";
            lblCardValue1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardTitle1
            // 
            lblCardTitle1.AutoSize = true;
            lblCardTitle1.Dock = DockStyle.Bottom;
            lblCardTitle1.Location = new Point(0, 168);
            lblCardTitle1.Name = "lblCardTitle1";
            lblCardTitle1.Size = new Size(78, 32);
            lblCardTitle1.TabIndex = 0;
            lblCardTitle1.Text = "label3";
            lblCardTitle1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(lblCardValue2);
            panel5.Controls.Add(lblCardTitle2);
            panel5.Location = new Point(840, 210);
            panel5.Name = "panel5";
            panel5.Size = new Size(353, 200);
            panel5.TabIndex = 5;
            // 
            // lblCardValue2
            // 
            lblCardValue2.AutoSize = true;
            lblCardValue2.Dock = DockStyle.Top;
            lblCardValue2.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue2.Location = new Point(0, 0);
            lblCardValue2.Name = "lblCardValue2";
            lblCardValue2.Size = new Size(181, 71);
            lblCardValue2.TabIndex = 2;
            lblCardValue2.Text = "label2";
            // 
            // lblCardTitle2
            // 
            lblCardTitle2.AutoSize = true;
            lblCardTitle2.Dock = DockStyle.Bottom;
            lblCardTitle2.Location = new Point(0, 168);
            lblCardTitle2.Name = "lblCardTitle2";
            lblCardTitle2.Size = new Size(78, 32);
            lblCardTitle2.TabIndex = 1;
            lblCardTitle2.Text = "label4";
            lblCardTitle2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(lblCardValue3);
            panel6.Controls.Add(lblCardTitle3);
            panel6.Location = new Point(1280, 210);
            panel6.Name = "panel6";
            panel6.Size = new Size(353, 200);
            panel6.TabIndex = 5;
            // 
            // lblCardValue3
            // 
            lblCardValue3.AutoSize = true;
            lblCardValue3.Dock = DockStyle.Top;
            lblCardValue3.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue3.Location = new Point(0, 0);
            lblCardValue3.Name = "lblCardValue3";
            lblCardValue3.Size = new Size(181, 71);
            lblCardValue3.TabIndex = 3;
            lblCardValue3.Text = "label7";
            // 
            // lblCardTitle3
            // 
            lblCardTitle3.AutoSize = true;
            lblCardTitle3.Dock = DockStyle.Bottom;
            lblCardTitle3.Location = new Point(0, 168);
            lblCardTitle3.Name = "lblCardTitle3";
            lblCardTitle3.Size = new Size(78, 32);
            lblCardTitle3.TabIndex = 2;
            lblCardTitle3.Text = "label5";
            lblCardTitle3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(lblCardValue4);
            panel7.Controls.Add(lblCardTitle4);
            panel7.Location = new Point(1736, 210);
            panel7.Name = "panel7";
            panel7.Size = new Size(353, 200);
            panel7.TabIndex = 5;
            // 
            // lblCardValue4
            // 
            lblCardValue4.AutoSize = true;
            lblCardValue4.Dock = DockStyle.Top;
            lblCardValue4.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue4.Location = new Point(0, 0);
            lblCardValue4.Name = "lblCardValue4";
            lblCardValue4.Size = new Size(181, 71);
            lblCardValue4.TabIndex = 4;
            lblCardValue4.Text = "label8";
            // 
            // lblCardTitle4
            // 
            lblCardTitle4.AutoSize = true;
            lblCardTitle4.Dock = DockStyle.Bottom;
            lblCardTitle4.Location = new Point(0, 168);
            lblCardTitle4.Name = "lblCardTitle4";
            lblCardTitle4.Size = new Size(78, 32);
            lblCardTitle4.TabIndex = 3;
            lblCardTitle4.Text = "label6";
            lblCardTitle4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(dgvDashboard);
            panel8.Controls.Add(lblTableTitle);
            panel8.Location = new Point(408, 499);
            panel8.Name = "panel8";
            panel8.Size = new Size(1681, 611);
            panel8.TabIndex = 6;
            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboard.BackgroundColor = Color.White;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(20, 60);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersWidth = 82;
            dgvDashboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashboard.Size = new Size(1643, 538);
            dgvDashboard.TabIndex = 1;
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Location = new Point(3, 9);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new Size(199, 32);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "Data Produk Kopi";
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2122, 1134);
            Controls.Add(panel8);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "FormDashboard";
            Text = "Dashboard Admin";
            Load += FormDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblHeaderTitle;
        private Label lblSidebarTitle;
        private Panel panel3;
        private Button btnMenu1;
        private Button btnMenu6;
        private Button btnLogout;
        private Button btnMenu5;
        private Button btnMenu4;
        private Button btnMenu3;
        private Button btnMenu2;
        private Button btnMenu7;
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
        private Panel panel8;
        private Label lblTableTitle;
        private DataGridView dgvDashboard;
    }
}