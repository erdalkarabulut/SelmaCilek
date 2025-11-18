using System;

namespace Bps.Bomex.Models
{
    public class Revizyon
    {
        public int Id { get; set; }

        public int RevNo { get; set; }

        public string RevAciklama { get; set; }

        public DateTime RevTarih { get; set; }

        public string RevIlgili { get; set; }

        public bool RevAktif { get; set; }
    }
}