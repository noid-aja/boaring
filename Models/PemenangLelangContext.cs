using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal class PemenangLelangContext
    {
        public static List<Dictionary<string, object>> AmbilSemuaPemenang()
        {
            var list = new List<Dictionary<string, object>>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select 
                        pl.id_pemenang,
                        p.nama_produk,
                        u_petani.nama_lengkap AS nama_petani,
                        u_pembeli.nama_lengkap AS nama_pembeli,
                        b.nominal AS harga_menang,
                        pl.tgl_ditetapkan
                    from kapten.pemenang_lelang pl
                    join kapten.bid b on pl.id_bid = b.id_bid
                    join kapten.lelang l on pl.id_lelang = l.id_lelang
                    join kapten.produk_kopi p on l.id_produk = p.id_produk
                    join kapten.users u_petani on p.id_petani = u_petani.id_user
                    join kapten.users u_pembeli on b.id_pembeli = u_pembeli.id_user
                    order by pl.tgl_ditetapkan desc", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>
                    {
                        { "IdPemenang", reader.GetInt32(0) },
                        { "NamaProduk", reader.GetString(1) },
                        { "NamaPetani", reader.GetString(2) },
                        { "NamaPembeli", reader.GetString(3) },
                        { "HargaMenang", reader.GetDecimal(4) },
                        { "TglDitetapkan", reader.GetDateTime(5) }
                    };
                    list.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data pemenang lelang: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}
