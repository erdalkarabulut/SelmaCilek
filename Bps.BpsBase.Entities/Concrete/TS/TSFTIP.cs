using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.TS
{
    public class TSFTIP : BaseEntity
    {
        [Required]
        [CsDisplayName("TSFTNO")]
        public int TSFTNO { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("TSHRTP")]
        public int TSHRTP { get; set; }

        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [Required]
        [CsDisplayName("GNONAY")]
        public bool GNONAY { get; set; }

        [CsDisplayName("GNEVID")]
        public int? GNEVID { get; set; }

        [Required]
        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [CsDisplayName("FUNCNM")]
        [MaxLength(50)]
        public string FUNCNM { get; set; }

        [CsDisplayName("DIZAYN")]
        [MaxLength(200)]
        public string DIZAYN { get; set; }

        [Required]
        [CsDisplayName("FTFTNO")]
        public int FTFTNO { get; set; }

        public TSFTIP ShallowCopy()
        {
            return (TSFTIP)this.MemberwiseClone();
        }

    }
}
