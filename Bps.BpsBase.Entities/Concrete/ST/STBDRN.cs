using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STBDRN : BaseEntity
    {
        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("VRYTNM")]
        [MaxLength(150)]
        public string VRYTNM { get; set; }

        [CsDisplayName("RENKKD")]
        [MaxLength(20)]
        public string RENKKD { get; set; }

        [CsDisplayName("BEDNKD")]
        [MaxLength(20)]
        public string BEDNKD { get; set; }

        [CsDisplayName("DROPKD")]
        [MaxLength(20)]
        public string DROPKD { get; set; }

        [CsDisplayName("EANTKD")]
        [MaxLength(20)]
        public string EANTKD { get; set; }

        [CsDisplayName("EANKOD")]
        [MaxLength(40)]
        public string EANKOD { get; set; }

        [CsDisplayName("STOZEL")]
        [MaxLength(20)]
        public string STOZEL { get; set; }

        public STBDRN ShallowCopy()
        {
            return (STBDRN)this.MemberwiseClone();
        }

    }
}
