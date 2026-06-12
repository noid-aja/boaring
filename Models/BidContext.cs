using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class BidContext
    {
        public static bool EksekusiBid(int idLelang, int idPembeli, decimal nominalBid)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                using var cmdLelang = new NpgsqlCommand(@"
                    select bid_minimum, tgl_akhir, status 
                    from kapten.lelang 
                    where id_lelang = @idLelang for update", conn); 
                cmdLelang.Parameters.AddWithValue("idLelang", idLelang);

                using var reader = cmdLelang.ExecuteReader();
                if (!reader.Read()) throw new Exception("Data lelang tidak ada");

                decimal bidMinimum = reader.GetDecimal(0);
                DateTime tglAkhir = reader.GetDateTime(1);
                string statusLelang = reader.GetString(2);
                reader.Close();

                if (statusLelang != "Berlangsung")
                    throw new Exception("Lelang telah selesai!");

                if (DateTime.Now > tglAkhir)
                    throw new Exception("Waktu lelang sudah terlewat");

                using var cmdCekBid = new NpgsqlCommand(@"select coalesce(max(nominal), 0) 
                                                        from kapten.bid where id_lelang = @idLelang", conn);
                cmdCekBid.Parameters.AddWithValue("idLelang", idLelang);
                decimal bidTertinggi = Convert.ToDecimal(cmdCekBid.ExecuteScalar());

                decimal batasMinimal = bidTertinggi > 0 ? bidTertinggi : bidMinimum;

                if (nominalBid <= batasMinimal)
                    throw new Exception($"Nominal bid lu kekecilan! Harus lebih tinggi dari {batasMinimal:N0}");

                TimeSpan sisaWaktu = tglAkhir - DateTime.Now;
                bool dapetBonusWaktu = false;

                if (sisaWaktu.TotalMinutes <= 1.0)
                {
                    tglAkhir = tglAkhir.AddSeconds(10); 
                    dapetBonusWaktu = true;

                    using var cmdUpdateWaktu = new NpgsqlCommand(@"
                        update kapten.lelang set tgl_akhir = @tglAkhir where id_lelang = @idLelang", conn);
                    cmdUpdateWaktu.Parameters.AddWithValue("tglAkhir", tglAkhir);
                    cmdUpdateWaktu.Parameters.AddWithValue("idLelang", idLelang);
                    cmdUpdateWaktu.ExecuteNonQuery();
                }

                using var cmdInsertBid = new NpgsqlCommand(@"
                    insert into kapten.bid (id_lelang, id_pembeli, nominal, tgl_bid) 
                    values (@idLelang, @idPembeli, @nominal, @tglBid)", conn);
                cmdInsertBid.Parameters.AddWithValue("idLelang", idLelang);
                cmdInsertBid.Parameters.AddWithValue("idPembeli", idPembeli);
                cmdInsertBid.Parameters.AddWithValue("nominal", nominalBid);
                cmdInsertBid.Parameters.AddWithValue("tglBid", DateTime.Now);
                cmdInsertBid.ExecuteNonQuery();

                trans.Commit();

                if (dapetBonusWaktu)
                    MessageBox.Show("Karena sudah mepet setiap input bit tambah 10 detik!", "Sniper Protection Active", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message, "Gagal Nge-Bid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static List<Bid> AmbilRiwayatBidPembeli(int idPembeli)
        {
            var listBid = new List<Bid>();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select id_bid, id_lelang, id_pembeli, nominal, tgl_bid 
                    from kapten.bid 
                    where id_pembeli = @idPembeli 
                    order by tgl_bid DESC", conn);

                cmd.Parameters.AddWithValue("idPembeli", idPembeli);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBid.Add(new Bid(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetDecimal(3),
                        reader.GetDateTime(4)
                    ));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mengambil riwayat bid: " + ex.Message,
                    "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return listBid;
        }
    }
}
