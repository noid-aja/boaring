using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms; 
using WinFormsApp1.Helpers; 
using WinFormsApp1.Models;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Models
{
    public class UserRepository
    {
        public User? Login(string username, string password)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmdUser = new NpgsqlCommand(@"
            SELECT id_user, nama_lengkap, username, password, no_telp, is_aktif 
            FROM kapten.users 
            WHERE username = @username AND password = @password AND is_aktif = true", conn);

                cmdUser.Parameters.AddWithValue("username", username);
                cmdUser.Parameters.AddWithValue("password", password);

                using var reader = cmdUser.ExecuteReader();
                if (!reader.Read()) return null; 

                int idUser = reader.GetInt32(0);
                string namaLengkap = reader.GetString(1);
                string uname = reader.GetString(2);
                string pass = reader.GetString(3);
                string? noTelp = reader.IsDBNull(4) ? null : reader.GetString(4);
                bool isAktif = reader.GetBoolean(5);
                reader.Close(); // Tutup reader user agar bisa query role

                // Ambil daftar role milik user tersebut
                List<Userrole> roles = new List<Userrole>();
                using var cmdRoles = new NpgsqlCommand(@"
            SELECT ur.id_user, ur.id_role, r.nama_role 
            FROM kapten.user_roles ur
            INNER JOIN kapten.roles r ON ur.id_role = r.id_role
            WHERE ur.id_user = @idUser", conn);
                cmdRoles.Parameters.AddWithValue("idUser", idUser);

                using var readerRoles = cmdRoles.ExecuteReader();
                while (readerRoles.Read())
                {
                    roles.Add(new Userrole(readerRoles.GetInt32(0), readerRoles.GetInt32(1), readerRoles.GetString(2)));
                }

                // Manfaatkan method bawaanmu untuk generate object sesuai Role-nya!
                return CreateUserByRoles(idUser, namaLengkap, uname, pass, noTelp, isAktif, roles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror Login: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private User CreateUserByRoles(int idUser, string namaLengkap, string username, string password, string? noTelp, bool isAktif, List<Userrole> roles)
        {
            var user = new User
            {
                IdUser = idUser,
                NamaLengkap = namaLengkap,
                Username = username,
                Password = password,
                NoTelp = noTelp,
                IsAktif = isAktif,
                Roles = roles ?? new List<Userrole>()
            };

            return user;
        }


        public bool Register(User user, string roleAwal)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction(); 
            try
            {
                using var cmdUser = new NpgsqlCommand(@"
                INSERT INTO kapten.users (nama_lengkap, username, password, no_telp, is_aktif) 
                VALUES (@nama, @username, @password, @noTelp, true) RETURNING id_user", conn);

                cmdUser.Parameters.AddWithValue("nama", user.NamaLengkap);
                cmdUser.Parameters.AddWithValue("username", user.Username);
                cmdUser.Parameters.AddWithValue("password", user.Password);
                cmdUser.Parameters.AddWithValue("noTelp", (object?)user.NoTelp ?? DBNull.Value);

                int newIdUser = Convert.ToInt32(cmdUser.ExecuteScalar());
                user.IdUser = newIdUser;

                int idRole = 3; 
                if (roleAwal.Equals("petani", StringComparison.OrdinalIgnoreCase)) idRole = 2;
                else if (roleAwal.Equals("inspektor", StringComparison.OrdinalIgnoreCase)) idRole = 4;
                else if (roleAwal.Equals("admin", StringComparison.OrdinalIgnoreCase)) idRole = 1;

                using var cmdRole = new NpgsqlCommand(@"
                INSERT INTO kapten.user_roles (id_user, id_role) VALUES (@idUser, @idRole)", conn);
                cmdRole.Parameters.AddWithValue("idUser", newIdUser);
                cmdRole.Parameters.AddWithValue("idRole", idRole);

                cmdRole.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback(); 
                MessageBox.Show("Gagal Register: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool AddRole(int idUser, string role)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                int idRole = role.Equals("petani", StringComparison.OrdinalIgnoreCase) ? 2 : 3;

                using var cmd = new NpgsqlCommand("INSERT INTO kapten.user_roles (id_user, id_role) VALUES (@idUser, @idRole)", conn);
                cmd.Parameters.AddWithValue("idUser", idUser);
                cmd.Parameters.AddWithValue("idRole", idRole);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
        }

        public bool RemoveRole(int idUser, string role)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                int idRole = role.Equals("petani", StringComparison.OrdinalIgnoreCase) ? 2 : 3;

                using var cmd = new NpgsqlCommand("DELETE FROM kapten.user_roles WHERE id_user = @idUser AND id_role = @idRole", conn);
                cmd.Parameters.AddWithValue("idUser", idUser);
                cmd.Parameters.AddWithValue("idRole", idRole);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
        }

        public bool SoftDeleteUser(int idUser)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
            UPDATE kapten.users 
            SET is_aktif = false 
            WHERE id_user = @id", conn);

                cmd.Parameters.AddWithValue("id", idUser);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menonaktifkan user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsNoTelpTaken(string noTelp)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT COUNT(1) FROM kapten.users WHERE no_telp = @noTelp AND is_aktif = true", conn);
            cmd.Parameters.AddWithValue("noTelp", noTelp);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool UpdateProfile(User user)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("UPDATE kapten.users SET nama_lengkap = @nama, no_telp = @noTelp WHERE id_user = @id", conn);
                cmd.Parameters.AddWithValue("nama", user.NamaLengkap);
                cmd.Parameters.AddWithValue("noTelp", (object?)user.NoTelp ?? DBNull.Value);
                cmd.Parameters.AddWithValue("id", user.IdUser);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
        }

        public bool UpdatePassword(int idUser, string newPassword)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("UPDATE kapten.users SET password = @pass WHERE id_user = @id", conn);
                cmd.Parameters.AddWithValue("pass", newPassword);
                cmd.Parameters.AddWithValue("id", idUser);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
        }
    } 
}