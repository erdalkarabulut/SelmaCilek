using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR
{
    public class CrcafyMap : BaseEntityMap<CRCAFY>
    {
        public CrcafyMap()
        {
            ToTable(@"CRCAFY", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.VARSAY).HasColumnName("VARSAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
