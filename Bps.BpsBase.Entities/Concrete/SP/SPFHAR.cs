using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPFHAR : BaseEntity
    {
        [CsDisplayName("SPHRTP")]
        public int? SPHRTP { get; set; }

        [CsDisplayName("SPFTNO")]
        public int? SPFTNO { get; set; }

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

        [CsDisplayName("CRHRKD")]
        [MaxLength(20)]
        public string CRHRKD { get; set; }

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("STKNAM")]
        [MaxLength(100)]
        public string STKNAM { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [CsDisplayName("FTNKLM")]
        public bool? FTNKLM { get; set; }

        [Required]
        [CsDisplayName("STFYNO")]
        public int STFYNO { get; set; }

        [CsDisplayName("GRDEPO")]
        [MaxLength(4)]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        [CsDisplayName("BRTAGR")]
        public decimal? BRTAGR { get; set; }

        [CsDisplayName("NETAGR")]
        public decimal? NETAGR { get; set; }

        [CsDisplayName("AGOLKD")]
        [MaxLength(20)]
        public string AGOLKD { get; set; }

        [CsDisplayName("PARTIN")]
        [MaxLength(50)]
        public string PARTIN { get; set; }

        [CsDisplayName("PARTIT")]
        public bool? PARTIT { get; set; }

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

        [CsDisplayName("VRGSIZ")]
        public bool? VRGSIZ { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("OPSFYT")]
        public decimal? OPSFYT { get; set; }

        [CsDisplayName("GNTUTR")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("KDVFLG")]
        public bool? KDVFLG { get; set; }

        [CsDisplayName("GISKNT")]
        public decimal? GISKNT { get; set; }

        [CsDisplayName("VRGORN")]
        public decimal? VRGORN { get; set; }

        [CsDisplayName("OTVORN")]
        public int? OTVORN { get; set; }

        [CsDisplayName("OTVTUT")]
        public decimal? OTVTUT { get; set; }

        [CsDisplayName("OIVORN")]
        public int? OIVORN { get; set; }

        [CsDisplayName("OIVTUT")]
        public decimal? OIVTUT { get; set; }

        [CsDisplayName("VRGTUT")]
        public decimal? VRGTUT { get; set; }

        [CsDisplayName("MLKBTR")]
        public DateTime? MLKBTR { get; set; }

        [CsDisplayName("TEVKIF")]
        public int? TEVKIF { get; set; }

        [CsDisplayName("ILVKDV")]
        public decimal? ILVKDV { get; set; }

        [CsDisplayName("TSEVRK")]
        [MaxLength(50)]
        public string TSEVRK { get; set; }

        [CsDisplayName("TSSATR")]
        public int? TSSATR { get; set; }

        [CsDisplayName("GNACIK")]
        [MaxLength(200)]
        public string GNACIK { get; set; }

        [CsDisplayName("FLGKPN")]
        public bool? FLGKPN { get; set; }

        [CsDisplayName("KLNMKTR")]
        public decimal? KLNMKTR { get; set; }

        [CsDisplayName("SADEGK")]
        [MaxLength(4)]
        public string SADEGK { get; set; }

        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [CsDisplayName("ORDRID")]
        [MaxLength(50)]
        public string ORDRID { get; set; }

        [CsDisplayName("LINEID")]
        [MaxLength(50)]
        public string LINEID { get; set; }

        public SPFHAR ShallowCopy()
        {
            return (SPFHAR)this.MemberwiseClone();
        }

    }
}
