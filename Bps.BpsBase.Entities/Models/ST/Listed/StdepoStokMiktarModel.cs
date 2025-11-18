using System;
using Bps.Core.AttributeHelpers;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    [Serializable]
    public class StdepoStokMiktarModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("STMLTR")]
        public string STMLTR { get; set; }

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

        [CsDisplayName("DPKODU")]
        public string DPKODU { get; set; }

        [CsDisplayName("DPTANM")]
        public string DPTANM { get; set; }

        [CsDisplayName("YNSPSV")]
        public decimal YNSPSV { get; set; }

        [CsDisplayName("MPPRTB")]
        public decimal MPPRTB { get; set; }

        [CsDisplayName("SAPRTB")]
        public decimal SAPRTB { get; set; }

        [CsDisplayName("EMNSTK")]
        public decimal EMNSTK { get; set; }

        [CsDisplayName("SADEGK")]
        public string SADEGK { get; set; }

        [CsDisplayName("SAOLKD")]
        public string SAOLKD { get; set; }

        [CsDisplayName("MIPGOS")]
        public bool MIPGOS { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal GFIYAT { get; set; }

        [CsDisplayName("DVCNKD")]
        public string DVCNKD { get; set; }
        [CsDisplayName("VRKODU")]
        public string VRKODU { get; set; }
    }
}