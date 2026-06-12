using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    internal class InspeksiController
    {
        public bool KirimHasilQc(int idProduk, int nilai, decimal hargaRekomendasi, string? catatan, bool isLolos)
        {
            if (!UserContext.IsLoggedIn)
            {
                MessageBox.Show("Sesi login habis, Co!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsInspektor)
            {
                MessageBox.Show("Akses ditolak! Cuma akun Inspektor yang bisa ngasih penilaian QC.", "Bukan Inspektor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int idInspektorAktif = UserContext.CurrentUser!.IdUser;

                bool sukses = InspeksiContext.SimpanHasilInspeksi(
                    idProduk,
                    idInspektorAktif,
                    nilai,
                    hargaRekomendasi,
                    catatan,
                    isLolos
                );

                return sukses;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
