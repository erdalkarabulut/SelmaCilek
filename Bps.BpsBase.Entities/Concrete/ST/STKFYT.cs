using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STKFYT : BaseEntity
    {
        [Required]
        [CsDisplayName("STFYNO")]
        [MaxLength(50)]
        public string STFYNO { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("DVCNKD")]
        [MaxLength(20)]
        public string DVCNKD { get; set; }

        [CsDisplayName("KDVFLG")]
        public bool? KDVFLG { get; set; }

        [CsDisplayName("GISKNT1")]
        public decimal? GISKNT1 { get; set; }

        [CsDisplayName("GISKNT2")]
        public decimal? GISKNT2 { get; set; }

        [CsDisplayName("GISKNT3")]
        public decimal? GISKNT3 { get; set; }

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

        public STKFYT ShallowCopy()
        {
            return (STKFYT)this.MemberwiseClone();
        }

    }
}
