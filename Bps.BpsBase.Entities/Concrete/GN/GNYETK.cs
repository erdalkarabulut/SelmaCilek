using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNYETK : BaseEntity
    {
        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

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
        [CsDisplayName("EKLEME")]
        public bool EKLEME { get; set; }

        [Required]
        [CsDisplayName("DEGIST")]
        public bool DEGIST { get; set; }

        [Required]
        [CsDisplayName("KAYDET")]
        public bool KAYDET { get; set; }

        [Required]
        [CsDisplayName("SILMEK")]
        public bool SILMEK { get; set; }

        [Required]
        [CsDisplayName("GRNTLM")]
        public bool GRNTLM { get; set; }

        [Required]
        [CsDisplayName("KOPYAL")]
        public bool KOPYAL { get; set; }

        [Required]
        [CsDisplayName("PDFGOS")]
        public bool PDFGOS { get; set; }

        [Required]
        [CsDisplayName("EXCGOS")]
        public bool EXCGOS { get; set; }

        [Required]
        [CsDisplayName("YAZDIR")]
        public bool YAZDIR { get; set; }

        [Required]
        [CsDisplayName("CSVGOS")]
        public bool CSVGOS { get; set; }

        [Required]
        [CsDisplayName("XMLGOS")]
        public bool XMLGOS { get; set; }

        [Required]
        [CsDisplayName("DOCGOS")]
        public bool DOCGOS { get; set; }

        [Required]
        [CsDisplayName("GNONAY")]
        public bool GNONAY { get; set; }

        public GNYETK ShallowCopy()
        {
            return (GNYETK)this.MemberwiseClone();
        }

    }
}
