using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPODTB : BaseEntity
    {
        [Required]
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("ODMSKL")]
        [MaxLength(100)]
        public string ODMSKL { get; set; }

        [Required]
        [CsDisplayName("ODMTRH")]
        public DateTime ODMTRH { get; set; }

        [CsDisplayName("ODMACK")]
        [MaxLength(200)]
        public string ODMACK { get; set; }

        [Required]
        [CsDisplayName("ODMTTR")]
        public decimal ODMTTR { get; set; }

        [Required]
        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

        [Required]
        [CsDisplayName("ODMORN")]
        public decimal ODMORN { get; set; }

        public SPODTB ShallowCopy()
        {
            return (SPODTB)this.MemberwiseClone();
        }

    }
}
