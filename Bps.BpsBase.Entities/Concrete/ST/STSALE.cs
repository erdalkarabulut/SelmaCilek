using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STSALE : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("SPORKD")]
        [MaxLength(20)]
        public string SPORKD { get; set; }

        [Required]
        [CsDisplayName("SPDGKD")]
        [MaxLength(20)]
        public string SPDGKD { get; set; }

        [Required]
        [CsDisplayName("ASGMIK")]
        public decimal ASGMIK { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [CsDisplayName("MALGK1")]
        [MaxLength(20)]
        public string MALGK1 { get; set; }

        [CsDisplayName("MALGK2")]
        [MaxLength(20)]
        public string MALGK2 { get; set; }

        [CsDisplayName("MALGK3")]
        [MaxLength(20)]
        public string MALGK3 { get; set; }

        public STSALE ShallowCopy()
        {
            return (STSALE)this.MemberwiseClone();
        }

    }
}
