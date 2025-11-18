using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNBNHR : BaseEntity
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
        [MaxLength(100)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [CsDisplayName("GNICON")]
        [MaxLength(50)]
        public string GNICON { get; set; }

        [CsDisplayName("EXTRA1")]
        [MaxLength(250)]
        public string EXTRA1 { get; set; }

        public GNBNHR ShallowCopy()
        {
            return (GNBNHR)this.MemberwiseClone();
        }

    }
}
