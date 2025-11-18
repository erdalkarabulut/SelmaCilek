using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnorgaMap : BaseEntityMap<GNORGA>
    {
        public GnorgaMap()
        {
            ToTable(@"GNORGA", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ORGTKD).HasColumnName("ORGTKD");
            Property(x => x.TANIMI).HasColumnName("TANIMI");
            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.GNNAME).HasColumnName("GNNAME");
            Property(x => x.GNSNAM).HasColumnName("GNSNAM");
            Property(x => x.PARENT).HasColumnName("PARENT");
            Property(x => x.CHILDD).HasColumnName("CHILDD");
            Property(x => x.SEVIYE).HasColumnName("SEVIYE");
            Property(x => x.ONYSVY).HasColumnName("ONYSVY");
            Property(x => x.SIRASI).HasColumnName("SIRASI");
            Property(x => x.GNONAY).HasColumnName("GNONAY");
            Property(x => x.GNLONY).HasColumnName("GNLONY");
            Property(x => x.GNDFON).HasColumnName("GNDFON");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
