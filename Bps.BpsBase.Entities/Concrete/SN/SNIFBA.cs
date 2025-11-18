using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SN
{
    public class SNIFBA : BaseEntity
    {
        [Required]
        [CsDisplayName("SNTRKD")]
        [MaxLength(20)]
        public string SNTRKD { get; set; }

        [Required]
        [CsDisplayName("SINFKD")]
        [MaxLength(20)]
        public string SINFKD { get; set; }

        [Required]
        [CsDisplayName("SNFKOD")]
        [MaxLength(50)]
        public string SNFKOD { get; set; }

        [CsDisplayName("SNFTAN")]
        [MaxLength(50)]
        public string SNFTAN { get; set; }

        [Required]
        [CsDisplayName("GECBAS")]
        public DateTime GECBAS { get; set; }

        [Required]
        [CsDisplayName("GECBIT")]
        public DateTime GECBIT { get; set; }

        public SNIFBA ShallowCopy()
        {
            return (SNIFBA)this.MemberwiseClone();
        }

    }
}
