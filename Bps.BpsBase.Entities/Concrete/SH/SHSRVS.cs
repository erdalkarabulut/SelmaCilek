using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SH
{
    public class SHSRVS : BaseEntity
    {
        [Required]
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [Required]
        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [Required]
        [CsDisplayName("SRTLTR")]
        public DateTime SRTLTR { get; set; }

        [Required]
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [Required]
        [CsDisplayName("CRUNVN")]
        [MaxLength(127)]
        public string CRUNVN { get; set; }

        [Required]
        [CsDisplayName("CRADRS")]
        [MaxLength(250)]
        public string CRADRS { get; set; }

        [CsDisplayName("GPSENL")]
        public double? GPSENL { get; set; }

        [CsDisplayName("GPSBOY")]
        public double? GPSBOY { get; set; }

        [Required]
        [CsDisplayName("CRTLFN")]
        [MaxLength(30)]
        public string CRTLFN { get; set; }

        [Required]
        [CsDisplayName("CRYTKL")]
        [MaxLength(50)]
        public string CRYTKL { get; set; }

        [Required]
        [CsDisplayName("TLPACN")]
        [MaxLength(100)]
        public string TLPACN { get; set; }

        [Required]
        [CsDisplayName("SRVTUR")]
        [MaxLength(25)]
        public string SRVTUR { get; set; }

        [Required]
        [CsDisplayName("SRVDRM")]
        [MaxLength(25)]
        public string SRVDRM { get; set; }

        [Required]
        [CsDisplayName("GRNDRM")]
        [MaxLength(25)]
        public string GRNDRM { get; set; }

        [Required]
        [CsDisplayName("MKNDRM")]
        [MaxLength(25)]
        public string MKNDRM { get; set; }

        [CsDisplayName("MKKRTR")]
        public DateTime? MKKRTR { get; set; }

        [CsDisplayName("SRPRID")]
        public int? SRPRID { get; set; }

        [CsDisplayName("SRVPRS")]
        [MaxLength(50)]
        public string SRVPRS { get; set; }

        [Required]
        [CsDisplayName("URKTGR")]
        [MaxLength(50)]
        public string URKTGR { get; set; }

        [CsDisplayName("URMODL")]
        [MaxLength(50)]
        public string URMODL { get; set; }

        [Required]
        [CsDisplayName("URSERI")]
        [MaxLength(50)]
        public string URSERI { get; set; }

        [CsDisplayName("URSASI")]
        [MaxLength(50)]
        public string URSASI { get; set; }

        [Required]
        [CsDisplayName("PRBTNM")]
        public string PRBTNM { get; set; }

        [CsDisplayName("PRBTSP")]
        public string PRBTSP { get; set; }

        [CsDisplayName("AKSYON")]
        public string AKSYON { get; set; }

        [CsDisplayName("ONYLYN")]
        [MaxLength(100)]
        public string ONYLYN { get; set; }

        [CsDisplayName("SRBSTR")]
        public DateTime? SRBSTR { get; set; }

        [CsDisplayName("SRBTTR")]
        public DateTime? SRBTTR { get; set; }

        [CsDisplayName("KULPRC")]
        public string KULPRC { get; set; }

        [CsDisplayName("MSIMZA")]
        public string MSIMZA { get; set; }

        [CsDisplayName("PRIMZA")]
        public string PRIMZA { get; set; }

        [CsDisplayName("STRSTP")]
        public string STRSTP { get; set; }

        [CsDisplayName("PDFURL")]
        public string PDFURL { get; set; }

        [Required]
        [CsDisplayName("CLSYNC")]
        public bool CLSYNC { get; set; }

        [Required]
        [CsDisplayName("SRSYNC")]
        public bool SRSYNC { get; set; }

        public SHSRVS ShallowCopy()
        {
            return (SHSRVS)this.MemberwiseClone();
        }

    }
}
