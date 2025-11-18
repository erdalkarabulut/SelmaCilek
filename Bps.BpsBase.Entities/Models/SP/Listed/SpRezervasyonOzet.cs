using System;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SpRezervasyonOzet
    {
        [CsDisplayName("BELGEN")]
        public string BELGEN { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("GNACIK")]
        public string GNACIK { get; set; }

        [CsDisplayName("SPMKTR")]
        public decimal? SPMKTR { get; set; }

        [CsDisplayName("RZMKTR")]
        public decimal? RZMKTR { get; set; }

        [CsDisplayName("MXRZMK")]
        public decimal? MXRZMK { get; set; }

        [CsDisplayName("USESTK")]
        public decimal? USESTK { get; set; }

        [CsDisplayName("KLMKTR")]
        public decimal? KLMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("CKDEPO")]
        public string CKDEPO { get; set; }

        [CsDisplayName("SPREZV")]
        public List<SPREZV> SPREZV { get; set; }
    }
}
