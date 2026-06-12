using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class PemenangLelang
    {
        public int IdPemenang { get; set; }
        public int IdLelang { get; set; }
        public int IdBid { get; set; }
        public DateTime TglDitetapkan { get; set; } = DateTime.Now;

        public PemenangLelang() { }

        public PemenangLelang(int idPemenang, int idLelang, int idBid, DateTime tglDitetapkan)
        {
            IdPemenang = idPemenang;
            IdLelang = idLelang;
            IdBid = idBid;
            TglDitetapkan = tglDitetapkan;
        }
    }
}
