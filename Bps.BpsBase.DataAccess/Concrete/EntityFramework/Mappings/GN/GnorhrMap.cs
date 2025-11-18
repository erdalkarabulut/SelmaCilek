using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnorhrMap : BaseEntityMap<GNORHR>
    {
        public GnorhrMap()
        {
            ToTable(@"GNORHR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ORGKOD).HasColumnName("ORGKOD").IsRequired();
            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.TABLNM).HasColumnName("TABLNM").IsRequired();
            Property(x => x.TABLID).HasColumnName("TABLID").IsRequired();
            Property(x => x.GNONAY).HasColumnName("GNONAY");
            Property(x => x.GNONTR).HasColumnName("GNONTR");
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
