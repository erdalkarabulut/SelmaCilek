using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMNKSB : BaseEntity
    {
        [Required]
        [CsDisplayName("DEPOKD")]
        [MaxLength(20)]
        public string DEPOKD { get; set; }

        [CsDisplayName("NKBELG")]
        [MaxLength(20)]
        public string NKBELG { get; set; }

        [CsDisplayName("WMHRKD")]
        [MaxLength(20)]
        public string WMHRKD { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [CsDisplayName("WMNKTR")]
        [MaxLength(1)]
        public string WMNKTR { get; set; }

        [Required]
        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [Required]
        [CsDisplayName("GNONAY")]
        public bool GNONAY { get; set; }

        public WMNKSB ShallowCopy()
        {
            return (WMNKSB)this.MemberwiseClone();
        }

    }
}
