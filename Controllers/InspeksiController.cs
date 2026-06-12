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
                MessageBox.Show("Sesi login habis", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsInspektor)
            {
                MessageBox.Show("Akses ditolak.", "Bukan Inspektor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nilai < 0 || nilai > 100)
            {
                MessageBox.Show("Nilai QC tidak valid! Harus berada di antara angka 0 sampai 100.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string gradeOtomatis = "D";
            if (nilai >= 85) gradeOtomatis = "A";
            else if (nilai >= 70) gradeOtomatis = "B";
            else if (nilai >= 50) gradeOtomatis = "C";

            try
            {
                int idInspektorAktif = UserContext.CurrentUser!.IdUser;

               bool sukses = InspeksiContext.SimpanHasilInspeksi(
                    idProduk,
                    idInspektorAktif,
                    nilai,
                    gradeOtomatis, 
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
