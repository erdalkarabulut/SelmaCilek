using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SN
{
    public class SNKRTR : BaseEntity
    {
        [Required]
        [CsDisplayName("KRKTNO")]
        [MaxLength(50)]
        public string KRKTNO { get; set; }

        [Required]
        [CsDisplayName("KRKTTN")]
        [MaxLength(100)]
        public string KRKTTN { get; set; }

        [Required]
        [CsDisplayName("DTTPKD")]
        [MaxLength(20)]
        public string DTTPKD { get; set; }

        [Required]
        [CsDisplayName("KRKTSY")]
        public int KRKTSY { get; set; }

        [Required]
        [CsDisplayName("ONDASY")]
        public int ONDASY { get; set; }

        [CsDisplayName("FORMAT")]
        [MaxLength(20)]
        public string FORMAT { get; set; }

        public SNKRTR ShallowCopy()
        {
            return (SNKRTR)this.MemberwiseClone();
        }

    }
}
