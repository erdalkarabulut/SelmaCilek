using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CM
{
    public class CMAKSN : BaseEntity
    {
        [Required]
        [CsDisplayName("AKSNNO")]
        public int AKSNNO { get; set; }

        [Required]
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [Required]
        [CsDisplayName("CMDRKD")]
        [MaxLength(20)]
        public string CMDRKD { get; set; }

        public CMAKSN ShallowCopy()
        {
            return (CMAKSN)this.MemberwiseClone();
        }

    }
}
