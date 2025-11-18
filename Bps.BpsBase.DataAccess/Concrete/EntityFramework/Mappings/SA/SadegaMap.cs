using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SA
{
    public class SadegaMap : BaseEntityMap<SADEGA>
    {
        public SadegaMap()
        {
            ToTable(@"SADEGA", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SADEGK).HasColumnName("SADEGK").IsRequired();
            Property(x => x.TESACT).HasColumnName("TESACT").IsRequired().HasPrecision(8, 3);
            Property(x => x.TESFZT).HasColumnName("TESFZT").IsRequired().HasPrecision(8, 3);
            Property(x => x.GNIHT1).HasColumnName("GNIHT1").IsRequired();
            Property(x => x.GNIHT2).HasColumnName("GNIHT2").IsRequired();
            Property(x => x.GNIHT3).HasColumnName("GNIHT3").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
