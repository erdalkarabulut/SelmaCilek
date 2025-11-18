using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UA
{
    public class UAMLTY : BaseEntity
    {
        [CsDisplayName("UAKLNT")]
        [MaxLength(4)]
        public string UAKLNT { get; set; }

        [Required]
        [CsDisplayName("STMLTR")]
        [MaxLength(50)]
        public string STMLTR { get; set; }

        public UAMLTY ShallowCopy()
        {
            return (UAMLTY)this.MemberwiseClone();
        }

    }
}
