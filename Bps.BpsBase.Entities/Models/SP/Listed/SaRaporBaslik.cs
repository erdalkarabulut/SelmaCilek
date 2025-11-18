using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SaRaporBaslik
    {
        [CsDisplayName("Şirket Id")]
        public int SIRKID { get; set; }
        
        [CsDisplayName("Cari Kodu")]
        public string CRKODU { get; set; }

        [CsDisplayName("Cari Ünvan")]
        public string CRUNV1 { get; set; }

        [CsDisplayName("Toplam Net Tutar")]
        public double? TOPKDT { get; set; }

        [CsDisplayName("Toplam TL Tutar")]
        public double? TLFIYT { get; set; }

        [CsDisplayName("Döviz Cinsi")]
        public string DVCNKD { get; set; }

        public SaRaporBaslik ShallowCopy()
        {
            return (SaRaporBaslik)this.MemberwiseClone();
        }
    }
}
