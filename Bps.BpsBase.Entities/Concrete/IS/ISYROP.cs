using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISYROP : BaseEntity
    {
        [Required]
        [CsDisplayName("ISYRID")]
        public int ISYRID { get; set; }

        [Required]
        [CsDisplayName("ISOPKD")]
        [MaxLength(20)]
        public string ISOPKD { get; set; }

        public ISYROP ShallowCopy()
        {
            return (ISYROP)this.MemberwiseClone();
        }

    }
}
