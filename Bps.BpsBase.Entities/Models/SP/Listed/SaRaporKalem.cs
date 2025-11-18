using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SaRaporKalem
    {
        [CsDisplayName("Şirket Id")]
        public int SIRKID { get; set; }

        [CsDisplayName("Belge No")]
        public string BELGEN { get; set; }

        [CsDisplayName("Satır No")]
        public int SATIRN { get; set; }

        [CsDisplayName("Stok Kodu")]
        public string STKODU { get; set; }

        [CsDisplayName("Stok Adı")]
        public string STKNAM { get; set; }

        [CsDisplayName("Parti No")]
        public string PARTIN { get; set; }

        [CsDisplayName("Giriş Miktarı")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("Giriş Ölçü Birimi")]
        public string GROLBR { get; set; }

        [CsDisplayName("Giriş Depo Kodu")]
        public string GRDEPO { get; set; }

        [CsDisplayName("Giriş Depo")]
        public string DPTANM { get; set; }

        [CsDisplayName("Fiyat")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("Tutar")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("Döviz Cinsi")]
        public string DVCNKD { get; set; }

        [CsDisplayName("Tutar (TL)")]
        public decimal? DVZFYT { get; set; }

        [CsDisplayName("İskonto")]
        public decimal? GISKNT { get; set; }

        [CsDisplayName("KDV")]
        public decimal? VRGORN { get; set; }

        [CsDisplayName("İstenilen Termin Tarihi")]
        public DateTime? TERTAR { get; set; }

        [CsDisplayName("Tamamlandı")]
        public bool? FLGKPN { get; set; }
    }
}
