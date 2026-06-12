using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class ProdukKopiController
    {
        public bool KirimPengajuanProduk(string namaProduk, int idJenis, decimal beratKg, decimal hargaPengajuan, string? deskripsi)
        {
            if (!UserContext.IsLoggedIn)
            {
                MessageBox.Show("Login dulu pls.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsPetani)
            {
                MessageBox.Show("Bukan petani.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int idPetaniAktif = UserContext.CurrentUser!.IdUser;

                bool isSukses = ProdukKopiContext.TambahProduk(
                    idPetaniAktif,
                    namaProduk,
                    idJenis,
                    beratKg,
                    hargaPengajuan,
                    deskripsi
                );

                return isSukses;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
