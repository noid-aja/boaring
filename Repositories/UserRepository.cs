using Npgsql;
using NpgsqlTypes;
using WinFormsApp1.Models;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Repositories
{
    public class UserRepository
    {
        public void Register(User user, string namaRole)
        {
            if (namaRole != "petani" && namaRole != "pembeli")
            {
                throw new ArgumentException(
                    "Role hanya boleh petani atau pembeli.");
            }

            using NpgsqlConnection conn = ConnectDB.GetConnection();
            conn.Open();

            using NpgsqlTransaction transaction = conn.BeginTransaction();

            try
            {
                const string insertUserQuery = """
                    INSERT INTO kapten.users
                    (
                        nama_lengkap,
                        username,
                        password,
                        no_telp,
                        is_aktif
                    )
                    VALUES
                    (
                        @nama_lengkap,
                        @username,
                        @password,
                        @no_telp,
                        TRUE
                    )
                    RETURNING id_user;
                    """;

                int idUser;

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    insertUserQuery,
                    conn,
                    transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "nama_lengkap",
                        NpgsqlDbType.Varchar,
                        user.NamaLengkap);

                    cmd.Parameters.AddWithValue(
                        "username",
                        NpgsqlDbType.Varchar,
                        user.Username);

                    cmd.Parameters.AddWithValue(
                        "password",
                        NpgsqlDbType.Varchar,
                        user.Password);

                    cmd.Parameters.Add(
                        "no_telp",
                        NpgsqlDbType.Varchar
                    ).Value = string.IsNullOrWhiteSpace(user.NoTelp)
                        ? DBNull.Value
                        : user.NoTelp;

                    object? result = cmd.ExecuteScalar();

                    if (result is null || result == DBNull.Value)
                    {
                        throw new InvalidOperationException(
                            "ID user gagal dibuat.");
                    }

                    idUser = Convert.ToInt32(result);
                }

                const string insertRoleQuery = """
                    INSERT INTO kapten.user_roles
                    (
                        id_user,
                        id_role
                    )
                    SELECT
                        @id_user,
                        id_role
                    FROM kapten.roles
                    WHERE LOWER(nama_role) = LOWER(@nama_role);
                    """;

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    insertRoleQuery,
                    conn,
                    transaction))
                {
                    cmd.Parameters.AddWithValue(
                        "id_user",
                        NpgsqlDbType.Integer,
                        idUser);

                    cmd.Parameters.AddWithValue(
                        "nama_role",
                        NpgsqlDbType.Varchar,
                        namaRole);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            "Role tidak ditemukan atau gagal diberikan.");
                    }
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
        SELECT
            u.id_user,
            u.nama_lengkap,
            u.username,
            u.no_telp,
            u.is_aktif,
            r.nama_role
        FROM kapten.users u
        JOIN kapten.user_roles ur
            ON ur.id_user = u.id_user
        JOIN kapten.roles r
            ON r.id_role = ur.id_role
        WHERE u.username = @username
          AND u.password = @password
          AND u.is_aktif = TRUE;
        """;

            using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
                "username",
                NpgsqlDbType.Varchar,
                username);

            cmd.Parameters.AddWithValue(
                "password",
                NpgsqlDbType.Varchar,
                password);

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
                        NoTelp = reader.IsDBNull(3)
                            ? null
                            : reader.GetString(3),
                        IsAktif = reader.GetBoolean(4)
                    };
                }

                user.Roles.Add(reader.GetString(5));
            }

            return user;
        }
    }
}