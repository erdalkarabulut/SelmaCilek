using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StmhsbBatchModel
    {
        [CsDisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

        [CsDisplayName("HSPKOD")]
        public string HSPKOD { get; set; }

        [CsDisplayName("DPKODU")]
        public string DPKODU { get; set; }

        public int BatchType { get; set; }
    }
}