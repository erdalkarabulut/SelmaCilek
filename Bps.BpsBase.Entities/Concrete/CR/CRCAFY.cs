using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CR
{
    public class CRCAFY : BaseEntity
    {
        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("STFYNO")]
        [MaxLength(50)]
        public string STFYNO { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("VARSAY")]
        public bool VARSAY { get; set; }

        public CRCAFY ShallowCopy()
        {
            return (CRCAFY)this.MemberwiseClone();
        }

    }
}
