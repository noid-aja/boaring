namespace WinFormsApp1.Models
{
    public class User
    {
        protected int IdUser;

        protected string NamaLengkap;

        protected string Username;

        protected string Password;

        protected string? NoTelp;

        protected bool IsAktif;

        protected List<string> Roles;

        public User(int IDUser, string NamaLengkap, string usr, string pw, string? notelp, bool Isaktif, List<string> roles)
        {
            this.IdUser= IdUser;
            this.NamaLengkap = NamaLengkap;
            this.Username = usr;
            this.Password = pw;
            this.NoTelp = notelp;
            this.IsAktif = Isaktif;
            this.Roles = roles;
        }

        public int getid()
        {
            return this.IdUser;
        }

        public string getNamaLengkap()
        {
            return this.NamaLengkap;
        }
        
        public string getusr()
        {
            return this.Username;
        }

        public string? getNoTelp()
        {
            return this.NoTelp;
        }

        public bool getIsAktif()
        {
            return this.IsAktif;
        }

        public List<string> getroles()
        {
            return this.Roles;
        }
    }

}