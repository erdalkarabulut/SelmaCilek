using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.MH
{
    public class MHHSPL : BaseEntity
    {
        [CsDisplayName("HSPKOD")]
        [MaxLength(25)]
        public string HSPKOD { get; set; }

        [CsDisplayName("HSPTNM")]
        [MaxLength(40)]
        public string HSPTNM { get; set; }

        [CsDisplayName("HSPTKD")]
        [MaxLength(20)]
        public string HSPTKD { get; set; }

        [CsDisplayName("DVCNKD")]
        [MaxLength(20)]
        public string DVCNKD { get; set; }

        [CsDisplayName("KURFLG")]
        public bool? KURFLG { get; set; }

        [CsDisplayName("SRMFLG")]
        public bool? SRMFLG { get; set; }

        [CsDisplayName("DAVBCM")]
        public int? DAVBCM { get; set; }

        [CsDisplayName("DGSKKD")]
        [MaxLength(20)]
        public string DGSKKD { get; set; }

        [CsDisplayName("MGRKOD")]
        [MaxLength(4)]
        public string MGRKOD { get; set; }

        [CsDisplayName("KDVDKD")]
        [MaxLength(10)]
        public string KDVDKD { get; set; }

        [CsDisplayName("ENFFLG")]
        public bool? ENFFLG { get; set; }

        [CsDisplayName("KMZKOD")]
        [MaxLength(25)]
        public string KMZKOD { get; set; }

        [CsDisplayName("HSKFLG")]
        public bool? HSKFLG { get; set; }

        public MHHSPL ShallowCopy()
        {
            return (MHHSPL)this.MemberwiseClone();
        }

    }
}
