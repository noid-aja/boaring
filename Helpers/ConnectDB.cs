using System;
using Npgsql;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class ConnectDB
    {
        private static string ConnString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=postgres;" +
            "Database=kaptencoi;";
        public static NpgsqlConnection GetConn()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal di : " + ex.Message);
            }

            return conn;


        }

    }
}
