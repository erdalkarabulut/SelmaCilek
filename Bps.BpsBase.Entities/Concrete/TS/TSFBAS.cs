using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.TS
{
    public class TSFBAS : BaseEntity
    {
        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [Required]
        [CsDisplayName("TSHRTP")]
        public int TSHRTP { get; set; }

        [Required]
        [CsDisplayName("TSFTNO")]
        public int TSFTNO { get; set; }

        [CsDisplayName("EVRSER")]
        [MaxLength(6)]
        public string EVRSER { get; set; }

        [CsDisplayName("EVRSRN")]
        public int? EVRSRN { get; set; }

        [CsDisplayName("EVRAKN")]
        [MaxLength(50)]
        public string EVRAKN { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("MALTES")]
        [MaxLength(25)]
        public string MALTES { get; set; }

        [CsDisplayName("GRDEPO")]
        [MaxLength(4)]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [CsDisplayName("TERTAR")]
        public DateTime? TERTAR { get; set; }

        [Required]
        [CsDisplayName("STFYNO")]
        [MaxLength(50)]
        public string STFYNO { get; set; }

        public TSFBAS ShallowCopy()
        {
            return (TSFBAS)this.MemberwiseClone();
        }

    }
}
