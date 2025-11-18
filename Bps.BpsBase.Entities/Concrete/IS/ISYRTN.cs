using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISYRTN : BaseEntity
    {
        [CsDisplayName("ISYKOD")]
        [MaxLength(20)]
        public string ISYKOD { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [CsDisplayName("ISBLKD")]
        [MaxLength(20)]
        public string ISBLKD { get; set; }

        [CsDisplayName("STDADM")]
        public decimal? STDADM { get; set; }

        [CsDisplayName("STADBR")]
        [MaxLength(20)]
        public string STADBR { get; set; }

        [CsDisplayName("GCTSUR")]
        public int? GCTSUR { get; set; }

        [CsDisplayName("GCTSUB")]
        [MaxLength(20)]
        public string GCTSUB { get; set; }

        [CsDisplayName("BEKSUR")]
        public int? BEKSUR { get; set; }

        [CsDisplayName("BEKSUB")]
        [MaxLength(20)]
        public string BEKSUB { get; set; }

        public ISYRTN ShallowCopy()
        {
            return (ISYRTN)this.MemberwiseClone();
        }

    }
}
