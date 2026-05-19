using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Npgsql;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            chart1.Series.Clear();
            Series s = new Series("Penjualan")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            chart1.Series.Add(s);

            using (NpgsqlConnection conn = ConnectDB.GetConn())
            {
                string query = @"Select p.nama_produk, sum(jumlah) as total from penjualan pj
                                join produk p using(produk_id) group by 1";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string nama = rd.IsDBNull(0) ? "(unknown)" : rd.GetString(0);
                        double total = 0;
                        if (!rd.IsDBNull(1))
                        {
                            try { total = Convert.ToDouble(rd.GetValue(1)); }
                            catch { total = 0; }
                        }

                        s.Points.AddXY(nama, total);
                    }
                }
            }

            chart1.Invalidate();
        }
    }
}
