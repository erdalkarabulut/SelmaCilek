using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STALTG : BaseEntity
    {
        [CsDisplayName("STANAK")]
        public string STANAK { get; set; }

        [CsDisplayName("STALTK")]
        public string STALTK { get; set; }

        [CsDisplayName("STALTN")]
        public string STALTN { get; set; }

    }
}
