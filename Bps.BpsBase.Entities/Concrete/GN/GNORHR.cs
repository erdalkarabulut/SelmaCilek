using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNORHR : BaseEntity
    {
        [Required]
        [CsDisplayName("ORGKOD")]
        [MaxLength(20)]
        public string ORGKOD { get; set; }

        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [Required]
        [CsDisplayName("TABLNM")]
        [MaxLength(6)]
        public string TABLNM { get; set; }

        [Required]
        [CsDisplayName("TABLID")]
        public int TABLID { get; set; }

        [CsDisplayName("GNONAY")]
        public bool? GNONAY { get; set; }

        [CsDisplayName("GNONTR")]
        public DateTime? GNONTR { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        public GNORHR ShallowCopy()
        {
            return (GNORHR)this.MemberwiseClone();
        }

    }
}
