using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISPLST : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        public int GNREZV { get; set; }

        [CsDisplayName("BASTAR")]
        public DateTime? BASTAR { get; set; }

        [CsDisplayName("URRVNO")]
        [MaxLength(10)]
        public string URRVNO { get; set; }

        [CsDisplayName("URAKOD")]
        [MaxLength(10)]
        public string URAKOD { get; set; }

        public ISPLST ShallowCopy()
        {
            return (ISPLST)this.MemberwiseClone();
        }

    }
}
