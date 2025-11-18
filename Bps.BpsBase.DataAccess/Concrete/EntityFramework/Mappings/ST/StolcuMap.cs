using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StolcuMap : BaseEntityMap<STOLCU>
    {
        public StolcuMap()
        {
            ToTable(@"STOLCU", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.OLCHDF).HasColumnName("OLCHDF").IsRequired();
            Property(x => x.BOLNEN).HasColumnName("BOLNEN").IsRequired();
            Property(x => x.BOLLEN).HasColumnName("BOLLEN").IsRequired();
            Property(x => x.EANTKD).HasColumnName("EANTKD");
            Property(x => x.EANKOD).HasColumnName("EANKOD");
            Property(x => x.UZUNLK).HasColumnName("UZUNLK").HasPrecision(8, 3);
            Property(x => x.GENSLK).HasColumnName("GENSLK").HasPrecision(8, 3);
            Property(x => x.YUKSLK).HasColumnName("YUKSLK").HasPrecision(8, 3);
            Property(x => x.UGYBKD).HasColumnName("UGYBKD");
            Property(x => x.BRTAGR).HasColumnName("BRTAGR").HasPrecision(8, 3);
            Property(x => x.NETAGR).HasColumnName("NETAGR").HasPrecision(8, 3);
            Property(x => x.AGOLKD).HasColumnName("AGOLKD");
            Property(x => x.GNHACM).HasColumnName("GNHACM").HasPrecision(8, 3);
            Property(x => x.HCOLKD).HasColumnName("HCOLKD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
