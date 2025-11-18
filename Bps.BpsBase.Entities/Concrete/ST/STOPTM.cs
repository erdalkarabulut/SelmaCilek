using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.ST
{
    public class STOPTM : BaseEntity
    {
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [CsDisplayName("STKNAM")]
        [MaxLength(100)]
        public string STKNAM { get; set; }

        [CsDisplayName("BELGEN")]
        [MaxLength(20)]
        public string BELGEN { get; set; }

        [CsDisplayName("MCBELG")]
        [MaxLength(20)]
        public string MCBELG { get; set; }

        [CsDisplayName("MGBELG")]
        [MaxLength(20)]
        public string MGBELG { get; set; }

        [CsDisplayName("OPTMZS")]
        public byte[] OPTMZS { get; set; }

        public STOPTM ShallowCopy()
        {
            return (STOPTM)this.MemberwiseClone();
        }

    }
}
