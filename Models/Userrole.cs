using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Userrole
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }

        public string NamaRole { get; set; } = string.Empty;
        public Userrole(int idUser, int idRole, string namaRole)
        {
            IdUser = idUser;
            IdRole = idRole;
            NamaRole = namaRole;
        }

    }
}
