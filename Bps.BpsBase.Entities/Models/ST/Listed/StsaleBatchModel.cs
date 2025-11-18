using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StsaleBatchModel
    {
        [CsDisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("SLORKD")]
        public string SLORKD { get; set; }

        [CsDisplayName("SLKNKD")]
        public string SLKNKD { get; set; }

        [CsDisplayName("ASGMIK")]
        public decimal ASGMIK { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("MALGK1")]
        public string MALGK1 { get; set; }

        [CsDisplayName("MALGK2")]
        public string MALGK2 { get; set; }

        [CsDisplayName("MALGK3")]
        public string MALGK3 { get; set; }

        public int BatchType { get; set; }
    }
}