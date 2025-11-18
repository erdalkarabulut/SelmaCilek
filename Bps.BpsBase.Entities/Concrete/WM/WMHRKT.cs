using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMHRKT : BaseEntity
    {
        [Required]
        [CsDisplayName("DEPOKD")]
        [MaxLength(20)]
        public string DEPOKD { get; set; }

        [CsDisplayName("WMHRKD")]
        [MaxLength(20)]
        public string WMHRKD { get; set; }

        [CsDisplayName("WMNKTR")]
        [MaxLength(1)]
        public string WMNKTR { get; set; }

        [CsDisplayName("KPTIPI")]
        [MaxLength(4)]
        public string KPTIPI { get; set; }

        [CsDisplayName("KPADRS")]
        [MaxLength(50)]
        public string KPADRS { get; set; }

        [CsDisplayName("HPTIPI")]
        [MaxLength(4)]
        public string HPTIPI { get; set; }

        [CsDisplayName("HPADRS")]
        [MaxLength(50)]
        public string HPADRS { get; set; }

        [CsDisplayName("NSMNEL")]
        public bool? NSMNEL { get; set; }

        [CsDisplayName("WMHRON")]
        public bool? WMHRON { get; set; }

        [CsDisplayName("WMDNMK")]
        public bool? WMDNMK { get; set; }

        [CsDisplayName("WMNSOT")]
        public bool? WMNSOT { get; set; }

        public WMHRKT ShallowCopy()
        {
            return (WMHRKT)this.MemberwiseClone();
        }

    }
}
