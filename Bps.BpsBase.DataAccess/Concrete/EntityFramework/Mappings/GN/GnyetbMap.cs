using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnyetbMap : BaseEntityMap<GNYETB>
    {
        public GnyetbMap()
        {
            ToTable(@"GNYETB", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.YetkId).HasColumnName("YetkId").IsRequired();
            Property(x => x.MNUNAM).HasColumnName("MNUNAM").IsRequired();
            Property(x => x.MNUTAG).HasColumnName("MNUTAG").IsRequired();
            Property(x => x.MENUKD).HasColumnName("MENUKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
