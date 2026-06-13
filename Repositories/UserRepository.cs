using Npgsql;
using NpgsqlTypes;
using WinFormsApp1.Models;
using WinFormsApp1.Helpers;
using System;
using System.Collections.Generic;

namespace WinFormsApp1.Repositories
{
    public class UserRepository
    {
        public void Register(User user, string namaRole)
        {
            string roleLower = namaRole.Trim().ToLower();
            if (roleLower != "petani" && roleLower != "pembeli" && roleLower != "inspektor")
            {
                throw new ArgumentException("Role hanya boleh petani, pembeli, atau inspektor.");
            }

            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();
            using NpgsqlTransaction transaction = conn.BeginTransaction();

            try
            {
                const string insertUserQuery = """
                    INSERT INTO kapten.users (nama_lengkap, username, password, no_telp, is_aktif)
                    VALUES (@nama_lengkap, @username, @password, @no_telp, TRUE)
                    RETURNING id_user;
                    """;

                int idUser;
                using (NpgsqlCommand cmd = new NpgsqlCommand(insertUserQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("nama_lengkap", NpgsqlDbType.Varchar, user.NamaLengkap);
                    cmd.Parameters.AddWithValue("username", NpgsqlDbType.Varchar, user.Username);
                    cmd.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, user.Password);
                    cmd.Parameters.Add("no_telp", NpgsqlDbType.Varchar).Value = string.IsNullOrWhiteSpace(user.NoTelp) ? DBNull.Value : user.NoTelp;

                    object? result = cmd.ExecuteScalar();
                    if (result is null || result == DBNull.Value)
                        throw new InvalidOperationException("ID user gagal dibuat.");

                    idUser = Convert.ToInt32(result);
                }

                const string insertRoleQuery = """
                    INSERT INTO kapten.user_roles (id_user, id_role)
                    SELECT @id_user, id_role FROM kapten.roles WHERE LOWER(nama_role) = LOWER(@nama_role);
                    """;

                using (NpgsqlCommand cmd = new NpgsqlCommand(insertRoleQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
                    cmd.Parameters.AddWithValue("nama_role", NpgsqlDbType.Varchar, namaRole);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows != 1)
                        throw new InvalidOperationException("Role tidak ditemukan atau gagal diberikan.");
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public User? Login(string username, string password)
        {
            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();

            const string query = """
                SELECT u.id_user, u.nama_lengkap, u.username, u.no_telp, u.is_aktif, r.id_role, r.nama_role
                FROM kapten.users u
                JOIN kapten.user_roles ur ON ur.id_user = u.id_user
                JOIN kapten.roles r ON r.id_role = ur.id_role
                WHERE u.username = @username AND u.password = @password AND u.is_aktif = TRUE
                ORDER BY r.id_role;
                """;

            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("username", NpgsqlDbType.Varchar, username);
            cmd.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, password);

            using NpgsqlDataReader reader = cmd.ExecuteReader();
            User? user = null;

            while (reader.Read())
            {
                if (user is null)
                {
                    user = new User
                    {
                        IdUser = reader.GetInt32(0),
                        NamaLengkap = reader.GetString(1),
                        Username = reader.GetString(2),
                        NoTelp = reader.IsDBNull(3) ? null : reader.GetString(3),
                        IsAktif = reader.GetBoolean(4),
                        Roles = new List<Userrole>()
                    };
                }

                int idRoleDb = reader.GetInt32(5);
                string namaRoleDb = reader.GetString(6);
                // DIKEMBALIKAN KE MODEL OBJEK USERROLE BIAR TIDAK ERROR COMPILE
                user.Roles.Add(new Userrole(user.IdUser, idRoleDb, namaRoleDb));
            }

            return user;
        }

        // FUNGSI MANAGEMENT PROFIL TAMBAHAN YANG DIBUTUHKAN USERCONTROLLER
        public bool IsNoTelpTaken(string noTelp)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("select count(1) from kapten.users where no_telp = @no_telp", conn);
            cmd.Parameters.AddWithValue("no_telp", NpgsqlDbType.Varchar, noTelp);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool UpdateProfile(User user)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("update kapten.users set nama_lengkap = @nama_lengkap, no_telp = @no_telp where id_user = @id_user", conn);
            cmd.Parameters.AddWithValue("nama_lengkap", NpgsqlDbType.Varchar, user.NamaLengkap);
            cmd.Parameters.AddWithValue("no_telp", NpgsqlDbType.Varchar, (object?)user.NoTelp ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, user.IdUser);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdatePassword(int idUser, string newPassword)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("update kapten.users set password = @password where id_user = @id_user", conn);
            cmd.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, newPassword);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool AddRole(int idUser, string role)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("insert into kapten.user_roles (id_user, id_role) select @id_user, id_role FROM kapten.roles where LOWER(nama_role) = LOWER(@nama_role)", conn);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            cmd.Parameters.AddWithValue("nama_role", NpgsqlDbType.Varchar, role);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool RemoveRole(int idUser, string role)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("delete from kapten.user_roles where id_user = @id_user and id_role = (select id_role from kapten.roles where LOWER(nama_role) = LOWER(@nama_role))", conn);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            cmd.Parameters.AddWithValue("nama_role", NpgsqlDbType.Varchar, role);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool SoftDeleteUser(int idUser)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("update kapten.users set is_aktif = false where id_user = @id", conn);
            cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, idUser);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}