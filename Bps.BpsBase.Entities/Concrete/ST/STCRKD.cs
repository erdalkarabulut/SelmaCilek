using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STCRKD : BaseEntity
    {
        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [CsDisplayName("RENKKD")]
        [MaxLength(20)]
        public string RENKKD { get; set; }

        [CsDisplayName("BEDNKD")]
        [MaxLength(20)]
        public string BEDNKD { get; set; }

        [CsDisplayName("DROPKD")]
        [MaxLength(20)]
        public string DROPKD { get; set; }

        [CsDisplayName("CRSTKO")]
        [MaxLength(25)]
        public string CRSTKO { get; set; }

        [CsDisplayName("CRSTNM")]
        [MaxLength(40)]
        public string CRSTNM { get; set; }

        [CsDisplayName("CRVRKO")]
        [MaxLength(25)]
        public string CRVRKO { get; set; }

        [CsDisplayName("EANTKD")]
        [MaxLength(20)]
        public string EANTKD { get; set; }

        [CsDisplayName("EANKOD")]
        [MaxLength(40)]
        public string EANKOD { get; set; }

        public STCRKD ShallowCopy()
        {
            return (STCRKD)this.MemberwiseClone();
        }

    }
}
