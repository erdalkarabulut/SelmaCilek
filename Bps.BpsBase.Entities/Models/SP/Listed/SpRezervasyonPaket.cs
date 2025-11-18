using System;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SpRezervasyonPaket
    {
        [CsDisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }
        
        [CsDisplayName("CKDEPO")]
        public string CKDEPO { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal? GNMKTR { get; set; }

        [CsDisplayName("KLNMKTR")]
        public decimal? KLNMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("SRBLNO")]
        public string SRBLNO { get; set; }

        [CsDisplayName("SRTARH")]
        public DateTime? SRTARH { get; set; }

        [CsDisplayName("PKKODU")]
        public string PKKODU { get; set; }

        [CsDisplayName("PKTNAM")]
        public string PKTNAM { get; set; }

        [CsDisplayName("SPMKTR")]
        public decimal? SPMKTR { get; set; }

        [CsDisplayName("RZMKTR")]
        public decimal? RZMKTR { get; set; }

        [CsDisplayName("KLMKTR")]
        public decimal? KLMKTR { get; set; }
    }
}
