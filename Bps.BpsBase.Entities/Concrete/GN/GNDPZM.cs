using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNDPZM : BaseEntity
    {
        [Required]
        [CsDisplayName("PERSID")]
        public int PERSID { get; set; }

        [Required]
        [CsDisplayName("DPKODU")]
        [MaxLength(4)]
        public string DPKODU { get; set; }

        [Required]
        [CsDisplayName("DPTANM")]
        [MaxLength(40)]
        public string DPTANM { get; set; }

        [Required]
        [CsDisplayName("MOBILE")]
        public bool MOBILE { get; set; }

        public GNDPZM ShallowCopy()
        {
            return (GNDPZM)this.MemberwiseClone();
        }

    }
}
