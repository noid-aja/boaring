using Npgsql;

namespace WinFormsApp1.Helpers
{
    public static class ConnectDB
    {
        private const string ConnString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=postgres;" +
            "Database=Kapten;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnString);
        }
    }
}
