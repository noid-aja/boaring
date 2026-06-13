using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class KelolaUser : Form
    {
        public KelolaUser()
        {
            InitializeComponent();
            LoadRoles();
            LoadUsers();
        }

        private void KelolaUser_Load(object sender, EventArgs e)
        {
        }

        private void LoadUsers()
        {
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // NpgsqlDataAdapter otomatis mengelola open/close koneksi jika ditutup
                    string query = @"select u.id_user, u.username, u.nama_lengkap, u.no_telp, u.is_aktif,
                               r.nama_role as role
                            from kapten.users u
                            left join kapten.user_roles ur on ur.id_user = u.id_user
                            left join kapten.roles r on r.id_role = ur.id_role
                            order by u.id_user";
                    var da = new NpgsqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                    dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            cbRole.Items.Clear();
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // 1. PERBAIKAN: Buka koneksi sebelum menjalankan ExecuteReader
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("select nama_role from kapten.roles order by id_role", conn))
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var r = rdr.GetString(0);
                            cbRole.Items.Add(r);
                        }
                    }
                }
                if (cbRole.Items.Count > 0) cbRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                MessageBox.Show("Username harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // 2. PERBAIKAN: Wajib buka koneksi sebelum membuat Transaction
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        // insert user and get new id_user
                        using (var cmd = new NpgsqlCommand("insert into kapten.users(nama_lengkap, username, password, no_telp, is_aktif) values(@nama, @username, @password, @notelp, true) returning id_user", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@nama", string.IsNullOrWhiteSpace(tbFullName.Text) ? (object)DBNull.Value : tbFullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", string.IsNullOrWhiteSpace(tbPassword.Text) ? (object)DBNull.Value : tbPassword.Text);
                            cmd.Parameters.AddWithValue("@notelp", string.IsNullOrWhiteSpace(tbNoTelp.Text) ? (object)DBNull.Value : tbNoTelp.Text.Trim());

                            var newIdObj = cmd.ExecuteScalar();
                            if (newIdObj != null)
                            {
                                int newId = Convert.ToInt32(newIdObj);
                                var roleName = cbRole.Text;
                                if (!string.IsNullOrWhiteSpace(roleName))
                                {
                                    using (var cmdRole = new NpgsqlCommand("select id_role from kapten.roles where lower(nama_role)=lower(@r)", conn, tran))
                                    {
                                        cmdRole.Parameters.AddWithValue("@r", roleName);
                                        var roleIdObj = cmdRole.ExecuteScalar();
                                        if (roleIdObj != null)
                                        {
                                            using (var ir = new NpgsqlCommand("insert into kapten.user_roles(id_user, id_role) values(@u, @r)", conn, tran))
                                            {
                                                ir.Parameters.AddWithValue("@u", newId);
                                                ir.Parameters.AddWithValue("@r", Convert.ToInt32(roleIdObj));
                                                ir.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        tran.Commit();
                    }
                }
                MessageBox.Show("User berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                MessageBox.Show("Username harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // 3. PERBAIKAN: Wajib buka koneksi sebelum membuat Transaction
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        // update user fields
                        using (var cmd = new NpgsqlCommand("update kapten.users set username=@username, nama_lengkap=@nama, no_telp=@notelp where id_user=@id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@nama", string.IsNullOrWhiteSpace(tbFullName.Text) ? (object)DBNull.Value : tbFullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@notelp", string.IsNullOrWhiteSpace(tbNoTelp.Text) ? (object)DBNull.Value : tbNoTelp.Text.Trim());
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        // update role: remove existing and insert selected
                        using (var del = new NpgsqlCommand("delete from kapten.user_roles where id_user=@id", conn, tran))
                        {
                            del.Parameters.AddWithValue("@id", id);
                            del.ExecuteNonQuery();
                        }
                        var roleName = cbRole.Text;
                        if (!string.IsNullOrWhiteSpace(roleName))
                        {
                            using (var cmdRole = new NpgsqlCommand("select id_role from kapten.roles where lower(nama_role)=lower(@r)", conn, tran))
                            {
                                cmdRole.Parameters.AddWithValue("@r", roleName);
                                var roleIdObj = cmdRole.ExecuteScalar();
                                if (roleIdObj != null)
                                {
                                    using (var ir = new NpgsqlCommand("insert into kapten.user_roles(id_user, id_role) values(@u, @r)", conn, tran))
                                    {
                                        ir.Parameters.AddWithValue("@u", id);
                                        ir.Parameters.AddWithValue("@r", Convert.ToInt32(roleIdObj));
                                        ir.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        tran.Commit();
                    }
                }
                MessageBox.Show("User berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
            var dr = MessageBox.Show("Yakin ingin menonaktifkan user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // 4. PERBAIKAN: Buka koneksi sebelum ExecuteNonQuery
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("update kapten.users set is_aktif = false where id_user = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User berhasil dinonaktifkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menonaktifkan user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvUsers.Rows[e.RowIndex];
            try { tbUsername.Text = row.Cells["username"].Value?.ToString() ?? string.Empty; } catch { tbUsername.Text = row.Cells.Count > 1 ? row.Cells[1].Value?.ToString() ?? string.Empty : string.Empty; }
            try { tbFullName.Text = row.Cells["nama_lengkap"].Value?.ToString() ?? string.Empty; } catch { tbFullName.Text = row.Cells.Count > 2 ? row.Cells[2].Value?.ToString() ?? string.Empty : string.Empty; }
            try { cbRole.Text = row.Cells["role"].Value?.ToString() ?? string.Empty; } catch { cbRole.Text = string.Empty; }
            try { tbNoTelp.Text = row.Cells["no_telp"].Value?.ToString() ?? string.Empty; } catch { tbNoTelp.Text = string.Empty; }
        }

        private void ClearInputs()
        {
            tbUsername.Text = string.Empty;
            tbFullName.Text = string.Empty;
            tbPassword.Text = string.Empty;
            cbRole.Text = string.Empty;
            tbNoTelp.Text = string.Empty;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("update kapten.users set is_aktif = true where id_user = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User berhasil diaktifkan kembali", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengaktifkan user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // no-op: kept for Designer event wiring
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            // no-op: kept for Designer event wiring
        }

        private void tbFullName_TextChanged(object sender, EventArgs e)
        {
            // no-op: kept for Designer event wiring
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}