using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Petani : User
    {
        public List<ProdukKopi> DaftarProduk { get; set; } = new List<ProdukKopi>();

        public Petani(int idUser, string namaLengkap, string username,
                      string password, string? noTelp, bool isAktif)
            : base(idUser, namaLengkap, username, password, noTelp, isAktif)
        {
            // contoh: this.Roles.Add(new Userrole(idUser, 2, "petani"));
        }

        public void TambahProduk(ProdukKopi produk)
            => DaftarProduk.Add(produk);

        public void HapusProduk(int idProduk)
            => DaftarProduk.RemoveAll(p => p.IdProduk == idProduk);
    }
}
