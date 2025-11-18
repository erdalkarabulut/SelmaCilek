using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNEVRK : BaseEntity
    {
        [Required]
        [CsDisplayName("TABLNM")]
        [MaxLength(6)]
        public string TABLNM { get; set; }

        [Required]
        [CsDisplayName("TEKNAD")]
        [MaxLength(6)]
        public string TEKNAD { get; set; }

        [Required]
        [CsDisplayName("ISLTUR")]
        public int ISLTUR { get; set; }

        [Required]
        [CsDisplayName("GNYEAR")]
        public int GNYEAR { get; set; }

        [CsDisplayName("GNONEK")]
        [MaxLength(10)]
        public string GNONEK { get; set; }

        [Required]
        [CsDisplayName("KARSAY")]
        public int KARSAY { get; set; }

        [Required]
        [CsDisplayName("BASDEG")]
        public long BASDEG { get; set; }

        [Required]
        [CsDisplayName("BITDEG")]
        public long BITDEG { get; set; }

        [Required]
        [CsDisplayName("KALDEG")]
        public long KALDEG { get; set; }

        public GNEVRK ShallowCopy()
        {
            return (GNEVRK)this.MemberwiseClone();
        }

    }
}
