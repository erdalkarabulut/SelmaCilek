using System;

namespace Bps.BpsBase.Entities.Models.SP.Single
{
    public class SaSiparisEpostaModel
    {
        public int SiraNo { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public decimal? Miktar { get; set; }
        public string Birim { get; set; }
    }
}