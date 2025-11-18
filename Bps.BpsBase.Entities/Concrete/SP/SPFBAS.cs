using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPFBAS : BaseEntity
    {
        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [Required]
        [CsDisplayName("SPHRTP")]
        public int SPHRTP { get; set; }

        [Required]
        [CsDisplayName("SPFTNO")]
        public int SPFTNO { get; set; }

        [CsDisplayName("EVRAKN")]
        [MaxLength(50)]
        public string EVRAKN { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("CRHRKD")]
        [MaxLength(20)]
        public string CRHRKD { get; set; }

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("MALTES")]
        [MaxLength(25)]
        public string MALTES { get; set; }

        [CsDisplayName("GRDEPO")]
        [MaxLength(4)]
        public string GRDEPO { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        [CsDisplayName("DOVTRH")]
        public DateTime? DOVTRH { get; set; }

        [Required]
        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

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

        [CsDisplayName("TOPOTV")]
        public decimal? TOPOTV { get; set; }

        [CsDisplayName("TERTAR")]
        public DateTime? TERTAR { get; set; }

        [Required]
        [CsDisplayName("STFYNO")]
        public int STFYNO { get; set; }

        [CsDisplayName("EURFYT")]
        public decimal? EURFYT { get; set; }

        [CsDisplayName("USDFYT")]
        public decimal? USDFYT { get; set; }

        [CsDisplayName("TSEVRK")]
        [MaxLength(50)]
        public string TSEVRK { get; set; }

        [CsDisplayName("TRMDKD")]
        [MaxLength(20)]
        public string TRMDKD { get; set; }

        [CsDisplayName("TSSRKD")]
        [MaxLength(20)]
        public string TSSRKD { get; set; }

        [CsDisplayName("GCRTRH")]
        public DateTime? GCRTRH { get; set; }

        [CsDisplayName("NAVMAS")]
        public decimal? NAVMAS { get; set; }

        [CsDisplayName("DIGMAS")]
        public decimal? DIGMAS { get; set; }

        [CsDisplayName("FLGKPN")]
        public bool? FLGKPN { get; set; }

        [CsDisplayName("SIPVER")]
        public bool? SIPVER { get; set; }

        [CsDisplayName("TLBLNO")]
        [MaxLength(20)]
        public string TLBLNO { get; set; }

        [CsDisplayName("TKBGNO")]
        [MaxLength(20)]
        public string TKBGNO { get; set; }

        [CsDisplayName("TKTRKD")]
        [MaxLength(20)]
        public string TKTRKD { get; set; }

        [CsDisplayName("SPUTKD")]
        [MaxLength(20)]
        public string SPUTKD { get; set; }

        [CsDisplayName("SPDRKD")]
        [MaxLength(20)]
        public string SPDRKD { get; set; }

        [CsDisplayName("TKDRKD")]
        [MaxLength(20)]
        public string TKDRKD { get; set; }

        [CsDisplayName("KAYNAK")]
        [MaxLength(100)]
        public string KAYNAK { get; set; }

        [CsDisplayName("TEVKIF")]
        public int? TEVKIF { get; set; }

        [CsDisplayName("DNSMKD")]
        [MaxLength(20)]
        public string DNSMKD { get; set; }

        public SPFBAS ShallowCopy()
        {
            return (SPFBAS)this.MemberwiseClone();
        }

    }
}
