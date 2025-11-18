using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IK.Listed
{
    public class IkpersSicilAdPozModel
    {
        [CsDisplayName("Id")]
        public int Id { get; set; }
        
        [CsDisplayName("SICILN")]
        public string SICILN { get; set; }

        [CsDisplayName("GNNAME")]
        public string GNNAME { get; set; }

        [CsDisplayName("POZSYN")]
        public string POZSYN { get; set; }

        [CsDisplayName("ISYKOD")]
        public string ISYKOD { get; set; }

        [CsDisplayName("ISYTNM")]
        public string ISYTNM { get; set; }

        [CsDisplayName("CINSKD")]
        public string CINSKD { get; set; }
    }
}
