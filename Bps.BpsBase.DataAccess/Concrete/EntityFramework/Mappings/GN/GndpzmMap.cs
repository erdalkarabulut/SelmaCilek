using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GndpzmMap : BaseEntityMap<GNDPZM>
    {
        public GndpzmMap()
        {
            ToTable(@"GNDPZM", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.PERSID).HasColumnName("PERSID").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.DPTANM).HasColumnName("DPTANM").IsRequired();
            Property(x => x.MOBILE).HasColumnName("MOBILE").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
