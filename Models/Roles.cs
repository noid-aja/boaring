using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Roles
    {
        public int IdRole { get; set; }
        public string NamaRole { get; set; } = string.Empty;

        public Roles() 
        { 
        }

        public Roles(int idRole, string namaRole)
        {
            IdRole = idRole;
            NamaRole = namaRole;
        }
    }
}
