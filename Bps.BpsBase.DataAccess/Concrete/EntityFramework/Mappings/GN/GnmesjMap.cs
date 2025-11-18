using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnmesjMap : BaseEntityMap<GNMESJ>
    {
        public GnmesjMap()
        {
            ToTable(@"GNMESJ", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.LANGKD).HasColumnName("LANGKD").IsRequired();
            Property(x => x.MESJKD).HasColumnName("MESJKD").IsRequired();
            Property(x => x.MESJNO).HasColumnName("MESJNO").IsRequired();
            Property(x => x.MSTEXT).HasColumnName("MSTEXT").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
