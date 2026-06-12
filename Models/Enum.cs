using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Enum
    {
        public enum StatusProduk
        {
            PendingInspeksi, 
            LolosQc,
            DitolakQc,
            DijadwalkanLelang,
            Berlangsung,
            Terjual,
            Dibatalkan
        }

        public enum StatusLelang
        {
            Dijadwalkan,    
            Berlangsung,
            Selesai,
            Dibatalkan
        }

        public enum StatusBayar
        {
            BelumBayar,      
            Lunas,
            Dibatalkan
        }
    }
}
