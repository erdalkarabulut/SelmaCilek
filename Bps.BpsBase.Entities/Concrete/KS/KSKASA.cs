using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.KS
{
    public class KSKASA : BaseEntity
    {
        [CsDisplayName("KSTPKD")]
        [MaxLength(20)]
        public string KSTPKD { get; set; }

        [CsDisplayName("KSKODU")]
        [MaxLength(25)]
        public string KSKODU { get; set; }

        [CsDisplayName("KSISIM")]
        [MaxLength(40)]
        public string KSISIM { get; set; }

        [CsDisplayName("HSPKOD")]
        [MaxLength(25)]
        public string HSPKOD { get; set; }

        [CsDisplayName("KSDVCN")]
        [MaxLength(10)]
        public string KSDVCN { get; set; }

        [CsDisplayName("UFRHSP")]
        [MaxLength(25)]
        public string UFRHSP { get; set; }

        public KSKASA ShallowCopy()
        {
            return (KSKASA)this.MemberwiseClone();
        }

    }
}
