using Npgsql;
using System;
using System.Collections.Generic;
using WinFormsApp1.Models;

namespace WinFormsApp1.Helpers
{
    public static class UserContext
    {
        public static User? CurrentUser { get; private set; }

        public static void Login(User user) => CurrentUser = user;
        public static void Logout() => CurrentUser = null;

        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser?.IsInRole("admin") == true;
        public static bool IsPetani => CurrentUser?.IsInRole("petani") == true;
        public static bool IsPembeli => CurrentUser?.IsInRole("pembeli") == true;
        public static bool IsInspektor => CurrentUser?.IsInRole("inspektor") == true;

        public static void RequireRole(string role)
        {
            if (CurrentUser == null)
                throw new UnauthorizedAccessException("Belum login.");
            if (!CurrentUser.IsInRole(role))
                throw new UnauthorizedAccessException($"Akses ditolak. Role '{role}' dibutuhkan.");
        }

        public static List<User> GetAllUserAdmin()
        {
            List<User> dataAdmin = new List<User>(); 
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var query = new NpgsqlCommand(@"
                    select u.id_user, u.nama_lengkap, u.username,
                           u.password, u.no_telp, u.is_aktif
                    from kapten.users u
                    inner join kapten.user_roles ur on u.id_user = ur.id_user
                    inner join kapten.roles r on ur.id_role = r.id_role
                    where r.nama_role = 'admin'", conn); 

                using var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.IsDBNull(4) ? null : reader.GetString(4),
                        reader.GetBoolean(5)
                    );
                    user.Roles.Add("admin");
                    dataAdmin.Add(user);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Gagal mengambil data: " + ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataAdmin;
        }

        public static List<User> GetAllUserInspektor()
        {
            List<User> dataInspektor = new List<User>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var query = new NpgsqlCommand(@"
                    SELECT u.id_user, u.nama_lengkap, u.username,
                           u.password, u.no_telp, u.is_aktif
                    FROM kapten.users u
                    INNER JOIN kapten.user_roles ur ON u.id_user = ur.id_user
                    INNER JOIN kapten.roles r ON ur.id_role = r.id_role
                    WHERE r.nama_role = 'inspektor'", conn); 

                using var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.IsDBNull(4) ? null : reader.GetString(4),
                        reader.GetBoolean(5)
                    );
                    user.Roles.Add("inspektor");
                    dataInspektor.Add(user);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Gagal mengambil data: " + ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataInspektor;
        }
    }
}