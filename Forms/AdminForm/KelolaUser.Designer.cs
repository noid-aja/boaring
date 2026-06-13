namespace WinFormsApp1.Forms.AdminForm
{
    partial class KelolaUser
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
            dgvUsers = new DataGridView();
            tbNoTelp = new TextBox();
            btnEnable = new Button();
            btnRefresh = new Button();
            tbUsername = new TextBox();
            btnDisable = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cbRole = new ComboBox();
            tbPassword = new TextBox();
            tbFullName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(53, 390);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(978, 510);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // tbNoTelp
            // 
            tbNoTelp.BackColor = Color.FromArgb(235, 235, 235);
            tbNoTelp.BorderStyle = BorderStyle.None;
            tbNoTelp.Location = new Point(696, 108);
            tbNoTelp.Name = "tbNoTelp";
            tbNoTelp.PlaceholderText = "No. Telp";
            tbNoTelp.Size = new Size(282, 20);
            tbNoTelp.TabIndex = 10;
            // 
            // btnEnable
            // 
            btnEnable.BackColor = Color.Transparent;
            btnEnable.FlatAppearance.BorderSize = 0;
            btnEnable.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEnable.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEnable.FlatStyle = FlatStyle.Flat;
            btnEnable.Location = new Point(613, 288);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(176, 61);
            btnEnable.TabIndex = 11;
            btnEnable.UseVisualStyleBackColor = false;
            btnEnable.Click += btnEnable_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(77, 290);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(84, 63);
            btnRefresh.TabIndex = 9;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.FromArgb(235, 235, 235);
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Location = new Point(228, 170);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "Username";
            tbUsername.Size = new Size(298, 20);
            tbUsername.TabIndex = 1;
            tbUsername.TextChanged += tbUsername_TextChanged;
            // 
            // btnDisable
            // 
            btnDisable.BackColor = Color.Transparent;
            btnDisable.FlatAppearance.BorderSize = 0;
            btnDisable.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnDisable.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnDisable.FlatStyle = FlatStyle.Flat;
            btnDisable.Location = new Point(797, 289);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(210, 59);
            btnDisable.TabIndex = 7;
            btnDisable.UseVisualStyleBackColor = false;
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(412, 289);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(193, 61);
            btnEdit.TabIndex = 6;
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(176, 288);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(221, 63);
            btnAdd.TabIndex = 5;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.FromArgb(235, 235, 235);
            cbRole.FlatStyle = FlatStyle.Flat;
            cbRole.Font = new Font("Segoe UI", 12F);
            cbRole.ForeColor = SystemColors.WindowFrame;
            cbRole.Location = new Point(692, 163);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(291, 36);
            cbRole.TabIndex = 4;
            cbRole.Text = "Role";
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(235, 235, 235);
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Location = new Point(228, 231);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(298, 20);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // tbFullName
            // 
            tbFullName.BackColor = Color.FromArgb(235, 235, 235);
            tbFullName.BorderStyle = BorderStyle.None;
            tbFullName.Location = new Point(228, 108);
            tbFullName.Name = "tbFullName";
            tbFullName.PlaceholderText = "Full name";
            tbFullName.Size = new Size(298, 20);
            tbFullName.TabIndex = 2;
            tbFullName.TextChanged += tbFullName_TextChanged;
            // 
            // KelolaUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            BackgroundImage = Properties.Resources.kelolauser;
            ClientSize = new Size(1054, 938);
            Controls.Add(btnRefresh);
            Controls.Add(btnDisable);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnEnable);
            Controls.Add(cbRole);
            Controls.Add(tbPassword);
            Controls.Add(tbFullName);
            Controls.Add(tbUsername);
            Controls.Add(tbNoTelp);
            Controls.Add(dgvUsers);
            Name = "KelolaUser";
            Text = "KelolaUser";
            Load += KelolaUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox tbNoTelp;
        private System.Windows.Forms.Button btnEnable;
        private Button btnRefresh;
        private TextBox tbUsername;
        private Button btnDisable;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox cbRole;
        private TextBox tbPassword;
        private TextBox tbFullName;
    }
}