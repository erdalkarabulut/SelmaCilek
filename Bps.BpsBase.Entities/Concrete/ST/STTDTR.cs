using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STTDTR : BaseEntity
    {
        [Required]
        [CsDisplayName("TEDKOD")]
        [MaxLength(4)]
        public string TEDKOD { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("TEDTNM")]
        [MaxLength(40)]
        public string TEDTNM { get; set; }

        [Required]
        [CsDisplayName("YAPAYK")]
        public bool YAPAYK { get; set; }

        [Required]
        [CsDisplayName("FASONK")]
        public bool FASONK { get; set; }

        public STTDTR ShallowCopy()
        {
            return (STTDTR)this.MemberwiseClone();
        }

    }
}
