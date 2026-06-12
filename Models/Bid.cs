using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Bid
    {
        public int IdBid { get; set; }
        public int IdLelang { get; set; }
        public int IdPembeli { get; set; }
        public decimal Nominal { get; set; }
        public DateTime TglBid { get; set; } = DateTime.Now;

        public Bid() { }

        public Bid(int idBid, int idLelang, int idPembeli, decimal nominal, DateTime tglBid)
        {
            IdBid = idBid;
            IdLelang = idLelang;
            IdPembeli = idPembeli;
            Nominal = nominal;
            TglBid = tglBid;
        }
    }
}
