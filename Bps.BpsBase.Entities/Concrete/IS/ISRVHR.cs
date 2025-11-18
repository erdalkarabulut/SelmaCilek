using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISRVHR : BaseEntity
    {
        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [CsDisplayName("MALHRK")]
        public bool? MALHRK { get; set; }

        [CsDisplayName("SONCIK")]
        public bool? SONCIK { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [Required]
        [CsDisplayName("DPKODU")]
        [MaxLength(4)]
        public string DPKODU { get; set; }

        [CsDisplayName("IHTRTR")]
        public DateTime? IHTRTR { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal? GNMKTR { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("URSPNO")]
        [MaxLength(10)]
        public string URSPNO { get; set; }

        [CsDisplayName("USRSNO")]
        [MaxLength(10)]
        public string USRSNO { get; set; }

        [CsDisplayName("USSTKO")]
        [MaxLength(25)]
        public string USSTKO { get; set; }

        [Required]
        [CsDisplayName("ISLTUR")]
        public int ISLTUR { get; set; }

        [CsDisplayName("URAGPI")]
        public int? URAGPI { get; set; }

        [CsDisplayName("URAGID")]
        public int? URAGID { get; set; }

        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [CsDisplayName("URKLTP")]
        [MaxLength(1)]
        public string URKLTP { get; set; }

        [CsDisplayName("SIRALM")]
        [MaxLength(50)]
        public string SIRALM { get; set; }

        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [CsDisplayName("ISLMNO")]
        public int? ISLMNO { get; set; }

        public ISRVHR ShallowCopy()
        {
            return (ISRVHR)this.MemberwiseClone();
        }

    }
}
