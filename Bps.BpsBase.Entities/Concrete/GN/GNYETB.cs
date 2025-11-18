using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNYETB : BaseEntity
    {
        [Required]
        [CsDisplayName("YetkId")]
        public int YetkId { get; set; }

        [Required]
        [CsDisplayName("MNUNAM")]
        [MaxLength(50)]
        public string MNUNAM { get; set; }

        [Required]
        [CsDisplayName("MNUTAG")]
        public int MNUTAG { get; set; }

        [Required]
        [CsDisplayName("MENUKD")]
        [MaxLength(20)]
        public string MENUKD { get; set; }

        public GNYETB ShallowCopy()
        {
            return (GNYETB)this.MemberwiseClone();
        }

    }
}
