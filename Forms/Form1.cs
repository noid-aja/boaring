using Npgsql;
using System;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly AuthController _authController;

        public Form1()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _authController.Login(
                    tbusr.Text,
                    tbpw.Text
                );

                UserContext.SetUser(user);

                MessageBox.Show(
                    $"Login berhasil!\nSelamat datang, {user.NamaLengkap}.",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Formmenu menu = new Formmenu();
                menu.Show();
                Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal mengakses database:\n" + ex.Message,
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

        private void btnregister_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tbusr_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbpw_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}