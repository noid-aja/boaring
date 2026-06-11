namespace WinFormsApp1.Models
{
    public class User
    {
        public int IdUser { get; set; }

        public string NamaLengkap { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? NoTelp { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsAktif { get; set; } = true;
        public List<string> Roles { get; set; } = new();
    }

}