using Npgsql;
using NpgsqlTypes;
using WinFormsApp1.Models;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Repositories
{
    public class UserRepository
    {
        public bool IsNoTelpTaken(string noTelp)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"select count(1) from kapten.users where no_telp = @no_telp", conn);
            cmd.Parameters.AddWithValue("no_telp", NpgsqlDbType.Varchar, noTelp);
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }

        public bool UpdateProfile(User user)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                update kapten.users
                set nama_lengkap = @nama_lengkap,
                    no_telp = @no_telp
                where id_user = @id_user", conn);
            cmd.Parameters.AddWithValue("nama_lengkap", NpgsqlDbType.Varchar, user.NamaLengkap);
            cmd.Parameters.AddWithValue("no_telp", NpgsqlDbType.Varchar, (object?)user.NoTelp ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, user.IdUser);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdatePassword(int idUser, string newPassword)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                update kapten.users
                set password = @password
                where id_user = @id_user", conn);
            cmd.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, newPassword);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool AddRole(int idUser, string role)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                insert into kapten.user_roles (id_user, id_role)
                select @id_user, id_role
                from kapten.roles
                where lower(nama_role) = lower(@nama_role)", conn);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            cmd.Parameters.AddWithValue("nama_role", NpgsqlDbType.Varchar, role);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool RemoveRole(int idUser, string role)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                delete from kapten.user_roles
                where id_user = @id_user
                  and id_role = (
                    select id_role from kapten.roles where lower(nama_role) = lower(@nama_role)
                  )", conn);
            cmd.Parameters.AddWithValue("id_user", NpgsqlDbType.Integer, idUser);
            cmd.Parameters.AddWithValue("nama_role", NpgsqlDbType.Varchar, role);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool SoftDeleteUser(int idUser)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                update kapten.users set is_aktif = false where id_user = @id", conn);
            cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, idUser);
            return cmd.ExecuteNonQuery() > 0;
        }

        public void Register(User user, string namaRole)
        {
            namaRole = namaRole.Trim().ToLower();
            if (namaRole != "petani" && namaRole != "pembeli" && namaRole != "inspektor")
                throw new ArgumentException("Role tidak valid.");

            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();
            using NpgsqlTransaction transaction = conn.BeginTransaction();

            try
            {
                const string insertUserQuery = """
                    insert into kapten.users (nama_lengkap, username, password, no_telp, is_aktif)
                    values (@nama_lengkap, @username, @password, @no_telp, TRUE)
                    returning id_user;
                    """;

                int idUser;
                using (NpgsqlCommand cmd = new NpgsqlCommand(insertUserQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("nama_lengkap", NpgsqlDbType.Varchar, user.NamaLengkap);
                    cmd.Parameters.AddWithValue("username", NpgsqlDbType.Varchar, user.Username);
                    cmd.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, user.Password);
                    cmd.Parameters.Add("no_telp", NpgsqlDbType.Varchar).Value =
                        string.IsNullOrWhiteSpace(user.NoTelp) ? DBNull.Value : user.NoTelp;

                    object? result = cmd.ExecuteScalar();
                    if (result is null || result == DBNull.Value)
                        throw new InvalidOperationException("ID user gagal dibuat.");

                    idUser = Convert.ToInt32(result);
                }

                const string insertRoleQuery = """
                    insert into kapten.user_roles (id_user, id_role)
                    select @id_user, id_role
                    from kapten.roles
                    where lower(nama_role) = lower(@nama_role);
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

            // Catatan: query ini butuh kolom kapten.user_roles.is_role_aktif.
            // Kalau database belum punya kolom itu, jalankan ALTER TABLE yang gue tulis di chat.
            const string query = """
                select
                    u.id_user,
                    u.nama_lengkap,
                    u.username,
                    u.password,
                    u.no_telp,
                    u.is_aktif,
                    r.id_role,
                    r.nama_role
                from kapten.users u
                join kapten.user_roles ur on ur.id_user = u.id_user
                join kapten.roles r on r.id_role = ur.id_role
                where u.username = @username
                  and u.password = @password
                  and u.is_aktif = TRUE
                  and ur.is_role_aktif = TRUE
                order by r.id_role;
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
                        Password = reader.GetString(3),
                        NoTelp = reader.IsDBNull(4) ? null : reader.GetString(4),
                        IsAktif = reader.GetBoolean(5),
                        Roles = new List<Userrole>()
                    };
                }

                int idRoleFromDb = reader.GetInt32(6);
                string namaRoleFromDb = reader.GetString(7);
                user.Roles.Add(new Userrole(user.IdUser, idRoleFromDb, namaRoleFromDb));
            }

            return user;
        }
    }
}
