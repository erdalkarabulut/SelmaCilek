using Bps.Core.AttributeHelpers;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StnameBatchModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("LANGKD")]
        public string LANGKD { get; set; }

        public int BatchType { get; set; }
    }
}