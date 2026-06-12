using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Pembeli : User
    {
        public List<Bid> RiwayatBid { get; set; } = new List<Bid>();

        public Pembeli(int idUser, string namaLengkap, string username,
                       string password, string? noTelp, bool isAktif)
            : base(idUser, namaLengkap, username, password, noTelp, isAktif)
        {
            //contoh: this.Roles.Add(new UserRole(idUser, 3, "pembeli"));
        }

        public void TambahBid(Bid bid) => RiwayatBid.Add(bid);

        public Bid? GetBidTertinggi()
            => RiwayatBid.OrderByDescending(b => b.Nominal).FirstOrDefault();
    }
}
