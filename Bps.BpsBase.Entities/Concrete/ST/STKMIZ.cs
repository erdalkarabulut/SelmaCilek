using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STKMIZ : BaseEntity
    {
        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("DGMKTR")]
        public decimal? DGMKTR { get; set; }

        [CsDisplayName("DGSTDG")]
        public decimal? DGSTDG { get; set; }

        [Required]
        [CsDisplayName("MALHSP")]
        public int MALHSP { get; set; }

        [CsDisplayName("KAYORT")]
        public decimal? KAYORT { get; set; }

        [CsDisplayName("STNFIY")]
        public decimal? STNFIY { get; set; }

        [Required]
        [CsDisplayName("MALIYL")]
        public int MALIYL { get; set; }

        [Required]
        [CsDisplayName("MALIAY")]
        public int MALIAY { get; set; }

        [CsDisplayName("DGMKTO")]
        public decimal? DGMKTO { get; set; }

        [CsDisplayName("DGSTDO")]
        public decimal? DGSTDO { get; set; }

        [CsDisplayName("MALHSO")]
        public int? MALHSO { get; set; }

        [CsDisplayName("KAYORO")]
        public decimal? KAYORO { get; set; }

        [CsDisplayName("STNFIO")]
        public decimal? STNFIO { get; set; }

        [CsDisplayName("DGMKTY")]
        public decimal? DGMKTY { get; set; }

        [CsDisplayName("DGSTDY")]
        public decimal? DGSTDY { get; set; }

        [CsDisplayName("MALHSY")]
        public int? MALHSY { get; set; }

        [CsDisplayName("KAYORY")]
        public decimal? KAYORY { get; set; }

        [CsDisplayName("STOFIY")]
        public decimal? STOFIY { get; set; }

        public STKMIZ ShallowCopy()
        {
            return (STKMIZ)this.MemberwiseClone();
        }

    }
}
