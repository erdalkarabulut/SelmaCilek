using Bps.Core.AttributeHelpers;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StdepoStokAdresModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("STMLNM")]
        public string STMLNM { get; set; }

        [CsDisplayName("MALGKD")]
        public string MALGKD { get; set; }

        [CsDisplayName("STANKD")]
        public string STANKD { get; set; }

        [CsDisplayName("STALKD")]
        public string STALKD { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("USESTK")]
        public decimal USESTK { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("DPADRS")]
        public string DPADRS { get; set; }

        [CsDisplayName("DPTIPT")]
        public string DPTIPT { get; set; }

        [CsDisplayName("URYRKD")]
        public string URYRKD { get; set; }

        [CsDisplayName("DEPOKD")]
        public string DEPOKD { get; set; }

        [CsDisplayName("DPKODU")]
        public string DPKODU { get; set; }

        [CsDisplayName("DPTANM")]
        public string DPTANM { get; set; }

        [CsDisplayName("PARTIN")]
        public string PARTIN { get; set; }

        [CsDisplayName("PARTIT")]
        public bool? PARTIT { get; set; }
    }
}