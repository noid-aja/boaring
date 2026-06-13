using Npgsql;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class Inspeksi : Form
    {
        public Inspeksi()
        {
            InitializeComponent();
            LoadPendingProducts();
            // inspector id is taken from current logged user (UserContext) when submitting
        }

        private void Inspeksi_Load(object sender, EventArgs e)
        {
        }

        private void LoadPendingProducts()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = "select id_produk, nama_produk, id_petani, id_jenis, berat_kg, harga_pengajuan, status_produk from kapten.produk_kopi where status_produk = 'pending_inspeksi' order by id_produk";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPending.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPending.Rows[e.RowIndex];
            // ensure selected product id is available
            nudNilai.Value = 0;
            tbHargaRekomendasi.Text = string.Empty;
            tbCatatan.Text = string.Empty;
        }

        private string ComputeGrade(int nilai)
        {
            if (nilai >= 85 && nilai <= 100) return "A";
            if (nilai >= 80 && nilai <= 84) return "B";
            if (nilai >= 60 && nilai <= 79) return "C";
            return "D";
        }

        private string ComputeStatus(int nilai)
        {
            return (nilai >= 80) ? "lolos_qc" : "ditolak_qc";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingProducts();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProduk = Convert.ToInt32(dgvPending.SelectedRows[0].Cells["id_produk"].Value);

            int idInspektor = UserContext.IdUser;
            if (idInspektor <= 0)
            {
                MessageBox.Show("ID inspektor tidak tersedia. Silakan login terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nilai = (int)nudNilai.Value;
            decimal? harga = null;
            if (!string.IsNullOrWhiteSpace(tbHargaRekomendasi.Text))
            {
                if (decimal.TryParse(tbHargaRekomendasi.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
                    harga = v;
                else
                {
                    MessageBox.Show("Harga rekomendasi tidak valid", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbHargaRekomendasi.Focus();
                    return;
                }
            }

            string catatan = string.IsNullOrWhiteSpace(tbCatatan.Text) ? null : tbCatatan.Text.Trim();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                // upsert inspeksi by id_produk
                using var cmd = new NpgsqlCommand(@"INSERT INTO kapten.inspeksi(id_produk, id_inspektor, nilai, harga_rekomendasi, catatan)
VALUES(@idproduk, @idinspektor, @nilai, @harga, @cat)
ON CONFLICT (id_produk) DO UPDATE
  SET id_inspektor = EXCLUDED.id_inspektor,
      nilai = EXCLUDED.nilai,
      harga_rekomendasi = EXCLUDED.harga_rekomendasi,
      catatan = EXCLUDED.catatan,
      tgl_inspeksi = CURRENT_DATE;", conn);

                cmd.Parameters.AddWithValue("@idproduk", idProduk);
                cmd.Parameters.AddWithValue("@idinspektor", idInspektor);
                cmd.Parameters.AddWithValue("@nilai", nilai);
                if (harga.HasValue)
                    cmd.Parameters.AddWithValue("@harga", harga.Value);
                else
                    cmd.Parameters.AddWithValue("@harga", DBNull.Value);
                if (catatan != null)
                    cmd.Parameters.AddWithValue("@cat", catatan);
                else
                    cmd.Parameters.AddWithValue("@cat", DBNull.Value);

                cmd.ExecuteNonQuery();
                // compute grade/status locally for message
                var grade = ComputeGrade(nilai);
                var status = ComputeStatus(nilai);
                MessageBox.Show($"Inspeksi disimpan. Grade: {grade}, Status: {status}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan inspeksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
