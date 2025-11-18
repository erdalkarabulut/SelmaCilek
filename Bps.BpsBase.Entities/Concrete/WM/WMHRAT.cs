using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.WM
{
    public class WMHRAT : BaseEntity
    {
        [Required]
        [CsDisplayName("STFTNO")]
        public int STFTNO { get; set; }

        [Required]
        [CsDisplayName("WMHRKD")]
        [MaxLength(20)]
        public string WMHRKD { get; set; }

        public WMHRAT ShallowCopy()
        {
            return (WMHRAT)this.MemberwiseClone();
        }

    }
}
