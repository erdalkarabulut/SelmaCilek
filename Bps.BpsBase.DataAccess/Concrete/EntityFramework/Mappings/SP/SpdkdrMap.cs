using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpdkdrMap : BaseEntityMap<SPDKDR>
    {
        public SpdkdrMap()
        {
            ToTable(@"SPDKDR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.DURKOD).HasColumnName("DURKOD");
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.SPBLKJ).HasColumnName("SPBLKJ").IsRequired();
            Property(x => x.TSBLKJ).HasColumnName("TSBLKJ").IsRequired();
        }
    }
}
