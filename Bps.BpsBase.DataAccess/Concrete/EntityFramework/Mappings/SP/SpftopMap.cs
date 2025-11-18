using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpftopMap : BaseEntityMap<SPFTOP>
    {
        public SpftopMap()
        {
            ToTable(@"SPFTOP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.SPHRTP).HasColumnName("SPHRTP").IsRequired();
            Property(x => x.SPFTNO).HasColumnName("SPFTNO").IsRequired();
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.MALTES).HasColumnName("MALTES");
            Property(x => x.SPKONU).HasColumnName("SPKONU");
            Property(x => x.SPBASL).HasColumnName("SPBASL");
            Property(x => x.GNTUTR).HasColumnName("GNTUTR").HasPrecision(18, 3);
            Property(x => x.GNMTRH).HasColumnName("GNMTRH").HasPrecision(18, 3);
            Property(x => x.VRGORN).HasColumnName("VRGORN").HasPrecision(8, 3);
            Property(x => x.DVCNKD).HasColumnName("DVCNKD");
            Property(x => x.DVZTUT).HasColumnName("DVZTUT").HasPrecision(18, 3);
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
