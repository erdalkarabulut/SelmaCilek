using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN
{
    public class SnkrtyMap : BaseEntityMap<SNKRTY>
    {
        public SnkrtyMap()
        {
            ToTable(@"SNKRTY", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.OBJKEY).HasColumnName("OBJKEY");
            Property(x => x.SNFKOD).HasColumnName("SNFKOD").IsRequired();
            Property(x => x.KRKTNO).HasColumnName("KRKTNO").IsRequired();
            Property(x => x.GVALUE).HasColumnName("GVALUE").IsRequired();
        }
    }
}
