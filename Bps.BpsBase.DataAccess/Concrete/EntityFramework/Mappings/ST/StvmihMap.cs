using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StvmihMap : BaseEntityMap<STVMIH>
    {
        public StvmihMap()
        {
            ToTable(@"STVMIH", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.MALHSP).HasColumnName("MALHSP").IsRequired();
            Property(x => x.KAYORT).HasColumnName("KAYORT").HasPrecision(13, 3);
            Property(x => x.STNFIY).HasColumnName("STNFIY").HasPrecision(13, 3);
            Property(x => x.DGMKTR).HasColumnName("DGMKTR").HasPrecision(13, 3);
            Property(x => x.DGSTDG).HasColumnName("DGSTDG").HasPrecision(13, 3);
            Property(x => x.MALIYL).HasColumnName("MALIYL").IsRequired();
            Property(x => x.MALIAY).HasColumnName("MALIAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
