using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STHBAS : BaseEntity
    {
        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

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

        [CsDisplayName("GRDEPO")]
        [MaxLength(4)]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        [CsDisplayName("DOVTRH")]
        public DateTime? DOVTRH { get; set; }

        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [CsDisplayName("TOPBRT")]
        public double? TOPBRT { get; set; }

        [CsDisplayName("TOPISK")]
        public double? TOPISK { get; set; }

        [CsDisplayName("TOPTUT")]
        public double? TOPTUT { get; set; }

        [CsDisplayName("TOPKDV")]
        public double? TOPKDV { get; set; }

        [CsDisplayName("TOPKDT")]
        public double? TOPKDT { get; set; }

        [CsDisplayName("OPTMZS")]
        public bool? OPTMZS { get; set; }

        public STHBAS ShallowCopy()
        {
            return (STHBAS)this.MemberwiseClone();
        }

    }
}
