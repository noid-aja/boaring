using System;
using System.Collections.Generic;
using System.Text;
using static WinFormsApp1.Models.Enum;

namespace WinFormsApp1.Models
{
    public class Lelang
    {
        public int IdLelang { get; set; }
        public int IdProduk { get; set; }
        public decimal BidMinimum { get; set; }
        public DateTime TglMulai { get; set; }  
        public DateTime TglAkhir { get; set; }
        public string? LokasiLelang { get; set; }
        public StatusLelang Status { get; set; } = StatusLelang.Dijadwalkan;

        public Lelang() { }

        public Lelang(int idLelang, int idProduk, decimal bidMinimum, DateTime tglMulai,
                      DateTime tglAkhir, string? lokasiLelang, StatusLelang status)
        {
            IdLelang = idLelang;
            IdProduk = idProduk;
            BidMinimum = bidMinimum;
            TglMulai = tglMulai;
            TglAkhir = tglAkhir;
            LokasiLelang = lokasiLelang;
            Status = status;
        }
    }
}
