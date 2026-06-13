using Npgsql;

namespace WinFormsApp1.Helpers
{
    static class ConnectDB
    {
        private const string ConnString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=NOIDAJA;" +
            "Database=prototype;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnString);
        }
    }
}