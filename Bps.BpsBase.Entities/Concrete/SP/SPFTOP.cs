using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPFTOP : BaseEntity
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

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("MALTES")]
        [MaxLength(25)]
        public string MALTES { get; set; }

        [CsDisplayName("SPKONU")]
        [MaxLength(10)]
        public string SPKONU { get; set; }

        [CsDisplayName("SPBASL")]
        [MaxLength(50)]
        public string SPBASL { get; set; }

        [CsDisplayName("GNTUTR")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("GNMTRH")]
        public decimal? GNMTRH { get; set; }

        [CsDisplayName("VRGORN")]
        public decimal? VRGORN { get; set; }

        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

        [CsDisplayName("DVZTUT")]
        public decimal? DVZTUT { get; set; }

        public SPFTOP ShallowCopy()
        {
            return (SPFTOP)this.MemberwiseClone();
        }

    }
}
