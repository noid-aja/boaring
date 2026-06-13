using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Models.Roles
{
    public class PembeliRole : RoleUser
    {
        public PembeliRole(User user) : base(user) { }

        public override string NamaRole => "pembeli";

        public override string JudulDashboard => "Dashboard Pembeli";

        public override List<string> GetMenuAkses()
        {
            return new List<string>
            {
                "Lihat Lelang",
                "Ikut Bid",
                "Lihat Riwayat Bid",
                "Lihat Transaksi"
            };
        }
    }
}