using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNDPTP : BaseEntity
    {
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

        [CsDisplayName("DPTIPT")]
        [MaxLength(50)]
        public string DPTIPT { get; set; }

        [CsDisplayName("DGSTKD")]
        [MaxLength(20)]
        public string DGSTKD { get; set; }

        [CsDisplayName("DGSTON")]
        public bool? DGSTON { get; set; }

        [CsDisplayName("DGSTEK")]
        public bool? DGSTEK { get; set; }

        [CsDisplayName("DGSTKR")]
        public bool? DGSTKR { get; set; }

        [CsDisplayName("DGSTBL")]
        public bool? DGSTBL { get; set; }

        [CsDisplayName("DGSTBR")]
        public bool? DGSTBR { get; set; }

        [CsDisplayName("DCSTKD")]
        [MaxLength(20)]
        public string DCSTKD { get; set; }

        [CsDisplayName("DCSTON")]
        public bool? DCSTON { get; set; }

        [CsDisplayName("DCSTTM")]
        public bool? DCSTTM { get; set; }

        [CsDisplayName("DCSTBL")]
        public bool? DCSTBL { get; set; }

        [CsDisplayName("DCSTAY")]
        public bool? DCSTAY { get; set; }

        public GNDPTP ShallowCopy()
        {
            return (GNDPTP)this.MemberwiseClone();
        }

    }
}
