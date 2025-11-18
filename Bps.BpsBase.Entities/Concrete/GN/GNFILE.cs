using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNFILE : BaseEntity
    {
        [Required]
        [CsDisplayName("TABLNM")]
        [MaxLength(6)]
        public string TABLNM { get; set; }

        [Required]
        [CsDisplayName("TABLID")]
        public int TABLID { get; set; }

        [Required]
        [CsDisplayName("FLNAME")]
        [MaxLength(50)]
        public string FLNAME { get; set; }

        [CsDisplayName("GNDOSY")]
        public byte[] GNDOSY { get; set; }

        [CsDisplayName("GNPATH")]
        [MaxLength(500)]
        public string GNPATH { get; set; }

        [Required]
        [CsDisplayName("FLTYPE")]
        public int FLTYPE { get; set; }

        [Required]
        [CsDisplayName("DEFAUL")]
        public bool DEFAUL { get; set; }

        public GNFILE ShallowCopy()
        {
            return (GNFILE)this.MemberwiseClone();
        }

    }
}
