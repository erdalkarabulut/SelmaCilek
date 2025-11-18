using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UA
{
    public class UAKLTP : BaseEntity
    {
        [CsDisplayName("KLNKOD")]
        [MaxLength(1)]
        public string KLNKOD { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [CsDisplayName("URTILS")]
        public bool? URTILS { get; set; }

        [CsDisplayName("TSRILS")]
        public bool? TSRILS { get; set; }

        [CsDisplayName("YDKPRC")]
        public bool? YDKPRC { get; set; }

        public UAKLTP ShallowCopy()
        {
            return (UAKLTP)this.MemberwiseClone();
        }

    }
}
