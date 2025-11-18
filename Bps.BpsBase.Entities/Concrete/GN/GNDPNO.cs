using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNDPNO : BaseEntity
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
        [CsDisplayName("DEPOKD")]
        [MaxLength(20)]
        public string DEPOKD { get; set; }

        public GNDPNO ShallowCopy()
        {
            return (GNDPNO)this.MemberwiseClone();
        }

    }
}
