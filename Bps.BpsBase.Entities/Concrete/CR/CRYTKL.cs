using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.CR
{
    public class CRYTKL : BaseEntity
    {
        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("CRADID")]
        public int? CRADID { get; set; }

        [Required]
        [CsDisplayName("YETADI")]
        [MaxLength(50)]
        public string YETADI { get; set; }

        [Required]
        [CsDisplayName("YETSOY")]
        [MaxLength(50)]
        public string YETSOY { get; set; }

        [CsDisplayName("YETUNV")]
        [MaxLength(50)]
        public string YETUNV { get; set; }

        [CsDisplayName("ISYTEL")]
        [MaxLength(30)]
        public string ISYTEL { get; set; }

        [CsDisplayName("CRDHLN")]
        [MaxLength(30)]
        public string CRDHLN { get; set; }

        [CsDisplayName("CEPTEL")]
        [MaxLength(30)]
        public string CEPTEL { get; set; }

        [CsDisplayName("ISYFAX")]
        [MaxLength(30)]
        public string ISYFAX { get; set; }

        [EmailAddress]
        [CsDisplayName("GNMAIL")]
        [MaxLength(100)]
        public string GNMAIL { get; set; }

        public CRYTKL ShallowCopy()
        {
            return (CRYTKL)this.MemberwiseClone();
        }

    }
}
