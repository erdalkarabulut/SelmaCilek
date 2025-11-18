using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.TS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.TS
{
    public class TsfbasMap : BaseEntityMap<TSFBAS>
    {
        public TsfbasMap()
        {
            ToTable(@"TSFBAS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.TSHRTP).HasColumnName("TSHRTP").IsRequired();
            Property(x => x.TSFTNO).HasColumnName("TSFTNO").IsRequired();
            Property(x => x.EVRSER).HasColumnName("EVRSER");
            Property(x => x.EVRSRN).HasColumnName("EVRSRN");
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.MALTES).HasColumnName("MALTES");
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.TERTAR).HasColumnName("TERTAR");
            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
