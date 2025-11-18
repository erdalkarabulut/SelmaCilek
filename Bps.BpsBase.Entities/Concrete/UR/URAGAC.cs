using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UR
{
    public class URAGAC : BaseEntity
    {
        [Required]
        [CsDisplayName("PARENT")]
        public int PARENT { get; set; }
        [Required]
        [CsDisplayName("CHILDD")]
        public int? CHILDD { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [CsDisplayName("SEVIYE")]
        public int? SEVIYE { get; set; }

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

        [CsDisplayName("URKLTP")]
        [MaxLength(1)]
        public string URKLTP { get; set; }

        [CsDisplayName("SIRALM")]
        [MaxLength(50)]
        public string SIRALM { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal? GNMKTR { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("SBTMIK")]
        public decimal? SBTMIK { get; set; }

        [CsDisplayName("STKKLM")]
        public bool? STKKLM { get; set; }

        [CsDisplayName("MTNKLM")]
        public bool? MTNKLM { get; set; }

        [CsDisplayName("FTNKLM")]
        public bool? FTNKLM { get; set; }

        [Required]
        [CsDisplayName("STMLTR")]
        [MaxLength(50)]
        public string STMLTR { get; set; }

        [CsDisplayName("AURKOD")]
        [MaxLength(50)]
        public string AURKOD { get; set; }

        public URAGAC ShallowCopy()
        {
            return (URAGAC)this.MemberwiseClone();
        }

    }
}
