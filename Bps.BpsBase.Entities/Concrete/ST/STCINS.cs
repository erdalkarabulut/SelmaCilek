using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STCINS : BaseEntity
    {
        [CsDisplayName("STCNSK")]
        public int? STCNSK { get; set; }

        [CsDisplayName("STCSNM")]
        public string STCSNM { get; set; }

    }
}
