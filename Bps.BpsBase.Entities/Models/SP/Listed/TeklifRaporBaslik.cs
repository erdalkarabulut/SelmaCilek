using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class TeklifRaporBaslik
    {
        [CsDisplayName("Şirket Id")]
        public int SIRKID { get; set; }

        [CsDisplayName("Belge No")]
        public string BELGEN { get; set; }

        [CsDisplayName("Belge Tarihi")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("Fiş Tipi")]
        public int SPFTNO { get; set; }

        [CsDisplayName("Cari Kodu")]
        public string CRKODU { get; set; }

        [CsDisplayName("Cari Ünvan")]
        public string CRUNV1 { get; set; }

        [CsDisplayName("Toplam Net Tutar")]
        public double? TOPKDT { get; set; }

        [CsDisplayName("Döviz Cinsi")]
        public string DVCNKD { get; set; }

        [CsDisplayName("Teklif Türü")]
        public string TKTRKD { get; set; }

        [CsDisplayName("Kaynak")]
        public string KAYNAK { get; set; }

        [CsDisplayName("Ürün Tipi")]
        public string SPUTKD { get; set; }

        [CsDisplayName("Yetkili")]
        public string YETKLI { get; set; }

        [CsDisplayName("Teklif Durumu")]
        public string TKDRKD { get; set; }

        [CsDisplayName("Açıklama")]
        public string GNACIK { get; set; }

        [CsDisplayName("Kaydeden")]
        public string KAYDEN { get; set; }

        [CsDisplayName("Kayıt Tarihi")]
        public DateTime? DTARIH { get; set; }
    }
}
