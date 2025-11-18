using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SiparisStokModel
    {
        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("Parti Kontrol")]
        public bool PARTIT { get; set; }

        [CsDisplayName("Parti No")]
        public string PARTIN { get; set; }

        [CsDisplayName("GRDEPO")]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        public string CKDEPO { get; set; }

        [CsDisplayName("GRMKTR")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("DPADRS")]
        public string DPADRS { get; set; }

        [CsDisplayName("SRBLNO")]
        public string SRBLNO { get; set; }
    }
}
