using Npgsql;
using NpgsqlTypes;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Repositories
{
    public class DashboardRepository
    {
        private int ExecuteScalarInt(string query, params NpgsqlParameter[] parameters)
        {
            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();

            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);

            object? result = cmd.ExecuteScalar();
            return result == null || result == DBNull.Value
                ? 0
                : Convert.ToInt32(result);
        }

        private DataTable GetDataTable(string query, params NpgsqlParameter[] parameters)
        {
            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();

            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);

            using NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public int CountTotalUser()
        {
            return ExecuteScalarInt("SELECT COUNT(*) FROM kapten.users;");
        }

        public int CountProdukByStatus(string status)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM kapten.produk_kopi WHERE status_produk = @status;",
                new NpgsqlParameter("status", NpgsqlDbType.Varchar) { Value = status });
        }

        public int CountLelangByStatus(string status)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM kapten.lelang WHERE status_lelang = @status;",
                new NpgsqlParameter("status", NpgsqlDbType.Varchar) { Value = status });
        }

        public int CountProdukPetani(int idPetani)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM kapten.produk_kopi WHERE id_petani = @id_petani;",
                new NpgsqlParameter("id_petani", NpgsqlDbType.Integer) { Value = idPetani });
        }

        public int CountProdukPetaniByStatus(int idPetani, string status)
        {
            return ExecuteScalarInt(
                """
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE id_petani = @id_petani
                  AND status_produk = @status;
                """,
                new NpgsqlParameter("id_petani", NpgsqlDbType.Integer) { Value = idPetani },
                new NpgsqlParameter("status", NpgsqlDbType.Varchar) { Value = status });
        }

        public int CountBidPembeli(int idPembeli)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM kapten.bid WHERE id_pembeli = @id_pembeli;",
                new NpgsqlParameter("id_pembeli", NpgsqlDbType.Integer) { Value = idPembeli });
        }

        public int CountMenangPembeli(int idPembeli)
        {
            return ExecuteScalarInt(
                """
                SELECT COUNT(*)
                FROM kapten.pemenang_lelang pl
                JOIN kapten.bid b ON b.id_bid = pl.id_bid
                WHERE b.id_pembeli = @id_pembeli;
                """,
                new NpgsqlParameter("id_pembeli", NpgsqlDbType.Integer) { Value = idPembeli });
        }

        public int CountTransaksiPembeliByStatus(int idPembeli, string statusBayar)
        {
            return ExecuteScalarInt(
                """
                SELECT COUNT(*)
                FROM kapten.transaksi t
                JOIN kapten.pemenang_lelang pl ON pl.id_pemenang = t.id_pemenang
                JOIN kapten.bid b ON b.id_bid = pl.id_bid
                WHERE b.id_pembeli = @id_pembeli
                  AND t.status_bayar = @status_bayar;
                """,
                new NpgsqlParameter("id_pembeli", NpgsqlDbType.Integer) { Value = idPembeli },
                new NpgsqlParameter("status_bayar", NpgsqlDbType.Varchar) { Value = statusBayar });
        }

        public int CountInspeksiByInspektor(int idInspektor)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM kapten.inspeksi WHERE id_inspektor = @id_inspektor;",
                new NpgsqlParameter("id_inspektor", NpgsqlDbType.Integer) { Value = idInspektor });
        }

        public int CountInspeksiByInspektorAndStatus(int idInspektor, string statusInspeksi)
        {
            return ExecuteScalarInt(
                """
                SELECT COUNT(*)
                FROM kapten.inspeksi
                WHERE id_inspektor = @id_inspektor
                  AND status_inspeksi = @status_inspeksi;
                """,
                new NpgsqlParameter("id_inspektor", NpgsqlDbType.Integer) { Value = idInspektor },
                new NpgsqlParameter("status_inspeksi", NpgsqlDbType.Varchar) { Value = statusInspeksi });
        }

        public DataTable GetProdukAdmin()
        {
            return GetDataTable(
                """
                SELECT
                    p.nama_produk AS "Produk",
                    u.nama_lengkap AS "Petani",
                    jk.nama_jenis AS "Jenis Kopi",
                    p.berat_kg AS "Berat Kg",
                    p.status_produk AS "Status",
                    COALESCE(i.grade, '-') AS "Grade"
                FROM kapten.produk_kopi p
                JOIN kapten.users u ON u.id_user = p.id_petani
                JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
                LEFT JOIN kapten.inspeksi i ON i.id_produk = p.id_produk
                ORDER BY p.id_produk DESC;
                """);
        }

        public DataTable GetProdukPetani(int idPetani)
        {
            return GetDataTable(
                """
                SELECT
                    p.nama_produk AS "Produk",
                    jk.nama_jenis AS "Jenis Kopi",
                    p.berat_kg AS "Berat Kg",
                    p.harga_pengajuan AS "Harga Pengajuan",
                    p.status_produk AS "Status",
                    COALESCE(i.grade, '-') AS "Grade"
                FROM kapten.produk_kopi p
                JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
                LEFT JOIN kapten.inspeksi i ON i.id_produk = p.id_produk
                WHERE p.id_petani = @id_petani
                ORDER BY p.id_produk DESC;
                """,
                new NpgsqlParameter("id_petani", NpgsqlDbType.Integer) { Value = idPetani });
        }

        public DataTable GetLelangPembeli()
        {
            return GetDataTable(
                """
                SELECT
                    p.nama_produk AS "Produk",
                    jk.nama_jenis AS "Jenis Kopi",
                    COALESCE(i.grade, '-') AS "Grade",
                    l.bid_minimum AS "Bid Minimum",
                    l.lokasi_lelang AS "Lokasi",
                    l.status_lelang AS "Status"
                FROM kapten.lelang l
                JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
                JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
                LEFT JOIN kapten.inspeksi i ON i.id_produk = p.id_produk
                ORDER BY l.tgl_mulai DESC;
                """);
        }

        public DataTable GetProdukPendingInspeksi()
        {
            return GetDataTable(
                """
                SELECT
                    p.nama_produk AS "Produk",
                    u.nama_lengkap AS "Petani",
                    jk.nama_jenis AS "Jenis Kopi",
                    p.berat_kg AS "Berat Kg",
                    p.harga_pengajuan AS "Harga Pengajuan",
                    p.status_produk AS "Status"
                FROM kapten.produk_kopi p
                JOIN kapten.users u ON u.id_user = p.id_petani
                JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
                WHERE p.status_produk = 'pending_inspeksi'
                ORDER BY p.id_produk DESC;
                """);
        }
    }
}
