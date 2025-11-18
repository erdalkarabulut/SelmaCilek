using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.SA
{
    public class SADEGA : BaseEntity
    {
        [Required]
        [CsDisplayName("SADEGK")]
        [MaxLength(4)]
        public string SADEGK { get; set; }

        [Required]
        [CsDisplayName("TESACT")]
        public decimal TESACT { get; set; }

        [Required]
        [CsDisplayName("TESFZT")]
        public decimal TESFZT { get; set; }

        [Required]
        [CsDisplayName("GNIHT1")]
        public int GNIHT1 { get; set; }

        [Required]
        [CsDisplayName("GNIHT2")]
        public int GNIHT2 { get; set; }

        [Required]
        [CsDisplayName("GNIHT3")]
        public int GNIHT3 { get; set; }

        public SADEGA ShallowCopy()
        {
            return (SADEGA)this.MemberwiseClone();
        }

    }
}
