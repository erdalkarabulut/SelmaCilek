using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA
{
    public class UamltyMap : BaseEntityMap<UAMLTY>
    {
        public UamltyMap()
        {
            ToTable(@"UAMLTY", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.UAKLNT).HasColumnName("UAKLNT");
            Property(x => x.STMLTR).HasColumnName("STMLTR").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
