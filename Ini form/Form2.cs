using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

private void btntambah_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(tbnp.Text))
    {
        MessageBox.Show("Nama produk harus diisi.", 
                        "Validasi", 
                           MessageBoxButtons.OK, 
                           MessageBoxIcon.Warning);
        tbnp.Focus();
        return;
    }

    if (!int.TryParse(tbharga.Text, out int harga))
    {
        MessageBox.Show("Harga harus berupa angka.", 
                        "Validasi", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
        tbharga.Focus();
        return;
    }

    if (harga < 0)
    {
        MessageBox.Show("Harga tidak boleh negatif.", 
                        "Validasi", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
        tbharga.Focus();
        return;
    }

    int stok = (int)NUD.Value;
    if (stok < 0)
    {
        MessageBox.Show("Stok tidak boleh negatif.", 
                        "Validasi", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
        NUD.Focus();
        return;
    }

    try
    {
        using (NpgsqlConnection conn = ConnectDB.GetConn())
        {
            string query = "insert into produk(nama_produk, harga, stok) values(@nama, @harga, @stok)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nama", tbnp.Text.Trim());
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@stok", stok);

                cmd.ExecuteNonQuery();
            }
        }

        MessageBox.Show("Data berhasil ditambah.", 
                        "Sukses",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
        LoadProducts();
    }
    catch (Exception ex)
    {

        MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + 
                        ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void LoadProducts()
        {
            using (NpgsqlConnection conn = ConnectDB.GetConn())
            {
                string query = "select * from produk";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
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
