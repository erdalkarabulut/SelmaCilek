using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STUROP : BaseEntity
    {
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

        [Required]
        [CsDisplayName("TIPKOD")]
        [MaxLength(20)]
        public string TIPKOD { get; set; }

        [Required]
        [CsDisplayName("HARKOD")]
        [MaxLength(20)]
        public string HARKOD { get; set; }

        public STUROP ShallowCopy()
        {
            return (STUROP)this.MemberwiseClone();
        }

    }
}
