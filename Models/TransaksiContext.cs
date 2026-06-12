using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal class TransaksiContext
    {
        public static void CekDanTutupLelangExpired()
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();

            using var cmdCari = new NpgsqlCommand(@"
                select id_lelang, id_produk 
                FROM kapten.lelang 
                WHERE status = 'Berlangsung' AND tgl_akhir <= @now", conn);
            cmdCari.Parameters.AddWithValue("now", DateTime.Now);

            var lelangExpiredList = new System.Collections.Generic.List<(int IdLelang, int IdProduk)>();
            using (var reader = cmdCari.ExecuteReader())
            {
                while (reader.Read())
                {
                    lelangExpiredList.Add((reader.GetInt32(0), reader.GetInt32(1)));
                }
            }

            foreach (var lelang in lelangExpiredList)
            {
                using var trans = conn.BeginTransaction();
                try
                {
                    using var cmdGetMaxBid = new NpgsqlCommand(@"
                        SELECT id_bid, id_pembeli, nominal 
                        FROM kapten.bid 
                        WHERE id_lelang = @idLelang 
                        ORDER BY nominal DESC LIMIT 1", conn);
                    cmdGetMaxBid.Parameters.AddWithValue("idLelang", lelang.IdLelang);

                    int idBidPemenang = 0;
                    int idPembeliPemenang = 0;
                    decimal nominalTertinggi = 0;

                    using (var readerBid = cmdGetMaxBid.ExecuteReader())
                    {
                        if (readerBid.Read())
                        {
                            idBidPemenang = readerBid.GetInt32(0);
                            idPembeliPemenang = readerBid.GetInt32(1);
                            nominalTertinggi = readerBid.GetDecimal(2);
                        }
                    }

                    if (idBidPemenang > 0)
                    {
                        using var cmdUpdateLelang = new NpgsqlCommand("UPDATE kapten.lelang SET status = 'Selesai' WHERE id_lelang = @id", conn);
                        cmdUpdateLelang.Parameters.AddWithValue("id", lelang.IdLelang);
                        cmdUpdateLelang.ExecuteNonQuery();

                        using var cmdUpdateProduk = new NpgsqlCommand("UPDATE kapten.produk_kopi SET status = 'Terjual' WHERE id_produk = @id", conn);
                        cmdUpdateProduk.Parameters.AddWithValue("id", lelang.IdProduk);
                        cmdUpdateProduk.ExecuteNonQuery();

                        using var cmdPemenang = new NpgsqlCommand(@"
                            INSERT INTO kapten.pemenang_lelang (id_lelang, id_bid, tgl_ditetapkan) 
                            VALUES (@idLelang, @idBid, @tgl) RETURNING id_pemenang", conn);
                        cmdPemenang.Parameters.AddWithValue("idLelang", lelang.IdLelang);
                        cmdPemenang.Parameters.AddWithValue("idBid", idBidPemenang);
                        cmdPemenang.Parameters.AddWithValue("tgl", DateTime.Now);
                        int idPemenangGenerated = Convert.ToInt32(cmdPemenang.ExecuteScalar());

                        decimal persentaseKomisi = 5.00m;
                        decimal biayaKomisi = nominalTertinggi * (persentaseKomisi / 100m);
                        decimal totalDiterimaPetani = nominalTertinggi - biayaKomisi;

                        using var cmdTransaksi = new NpgsqlCommand(@"
                            INSERT INTO kapten.transaksi (id_pemenang, tgl_transaksi, total_bayar, persentase_komisi, biaya_komisi, total_diterima_petani, status) 
                            VALUES (@idPemenang, @tgl, @total, @persen, @komisi, @diterima, 'BelumBayar')", conn);
                        cmdTransaksi.Parameters.AddWithValue("idPemenang", idPemenangGenerated);
                        cmdTransaksi.Parameters.AddWithValue("tgl", DateTime.Now);
                        cmdTransaksi.Parameters.AddWithValue("total", nominalTertinggi);
                        cmdTransaksi.Parameters.AddWithValue("persen", persentaseKomisi);
                        cmdTransaksi.Parameters.AddWithValue("komisi", biayaKomisi);
                        cmdTransaksi.Parameters.AddWithValue("diterima", totalDiterimaPetani);
                        cmdTransaksi.ExecuteNonQuery();
                    }
                    else
                    {
                        using var cmdUpdateLelang = new NpgsqlCommand("UPDATE kapten.lelang SET status = 'Dibatalkan' WHERE id_lelang = @id", conn);
                        cmdUpdateLelang.Parameters.AddWithValue("id", lelang.IdLelang);
                        cmdUpdateLelang.ExecuteNonQuery();

                        using var cmdUpdateProduk = new NpgsqlCommand("UPDATE kapten.produk_kopi SET status = 'LolosQc' WHERE id_produk = @id", conn);
                        cmdUpdateProduk.Parameters.AddWithValue("id", lelang.IdProduk);
                        cmdUpdateProduk.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        public static bool AdminKonfirmasiLunas(int idTransaksi)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                using var cmdTx = new NpgsqlCommand("UPDATE kapten.transaksi SET status = 'Lunas' WHERE id_transaksi = @id", conn);
                cmdTx.Parameters.AddWithValue("id", idTransaksi);
                cmdTx.ExecuteNonQuery();

                using var cmdGetProduk = new NpgsqlCommand(@"
                    SELECT l.id_produk FROM kapten.transaksi t
                    JOIN kapten.pemenang_lelang p ON t.id_pemenang = p.id_pemenang
                    JOIN kapten.lelang l ON p.id_lelang = l.id_lelang
                    WHERE t.id_transaksi = @id", conn);
                cmdGetProduk.Parameters.AddWithValue("id", idTransaksi);
                int idProduk = Convert.ToInt32(cmdGetProduk.ExecuteScalar());

                using var cmdProd = new NpgsqlCommand("UPDATE kapten.produk_kopi SET status = 'Terjual' WHERE id_produk = @id", conn);
                cmdProd.Parameters.AddWithValue("id", idProduk);
                cmdProd.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal eksekusi lunas di DB: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool AdminKonfirmasiGagalBayar(int idTransaksi)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                using var cmdTx = new NpgsqlCommand("UPDATE kapten.transaksi SET status = 'Dibatalkan' WHERE id_transaksi = @id", conn);
                cmdTx.Parameters.AddWithValue("id", idTransaksi);
                cmdTx.ExecuteNonQuery();

                using var cmdGetProduk = new NpgsqlCommand(@"
                    SELECT l.id_produk FROM kapten.transaksi t
                    JOIN kapten.pemenang_lelang p ON t.id_pemenang = p.id_pemenang
                    JOIN kapten.lelang l ON p.id_lelang = l.id_lelang
                    WHERE t.id_transaksi = @id", conn);
                cmdGetProduk.Parameters.AddWithValue("id", idTransaksi);
                int idProduk = Convert.ToInt32(cmdGetProduk.ExecuteScalar());

                using var cmdProd = new NpgsqlCommand("UPDATE kapten.produk_kopi SET status = 'LolosQc' WHERE id_produk = @id", conn);
                cmdProd.Parameters.AddWithValue("id", idProduk);
                cmdProd.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal eksekusi pembatalan di DB: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
        
    

