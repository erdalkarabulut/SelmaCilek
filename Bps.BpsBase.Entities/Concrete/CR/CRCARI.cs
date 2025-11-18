using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CR
{
    public class CRCARI : BaseEntity
    {
        [Required]
        [CsDisplayName("CRHRKD")]
        [MaxLength(20)]
        public string CRHRKD { get; set; }

        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("ADCRKD")]
        [MaxLength(25)]
        public string ADCRKD { get; set; }

        [CsDisplayName("ASCRKD")]
        [MaxLength(25)]
        public string ASCRKD { get; set; }

        [Required]
        [CsDisplayName("CRUNV1")]
        [MaxLength(256)]
        public string CRUNV1 { get; set; }

        [CsDisplayName("CRUNV2")]
        [MaxLength(256)]
        public string CRUNV2 { get; set; }

        [CsDisplayName("CRBGKD")]
        [MaxLength(20)]
        public string CRBGKD { get; set; }

        [CsDisplayName("CRSACN")]
        public int? CRSACN { get; set; }

        [CsDisplayName("CRSSCN")]
        public int? CRSSCN { get; set; }

        [CsDisplayName("CRHSP1")]
        [MaxLength(25)]
        public string CRHSP1 { get; set; }

        [CsDisplayName("CRHSP2")]
        [MaxLength(25)]
        public string CRHSP2 { get; set; }

        [CsDisplayName("CRHSP3")]
        [MaxLength(25)]
        public string CRHSP3 { get; set; }

        [CsDisplayName("CRDVCN")]
        [MaxLength(10)]
        public string CRDVCN { get; set; }

        [CsDisplayName("CRDVC1")]
        [MaxLength(10)]
        public string CRDVC1 { get; set; }

        [CsDisplayName("CRDVC2")]
        [MaxLength(10)]
        public string CRDVC2 { get; set; }

        [CsDisplayName("CRVDYZ")]
        public double? CRVDYZ { get; set; }

        [CsDisplayName("CRVDY1")]
        public double? CRVDY1 { get; set; }

        [CsDisplayName("CRVDY2")]
        public double? CRVDY2 { get; set; }

        [CsDisplayName("KURHSK")]
        public int? KURHSK { get; set; }

        [Required]
        [CsDisplayName("VERGDA")]
        [MaxLength(50)]
        public string VERGDA { get; set; }

        [Required]
        [CsDisplayName("VERGNO")]
        [MaxLength(15)]
        public string VERGNO { get; set; }

        [CsDisplayName("TSICNO")]
        [MaxLength(50)]
        public string TSICNO { get; set; }

        [CsDisplayName("VERKML")]
        [MaxLength(15)]
        public string VERKML { get; set; }

        [CsDisplayName("CRODCN")]
        public int? CRODCN { get; set; }

        [CsDisplayName("FTADNO")]
        public int? FTADNO { get; set; }

        [CsDisplayName("SVADNO")]
        public int? SVADNO { get; set; }

        [CsDisplayName("CRAKOD")]
        [MaxLength(25)]
        public string CRAKOD { get; set; }

        [CsDisplayName("EFATUR")]
        public bool? EFATUR { get; set; }

        [CsDisplayName("ODGUNU")]
        public int? ODGUNU { get; set; }

        [CsDisplayName("ODTERC")]
        public int? ODTERC { get; set; }

        [CsDisplayName("OTVTEV")]
        public bool? OTVTEV { get; set; }

        [CsDisplayName("CRSKOD")]
        [MaxLength(25)]
        public string CRSKOD { get; set; }

        [EmailAddress]
        [CsDisplayName("GNMAIL")]
        [MaxLength(100)]
        public string GNMAIL { get; set; }

        [CsDisplayName("GNWEBA")]
        [MaxLength(100)]
        public string GNWEBA { get; set; }

        public CRCARI ShallowCopy()
        {
            return (CRCARI)this.MemberwiseClone();
        }

    }
}
