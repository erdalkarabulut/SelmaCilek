using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPFTIP : BaseEntity
    {
        [Required]
        [CsDisplayName("SPFTNO")]
        public int SPFTNO { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("SPHRTP")]
        public int SPHRTP { get; set; }

        [CsDisplayName("SPHRTY")]
        public int? SPHRTY { get; set; }

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

        [CsDisplayName("KDVFLG")]
        public bool? KDVFLG { get; set; }

        [CsDisplayName("OTVFLG")]
        public bool? OTVFLG { get; set; }

        [Required]
        [CsDisplayName("TSFTNO")]
        public int TSFTNO { get; set; }

        [Required]
        [CsDisplayName("FTFTNO")]
        public int FTFTNO { get; set; }

        [CsDisplayName("STFYNO")]
        public int? STFYNO { get; set; }

        [CsDisplayName("ORGTKD")]
        [MaxLength(20)]
        public string ORGTKD { get; set; }

        public SPFTIP ShallowCopy()
        {
            return (SPFTIP)this.MemberwiseClone();
        }

    }
}
