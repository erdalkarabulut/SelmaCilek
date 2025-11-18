using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SphrplMap : BaseEntityMap<SPHRPL>
    {
        public SphrplMap()
        {
            ToTable(@"SPHRPL", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN").IsRequired();
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.URAKOD).HasColumnName("URAKOD").IsRequired();
            Property(x => x.SATIRN).HasColumnName("SATIRN").IsRequired();
            Property(x => x.PKKODU).HasColumnName("PKKODU").IsRequired();
            Property(x => x.PKTNAM).HasColumnName("PKTNAM").IsRequired();
            Property(x => x.PLNMKT).HasColumnName("PLNMKT").IsRequired().HasPrecision(18, 3);
            Property(x => x.ACIKLM).HasColumnName("ACIKLM");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
