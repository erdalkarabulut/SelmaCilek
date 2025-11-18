using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNMENU : BaseEntity
    {
        [Required]
        [CsDisplayName("PROKOD")]
        [MaxLength(20)]
        public string PROKOD { get; set; }

        [Required]
        [CsDisplayName("MNUNAM")]
        [MaxLength(50)]
        public string MNUNAM { get; set; }

        [Required]
        [CsDisplayName("MNUTAG")]
        public int MNUTAG { get; set; }

        [Required]
        [CsDisplayName("PARENT")]
        public int PARENT { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [CsDisplayName("GNICON")]
        [MaxLength(50)]
        public string GNICON { get; set; }

        [CsDisplayName("GNAREA")]
        [MaxLength(6)]
        public string GNAREA { get; set; }

        [CsDisplayName("CONTNM")]
        [MaxLength(50)]
        public string CONTNM { get; set; }

        [CsDisplayName("FUNCNM")]
        [MaxLength(50)]
        public string FUNCNM { get; set; }

        [CsDisplayName("FORNM")]
        [MaxLength(50)]
        public string FORNM { get; set; }

        public GNMENU ShallowCopy()
        {
            return (GNMENU)this.MemberwiseClone();
        }

    }
}
