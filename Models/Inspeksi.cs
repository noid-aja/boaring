using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Inspeksi
    {
        public int IdInspeksi { get; set; }
        public int IdProduk { get; set; }
        public int IdInspektor { get; set; }
        public DateTime TglInspeksi { get; set; } = DateTime.Today;
        public int Nilai { get; set; }
        public string Grade { get; set; } = string.Empty;
        public decimal HargaRekomendasi { get; set; }
        public string? Catatan { get; set; }
        public bool IsLolosQc { get; set; } 

        public Inspeksi() { }

        public Inspeksi(int idInspeksi, int idProduk, int idInspektor, DateTime tglInspeksi,
                        int nilai, string grade, decimal hargaRekomendasi, string? catatan, bool isLolosQc)
        {
            IdInspeksi = idInspeksi;
            IdProduk = idProduk;
            IdInspektor = idInspektor;
            TglInspeksi = tglInspeksi;
            Nilai = nilai;
            Grade = grade;
            HargaRekomendasi = hargaRekomendasi;
            Catatan = catatan;
            IsLolosQc = isLolosQc;
        }
    }
}
