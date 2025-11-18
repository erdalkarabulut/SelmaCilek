using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UA
{
    public class UASTBG : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [CsDisplayName("KLNKOD")]
        [MaxLength(1)]
        public string KLNKOD { get; set; }

        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [CsDisplayName("ALTERN")]
        public int? ALTERN { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        public UASTBG ShallowCopy()
        {
            return (UASTBG)this.MemberwiseClone();
        }

    }
}
