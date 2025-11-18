using System;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciList
    {
        [DisplayName("Şirket Id")]
        public int? SIRKID { get; set; }
        [DisplayName("AnaUrunKodu")]
        public string AnaUrunKodu { get; set; }
        [DisplayName("AnaUrunVaryanti")]
        public string AnaUrunVaryanti { get; set; }
        [DisplayName("UrunAgaciKodu")]
        public string UrunAgaciKodu { get; set; }
        [DisplayName("RevizyonNo")]
        public string RevizyonNo { get; set; }
        [DisplayName("Seviye")]
        public int Seviye { get; set; }

        [DisplayName("MalzemeKodu")]
        public string MalzemeKodu { get; set; }
        [DisplayName("MalzemeVaryanti")]
        public string MalzemeVaryanti { get; set; }

        [DisplayName("BilesenMiktari")]
        public Decimal BilesenMiktari { get; set; }
        [DisplayName("KümülatifMiktar")]
        public Decimal KümülatifMiktar { get; set; }


        [DisplayName("Birim")]
        public string Birim { get; set; }




    }
}
