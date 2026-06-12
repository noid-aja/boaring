using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Models.Roles
{
    public class AdminRole : RoleUser
    {
        public AdminRole(User user) : base(user) { }

        public override string NamaRole => "admin";

        public override string JudulDashboard => "Dashboard Admin";

        public override List<string> GetMenuAkses()
        {
            return new List<string>
            {
                "Kelola User",
                "Kelola Role",
                "Kelola Jenis Kopi",
                "Lihat Semua Produk",
                "Lihat Laporan"
            };
        }
    }
}