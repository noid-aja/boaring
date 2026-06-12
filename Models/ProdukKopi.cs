using System;
using System.Collections.Generic;
using System.Text;
using static WinFormsApp1.Models.Enum;

namespace WinFormsApp1.Models
{
    public class ProdukKopi
    {
        public int IdProduk { get; set; }
        public int IdPetani { get; set; }
        public int IdJenis { get; set; }
        public string NamaProduk { get; set; } = string.Empty;
        public decimal BeratKg { get; set; }
        public decimal HargaPengajuan { get; set; }
        public string? Deskripsi { get; set; }
        public StatusProduk Status { get; set; } = StatusProduk.PendingInspeksi;

        public ProdukKopi() { }

        public ProdukKopi(int idProduk, int idPetani, int idJenis, string namaProduk,
                          decimal beratKg, decimal hargaPengajuan, string? deskripsi, StatusProduk status)
        {
            IdProduk = idProduk;
            IdPetani = idPetani;
            IdJenis = idJenis;
            NamaProduk = namaProduk;
            BeratKg = beratKg;
            HargaPengajuan = hargaPengajuan;
            Deskripsi = deskripsi;
            Status = status;
        }
    }
}

