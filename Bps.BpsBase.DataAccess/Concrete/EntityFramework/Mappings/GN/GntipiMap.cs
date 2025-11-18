using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GntipiMap : BaseEntityMap<GNTIPI>
    {
        public GntipiMap()
        {
            ToTable(@"GNTIPI", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TIPKOD).HasColumnName("TIPKOD").IsRequired();
            Property(x => x.TIPADI).HasColumnName("TIPADI").IsRequired();
            Property(x => x.TEKNAD).HasColumnName("TEKNAD").IsRequired();
            Property(x => x.UTPKOD).HasColumnName("UTPKOD");
            Property(x => x.HRKTBL).HasColumnName("HRKTBL").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
