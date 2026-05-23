using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class FormRegister : Form  // ← bukan Form1, biar ga bentrok
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void Register_Click(object sender, EventArgs e)
        {
            string username = txtname.Text.Trim();
            string email = txtemail.Text.Trim();
            string password = txtpassword.Text;
            string confirmpassword = txtcpassword.Text;

            if (username == null || username == "")
            {
                MessageBox.Show("Plis masukin username.");
                return;
            }
            if (email == null || email == "")
            {
                MessageBox.Show("Plis masukin email.");
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Format email salah bro.");
                return;
            }
            if (password == null || password == "")
            {
                MessageBox.Show("Plis masukin password.");
                return;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 char lah.");
                return;
            }
            if (confirmpassword == null || confirmpassword == "")
            {
                MessageBox.Show("Plis confirm password.");
                return;
            }
            if (password != confirmpassword)
            {
                MessageBox.Show("Passwords gk cocok lol");
                return;
            }

            try
            {
                using (var conn = ConnectDB.GetConn())  // ← ConnectDB dari WinFormsApp1
                {
                    string query = @"INSERT INTO users (nama, email, password_hash, role) 
                                     VALUES (@nama, @email, @password_hash, 'petani')";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nama", username);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("password_hash", password);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registrasi berhasil! Selamat datang " + username);

                // balik ke login setelah register berhasil
                Form1 fl = new Form1();
                fl.Show();
                this.Hide();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                    MessageBox.Show("Email udah dipake orang lain.");
                else
                    MessageBox.Show("Error database: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}