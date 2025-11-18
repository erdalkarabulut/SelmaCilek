using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN
{
    public class SnsnkrMap : BaseEntityMap<SNSNKR>
    {
        public SnsnkrMap()
        {
            ToTable(@"SNSNKR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SNFKOD).HasColumnName("SNFKOD").IsRequired();
            Property(x => x.KRKTNO).HasColumnName("KRKTNO").IsRequired();
            Property(x => x.SATIRN).HasColumnName("SATIRN").IsRequired();
        }
    }
}
