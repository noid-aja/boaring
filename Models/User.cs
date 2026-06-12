namespace WinFormsApp1.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string NamaLengkap { get; set; } 
        public string Username { get; set; } 
        public string Password { get; set; }
        public string? NoTelp { get; set; }
        public bool IsAktif { get; set; }

        public List<Userrole> Roles { get; set; } = new List<Userrole>();

        public User() { }

        public User(int idUser, string namaLengkap, string username, string pw, string? noTelp, bool isAktif)
        {
            IdUser = idUser;
            NamaLengkap = namaLengkap;
            Username = username;
            Password = pw;
            NoTelp = noTelp;
            IsAktif = isAktif;
            Roles = new List<Userrole>();
        }

        public bool IsInRole(string role)
            => Roles.Any(r => r.NamaRole.Equals(role, StringComparison.OrdinalIgnoreCase));

        public override string ToString()
            => $"[{IdUser}] {NamaLengkap} ({Username})";
    }

}