using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISREVZ : BaseEntity
    {
        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }

        [CsDisplayName("BASTAR")]
        public DateTime? BASTAR { get; set; }

        [CsDisplayName("BITTAR")]
        public DateTime? BITTAR { get; set; }

        [CsDisplayName("URTONY")]
        public bool? URTONY { get; set; }

        public ISREVZ ShallowCopy()
        {
            return (ISREVZ)this.MemberwiseClone();
        }

    }
}
