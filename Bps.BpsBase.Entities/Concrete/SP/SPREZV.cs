using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPREZV : BaseEntity
    {
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [CsDisplayName("SPBLNO")]
        [MaxLength(20)]
        public string SPBLNO { get; set; }

        [CsDisplayName("SPBLTR")]
        public DateTime? SPBLTR { get; set; }

        [CsDisplayName("SATIRN")]
        public int? SATIRN { get; set; }

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

        [CsDisplayName("SPMKTR")]
        public decimal? SPMKTR { get; set; }

        [CsDisplayName("RZMKTR")]
        public decimal? RZMKTR { get; set; }

        [CsDisplayName("KLMKTR")]
        public decimal? KLMKTR { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("CKDEPO")]
        [MaxLength(4)]
        public string CKDEPO { get; set; }

        public SPREZV ShallowCopy()
        {
            return (SPREZV)this.MemberwiseClone();
        }

    }
}
