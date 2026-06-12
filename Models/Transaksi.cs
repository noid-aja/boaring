using System;
using System.Collections.Generic;
using System.Text;
using static WinFormsApp1.Models.Enum;

namespace WinFormsApp1.Models
{
    public class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int IdPemenang { get; set; }
        public DateTime TglTransaksi { get; set; } = DateTime.Now;
        public decimal TotalBayar { get; set; }
        public decimal PersentaseKomisi { get; set; } = 5.00m;
        public decimal BiayaKomisi { get; set; }
        public decimal TotalDiterimaPetani { get; set; }
        public StatusBayar Status { get; set; } = StatusBayar.BelumBayar;

        public Transaksi() { }

        public Transaksi(int idTransaksi, int idPemenang, DateTime tglTransaksi, decimal totalBayar,
                         decimal persentaseKomisi, decimal biayaKomisi, decimal totalDiterimaPetani, StatusBayar status)
        {
            IdTransaksi = idTransaksi;
            IdPemenang = idPemenang;
            TglTransaksi = tglTransaksi;
            TotalBayar = totalBayar;
            PersentaseKomisi = persentaseKomisi;
            BiayaKomisi = biayaKomisi;
            TotalDiterimaPetani = totalDiterimaPetani;
            Status = status;
        }
    }
}
