using System;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SpStokAdresMiktar
    {
        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }
        
        [CsDisplayName("DPADRS")]
        public string DPADRS { get; set; }

        [CsDisplayName("USESTK")]
        public decimal? USESTK { get; set; }
    }
}
