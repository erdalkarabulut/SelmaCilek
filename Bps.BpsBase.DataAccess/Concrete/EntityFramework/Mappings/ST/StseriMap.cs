using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StseriMap : BaseEntityMap<STSERI>
    {
        public StseriMap()
        {
            ToTable(@"STSERI", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SERINO).HasColumnName("SERINO").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.MALGRS).HasColumnName("MALGRS").IsRequired();
            Property(x => x.MALCKS).HasColumnName("MALCKS").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
