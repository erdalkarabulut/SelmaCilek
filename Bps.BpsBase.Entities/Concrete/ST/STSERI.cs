using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STSERI : BaseEntity
    {
        [Required]
        [CsDisplayName("SERINO")]
        [MaxLength(25)]
        public string SERINO { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [Required]
        [CsDisplayName("MALGRS")]
        public bool MALGRS { get; set; }

        [Required]
        [CsDisplayName("MALCKS")]
        public bool MALCKS { get; set; }

        public STSERI ShallowCopy()
        {
            return (STSERI)this.MemberwiseClone();
        }

    }
}
