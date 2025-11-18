using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SiparisKosulModel
    {
        [CsDisplayName("Id")]
        public int Id { get; set; }

        [CsDisplayName("BELGEN")]
        public string BELGEN { get; set; }

        [CsDisplayName("KOSULL")]
        public string KOSULL { get; set; }
        [CsDisplayName("LANGKD")]
        public string LANGKD { get; set; }
    }
}