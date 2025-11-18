using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNKXML : BaseEntity
    {
        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [Required]
        [CsDisplayName("MNUNAM")]
        [MaxLength(50)]
        public string MNUNAM { get; set; }

        [Required]
        [CsDisplayName("MNUTAG")]
        public int MNUTAG { get; set; }

        [Required]
        [CsDisplayName("GRDTAG")]
        public int GRDTAG { get; set; }

        [Required]
        [CsDisplayName("GRDTXT")]
        [MaxLength(50)]
        public string GRDTXT { get; set; }

        [Required]
        [CsDisplayName("GRDXML")]
        public string GRDXML { get; set; }

        [Required]
        [CsDisplayName("VARSAY")]
        public bool VARSAY { get; set; }

        public GNKXML ShallowCopy()
        {
            return (GNKXML)this.MemberwiseClone();
        }

    }
}
