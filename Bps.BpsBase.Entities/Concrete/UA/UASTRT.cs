using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UA
{
    public class UASTRT : BaseEntity
    {
        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [Required]
        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("PARENT")]
        public int PARENT { get; set; }

        [Required]
        [CsDisplayName("CHILDD")]
        public int CHILDD { get; set; }

        [Required]
        [CsDisplayName("SEVIYE")]
        public int SEVIYE { get; set; }

        [CsDisplayName("SIRANO")]
        public int? SIRANO { get; set; }

        [Required]
        [CsDisplayName("ISOPKD")]
        [MaxLength(20)]
        public string ISOPKD { get; set; }

        public UASTRT ShallowCopy()
        {
            return (UASTRT)this.MemberwiseClone();
        }

    }
}
