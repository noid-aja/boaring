using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal class JenisKopiContext
    {
        public static List<JenisKopi> AmbilSemua()
        {
            var list = new List<JenisKopi>();
            try
            {
                using var conn = ConnectDB.GetConnection(); 
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select id_jenis, nama_jenis, deskripsi 
                    from kapten.jenis_kopi 
                    order by id_jenis ASC", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new JenisKopi(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.IsDBNull(2) ? null : reader.GetString(2)
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data jenis kopi: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}
