using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StftipMap : BaseEntityMap<STFTIP>
    {
        public StftipMap()
        {
            ToTable(@"STFTIP", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STFTNO
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.GNONAY).HasColumnName("GNONAY").IsRequired();
            Property(x => x.GNEVID).HasColumnName("GNEVID");
            Property(x => x.GNACIK).HasColumnName("GNACIK").IsRequired();
            Property(x => x.FUNCNM).HasColumnName("FUNCNM");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
