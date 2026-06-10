using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbnp.Text))
            {
                MessageBox.Show(
                    "Nama produk harus diisi.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbnp.Focus();
                return;
            }

            if (!int.TryParse(tbharga.Text, out int harga))
            {
                MessageBox.Show(
                    "Harga harus berupa angka.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbharga.Focus();
                return;
            }

            if (harga < 0)
            {
                MessageBox.Show(
                    "Harga tidak boleh negatif.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbharga.Focus();
                return;
            }

            int stok = (int)NUD.Value;

            if (stok < 0)
            {
                MessageBox.Show(
                    "Stok tidak boleh negatif.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                NUD.Focus();
                return;
            }

            try
            {
                using NpgsqlConnection conn = ConnectDB.GetConnection();
                conn.Open();

                const string query = """
                    INSERT INTO produk
                    (
                        nama_produk,
                        harga,
                        stok
                    )
                    VALUES
                    (
                        @nama,
                        @harga,
                        @stok
                    );
                    """;

                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("nama", tbnp.Text.Trim());
                cmd.Parameters.AddWithValue("harga", harga);
                cmd.Parameters.AddWithValue("stok", stok);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Data berhasil ditambah.",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearInput();
                LoadProducts();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan database:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadProducts()
        {
            try
            {
                using NpgsqlConnection conn = ConnectDB.GetConnection();

                const string query = """
                    SELECT *
                    FROM produk
                    ORDER BY produk_id;
                    """;

                using NpgsqlDataAdapter adapter =
                    new NpgsqlDataAdapter(query, conn);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data produk:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Pilih data yang ingin dihapus terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                object? value =
                    dataGridView1.SelectedRows[0]
                        .Cells["produk_id"]
                        .Value;

                if (value is null || value == DBNull.Value)
                {
                    MessageBox.Show("ID produk tidak ditemukan.");
                    return;
                }

                int idProduk = Convert.ToInt32(value);

                using NpgsqlConnection conn = ConnectDB.GetConnection();
                conn.Open();

                const string query = """
                    DELETE FROM produk
                    WHERE produk_id = @produk_id;
                    """;

                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("produk_id", idProduk);

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    MessageBox.Show(
                        "Data produk tidak ditemukan.",
                        "Gagal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Data berhasil dihapus.",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadProducts();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal menghapus produk:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ClearInput()
        {
            tbnp.Clear();
            tbharga.Clear();
            NUD.Value = NUD.Minimum;
            tbnp.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void tbnp_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbharga_TextChanged(object sender, EventArgs e)
        {
        }

        private void NUD_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}