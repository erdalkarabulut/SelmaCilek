using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMSTHR : BaseEntity
    {
        [Required]
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [Required]
        [CsDisplayName("STHRTP")]
        public int STHRTP { get; set; }

        [Required]
        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

        [Required]
        [CsDisplayName("SATIRN")]
        public int SATIRN { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("GNMKTR")]
        public decimal GNMKTR { get; set; }

        [Required]
        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [Required]
        [CsDisplayName("DPADRS")]
        [MaxLength(50)]
        public string DPADRS { get; set; }

        public WMSTHR ShallowCopy()
        {
            return (WMSTHR)this.MemberwiseClone();
        }

    }
}
