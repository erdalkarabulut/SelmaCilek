using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STDPYN : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("DEPOKD")]
        [MaxLength(20)]
        public string DEPOKD { get; set; }

        [Required]
        [CsDisplayName("DPTIPI")]
        [MaxLength(4)]
        public string DPTIPI { get; set; }

        [CsDisplayName("DPADRS")]
        [MaxLength(50)]
        public string DPADRS { get; set; }

        [CsDisplayName("DPAMAX")]
        public decimal? DPAMAX { get; set; }

        [CsDisplayName("DPAMIN")]
        public decimal? DPAMIN { get; set; }

        [CsDisplayName("DPAIKM")]
        public decimal? DPAIKM { get; set; }

        [CsDisplayName("DPAKON")]
        public decimal? DPAKON { get; set; }

        public STDPYN ShallowCopy()
        {
            return (STDPYN)this.MemberwiseClone();
        }

    }
}
