using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Concrete
{
    public class SIRKET : IEntity
    {
        public int Id { get; set; }

        [CsDisplayName("KARSIS")]
        public int? KARSIS { get; set; }

        [CsDisplayName("SRKTYP")]
        public bool? SRKTYP { get; set; }
        [CsDisplayName("SRGUID")]
        public Guid? SRGUID { get; set; }
        [CsDisplayName("GNNAME")]
        public string GNNAME { get; set; }

        [CsDisplayName("KISAAD")]
        public string KISAAD { get; set; }

        [CsDisplayName("UNVANI")]
        public string UNVANI { get; set; }

        [CsDisplayName("ADRESS")]
        public string ADRESS { get; set; }

        [CsDisplayName("MAHAKD")]
        public string MAHAKD { get; set; }

        [CsDisplayName("ILCEKD")]
        public string ILCEKD { get; set; }

        [CsDisplayName("SEHRKD")]
        public string SEHRKD { get; set; }

        [CsDisplayName("ULKEKD")]
        public string ULKEKD { get; set; }

        [CsDisplayName("ISYTEL")]
        public string ISYTEL { get; set; }

        [CsDisplayName("CEPTEL")]
        public string CEPTEL { get; set; }

        [CsDisplayName("ISYFAX")]
        public string ISYFAX { get; set; }

        [CsDisplayName("EPOSTA")]
        public string EPOSTA { get; set; }

        [CsDisplayName("WEBSIT")]
        public string WEBSIT { get; set; }

        [CsDisplayName("VERGDA")]
        public string VERGDA { get; set; }

        [CsDisplayName("VERGNO")]
        public string VERGNO { get; set; }

        [CsDisplayName("TSICNO")]
        public string TSICNO { get; set; }

        [CsDisplayName("YMMSMM")]
        public string YMMSMM { get; set; }

        [CsDisplayName("TICODA")]
        public string TICODA { get; set; }

        [CsDisplayName("ODASIC")]
        public string ODASIC { get; set; }

        [CsDisplayName("ACTIVE")]
        public bool ACTIVE { get; set; }

        [CsDisplayName("RNKBDN")]
        public bool? RNKBDN { get; set; }

        [CsDisplayName("SLINDI")]
        public bool SLINDI { get; set; }

        [CsDisplayName("EKKULL")]
        public string EKKULL { get; set; }

        [CsDisplayName("ETARIH")]
        public DateTime ETARIH { get; set; }

        [CsDisplayName("DEKULL")]
        public string DEKULL { get; set; }

        [CsDisplayName("DTARIH")]
        public DateTime? DTARIH { get; set; }

        [CsDisplayName("KYNKKD")]
        public string KYNKKD { get; set; }

        public SIRKET ShallowCopy()
        {
            return (SIRKET)this.MemberwiseClone();
        }

    }
}
