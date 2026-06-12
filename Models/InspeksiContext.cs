using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class InspeksiContext
    {
        public static bool SimpanHasilInspeksi(int idProduk, int idInspektor, int nilai, string grade, decimal hargaRekomendasi, string? catatan, bool isLolos)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();

            using var trans = conn.BeginTransaction();
            try
            {
                using var cmdInspeksi = new NpgsqlCommand(@"
                    insert into kapten.inspeksi (id_produk, id_inspektor, tgl_inspeksi, nilai, grade, harga_rekomendasi, catatan, is_lolos_qc) 
                    values (@idProduk, @idInspektor, @tgl, @nilai, @grade, @hargaRekomendasi, @catatan, @isLolos)", conn);

                cmdInspeksi.Parameters.AddWithValue("idProduk", idProduk);
                cmdInspeksi.Parameters.AddWithValue("idInspektor", idInspektor);
                cmdInspeksi.Parameters.AddWithValue("tgl", DateTime.Today);
                cmdInspeksi.Parameters.AddWithValue("nilai", nilai);
                cmdInspeksi.Parameters.AddWithValue("grade", grade);
                cmdInspeksi.Parameters.AddWithValue("hargaRekomendasi", hargaRekomendasi);
                cmdInspeksi.Parameters.AddWithValue("catatan", (object?)catatan?.Trim() ?? DBNull.Value);
                cmdInspeksi.Parameters.AddWithValue("isLolos", isLolos);
                cmdInspeksi.ExecuteNonQuery();

                string statusBaru = isLolos ? "Lolos Quality Control!" : "Ditolak Quality Control";

                using var cmdProduk = new NpgsqlCommand(@"
                    update kapten.produk_kopi 
                    set status = @status 
                    where id_produk = @idProduk", conn);

                cmdProduk.Parameters.AddWithValue("status", statusBaru);
                cmdProduk.Parameters.AddWithValue("idProduk", idProduk);
                cmdProduk.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal menyimpan data QC ke DB: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
    
}
