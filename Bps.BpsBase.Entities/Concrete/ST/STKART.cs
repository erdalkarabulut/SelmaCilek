using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STKART : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("STKNAM")]
        [MaxLength(100)]
        public string STKNAM { get; set; }

        [Required]
        [CsDisplayName("STANKD")]
        [MaxLength(20)]
        public string STANKD { get; set; }

        [CsDisplayName("STALKD")]
        [MaxLength(20)]
        public string STALKD { get; set; }

        [CsDisplayName("STG1KD")]
        [MaxLength(20)]
        public string STG1KD { get; set; }

        [CsDisplayName("STG2KD")]
        [MaxLength(20)]
        public string STG2KD { get; set; }

        [CsDisplayName("STG3KD")]
        [MaxLength(20)]
        public string STG3KD { get; set; }

        [Required]
        [CsDisplayName("STMLTR")]
        [MaxLength(50)]
        public string STMLTR { get; set; }

        [CsDisplayName("STEKOD")]
        [MaxLength(50)]
        public string STEKOD { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("SADEGK")]
        [MaxLength(4)]
        public string SADEGK { get; set; }

        [Required]
        [CsDisplayName("SAOLKD")]
        [MaxLength(20)]
        public string SAOLKD { get; set; }

        [CsDisplayName("MALGKD")]
        [MaxLength(20)]
        public string MALGKD { get; set; }

        [CsDisplayName("BRTAGR")]
        public decimal? BRTAGR { get; set; }

        [CsDisplayName("NETAGR")]
        public decimal? NETAGR { get; set; }

        [CsDisplayName("AGOLKD")]
        [MaxLength(20)]
        public string AGOLKD { get; set; }

        [CsDisplayName("GNHACM")]
        public decimal? GNHACM { get; set; }

        [CsDisplayName("HCOLKD")]
        [MaxLength(20)]
        public string HCOLKD { get; set; }

        [CsDisplayName("EANTKD")]
        [MaxLength(20)]
        public string EANTKD { get; set; }

        [CsDisplayName("EANKOD")]
        [MaxLength(40)]
        public string EANKOD { get; set; }

        [CsDisplayName("UZUNLK")]
        public decimal? UZUNLK { get; set; }

        [CsDisplayName("GENSLK")]
        public decimal? GENSLK { get; set; }

        [CsDisplayName("YUKSLK")]
        public decimal? YUKSLK { get; set; }

        [CsDisplayName("UGYBKD")]
        [MaxLength(20)]
        public string UGYBKD { get; set; }

        [CsDisplayName("KDVORN")]
        public decimal? KDVORN { get; set; }

        [CsDisplayName("PARTIT")]
        public bool? PARTIT { get; set; }

        [CsDisplayName("FANTOM")]
        public bool? FANTOM { get; set; }

        [CsDisplayName("PKTSAY")]
        public int? PKTSAY { get; set; }

        [CsDisplayName("GTIPNO")]
        [MaxLength(30)]
        public string GTIPNO { get; set; }

        [CsDisplayName("UROPTB")]
        [MaxLength(20)]
        public string UROPTB { get; set; }

        [CsDisplayName("STKIMG")]
        [MaxLength(255)]
        public string STKIMG { get; set; }

        [CsDisplayName("STYKOD")]
        [MaxLength(50)]
        public string STYKOD { get; set; }

        public STKART ShallowCopy()
        {
            return (STKART)this.MemberwiseClone();
        }

    }
}
