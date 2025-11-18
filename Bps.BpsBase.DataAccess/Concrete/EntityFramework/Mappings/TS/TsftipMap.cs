using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.TS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.TS
{
    public class TsftipMap : BaseEntityMap<TSFTIP>
    {
        public TsftipMap()
        {
            ToTable(@"TSFTIP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TSFTNO).HasColumnName("TSFTNO").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.TSHRTP).HasColumnName("TSHRTP").IsRequired();
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.GNONAY).HasColumnName("GNONAY").IsRequired();
            Property(x => x.GNEVID).HasColumnName("GNEVID");
            Property(x => x.GNACIK).HasColumnName("GNACIK").IsRequired();
            Property(x => x.FUNCNM).HasColumnName("FUNCNM");
            Property(x => x.DIZAYN).HasColumnName("DIZAYN");
            Property(x => x.FTFTNO).HasColumnName("FTFTNO").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
