using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.UR
{
    public class URAGVR : BaseEntity
    {
        public URAGVR ShallowCopy()
        {
            return (URAGVR)this.MemberwiseClone();
        }

    }
}
