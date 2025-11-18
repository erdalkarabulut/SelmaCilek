using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNMESJ : BaseEntity
    {
        [Required]
        [CsDisplayName("LANGKD")]
        [MaxLength(20)]
        public string LANGKD { get; set; }

        [Required]
        [CsDisplayName("MESJKD")]
        [MaxLength(20)]
        public string MESJKD { get; set; }

        [Required]
        [CsDisplayName("MESJNO")]
        [MaxLength(4)]
        public string MESJNO { get; set; }

        [Required]
        [CsDisplayName("MSTEXT")]
        public string MSTEXT { get; set; }

        public GNMESJ ShallowCopy()
        {
            return (GNMESJ)this.MemberwiseClone();
        }

    }
}
