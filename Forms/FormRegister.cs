using Npgsql;
using System;
using System.Text.RegularExpressions;
using WinFormsApp1.Controllers;

namespace WinFormsApp1
{
    public partial class FormRegister : Form
    {
        private readonly AuthController _authController;

        public FormRegister()
        {
            InitializeComponent();

            _authController = new AuthController();

            txtrole.DropDownStyle = ComboBoxStyle.DropDownList;

            if (txtrole.Items.Count > 0)
            {
                txtrole.SelectedIndex = 0;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            string namaLengkap = txtnamapanjang.Text.Trim();
            string username = txtusername.Text.Trim();
            string noTelp = txtnotelp.Text.Trim();
            string password = txtpassword.Text;
            string confirmPassword = txtcpassword.Text;

            string role = txtrole.SelectedItem?
                .ToString()?
                .Trim()
                .ToLower() ?? string.Empty;

            // Validasi nama lengkap
            if (string.IsNullOrWhiteSpace(namaLengkap))
            {
                MessageBox.Show("Nama lengkap harus diisi.");
                txtnamapanjang.Focus();
                return;
            }

            if (namaLengkap.Length < 3)
            {
                MessageBox.Show("Nama lengkap minimal 3 karakter.");
                txtnamapanjang.Focus();
                return;
            }

            if (!Regex.IsMatch(namaLengkap, @"^[a-zA-ZÀ-ÿ.'\s]+$"))
            {
                MessageBox.Show(
                    "Nama lengkap hanya boleh berisi huruf, spasi, titik, dan apostrof.");

                txtnamapanjang.Focus();
                return;
            }

            // Validasi username
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username harus diisi.");
                txtusername.Focus();
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username minimal 4 karakter.");
                txtusername.Focus();
                return;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show(
                    "Username hanya boleh berisi huruf, angka, dan underscore.");

                txtusername.Focus();
                return;
            }

            // Validasi nomor telepon
            if (string.IsNullOrWhiteSpace(noTelp))
            {
                MessageBox.Show("Nomor telepon harus diisi.");
                txtnotelp.Focus();
                return;
            }

            if (!Regex.IsMatch(noTelp, @"^[0-9]{10,15}$"))
            {
                MessageBox.Show(
                    "Nomor telepon harus berisi 10 sampai 15 angka.");

                txtnotelp.Focus();
                return;
            }

            // Validasi role
            if (role != "petani" && role != "pembeli")
            {
                MessageBox.Show("Pilih role Petani atau Pembeli.");
                txtrole.Focus();
                return;
            }

            // Validasi password
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password harus diisi.");
                txtpassword.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter.");
                txtpassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Konfirmasi password harus diisi.");
                txtcpassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Konfirmasi password tidak cocok.");
                txtcpassword.Focus();
                return;
            }

            try
            {
                _authController.Register(
                    namaLengkap,
                    username,
                    password,
                    confirmPassword,
                    noTelp,
                    role);

                MessageBox.Show(
                    $"Registrasi berhasil!\nSelamat datang, {namaLengkap}.",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Form1 loginForm = new Form1();
                loginForm.Show();

                Hide();
            }
            catch (PostgresException ex)
                when (ex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                MessageBox.Show(
                    "Username sudah digunakan.",
                    "Registrasi Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtusername.Focus();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Data Tidak Valid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal mengakses database:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FormRegister_Load(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtrole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            Hide();
        }
    }
}