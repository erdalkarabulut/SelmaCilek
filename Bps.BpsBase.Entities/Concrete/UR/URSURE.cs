using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UR
{
    public class URSURE : BaseEntity
    {
        [CsDisplayName("ISPLID")]
        public int? ISPLID { get; set; }

        [Required]
        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [Required]
        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("ISYKOD")]
        [MaxLength(20)]
        public string ISYKOD { get; set; }

        [Required]
        [CsDisplayName("ISOPKD")]
        [MaxLength(20)]
        public string ISOPKD { get; set; }

        [CsDisplayName("PERSID")]
        public int? PERSID { get; set; }

        [Required]
        [CsDisplayName("ISLTUR")]
        [MaxLength(20)]
        public string ISLTUR { get; set; }

        [CsDisplayName("ISLMNO")]
        public int? ISLMNO { get; set; }

        [CsDisplayName("ISBASL")]
        public DateTime? ISBASL { get; set; }

        [CsDisplayName("ISBITS")]
        public DateTime? ISBITS { get; set; }

        [CsDisplayName("GRMKTR")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("GROLBR")]
        [MaxLength(20)]
        public string GROLBR { get; set; }

        [CsDisplayName("URDRKD")]
        [MaxLength(20)]
        public string URDRKD { get; set; }

        public URSURE ShallowCopy()
        {
            return (URSURE)this.MemberwiseClone();
        }

    }
}
