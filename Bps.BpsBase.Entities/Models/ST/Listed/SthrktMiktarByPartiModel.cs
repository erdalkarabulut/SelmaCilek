using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    [Serializable]
    public class SthrktMiktarByPartiModel
    {
	    [CsDisplayName("STMLTR")]
	    public string STMLTR { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("GRMKTR")]
        public decimal GRMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("PARTIN")]
        public string PARTIN { get; set; }

        [CsDisplayName("DPKODU")]
        public string DPKODU { get; set; }

        [CsDisplayName("DPTANM")]
        public string DPTANM { get; set; }

        [CsDisplayName("MIPGOS")]
        public bool MIPGOS { get; set; }
        [CsDisplayName("VRKODU")]
        public string VRKODU { get; set; }

    }
}
