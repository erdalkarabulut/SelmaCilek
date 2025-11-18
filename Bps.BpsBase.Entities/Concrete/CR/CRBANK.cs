using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CR
{
    public class CRBANK : BaseEntity
    {
        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("BANKKD")]
        [MaxLength(20)]
        public string BANKKD { get; set; }

        [CsDisplayName("BNSBKD")]
        [MaxLength(20)]
        public string BNSBKD { get; set; }

        [CsDisplayName("SEHRKD")]
        [MaxLength(20)]
        public string SEHRKD { get; set; }

        [CsDisplayName("BNKHSP")]
        [MaxLength(50)]
        public string BNKHSP { get; set; }

        [CsDisplayName("BNIBAN")]
        [MaxLength(50)]
        public string BNIBAN { get; set; }

        [Required]
        [CsDisplayName("VARSAY")]
        public bool VARSAY { get; set; }

        public CRBANK ShallowCopy()
        {
            return (CRBANK)this.MemberwiseClone();
        }

    }
}
