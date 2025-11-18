using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNORGA : BaseEntity
    {
        [CsDisplayName("ORGTKD")]
        [MaxLength(20)]
        public string ORGTKD { get; set; }

        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [CsDisplayName("GNNAME")]
        [MaxLength(50)]
        public string GNNAME { get; set; }

        [CsDisplayName("GNSNAM")]
        [MaxLength(50)]
        public string GNSNAM { get; set; }

        [CsDisplayName("PARENT")]
        public int? PARENT { get; set; }

        [CsDisplayName("CHILDD")]
        public int? CHILDD { get; set; }

        [CsDisplayName("SEVIYE")]
        public int? SEVIYE { get; set; }

        [CsDisplayName("ONYSVY")]
        public int? ONYSVY { get; set; }

        [CsDisplayName("SIRASI")]
        public int? SIRASI { get; set; }

        [CsDisplayName("GNONAY")]
        public bool? GNONAY { get; set; }

        [CsDisplayName("GNLONY")]
        public bool? GNLONY { get; set; }

        [CsDisplayName("GNDFON")]
        public bool? GNDFON { get; set; }

        public GNORGA ShallowCopy()
        {
            return (GNORGA)this.MemberwiseClone();
        }

    }
}
