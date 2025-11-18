using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPHRPL : BaseEntity
    {
        [Required]
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [Required]
        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [Required]
        [CsDisplayName("SATIRN")]
        public int SATIRN { get; set; }

        [Required]
        [CsDisplayName("PKKODU")]
        [MaxLength(25)]
        public string PKKODU { get; set; }

        [Required]
        [CsDisplayName("PKTNAM")]
        [MaxLength(100)]
        public string PKTNAM { get; set; }

        [Required]
        [CsDisplayName("PLNMKT")]
        public decimal PLNMKT { get; set; }

        [CsDisplayName("ACIKLM")]
        [MaxLength(255)]
        public string ACIKLM { get; set; }

        public SPHRPL ShallowCopy()
        {
            return (SPHRPL)this.MemberwiseClone();
        }

    }
}
