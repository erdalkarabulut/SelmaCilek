using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpodtbMap : BaseEntityMap<SPODTB>
    {
        public SpodtbMap()
        {
            ToTable(@"SPODTB", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN").IsRequired();
            Property(x => x.ODMSKL).HasColumnName("ODMSKL").IsRequired();
            Property(x => x.ODMTRH).HasColumnName("ODMTRH").IsRequired();
            Property(x => x.ODMACK).HasColumnName("ODMACK");
            Property(x => x.ODMTTR).HasColumnName("ODMTTR").IsRequired().HasPrecision(18, 3);
            Property(x => x.DVCNKD).HasColumnName("DVCNKD").IsRequired();
            Property(x => x.ODMORN).HasColumnName("ODMORN").IsRequired().HasPrecision(18, 2);
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
