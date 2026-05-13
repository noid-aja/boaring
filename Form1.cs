using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbusr.Text) ||
              string.IsNullOrWhiteSpace(tbpw.Text))
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            string username = tbusr.Text;
            string password = tbpw.Text;

            using (NpgsqlConnection conn =  ConnectDB.GetConn())
            {

                string query = "select count(*) from users where username=@user and password=@pass";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Formmenu fm = new Formmenu();
                        fm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Username atau Password Salah", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
