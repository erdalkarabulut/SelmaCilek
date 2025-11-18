using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GndpnoMap : BaseEntityMap<GNDPNO>
    {
        public GndpnoMap()
        {
            ToTable(@"GNDPNO", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
