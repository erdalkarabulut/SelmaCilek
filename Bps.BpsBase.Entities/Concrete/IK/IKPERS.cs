using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IK
{
    public class IKPERS : BaseEntity
    {
        [Required]
        [CsDisplayName("SICILN")]
        [MaxLength(50)]
        public string SICILN { get; set; }

        [Required]
        [CsDisplayName("GNNAME")]
        [MaxLength(50)]
        public string GNNAME { get; set; }

        [Required]
        [CsDisplayName("GNSNAM")]
        [MaxLength(50)]
        public string GNSNAM { get; set; }

        [Required]
        [CsDisplayName("DEPAKD")]
        [MaxLength(20)]
        public string DEPAKD { get; set; }

        [Required]
        [CsDisplayName("POZSKD")]
        [MaxLength(20)]
        public string POZSKD { get; set; }

        [Required]
        [CsDisplayName("LOKAKD")]
        [MaxLength(20)]
        public string LOKAKD { get; set; }

        [CsDisplayName("ISYKOD")]
        [MaxLength(20)]
        public string ISYKOD { get; set; }

        [EmailAddress]
        [CsDisplayName("GNMAIL")]
        [MaxLength(100)]
        public string GNMAIL { get; set; }

        [Required]
        [CsDisplayName("ISGRTR")]
        public DateTime ISGRTR { get; set; }

        [CsDisplayName("ISCKTR")]
        public DateTime? ISCKTR { get; set; }

        [CsDisplayName("CNEDKD")]
        [MaxLength(20)]
        public string CNEDKD { get; set; }

        [Required]
        [CsDisplayName("CLDRKD")]
        [MaxLength(20)]
        public string CLDRKD { get; set; }

        [CsDisplayName("MSRFKD")]
        [MaxLength(20)]
        public string MSRFKD { get; set; }

        [CsDisplayName("DOGTAR")]
        public DateTime? DOGTAR { get; set; }

        [CsDisplayName("DOGYER")]
        [MaxLength(50)]
        public string DOGYER { get; set; }

        [CsDisplayName("UYRKKD")]
        [MaxLength(20)]
        public string UYRKKD { get; set; }

        [Required]
        [CsDisplayName("CINSKD")]
        [MaxLength(20)]
        public string CINSKD { get; set; }

        [CsDisplayName("MHALKD")]
        [MaxLength(20)]
        public string MHALKD { get; set; }

        [CsDisplayName("EVLTAR")]
        public DateTime? EVLTAR { get; set; }

        [CsDisplayName("EVTELF")]
        [MaxLength(15)]
        public string EVTELF { get; set; }

        [CsDisplayName("CEPTEL")]
        [MaxLength(15)]
        public string CEPTEL { get; set; }

        [CsDisplayName("ADRESS")]
        [MaxLength(500)]
        public string ADRESS { get; set; }

        [CsDisplayName("MAHAKD")]
        [MaxLength(20)]
        public string MAHAKD { get; set; }

        [CsDisplayName("ILCEKD")]
        [MaxLength(20)]
        public string ILCEKD { get; set; }

        [CsDisplayName("SEHRKD")]
        [MaxLength(20)]
        public string SEHRKD { get; set; }

        [CsDisplayName("ULKEKD")]
        [MaxLength(20)]
        public string ULKEKD { get; set; }

        [CsDisplayName("ACLTEL")]
        [MaxLength(15)]
        public string ACLTEL { get; set; }

        [CsDisplayName("ACLCEP")]
        [MaxLength(15)]
        public string ACLCEP { get; set; }

        [CsDisplayName("ACLKIS")]
        [MaxLength(100)]
        public string ACLKIS { get; set; }

        [CsDisplayName("CCKSAY")]
        public int? CCKSAY { get; set; }

        public IKPERS ShallowCopy()
        {
            return (IKPERS)this.MemberwiseClone();
        }

    }
}
