using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    internal class TransaksiController
    {
        public void JalankanOtomatisasiPenutupan()
        {
            TransaksiContext.CekDanTutupLelangExpired();
        }

        public bool PembeliBayarTagihan(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn || !UserContext.IsPembeli)
            {
                MessageBox.Show("Hanya akun Pembeli yang bisa membayar!");
                return false;
            }
            return TransaksiContext.AdminKonfirmasiLunas(idTransaksi);
        }

        public bool GagalBayarHitAndRun(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn || !UserContext.IsAdmin)
            {
                MessageBox.Show("Hanya Admin", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool sukses = TransaksiContext.AdminKonfirmasiGagalBayar(idTransaksi);
            if (sukses)
            {
                MessageBox.Show("Transaksi dibatalkan! Kopi milik petani otomatis dikembalikan ke status 'Lolos QC' agar bisa dilelang ulang.");
            }
            return sukses;
        }
    }
}
