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
                        "Role user kosong. Cek hasil login dan mapping User.Roles.",
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
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Sesi login Anda tidak valid. Silakan login kembali.", "Sesi Habis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int currentIdUser = UserContext.CurrentUser.IdUser;

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
                    _dashboardRepository.CountProdukByStatus("PendingInspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountProdukByStatus("LolosQc").ToString(), "Lolos QC",
                    _dashboardRepository.CountLelangByStatus("Berlangsung").ToString(), "Lelang Aktif"
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

                AturCard(
                    _dashboardRepository.CountProdukPetani(currentIdUser).ToString(), "Produk Saya",
                    _dashboardRepository.CountProdukPetaniByStatus(currentIdUser, "PendingInspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountProdukPetaniByStatus(currentIdUser, "LolosQc").ToString(), "Lolos QC",
                    _dashboardRepository.CountProdukPetaniByStatus(currentIdUser, "Terjual").ToString(), "Terjual"
                );

                IsiTabelPetani(currentIdUser);
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

                AturCard(
                    _dashboardRepository.CountLelangByStatus("Berlangsung").ToString(), "Lelang Aktif",
                    _dashboardRepository.CountBidPembeli(currentIdUser).ToString(), "Bid Saya",
                    _dashboardRepository.CountMenangPembeli(currentIdUser).ToString(), "Menang",
                    _dashboardRepository.CountTransaksiPembeliByStatus(currentIdUser, "BelumBayar").ToString(), "Belum Bayar"
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

                int idInspektor = UserContext.CurrentUser != null ? UserContext.CurrentUser.IdUser : 0;

                AturCard(
                    _dashboardRepository.CountProdukByStatus("PendingInspeksi").ToString(), "Pending QC",
                    _dashboardRepository.CountInspeksiByInspektor(idInspektor).ToString(), "Sudah Dicek",
                    _dashboardRepository.CountProdukByStatus("LolosQc").ToString(), "Lolos QC",
                    _dashboardRepository.CountProdukByStatus("DitolakQc").ToString(), "Ditolak QC"
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
            Button[] tombolMenu = { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6, btnMenu7 };

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
            if (sender is not Button btn || btn.Tag == null) return;
            string menu = btn.Tag.ToString().Trim().ToLower();

            switch (menu)
            {
                case "beranda":
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
                case "input inspeksi":
                case "produk pending":
                    // SINKRONISASI: Menyebut nama form secara eksplisit agar tidak tabrakan namespace
                    openChildForm(new WinFormsApp1.Forms.AdminForm.Inspeksi());
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
            dgvDashboard.DataSource = table;
        }

        private void IsiTabelAdmin() => SetTable(_dashboardRepository.GetProdukAdmin());
        private void IsiTabelPetani(int idPetani) => SetTable(_dashboardRepository.GetProdukPetani(idPetani));
        private void IsiTabelPembeli() => SetTable(_dashboardRepository.GetLelangPembeli());
        private void IsiTabelInspektor() => SetTable(_dashboardRepository.GetProdukPendingInspeksi());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?",
                                                  "Konfirmasi Logout", 
                                                  MessageBoxButtons.YesNo, 
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserContext.Logout();

                Form1 login = new Form1();
                login.Show();

                this.Close();
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form child)
        {
            HideDashboardComponents();
            if (activeForm != null) activeForm.Close();

            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void HideDashboardComponents()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            lblTableTitle.Visible = false;
        }

        private void ShowDashboardComponents()
        {
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            lblTableTitle.Visible = true;
        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Equals(roleAktif, "admin", StringComparison.OrdinalIgnoreCase))
                {
                    openChildForm(new jeniskopi());
                }
                else if (string.Equals(roleAktif, "inspektor", StringComparison.OrdinalIgnoreCase))
                {
                    openChildForm(new WinFormsApp1.Forms.AdminForm.Inspeksi());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenu2_Click(object sender, EventArgs e) => openChildForm(new KelolaUser());

        // Designer-generated event handler stubs (prevent missing method errors)
        private void lblSidebarTitle_Click(object sender, EventArgs e)
        {
            // Intentionally left blank - no action required currently
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank - custom painting not required
        }

        private void lblCardValue1_Click(object sender, EventArgs e)
        {
            // Intentionally left blank - click not handled
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank - custom painting not required
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank - custom painting not required
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Intentionally left blank - no special cell handling at the moment
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank - custom painting not required
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            // Reuse existing logout logic if designer wired to a different handler name
            btnLogout_Click(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank - custom painting not required
        }
    }
}