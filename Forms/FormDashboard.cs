using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Repositories;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormDashboard : Form
    {
        private readonly DashboardRepository _dashboardRepository = new DashboardRepository();

        private string roleAktif = "admin";

        public FormDashboard()
        {
            InitializeComponent();
            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }

        public FormDashboard(string role)
        {
            InitializeComponent();
            roleAktif = role?.Trim().ToLower() ?? string.Empty;
            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleAktif))
                {
                    MessageBox.Show(
                        "Role user kosong. Cek hasil login dan mapping User.Role.",
                        "Role Kosong",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                AturDashboard(roleAktif);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat dashboard:\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AturDashboard(string role)
        {
            if (role == "admin")
            {
                lblSidebarTitle.Text = "Dashboard Admin";

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
                    _dashboardRepository.CountTotalUser().ToString(), "Total User",
                    _dashboardRepository.CountProdukByStatus("pending_inspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountProdukByStatus("lolos_qc").ToString(), "Lolos QC",
                    _dashboardRepository.CountLelangByStatus("berlangsung").ToString(), "Lelang Aktif"
                );

                IsiTabelAdmin();
            }
            else if (role == "petani")
            {
                lblSidebarTitle.Text = "Dashboard Petani";

                AturMenu(new List<string>
                {
                    "Beranda",
                    "Input Produk",
                    "Produk Saya",
                    "Hasil QC",
                    "Jadwal Lelang",
                    "Transaksi"
                });

                int idPetani = UserContext.IdUser;

                AturCard(
                    _dashboardRepository.CountProdukPetani(idPetani).ToString(), "Produk Saya",
                    _dashboardRepository.CountProdukPetaniByStatus(idPetani, "pending_inspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountProdukPetaniByStatus(idPetani, "lolos_qc").ToString(), "Lolos QC",
                    _dashboardRepository.CountProdukPetaniByStatus(idPetani, "terjual").ToString(), "Terjual"
                );

                IsiTabelPetani(idPetani);
            }
            else if (role == "pembeli")
            {
                lblSidebarTitle.Text = "Dashboard Pembeli";

                AturMenu(new List<string>
                {
                    "Beranda",
                    "Lihat Lelang",
                    "Ikut Bid",
                    "Riwayat Bid",
                    "Transaksi Saya"
                });

                int idPembeli = UserContext.IdUser;

                AturCard(
                    _dashboardRepository.CountLelangByStatus("berlangsung").ToString(), "Lelang Aktif",
                    _dashboardRepository.CountBidPembeli(idPembeli).ToString(), "Bid Saya",
                    _dashboardRepository.CountMenangPembeli(idPembeli).ToString(), "Menang",
                    _dashboardRepository.CountTransaksiPembeliByStatus(idPembeli, "belum_bayar").ToString(), "Belum Bayar"
                );

                IsiTabelPembeli();
            }
            else if (role == "inspektor")
            {
                lblSidebarTitle.Text = "Dashboard Inspektor";

                AturMenu(new List<string>
                {
                    "Beranda",
                    "Produk Pending",
                    "Input Inspeksi",
                    "Riwayat Inspeksi",
                    "Laporan QC"
                });

                int idInspektor = UserContext.IdUser;

                AturCard(
                    _dashboardRepository.CountProdukByStatus("pending_inspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountInspeksiByInspektor(idInspektor).ToString(), "Sudah Dicek",
                    _dashboardRepository.CountInspeksiByInspektorAndStatus(idInspektor, "lolos_qc").ToString(), "Lolos QC",
                    _dashboardRepository.CountInspeksiByInspektorAndStatus(idInspektor, "ditolak_qc").ToString(), "Ditolak QC"
                );

                IsiTabelInspektor();
            }
            else
            {
                MessageBox.Show(
                    "Role tidak dikenali: " + role,
                    "Role Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
                btnMenujeniskopi,
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
            if (sender is not Button btn || btn.Tag == null)
                return;

            string menu = (btn.Tag.ToString() ?? string.Empty).Trim().ToLower();

            switch (menu)
            {
                case "beranda":
                    // close any active child and show dashboard components
                    if (activeForm != null)
                    {
                        activeForm.Close();
                        activeForm = null;
                    }
                    ShowDashboardComponents();
                    break;
                case "kelola user":
                    openChildForm(new KelolaUser());
                    break;
                case "jenis kopi":
                    openChildForm(new jeniskopi());
                    break;
                default:
                    MessageBox.Show("Menu dipilih: " + btn.Tag.ToString());
                    break;
            }
        }

        private void SetTable(DataTable table)
        {
            dgvDashboard.DataSource = null;
            dgvDashboard.Columns.Clear();
            dgvDashboard.Rows.Clear();
            dgvDashboard.DataSource = table;
        }

        private void IsiTabelAdmin()
        {
            lblTableTitle.Text = "Data Produk Kopi";
            SetTable(_dashboardRepository.GetProdukAdmin());
        }

        private void IsiTabelPetani(int idPetani)
        {
            lblTableTitle.Text = "Status Produk Saya";
            SetTable(_dashboardRepository.GetProdukPetani(idPetani));
        }

        private void IsiTabelPembeli()
        {
            lblTableTitle.Text = "Jadwal Lelang Kopi";
            SetTable(_dashboardRepository.GetLelangPembeli());
        }

        private void IsiTabelInspektor()
        {
            lblTableTitle.Text = "Produk Menunggu Inspeksi";
            SetTable(_dashboardRepository.GetProdukPendingInspeksi());
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void lblTableTitle_Click(object sender, EventArgs e)
        {
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                UserContext.Clear();

                Form1 login = new Form1();
                login.Show();

                this.Close();
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSidebarTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            openChildForm(new jeniskopi());

        }

        private Form activeForm = null;
        private void openChildForm(Form child)
        {
            // hide dashboard components before showing child
            HideDashboardComponents();

            if (activeForm != null)
                activeForm.Close();

            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            // do not auto-restore dashboard when a child is closed due to switching.
            // restoring is performed explicitly when user returns to dashboard (e.g. Beranda).

            child.BringToFront();
            child.Show();
        }

        private void HideDashboardComponents()
        {
            try
            {
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                lblTableTitle.Visible = false;
            }
            catch { }
        }

        private void ShowDashboardComponents()
        {
            try
            {
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                lblTableTitle.Visible = true;
            }
            catch { }
        }

        private void btnOpenChildSmart_Click(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            openChildForm(new KelolaUser());
        }

        private void lblCardValue1_Click(object sender, EventArgs e)
        {

        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}