using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STVMIH : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("MALHSP")]
        public int MALHSP { get; set; }

        [CsDisplayName("KAYORT")]
        public decimal? KAYORT { get; set; }

        [CsDisplayName("STNFIY")]
        public decimal? STNFIY { get; set; }

        [CsDisplayName("DGMKTR")]
        public decimal? DGMKTR { get; set; }

        [CsDisplayName("DGSTDG")]
        public decimal? DGSTDG { get; set; }

        [Required]
        [CsDisplayName("MALIYL")]
        public int MALIYL { get; set; }

        [Required]
        [CsDisplayName("MALIAY")]
        public int MALIAY { get; set; }

        public STVMIH ShallowCopy()
        {
            return (STVMIH)this.MemberwiseClone();
        }

    }
}
