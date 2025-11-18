using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMADRT : BaseEntity
    {
        [Required]
        [CsDisplayName("DEPOKD")]
        [MaxLength(20)]
        public string DEPOKD { get; set; }

        [Required]
        [CsDisplayName("DPTIPI")]
        [MaxLength(4)]
        public string DPTIPI { get; set; }

        [CsDisplayName("DPADRS")]
        [MaxLength(50)]
        public string DPADRS { get; set; }

        [CsDisplayName("DPALKD")]
        [MaxLength(20)]
        public string DPALKD { get; set; }

        [CsDisplayName("DPATKD")]
        [MaxLength(20)]
        public string DPATKD { get; set; }

        [CsDisplayName("DPACKD")]
        [MaxLength(20)]
        public string DPACKD { get; set; }

        [CsDisplayName("DGSTBL")]
        public bool? DGSTBL { get; set; }

        [CsDisplayName("DCSTBL")]
        public bool? DCSTBL { get; set; }

        [CsDisplayName("STARIH")]
        public DateTime? STARIH { get; set; }

        [CsDisplayName("DPASRL")]
        [MaxLength(6)]
        public string DPASRL { get; set; }

        [CsDisplayName("DPCSRL")]
        [MaxLength(6)]
        public string DPCSRL { get; set; }

        public WMADRT ShallowCopy()
        {
            return (WMADRT)this.MemberwiseClone();
        }

    }
}
