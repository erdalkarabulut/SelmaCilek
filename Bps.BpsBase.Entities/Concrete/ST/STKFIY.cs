using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STKFIY : BaseEntity
    {
        [Required]
        [CsDisplayName("STFYNO")]
        public int STFYNO { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("GFIYAT")]
        public decimal GFIYAT { get; set; }

        [CsDisplayName("GISKNT")]
        public decimal? GISKNT { get; set; }

        [Required]
        [CsDisplayName("DVCNKD")]
        [MaxLength(20)]
        public string DVCNKD { get; set; }

        [CsDisplayName("KDVFLG")]
        public bool? KDVFLG { get; set; }

        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [CsDisplayName("BASTAR")]
        public DateTime? BASTAR { get; set; }

        [CsDisplayName("BITTAR")]
        public DateTime? BITTAR { get; set; }

        public STKFIY ShallowCopy()
        {
            return (STKFIY)this.MemberwiseClone();
        }

    }
}
