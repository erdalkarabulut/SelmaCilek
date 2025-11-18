using System;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SiparisPaketIhtiyac
    {
        [CsDisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [CsDisplayName("SPHRTP")]
        public int SPHRTP { get; set; }

        [CsDisplayName("SPFTNO")]
        public int SPFTNO { get; set; }

        [CsDisplayName("TANIMI")]
        public string TANIMI { get; set; }

        [CsDisplayName("BELGEN")]
        public string BELGEN { get; set; }

        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("CRKODU")]
        public string CRKODU { get; set; }

        [CsDisplayName("CRUNV1")]
        public string CRUNV1 { get; set; }

        [CsDisplayName("BSACIK")]
        public string BSACIK { get; set; }

        [CsDisplayName("TERTAR")]
        public DateTime? TERTAR { get; set; }

        [CsDisplayName("FLGKPN")]
        public bool FLGKPN { get; set; }

        [CsDisplayName("MDKODU")]
        public string MDKODU { get; set; }

        [CsDisplayName("MDLNAM")]
        public string MDLNAM { get; set; }

        [CsDisplayName("CKDEPO")]
        public string CKDEPO { get; set; }

        [CsDisplayName("DPTANM")]
        public string DPTANM { get; set; }

        [CsDisplayName("HRACIK")]
        public string HRACIK { get; set; }

        [CsDisplayName("GNREZV")]
        public string GNREZV { get; set; }

        [CsDisplayName("URAKOD")]
        public string URAKOD { get; set; }

        [CsDisplayName("SATIRN")]
        public int SATIRN { get; set; }

        [CsDisplayName("PKKODU")]
        public string PKKODU { get; set; }

        [CsDisplayName("PKTNAM")]
        public string PKTNAM { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("SPMKTR")]
        public decimal SPMKTR { get; set; }

        [CsDisplayName("KLNMKTR")]
        public decimal KLNMKTR { get; set; }

        [CsDisplayName("RZMKTR")]
        public decimal? RZMKTR { get; set; }

        [CsDisplayName("RZKLMK")]
        public decimal? RZKLMK { get; set; }

        [CsDisplayName("EKSIKK")]
        public decimal EKSIKK { get; set; }

        [CsDisplayName("PLNMKT")]
        public decimal PLNMKT { get; set; }

        [CsDisplayName("IHTIYC")]
        public decimal IHTIYC { get; set; }

        [CsDisplayName("USESTK")]
        public decimal USESTK { get; set; }

        public SiparisPaketIhtiyac ShallowCopy()
        {
            return (SiparisPaketIhtiyac)this.MemberwiseClone();
        }
    }
}
