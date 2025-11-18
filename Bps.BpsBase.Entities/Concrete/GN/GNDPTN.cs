using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNDPTN : BaseEntity
    {
        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("DPKODU")]
        [MaxLength(4)]
        public string DPKODU { get; set; }

        [Required]
        [CsDisplayName("DPTANM")]
        [MaxLength(40)]
        public string DPTANM { get; set; }

        [CsDisplayName("MIPGOS")]
        public bool? MIPGOS { get; set; }

        public GNDPTN ShallowCopy()
        {
            return (GNDPTN)this.MemberwiseClone();
        }

    }
}
