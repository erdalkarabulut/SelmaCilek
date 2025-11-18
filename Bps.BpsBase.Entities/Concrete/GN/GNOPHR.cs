using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNOPHR : BaseEntity
    {
        [Required]
        [CsDisplayName("TIPKOD")]
        [MaxLength(20)]
        public string TIPKOD { get; set; }

        [Required]
        [CsDisplayName("HARKOD")]
        [MaxLength(20)]
        public string HARKOD { get; set; }

        [Required]
        [CsDisplayName("PARENT")]
        public int PARENT { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [CsDisplayName("GNICON")]
        [MaxLength(50)]
        public string GNICON { get; set; }

        [CsDisplayName("EXTRA1")]
        [MaxLength(250)]
        public string EXTRA1 { get; set; }

        public GNOPHR ShallowCopy()
        {
            return (GNOPHR)this.MemberwiseClone();
        }

    }
}
