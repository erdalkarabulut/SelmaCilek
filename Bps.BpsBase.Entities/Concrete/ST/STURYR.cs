using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STURYR : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [CsDisplayName("ABCGOS")]
        [MaxLength(1)]
        public string ABCGOS { get; set; }

        [CsDisplayName("STNGKD")]
        [MaxLength(20)]
        public string STNGKD { get; set; }

        [CsDisplayName("PLNTES")]
        public decimal? PLNTES { get; set; }

        [CsDisplayName("MGSURE")]
        public decimal? MGSURE { get; set; }

        [Required]
        [CsDisplayName("YNSPSV")]
        public decimal YNSPSV { get; set; }

        [Required]
        [CsDisplayName("EMNSTK")]
        public decimal EMNSTK { get; set; }

        [CsDisplayName("MPPRTB")]
        public decimal? MPPRTB { get; set; }

        [CsDisplayName("TEDTUR")]
        public int? TEDTUR { get; set; }

        [CsDisplayName("ASPRTB")]
        public decimal? ASPRTB { get; set; }

        [CsDisplayName("AZPRTB")]
        public decimal? AZPRTB { get; set; }

        [CsDisplayName("YUVARL")]
        public decimal? YUVARL { get; set; }

        [CsDisplayName("SAPRTB")]
        public decimal? SAPRTB { get; set; }

        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("URDEPO")]
        [MaxLength(4)]
        public string URDEPO { get; set; }

        [CsDisplayName("BILISK")]
        public decimal? BILISK { get; set; }

        [CsDisplayName("URNGST")]
        public bool? URNGST { get; set; }

        public STURYR ShallowCopy()
        {
            return (STURYR)this.MemberwiseClone();
        }

    }
}
