using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.TS
{
    public class TSFHAR : BaseEntity
    {
        [CsDisplayName("TSHRTP")]
        public int? TSHRTP { get; set; }

        [CsDisplayName("TSFTNO")]
        public int? TSFTNO { get; set; }

        [CsDisplayName("STNMIA")]
        public int? STNMIA { get; set; }

        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [CsDisplayName("EVRAKN")]
        [MaxLength(50)]
        public string EVRAKN { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

        [CsDisplayName("USTPOS")]
        public int? USTPOS { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [CsDisplayName("BELTRH")]
        public DateTime? BELTRH { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("STKNAM")]
        [MaxLength(100)]
        public string STKNAM { get; set; }

        [CsDisplayName("FTNKLM")]
        public bool? FTNKLM { get; set; }

        [CsDisplayName("PARTIN")]
        [MaxLength(50)]
        public string PARTIN { get; set; }

        [CsDisplayName("ISM1KD")]
        [MaxLength(20)]
        public string ISM1KD { get; set; }

        [CsDisplayName("ISM2KD")]
        [MaxLength(20)]
        public string ISM2KD { get; set; }

        [CsDisplayName("ISM3KD")]
        [MaxLength(20)]
        public string ISM3KD { get; set; }

        [CsDisplayName("ISMSM1")]
        public bool? ISMSM1 { get; set; }

        [CsDisplayName("ISMSM2")]
        public bool? ISMSM2 { get; set; }

        [CsDisplayName("ISMSM3")]
        public bool? ISMSM3 { get; set; }

        [CsDisplayName("ISMSD1")]
        public decimal? ISMSD1 { get; set; }

        [CsDisplayName("ISMSD2")]
        public decimal? ISMSD2 { get; set; }

        [CsDisplayName("ISMSD3")]
        public decimal? ISMSD3 { get; set; }

        [CsDisplayName("PROFLG")]
        public bool? PROFLG { get; set; }

        [CsDisplayName("CRHRKD")]
        [MaxLength(20)]
        public string CRHRKD { get; set; }

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal? GNMKTR { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("GRMKTR")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("GROLBR")]
        [MaxLength(20)]
        public string GROLBR { get; set; }

        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [CsDisplayName("GRDEPO")]
        [MaxLength(4)]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        [CsDisplayName("MLKBTR")]
        public DateTime? MLKBTR { get; set; }

        [CsDisplayName("BRTAGR")]
        public decimal? BRTAGR { get; set; }

        [CsDisplayName("NETAGR")]
        public decimal? NETAGR { get; set; }

        [CsDisplayName("AGOLKD")]
        [MaxLength(20)]
        public string AGOLKD { get; set; }
        [CsDisplayName("REFBEL")]
        [MaxLength(20)]
        public string REFBEL { get; set; }

        [CsDisplayName("REFKLM")]
        public int? REFKLM { get; set; }
        public TSFHAR ShallowCopy()
        {
            return (TSFHAR)this.MemberwiseClone();
        }

    }
}
