using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STOLCU : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [Required]
        [CsDisplayName("OLCHDF")]
        [MaxLength(20)]
        public string OLCHDF { get; set; }

        [Required]
        [CsDisplayName("BOLNEN")]
        public double BOLNEN { get; set; }

        [Required]
        [CsDisplayName("BOLLEN")]
        public double BOLLEN { get; set; }

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

        public STOLCU ShallowCopy()
        {
            return (STOLCU)this.MemberwiseClone();
        }

    }
}
