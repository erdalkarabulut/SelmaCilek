using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SP
{
    public class SPKOSL : BaseEntity
    {
        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [CsDisplayName("KOSLID")]
        public int? KOSLID { get; set; }

        public SPKOSL ShallowCopy()
        {
            return (SPKOSL)this.MemberwiseClone();
        }

    }
}
