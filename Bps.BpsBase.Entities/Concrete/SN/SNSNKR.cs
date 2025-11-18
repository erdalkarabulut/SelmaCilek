using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SN
{
    public class SNSNKR : BaseEntity
    {
        [Required]
        [CsDisplayName("SNFKOD")]
        [MaxLength(50)]
        public string SNFKOD { get; set; }

        [Required]
        [CsDisplayName("KRKTNO")]
        [MaxLength(50)]
        public string KRKTNO { get; set; }

        [Required]
        [CsDisplayName("SATIRN")]
        public int SATIRN { get; set; }

        public SNSNKR ShallowCopy()
        {
            return (SNSNKR)this.MemberwiseClone();
        }

    }
}
