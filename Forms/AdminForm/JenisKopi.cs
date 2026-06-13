using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class jeniskopi : Form
    {
        public jeniskopi()
        {
            InitializeComponent();
            LoadJenis();
        }

        private void LoadJenis()
        {
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    // Menampilkan data sesuai nama kolom di tabel baru
                    string query = "select id_jenis, nama_jenis, deskripsi from kapten.jenis_kopi order by id_jenis";
                    var da = new NpgsqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvJenis.DataSource = dt;
                    dgvJenis.Columns["deskripsi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    conn.Open();

                    // Kolom disesuaikan menjadi nama_jenis
                    string query = "insert into kapten.jenis_kopi(nama_jenis, deskripsi) values(@nama, @deskripsi)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", tbNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@deskripsi", string.IsNullOrWhiteSpace(tbDeskripsi.Text) ? (object)DBNull.Value : tbDeskripsi.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil ditambah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvJenis.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            int id = Convert.ToInt32(dgvJenis.SelectedRows[0].Cells[0].Value);
            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    conn.Open();

                    // Query UPDATE disesuaikan dengan nama_jenis dan id_jenis
                    string query = "update kapten.jenis_kopi set nama_jenis=@nama, deskripsi=@deskripsi where id_jenis=@id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", tbNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@deskripsi", string.IsNullOrWhiteSpace(tbDeskripsi.Text) ? (object)DBNull.Value : tbDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ubah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvJenis.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvJenis.SelectedRows[0].Cells[0].Value);
            var dr = MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (var conn = ConnectDB.GetConnection())
                {
                    conn.Open();

                    // Langsung eksekusi perintah delete tanpa cek select count ke tabel produk
                    string del = "delete from kapten.jenis_kopi where id_jenis = @id";
                    using (var cmd = new NpgsqlCommand(del, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {
                // Kode "23503" adalah kode standar PostgreSQL untuk Foreign Key Violation (menyalahi relasi)
                MessageBox.Show("Jenis kopi tidak dapat dihapus karena sudah digunakan pada data produk.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvJenis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvJenis.Rows[e.RowIndex];

            // Mengambil indeks kolom secara aman (Cell[1] adalah nama_jenis)
            tbNama.Text = row.Cells[1].Value?.ToString() ?? string.Empty;

            object val = null;
            try
            {
                // Mencoba mapping berdasarkan nama kolom 'deskripsi'
                val = row.Cells["deskripsi"].Value;
            }
            catch { if (row.Cells.Count > 2) val = row.Cells[2].Value; }
            tbDeskripsi.Text = val?.ToString() ?? string.Empty;
        }

        private void ClearInputs()
        {
            tbNama.Text = string.Empty;
            tbDeskripsi.Text = string.Empty;
        }

        private void jeniskopi_Load(object sender, EventArgs e) { }
        private void tbNama_TextChanged(object sender, EventArgs e) { }
        private void tbDeskripsi_TextChanged(object sender, EventArgs e) { }

        private void dgvJenis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}