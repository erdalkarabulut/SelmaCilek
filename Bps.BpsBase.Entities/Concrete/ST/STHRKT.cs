using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STHRKT : BaseEntity
    {
        [CsDisplayName("STHRTP")]
        public int? STHRTP { get; set; }

        [CsDisplayName("STFTNO")]
        public int? STFTNO { get; set; }

        [CsDisplayName("STNMIA")]
        public int? STNMIA { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

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

        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

        [CsDisplayName("DVZFYT")]
        public decimal? DVZFYT { get; set; }

        [CsDisplayName("DVZALT")]
        public decimal? DVZALT { get; set; }

        [CsDisplayName("STDVCN")]
        [MaxLength(20)]
        public string STDVCN { get; set; }

        [CsDisplayName("STDFYT")]
        public decimal? STDFYT { get; set; }

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

        [CsDisplayName("GNTUTR")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("VRGORN")]
        public decimal? VRGORN { get; set; }

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

        [CsDisplayName("VRGTUT")]
        public decimal? VRGTUT { get; set; }

        [CsDisplayName("VRGSIZ")]
        public bool? VRGSIZ { get; set; }

        [CsDisplayName("OTVORN")]
        public int? OTVORN { get; set; }

        [CsDisplayName("OTVTUT")]
        public decimal? OTVTUT { get; set; }

        [CsDisplayName("BRTAGR")]
        public decimal? BRTAGR { get; set; }

        [CsDisplayName("NETAGR")]
        public decimal? NETAGR { get; set; }

        [CsDisplayName("AGOLKD")]
        [MaxLength(20)]
        public string AGOLKD { get; set; }

        [CsDisplayName("OIVORN")]
        public int? OIVORN { get; set; }

        [CsDisplayName("OIVTUT")]
        public decimal? OIVTUT { get; set; }

        [CsDisplayName("TEVKIF")]
        public int? TEVKIF { get; set; }

        [CsDisplayName("ILVKDV")]
        public decimal? ILVKDV { get; set; }

        [CsDisplayName("PARTIN")]
        [MaxLength(50)]
        public string PARTIN { get; set; }

        [CsDisplayName("PARTIT")]
        public bool? PARTIT { get; set; }

        [CsDisplayName("TSALAN")]
        [MaxLength(50)]
        public string TSALAN { get; set; }

        [CsDisplayName("TSTARH")]
        public DateTime? TSTARH { get; set; }

        [CsDisplayName("USTBLG")]
        [MaxLength(20)]
        public string USTBLG { get; set; }

        [CsDisplayName("USTKLM")]
        public int? USTKLM { get; set; }

        [CsDisplayName("SADEGK")]
        [MaxLength(4)]
        public string SADEGK { get; set; }

        [CsDisplayName("CKADRS")]
        [MaxLength(50)]
        public string CKADRS { get; set; }

        [CsDisplayName("GRADRS")]
        [MaxLength(50)]
        public string GRADRS { get; set; }
        public STHRKT ShallowCopy()
        {
            return (STHRKT)this.MemberwiseClone();
        }

    }
}
