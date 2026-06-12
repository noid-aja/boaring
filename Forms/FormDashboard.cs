using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormDashboard : Form
    {
        private string roleAktif = "admin";

        public FormDashboard()
        {
            InitializeComponent();
        }

        public FormDashboard(string role)
        {
            InitializeComponent();
            roleAktif = role.ToLower();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            AturDashboard(roleAktif);
        }

        private void AturDashboard(string role)
        {
            if (role == "admin")
            {
                lblSidebarTitle.Text = "Dashboard Admin";
                lblHeaderTitle.Text = "Dashboard Admin";

                AturMenu(new List<string>
        {
            "Beranda",
            "Kelola User",
            "Jenis Kopi",
            "Produk Kopi",
            "Lelang",
            "Transaksi",
            "Laporan"
        });

                AturCard(
                    "6", "Total User",
                    "4", "Pending QC",
                    "0", "Lolos QC",
                    "0", "Lelang Aktif"
                );

                IsiTabelAdmin();
            }
            else if (role == "petani")
            {
                lblSidebarTitle.Text = "Dashboard Petani";
                lblHeaderTitle.Text = "Dashboard Petani";

                AturMenu(new List<string>
        {
            "Beranda",
            "Input Produk",
            "Produk Saya",
            "Hasil QC",
            "Jadwal Lelang",
            "Transaksi"
        });

                AturCard(
                    "0", "Produk Saya",
                    "0", "Pending QC",
                    "0", "Lolos QC",
                    "0", "Terjual"
                );

                IsiTabelPetani();
            }
            else if (role == "pembeli")
            {
                lblSidebarTitle.Text = "Dashboard Pembeli";
                lblHeaderTitle.Text = "Dashboard Pembeli";

                AturMenu(new List<string>
        {
            "Beranda",
            "Lihat Lelang",
            "Ikut Bid",
            "Riwayat Bid",
            "Transaksi Saya"
        });

                AturCard(
                    "0", "Lelang Aktif",
                    "0", "Bid Saya",
                    "0", "Menang",
                    "0", "Belum Bayar"
                );

                IsiTabelPembeli();
            }
            else if (role == "inspektor")
            {
                lblSidebarTitle.Text = "Dashboard Inspektor";
                lblHeaderTitle.Text = "Dashboard Inspektor";

                AturMenu(new List<string>
        {
            "Beranda",
            "Produk Pending",
            "Input Inspeksi",
            "Riwayat Inspeksi",
            "Laporan QC"
        });

                AturCard(
                    "4", "Pending QC",
                    "0", "Sudah Dicek",
                    "0", "Lolos QC",
                    "0", "Ditolak QC"
                );

                IsiTabelInspektor();
            }
        }

        private void AturCard(
           string value1, string title1,
           string value2, string title2,
           string value3, string title3,
           string value4, string title4)
        {
            lblCardValue1.Text = value1;
            lblCardTitle1.Text = title1;

            lblCardValue2.Text = value2;
            lblCardTitle2.Text = title2;

            lblCardValue3.Text = value3;
            lblCardTitle3.Text = title3;

            lblCardValue4.Text = value4;
            lblCardTitle4.Text = title4;
        }

        private void AturMenu(List<string> menus)
        {
            Button[] tombolMenu =
            {
            btnMenu1,
            btnMenu2,
            btnMenu3,
            btnMenu4,
            btnMenu5,
            btnMenu6,
            btnMenu7
            };

            for (int i = 0; i < tombolMenu.Length; i++)
            {
                if (i < menus.Count)
                {
                    tombolMenu[i].Text = menus[i];
                    tombolMenu[i].Tag = menus[i];
                    tombolMenu[i].Visible = true;

                    tombolMenu[i].Click -= Menu_Click;
                    tombolMenu[i].Click += Menu_Click;
                }
                else
                {
                    tombolMenu[i].Visible = false;
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null || btn.Tag == null)
                return;

            string menu = btn.Tag.ToString();

            MessageBox.Show("Menu dipilih: " + menu);
        }

        private void IsiTabelAdmin()
        {
            lblTableTitle.Text = "Data Produk Kopi";

            dgvDashboard.Columns.Clear();
            dgvDashboard.Rows.Clear();

            dgvDashboard.Columns.Add("produk", "Produk");
            dgvDashboard.Columns.Add("petani", "Petani");
            dgvDashboard.Columns.Add("jenis", "Jenis Kopi");
            dgvDashboard.Columns.Add("berat", "Berat");
            dgvDashboard.Columns.Add("status", "Status");
            dgvDashboard.Columns.Add("grade", "Grade");

            dgvDashboard.Rows.Add("Kopi Arabika Gayo", "Pak Budi", "Arabika", "25 kg", "pending_inspeksi", "-");
            dgvDashboard.Rows.Add("Kopi Robusta Lampung", "Pak Joko", "Robusta", "40 kg", "pending_inspeksi", "-");
        }

        private void IsiTabelPetani()
        {
            lblTableTitle.Text = "Status Produk Saya";

            dgvDashboard.Columns.Clear();
            dgvDashboard.Rows.Clear();

            dgvDashboard.Columns.Add("produk", "Produk");
            dgvDashboard.Columns.Add("jenis", "Jenis Kopi");
            dgvDashboard.Columns.Add("berat", "Berat");
            dgvDashboard.Columns.Add("harga", "Harga Pengajuan");
            dgvDashboard.Columns.Add("status", "Status");
            dgvDashboard.Columns.Add("grade", "Grade");

            dgvDashboard.Rows.Add("Belum ada produk", "-", "-", "-", "-", "-");
        }

        private void IsiTabelPembeli()
        {
            lblTableTitle.Text = "Jadwal Lelang Kopi";

            dgvDashboard.Columns.Clear();
            dgvDashboard.Rows.Clear();

            dgvDashboard.Columns.Add("produk", "Produk");
            dgvDashboard.Columns.Add("jenis", "Jenis Kopi");
            dgvDashboard.Columns.Add("grade", "Grade");
            dgvDashboard.Columns.Add("bid", "Bid Minimum");
            dgvDashboard.Columns.Add("lokasi", "Lokasi");
            dgvDashboard.Columns.Add("status", "Status");

            dgvDashboard.Rows.Add("Belum ada lelang", "-", "-", "-", "-", "-");
        }

        private void IsiTabelInspektor()
        {
            lblTableTitle.Text = "Produk Menunggu Inspeksi";

            dgvDashboard.Columns.Clear();
            dgvDashboard.Rows.Clear();

            dgvDashboard.Columns.Add("produk", "Produk");
            dgvDashboard.Columns.Add("petani", "Petani");
            dgvDashboard.Columns.Add("jenis", "Jenis Kopi");
            dgvDashboard.Columns.Add("berat", "Berat");
            dgvDashboard.Columns.Add("harga", "Harga Pengajuan");
            dgvDashboard.Columns.Add("status", "Status");

            dgvDashboard.Rows.Add("Kopi Arabika Gayo", "Pak Budi", "Arabika", "25 kg", "500000", "pending_inspeksi");
            dgvDashboard.Rows.Add("Kopi Robusta Lampung", "Pak Joko", "Robusta", "40 kg", "600000", "pending_inspeksi");
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

            // Kalau form login lu Form1
            Form1 login = new Form1();
            login.Show();
        }
    }
}