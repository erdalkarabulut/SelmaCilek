using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNKUKR : BaseEntity
    {
        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [Required]
        [CsDisplayName("KARTKD")]
        [MaxLength(20)]
        public string KARTKD { get; set; }

        [Required]
        [CsDisplayName("GNPOSI")]
        public int GNPOSI { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        public GNKUKR ShallowCopy()
        {
            return (GNKUKR)this.MemberwiseClone();
        }

    }
}
