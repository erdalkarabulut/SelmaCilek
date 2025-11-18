using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SN
{
    public class SNKRTY : BaseEntity
    {
        [CsDisplayName("OBJKEY")]
        [MaxLength(50)]
        public string OBJKEY { get; set; }

        [Required]
        [CsDisplayName("SNFKOD")]
        [MaxLength(50)]
        public string SNFKOD { get; set; }

        [Required]
        [CsDisplayName("KRKTNO")]
        [MaxLength(50)]
        public string KRKTNO { get; set; }

        [Required]
        [CsDisplayName("GVALUE")]
        public string GVALUE { get; set; }

        public SNKRTY ShallowCopy()
        {
            return (SNKRTY)this.MemberwiseClone();
        }

    }
}
