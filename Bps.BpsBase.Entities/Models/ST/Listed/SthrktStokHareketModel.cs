using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class SthrktStokHareketModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [CsDisplayName("EVRAKN")]
        public string EVRAKN { get; set; }

        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("TANIMI")]
        public string TANIMI { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal GNMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("PARTIN")]
        public string PARTIN { get; set; }

        [CsDisplayName("GNACIK")]
        public string GNACIK { get; set; }

        [CsDisplayName("OPTMZS")]
        public bool? OPTMZS { get; set; }

        [CsDisplayName("TSALAN")]
        public string TSALAN { get; set; }

        [CsDisplayName("TSTARH")]
        public DateTime? TSTARH { get; set; }

        [CsDisplayName("CRKODU")]
        public string CRKODU { get; set; }

        [CsDisplayName("GNKULL")]
        public string GNKULL { get; set; }

        [CsDisplayName("ETARIH")]
        public DateTime ETARIH { get; set; }

        [CsDisplayName("BELGEN")]
        public string BELGEN { get; set; }

        [CsDisplayName("USTBLG")]
        public string USTBLG { get; set; }

        [CsDisplayName("CKADRS")]
        public string CKADRS { get; set; }

        [CsDisplayName("GRADRS")]
        public string GRADRS { get; set; }
        [CsDisplayName("VRKODU")]
        public string VRKODU { get; set; }

    }
}
