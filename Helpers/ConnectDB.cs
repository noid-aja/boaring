using Npgsql;

namespace WinFormsApp1.Helpers
{
    static class ConnectDB
    {
        private const string ConnString =
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=postgres8888;" +
            "Database=Kapten;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnString);
        }
    }
}