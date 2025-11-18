using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnkukrMap : BaseEntityMap<GNKUKR>
    {
        public GnkukrMap()
        {
            ToTable(@"GNKUKR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.KARTKD).HasColumnName("KARTKD").IsRequired();
            Property(x => x.GNPOSI).HasColumnName("GNPOSI").IsRequired();
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
        }
    }
}
