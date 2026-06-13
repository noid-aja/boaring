using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Models.Roles
{
    public class PetaniRole : RoleUser
    {
        public PetaniRole(User user) : base(user) { }

        public override string NamaRole => "petani";

        public override string JudulDashboard => "Dashboard Petani";

        public override List<string> GetMenuAkses()
        {
            return new List<string>
            {
                "Input Produk Kopi",
                "Lihat Produk Saya",
                "Lihat Hasil QC",
                "Lihat Jadwal Lelang",
                "Lihat Status Transaksi"
            };
        }
    }
}