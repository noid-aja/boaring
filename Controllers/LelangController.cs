using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class LelangController
    {
        public bool ProsesBukaLelang(int idProduk, string? lokasiLelang)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu pls", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsAdmin())
            {
                MessageBox.Show("Akses ditolak!.", "Bukan Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                return LelangContext.EksekusiBukaLelang(idProduk, lokasiLelang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
