using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SaRaporBaslikAyrinti
    {
        [CsDisplayName("Şirket Id")]
        public int SIRKID { get; set; }

        [CsDisplayName("Fiş Tipi")]
        public int SPFTNO { get; set; }

        [CsDisplayName("Cari Kodu")]
        public string CRKODU { get; set; }

        [CsDisplayName("Fiş Tipi")]
        public string TANIMI { get; set; }

        [CsDisplayName("Belge No")]
        public string BELGEN { get; set; }

        [CsDisplayName("Belge Tarihi")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("Toplam Brüt Tutar")]
        public double? TOPBRT { get; set; }

        [CsDisplayName("Toplam İskonto")]
        public double? TOPISK { get; set; }

        [CsDisplayName("Ara Toplam")]
        public double? TOPTUT { get; set; }

        [CsDisplayName("Toplam KDV")]
        public double? TOPKDV { get; set; }

        [CsDisplayName("Döviz Cinsi")]
        public string DVCNKD { get; set; }

        [CsDisplayName("Döviz Birim Fiyat")]
        public decimal DVBRFY { get; set; }

        [CsDisplayName("Toplam Net Tutar (Döviz)")]
        public double? TOPKDT { get; set; }

        [CsDisplayName("Toplam Net Tutar (TL)")]
        public double TLFIYT { get; set; }

        [CsDisplayName("İstenilen Termin Tarihi")]
        public DateTime? TERTAR { get; set; }

        [CsDisplayName("Tamamlandı")]
        public bool FLGKPN { get; set; }

        [CsDisplayName("Yetkili")]
        public string GNNAME { get; set; }
    }
}
