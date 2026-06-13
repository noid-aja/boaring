using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string NamaLengkap { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
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
        {
            return Roles.Any(r => r.NamaRole.Equals(role, StringComparison.OrdinalIgnoreCase));
        }
        public List<RoleUser> GetOopRoles()
        {
            var oopList = new List<RoleUser>();
            foreach (var r in Roles)
            {
                try
                {
                    oopList.Add(RoleFactory.Create(this, r.NamaRole));
                }
                catch
                {
                }
            }
            return oopList;
        }

        public override string ToString()
        {
            return $"[{IdUser}] {NamaLengkap} ({Username})";
        }
    }
}