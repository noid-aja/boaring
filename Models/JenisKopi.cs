using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    internal class JenisKopi
    {
        public int IdJenis { get; set; }
        public string NamaJenis { get; set; } = string.Empty;
        public string? Deskripsi { get; set; }

        public JenisKopi() { }

        public JenisKopi(int idJenis, string namaJenis, string? deskripsi)
        {
            IdJenis = idJenis;
            NamaJenis = namaJenis;
            Deskripsi = deskripsi;
        }
    }
}
