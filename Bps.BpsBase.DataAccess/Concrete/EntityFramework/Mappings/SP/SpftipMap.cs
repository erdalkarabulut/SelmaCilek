using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpftipMap : BaseEntityMap<SPFTIP>
    {
        public SpftipMap()
        {
            ToTable(@"SPFTIP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SPFTNO).HasColumnName("SPFTNO").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.SPHRTP).HasColumnName("SPHRTP").IsRequired();
            Property(x => x.SPHRTY).HasColumnName("SPHRTY");
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.GNONAY).HasColumnName("GNONAY").IsRequired();
            Property(x => x.GNEVID).HasColumnName("GNEVID");
            Property(x => x.GNACIK).HasColumnName("GNACIK").IsRequired();
            Property(x => x.FUNCNM).HasColumnName("FUNCNM");
            Property(x => x.DIZAYN).HasColumnName("DIZAYN");
            Property(x => x.KDVFLG).HasColumnName("KDVFLG");
            Property(x => x.OTVFLG).HasColumnName("OTVFLG");
            Property(x => x.TSFTNO).HasColumnName("TSFTNO").IsRequired();
            Property(x => x.FTFTNO).HasColumnName("FTFTNO").IsRequired();
            Property(x => x.STFYNO).HasColumnName("STFYNO");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.ORGTKD).HasColumnName("ORGTKD");
        }
    }
}
