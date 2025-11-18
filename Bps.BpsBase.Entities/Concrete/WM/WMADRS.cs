using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMADRS : BaseEntity
    {
        [CsDisplayName("WMASNO")]
        [MaxLength(20)]
        public string WMASNO { get; set; }

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

        [CsDisplayName("DGSTBL")]
        public bool? DGSTBL { get; set; }

        [CsDisplayName("DCSTBL")]
        public bool? DCSTBL { get; set; }

        [CsDisplayName("STARIH")]
        public DateTime? STARIH { get; set; }

        [CsDisplayName("SDPTAR")]
        public DateTime? SDPTAR { get; set; }

        [CsDisplayName("SDETAR")]
        public DateTime? SDETAR { get; set; }

        [CsDisplayName("STHRTP")]
        public int? STHRTP { get; set; }

        [CsDisplayName("STFTNO")]
        public int? STFTNO { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [CsDisplayName("BELTRH")]
        public DateTime? BELTRH { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

        [CsDisplayName("DPBRNO")]
        [MaxLength(20)]
        public string DPBRNO { get; set; }

        [CsDisplayName("TPLSTK")]
        public decimal? TPLSTK { get; set; }

        [CsDisplayName("USESTK")]
        public decimal? USESTK { get; set; }

        [CsDisplayName("DPLSTK")]
        public decimal? DPLSTK { get; set; }

        [CsDisplayName("DPCSTK")]
        public decimal? DPCSTK { get; set; }

        [CsDisplayName("PARTIN")]
        [MaxLength(50)]
        public string PARTIN { get; set; }

        [CsDisplayName("PARTIT")]
        public bool? PARTIT { get; set; }

        public WMADRS ShallowCopy()
        {
            return (WMADRS)this.MemberwiseClone();
        }

    }
}
