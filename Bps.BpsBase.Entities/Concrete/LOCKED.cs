using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Concrete
{
    public class LOCKED : IEntity
    {
        public int Id { get; set; }

        [CsDisplayName("SIRKID")]
        public int SIRKID { get; set; }

        [CsDisplayName("TABLNM")]
        public string TABLNM { get; set; }

        [CsDisplayName("KULKOD")]
        public string KULKOD { get; set; }

        [CsDisplayName("LOCKID")]
        public int? LOCKID { get; set; }

        [CsDisplayName("LCKDAT")]
        public DateTime? LCKDAT { get; set; }

        [CsDisplayName("LCTIME")]
        public int? LCTIME { get; set; }

        [CsDisplayName("CHKCTR")]
        public bool CHKCTR { get; set; }

        public LOCKED ShallowCopy()
        {
            return (LOCKED)this.MemberwiseClone();
        }

    }
}
