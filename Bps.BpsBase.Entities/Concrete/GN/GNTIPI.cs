using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNTIPI : BaseEntity
    {
        [Required]
        [CsDisplayName("TIPKOD")]
        [MaxLength(20)]
        public string TIPKOD { get; set; }

        [Required]
        [CsDisplayName("TIPADI")]
        [MaxLength(50)]
        public string TIPADI { get; set; }

        [Required]
        [CsDisplayName("TEKNAD")]
        [MaxLength(6)]
        public string TEKNAD { get; set; }

        [CsDisplayName("UTPKOD")]
        [MaxLength(20)]
        public string UTPKOD { get; set; }

        [Required]
        [CsDisplayName("HRKTBL")]
        [MaxLength(6)]
        public string HRKTBL { get; set; }

        public GNTIPI ShallowCopy()
        {
            return (GNTIPI)this.MemberwiseClone();
        }

    }
}
