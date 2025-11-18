using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STANAG : BaseEntity
    {
        [CsDisplayName("STANAK")]
        public string STANAK { get; set; }

        [CsDisplayName("STANAN")]
        public string STANAN { get; set; }

    }
}
