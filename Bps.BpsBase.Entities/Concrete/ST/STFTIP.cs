using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STFTIP : BaseEntity
    {
        [Required]
        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

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

        public STFTIP ShallowCopy()
        {
            return (STFTIP)this.MemberwiseClone();
        }

    }
}
