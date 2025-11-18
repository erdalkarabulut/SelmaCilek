using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Concrete
{
    public class DOVKUR : IEntity
    {
        [CsDisplayName("Id")]
        public int Id { get; set; }

        [CsDisplayName("DVCNKD")]
        public string DVCNKD { get; set; }

        [CsDisplayName("DOVTRH")]
        public DateTime DOVTRH { get; set; }

        [CsDisplayName("DVFYT1")]
        public double DVFYT1 { get; set; }

        [CsDisplayName("DVFYT2")]
        public double? DVFYT2 { get; set; }

        [CsDisplayName("DVFYT3")]
        public double? DVFYT3 { get; set; }

        [CsDisplayName("DVFYT4")]
        public double? DVFYT4 { get; set; }

        [CsDisplayName("MANUEL")]
        public bool? MANUEL { get; set; }

        [CsDisplayName("ACTIVE")]
        public bool ACTIVE { get; set; }

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

        [CsDisplayName("CHKCTR")]
        public bool CHKCTR { get; set; }

        public DOVKUR ShallowCopy()
        {
            return (DOVKUR)this.MemberwiseClone();
        }

    }
}
