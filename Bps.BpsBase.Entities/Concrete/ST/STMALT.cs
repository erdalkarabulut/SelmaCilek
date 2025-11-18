using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STMALT : BaseEntity
    {
        [Required]
        [CsDisplayName("STMLTR")]
        [MaxLength(50)]
        public string STMLTR { get; set; }

        [Required]
        [CsDisplayName("STMLNM")]
        [MaxLength(50)]
        public string STMLNM { get; set; }

        [Required]
        [CsDisplayName("STBKDR")]
        [MaxLength(15)]
        public string STBKDR { get; set; }

        [Required]
        [CsDisplayName("STCNKD")]
        [MaxLength(20)]
        public string STCNKD { get; set; }

        [CsDisplayName("OTMTIK")]
        public bool? OTMTIK { get; set; }

        [CsDisplayName("FORMUL")]
        [MaxLength(250)]
        public string FORMUL { get; set; }

        [CsDisplayName("STRENK")]
        public bool? STRENK { get; set; }

        [CsDisplayName("STBDEN")]
        public bool? STBDEN { get; set; }

        [CsDisplayName("STDROP")]
        public bool? STDROP { get; set; }

        public STMALT ShallowCopy()
        {
            return (STMALT)this.MemberwiseClone();
        }

    }
}
