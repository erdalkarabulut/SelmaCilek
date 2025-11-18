using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.GN
{
    public class GNKOSL : BaseEntity
    {
        [Required]
        [CsDisplayName("PROKOD")]
        [MaxLength(20)]
        public string PROKOD { get; set; }

        [CsDisplayName("KOSULL")]
        [MaxLength(250)]
        public string KOSULL { get; set; }

        [CsDisplayName("LANGKD")]
        [MaxLength(20)]
        public string LANGKD { get; set; }

        [CsDisplayName("DEFALT")]
        public bool? DEFALT { get; set; }

        public GNKOSL ShallowCopy()
        {
            return (GNKOSL)this.MemberwiseClone();
        }

    }
}
