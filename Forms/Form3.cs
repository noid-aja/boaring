using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Clear();

                Series series = new Series("Penjualan")
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Double
                };

                chart1.Series.Add(series);

                using NpgsqlConnection conn = ConnectDB.GetConnection();
                conn.Open();

                const string query = """
                    SELECT
                        p.nama_produk,
                        SUM(pj.jumlah) AS total
                    FROM penjualan pj
                    JOIN produk p
                        ON p.produk_id = pj.produk_id
                    GROUP BY p.nama_produk
                    ORDER BY p.nama_produk;
                    """;

                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string namaProduk = reader.IsDBNull(0)
                        ? "(unknown)"
                        : reader.GetString(0);

                    double total = reader.IsDBNull(1)
                        ? 0
                        : Convert.ToDouble(reader.GetValue(1));

                    series.Points.AddXY(namaProduk, total);
                }

                chart1.Invalidate();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data grafik:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}