using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnevrkMap : BaseEntityMap<GNEVRK>
    {
        public GnevrkMap()
        {
            ToTable(@"GNEVRK", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TABLNM).HasColumnName("TABLNM").IsRequired();
            Property(x => x.TEKNAD).HasColumnName("TEKNAD").IsRequired();
            Property(x => x.ISLTUR).HasColumnName("ISLTUR").IsRequired();
            Property(x => x.GNYEAR).HasColumnName("GNYEAR").IsRequired();
            Property(x => x.GNONEK).HasColumnName("GNONEK");
            Property(x => x.KARSAY).HasColumnName("KARSAY").IsRequired();
            Property(x => x.BASDEG).HasColumnName("BASDEG").IsRequired();
            Property(x => x.BITDEG).HasColumnName("BITDEG").IsRequired();
            Property(x => x.KALDEG).HasColumnName("KALDEG").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
