using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CR
{
    public class CRADRS : BaseEntity
    {
        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("ADRESS")]
        [MaxLength(500)]
        public string ADRESS { get; set; }

        [CsDisplayName("MAHAKD")]
        [MaxLength(20)]
        public string MAHAKD { get; set; }

        [CsDisplayName("SEMTKD")]
        [MaxLength(20)]
        public string SEMTKD { get; set; }

        [CsDisplayName("ILCEKD")]
        [MaxLength(20)]
        public string ILCEKD { get; set; }

        [CsDisplayName("SEHRKD")]
        [MaxLength(20)]
        public string SEHRKD { get; set; }

        [Required]
        [CsDisplayName("ULKEKD")]
        [MaxLength(20)]
        public string ULKEKD { get; set; }

        [CsDisplayName("ISYTEL")]
        [MaxLength(15)]
        public string ISYTEL { get; set; }

        [CsDisplayName("CEPTEL")]
        [MaxLength(15)]
        public string CEPTEL { get; set; }

        [CsDisplayName("ISYFAX")]
        [MaxLength(15)]
        public string ISYFAX { get; set; }

        [CsDisplayName("GNONOT")]
        [MaxLength(50)]
        public string GNONOT { get; set; }

        [CsDisplayName("GPSENL")]
        public double? GPSENL { get; set; }

        [CsDisplayName("GPSBOY")]
        public double? GPSBOY { get; set; }

        public CRADRS ShallowCopy()
        {
            return (CRADRS)this.MemberwiseClone();
        }

    }
}
