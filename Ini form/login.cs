using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void tbusr_TextChanged(object sender, EventArgs e) { }
        private void tbpw_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbusr.Text) ||
                string.IsNullOrWhiteSpace(tbpw.Text))
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            string nama = tbusr.Text;
            string password = tbpw.Text;

            using (NpgsqlConnection conn = ConnectDB.GetConn())
            {
              string query = @"SELECT COUNT(*) 
              FROM kapten.users AS u
              WHERE u.nama = @nama
                AND u.password = @pass
                AND u.is_aktif = TRUE";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
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
                        MessageBox.Show("Email atau Password Salah", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister fr = new FormRegister();
            fr.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}