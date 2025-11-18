using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StdepoBatchModel
    {
        [CsDisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("URYRKD")]
        public string URYRKD { get; set; }

        [CsDisplayName("DPKODU")]
        public string DPKODU { get; set; }

        [CsDisplayName("ENBLKJ")]
        public bool ENBLKJ { get; set; }

        [CsDisplayName("USESTK")]
        public decimal USESTK { get; set; }

        [CsDisplayName("BLKSTK")]
        public decimal BLKSTK { get; set; }

        [CsDisplayName("MIPGOS")]
        public bool MIPGOS { get; set; }

        [CsDisplayName("TEDKOD")]
        public string TEDKOD { get; set; }

        [CsDisplayName("YNSPSV")]
        public decimal YNSPSV { get; set; }

        [CsDisplayName("EMNSTK")]
        public decimal EMNSTK { get; set; }

        [CsDisplayName("DPADRS")]
        public string DPADRS { get; set; }

        public int BatchType { get; set; }
    }
}