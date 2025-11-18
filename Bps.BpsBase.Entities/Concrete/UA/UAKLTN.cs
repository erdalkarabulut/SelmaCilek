using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UA
{
    public class UAKLTN : BaseEntity
    {
        [CsDisplayName("KLMTIP")]
        [MaxLength(1)]
        public string KLMTIP { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [CsDisplayName("STKKLM")]
        public bool? STKKLM { get; set; }

        [CsDisplayName("MTNKLM")]
        public bool? MTNKLM { get; set; }

        [CsDisplayName("FTNKLM")]
        public bool? FTNKLM { get; set; }

        public UAKLTN ShallowCopy()
        {
            return (UAKLTN)this.MemberwiseClone();
        }

    }
}
