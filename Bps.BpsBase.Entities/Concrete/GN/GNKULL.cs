using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNKULL : BaseEntity
    {
        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [Required]
        [CsDisplayName("PASSWD")]
        [MaxLength(200)]
        public string PASSWD { get; set; }

        [Required]
        [CsDisplayName("GNNAME")]
        [MaxLength(50)]
        public string GNNAME { get; set; }

        [Required]
        [CsDisplayName("GNSNAM")]
        [MaxLength(50)]
        public string GNSNAM { get; set; }

        [EmailAddress]
        [CsDisplayName("GNMAIL")]
        [MaxLength(100)]
        public string GNMAIL { get; set; }

        [CsDisplayName("GNTELF")]
        [MaxLength(30)]
        public string GNTELF { get; set; }

        [Required]
        [CsDisplayName("LANGKD")]
        [MaxLength(20)]
        public string LANGKD { get; set; }

        [Required]
        [CsDisplayName("PERSID")]
        public int PERSID { get; set; }

        [CsDisplayName("DEFPRO")]
        [MaxLength(20)]
        public string DEFPRO { get; set; }

        [CsDisplayName("LGNDAT")]
        public DateTime? LGNDAT { get; set; }

        [Required]
        [CsDisplayName("SCQUKD")]
        [MaxLength(20)]
        public string SCQUKD { get; set; }

        [Required]
        [CsDisplayName("SCANSW")]
        [MaxLength(50)]
        public string SCANSW { get; set; }

        [Required]
        [CsDisplayName("ROLEKD")]
        [MaxLength(20)]
        public string ROLEKD { get; set; }

        [CsDisplayName("GNTHEM")]
        [MaxLength(50)]
        public string GNTHEM { get; set; }

        public GNKULL ShallowCopy()
        {
            return (GNKULL)this.MemberwiseClone();
        }

    }
}
