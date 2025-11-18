using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsrevzMap : BaseEntityMap<ISREVZ>
    {
        public IsrevzMap()
        {
            ToTable(@"ISREVZ", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.BASTAR).HasColumnName("BASTAR");
            Property(x => x.BITTAR).HasColumnName("BITTAR");
            Property(x => x.URTONY).HasColumnName("URTONY");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
