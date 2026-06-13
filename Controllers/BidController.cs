using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class BidController
    {
        public bool KirimBid(int idLelang, decimal nominalTawaran)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu pls", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsPembeli())
            {
                MessageBox.Show("Akun lu bukan Pembeli", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int idPembeliAktif = UserContext.CurrentUser!.IdUser;

                return BidContext.EksekusiBid(idLelang, idPembeliAktif, nominalTawaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
