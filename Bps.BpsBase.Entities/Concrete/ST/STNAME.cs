using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STNAME : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("STKNAM")]
        [MaxLength(100)]
        public string STKNAM { get; set; }

        [Required]
        [CsDisplayName("LANGKD")]
        [MaxLength(20)]
        public string LANGKD { get; set; }

        public STNAME ShallowCopy()
        {
            return (STNAME)this.MemberwiseClone();
        }

    }
}
