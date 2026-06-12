using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using static WinFormsApp1.Models.Enum;

namespace WinFormsApp1.Models
{
    public static class ProdukKopiContext
    {
        public static bool TambahProduk(int idPetani, string namaProduk, int idJenis, decimal beratKg, decimal hargaPengajuan, string? deskripsi)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    insert into kapten.produk_kopi (id_petani, id_jenis, nama_produk, berat_kg, harga_pengajuan, deskripsi, status) 
                    values (@idPetani, @idJenis, @nama, @berat, @harga, @deskripsi, 'PendingInspeksi')", conn);

                cmd.Parameters.AddWithValue("idPetani", idPetani);
                cmd.Parameters.AddWithValue("idPetani", UserContext.CurrentUser!.IdUser);
                cmd.Parameters.AddWithValue("idJenis", idJenis);
                cmd.Parameters.AddWithValue("nama", namaProduk.Trim());
                cmd.Parameters.AddWithValue("berat", beratKg);
                cmd.Parameters.AddWithValue("harga", hargaPengajuan);
                cmd.Parameters.AddWithValue("deskripsi", (object?)deskripsi?.Trim() ?? DBNull.Value);

                int barisTersimpan = cmd.ExecuteNonQuery();
                return barisTersimpan > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan produk ke database: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<ProdukKopi> AmbilProdukPending()
        {
            var list = new List<ProdukKopi>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select id_produk, id_petani, id_jenis, nama_produk, berat_kg, harga_pengajuan, deskripsi, status 
                    from kapten.produk_kopi 
                    where status = 'PendingInspeksi'
                    order by id_produk ASC", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string statusStr = reader.GetString(7);
                    Enum.StatusProduk statusEnum = (Enum.StatusProduk)System.Enum.Parse(typeof(Enum.StatusProduk), statusStr);

                    list.Add(new ProdukKopi(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetString(3),
                        reader.GetDecimal(4),
                        reader.GetDecimal(5),
                        reader.IsDBNull(6) ? null : reader.GetString(6),
                        statusEnum
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil antrean inspeksi: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}
