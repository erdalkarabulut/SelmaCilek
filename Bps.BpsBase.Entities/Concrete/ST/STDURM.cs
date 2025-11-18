using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STDURM : BaseEntity
    {
        [CsDisplayName("STDKOD")]
        public string STDKOD { get; set; }

        [CsDisplayName("STDNAM")]
        public string STDNAM { get; set; }

    }
}
