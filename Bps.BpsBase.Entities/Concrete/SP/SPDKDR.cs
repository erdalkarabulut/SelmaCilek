using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPDKDR : BaseEntity
    {
        [CsDisplayName("DURKOD")]
        [MaxLength(20)]
        public string DURKOD { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("SPBLKJ")]
        public bool SPBLKJ { get; set; }

        [Required]
        [CsDisplayName("TSBLKJ")]
        public bool TSBLKJ { get; set; }

        public SPDKDR ShallowCopy()
        {
            return (SPDKDR)this.MemberwiseClone();
        }

    }
}
