using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISURBG : BaseEntity
    {
        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [CsDisplayName("ISLMNO")]
        public int? ISLMNO { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        public int GNREZV { get; set; }

        [CsDisplayName("PARENT")]
        public int? PARENT { get; set; }

        [CsDisplayName("CHILDD")]
        public int? CHILDD { get; set; }

        [CsDisplayName("URRVNO")]
        [MaxLength(10)]
        public string URRVNO { get; set; }

        [CsDisplayName("URAKOD")]
        [MaxLength(10)]
        public string URAKOD { get; set; }

        public ISURBG ShallowCopy()
        {
            return (ISURBG)this.MemberwiseClone();
        }

    }
}
