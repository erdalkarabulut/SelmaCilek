using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNKLOP : BaseEntity
    {
        [Required]
        [CsDisplayName("PERSID")]
        public int PERSID { get; set; }

        [Required]
        [CsDisplayName("ISOPKD")]
        [MaxLength(20)]
        public string ISOPKD { get; set; }

        public GNKLOP ShallowCopy()
        {
            return (GNKLOP)this.MemberwiseClone();
        }

    }
}
