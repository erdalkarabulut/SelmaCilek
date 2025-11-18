using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STDEPV : BaseEntity
    {
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

        [Required]
        [CsDisplayName("ENBLKJ")]
        public bool ENBLKJ { get; set; }

        [Required]
        [CsDisplayName("USESTK")]
        public decimal USESTK { get; set; }

        [Required]
        [CsDisplayName("BLKSTK")]
        public decimal BLKSTK { get; set; }

        [Required]
        [CsDisplayName("MIPGOS")]
        public bool MIPGOS { get; set; }

        [CsDisplayName("TEDKOD")]
        [MaxLength(4)]
        public string TEDKOD { get; set; }

        [CsDisplayName("DPADRS")]
        [MaxLength(40)]
        public string DPADRS { get; set; }

        [CsDisplayName("ULKEKD")]
        [MaxLength(20)]
        public string ULKEKD { get; set; }

        public STDEPV ShallowCopy()
        {
            return (STDEPV)this.MemberwiseClone();
        }

    }
}
