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
        public bool IsAktif { get; set; } = true;

        // Punya fitur teman: support multi-role detail id_role + nama_role
        public List<Userrole> Roles { get; set; } = new List<Userrole>();

        // Kompatibilitas kode lama Dizy: Form1 masih pakai user.Role untuk buka dashboard.
        // Ambil role pertama dari daftar role aktif user.
        public string Role
        {
            get => Roles.FirstOrDefault()?.NamaRole ?? string.Empty;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && Roles.Count == 0)
                {
                    Roles.Add(new Userrole(IdUser, 0, value.Trim().ToLower()));
                }
            }
        }

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
