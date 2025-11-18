using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SN
{
    public class SNTYNN : BaseEntity
    {
        [CsDisplayName("OBJKEY")]
        [MaxLength(50)]
        public string OBJKEY { get; set; }

        [Required]
        [CsDisplayName("SNFKOD")]
        [MaxLength(50)]
        public string SNFKOD { get; set; }

        public SNTYNN ShallowCopy()
        {
            return (SNTYNN)this.MemberwiseClone();
        }

    }
}
