using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    internal class Inspektor : User
    {
        public List<Inspeksi> RiwayatInspeksi { get; set; } = new List<Inspeksi>();

        public Inspektor(int idUser, string namaLengkap, string username,
                         string password, string? noTelp, bool isAktif)
            : base(idUser, namaLengkap, username, password, noTelp, isAktif)
        {
            this.Roles.Add(new Userrole(idUser, 4, "inspektor"));
        }

        public void TambahInspeksi(Inspeksi inspeksi)
            => RiwayatInspeksi.Add(inspeksi);
    }
}
