using System;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class KullaniciModel : BaseEntity
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




        [Required]
        [CsDisplayName("SICILN")]
        [MaxLength(50)]
        public string SICILN { get; set; }

        [Required]
        [CsDisplayName("DEPAKD")]
        [MaxLength(20)]
        public string DEPAKD { get; set; }

        [Required]
        [CsDisplayName("POZSKD")]
        [MaxLength(20)]
        public string POZSKD { get; set; }

        [Required]
        [CsDisplayName("LOKAKD")]
        [MaxLength(20)]
        public string LOKAKD { get; set; }

        [Required]
        [CsDisplayName("DEPAKD")]
        [MaxLength(20)]
        public string Departman { get; set; }

        [Required]
        [CsDisplayName("POZSKD")]
        [MaxLength(20)]
        public string Pozisyon { get; set; }

        [CsDisplayName("GNPATH")]
        [MaxLength(500)]
        public string GNPATH { get; set; }


        [CsDisplayName("GNNAME")]
        public string FullName => GNNAME + " " + GNSNAM;
    }
}
