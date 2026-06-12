using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class LelangContext
    {
        public static List<ProdukKopi> AmbilProdukSiapLelang()
        {
            var list = new List<ProdukKopi>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select p.id_produk, p.id_petani, p.id_jenis, p.nama_produk, p.berat_kg, p.harga_pengajuan, p.deskripsi, p.status 
                    from kapten.produk_kopi p
                    where p.status = 'LolosQc'
                    order by p.id_produk ASC", conn);

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
                MessageBox.Show("Gagal mengambil data siap lelang: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public static bool EksekusiBukaLelang(int idProduk, string? lokasiLelang)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                using var cmdGetHarga = new NpgsqlCommand(@"
                    select harga_rekomendasi from kapten.inspeksi 
                    where id_produk = @idProduk 
                    ordere by id_inspeksi desc limit 1", conn);
                cmdGetHarga.Parameters.AddWithValue("idProduk", idProduk);

                object res = cmdGetHarga.ExecuteScalar();
                if (res == null)
                    throw new Exception("Produk ini belum memiliki data rekomendasi harga dari Inspektor!");

                decimal bidMinimum = Convert.ToDecimal(res);

                DateTime tglMulai = DateTime.Now;
                DateTime tglAkhir = tglMulai.AddMinutes(10);

                using var cmdLelang = new NpgsqlCommand(@"
                    insert into kapten.lelang (id_produk, bid_minimum, tgl_mulai, tgl_akhir, lokasi_lelang, status) 
                    values (@idProduk, @bidMin, @tglMulai, @tglAkhir, @lokasi, 'Berlangsung')", conn);

                cmdLelang.Parameters.AddWithValue("idProduk", idProduk);
                cmdLelang.Parameters.AddWithValue("bidMin", bidMinimum);
                cmdLelang.Parameters.AddWithValue("tglMulai", tglMulai);
                cmdLelang.Parameters.AddWithValue("tglAkhir", tglAkhir);
                cmdLelang.Parameters.AddWithValue("lokasi", (object?)lokasiLelang?.Trim() ?? DBNull.Value);
                cmdLelang.ExecuteNonQuery();


                using var cmdProduk = new NpgsqlCommand(@"
                    update kapten.produk_kopi 
                    set status = 'Berlangsung' 
                    where id_produk = @idProduk", conn);
                cmdProduk.Parameters.AddWithValue("idProduk", idProduk);
                cmdProduk.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal membuka lelang di database: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
