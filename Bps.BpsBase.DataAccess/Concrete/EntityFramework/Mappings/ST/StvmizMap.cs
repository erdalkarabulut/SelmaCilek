using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StvmizMap : BaseEntityMap<STVMIZ>
    {
        public StvmizMap()
        {
            ToTable(@"STVMIZ", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.DGMKTR).HasColumnName("DGMKTR").HasPrecision(13, 3);
            Property(x => x.DGSTDG).HasColumnName("DGSTDG").HasPrecision(13, 3);
            Property(x => x.MALHSP).HasColumnName("MALHSP").IsRequired();
            Property(x => x.KAYORT).HasColumnName("KAYORT").HasPrecision(13, 3);
            Property(x => x.STNFIY).HasColumnName("STNFIY").HasPrecision(13, 3);
            Property(x => x.MALIYL).HasColumnName("MALIYL").IsRequired();
            Property(x => x.MALIAY).HasColumnName("MALIAY").IsRequired();
            Property(x => x.DGMKTO).HasColumnName("DGMKTO").HasPrecision(13, 3);
            Property(x => x.DGSTDO).HasColumnName("DGSTDO").HasPrecision(13, 3);
            Property(x => x.MALHSO).HasColumnName("MALHSO");
            Property(x => x.KAYORO).HasColumnName("KAYORO").HasPrecision(13, 3);
            Property(x => x.STNFIO).HasColumnName("STNFIO").HasPrecision(13, 3);
            Property(x => x.DGMKTY).HasColumnName("DGMKTY").HasPrecision(13, 3);
            Property(x => x.DGSTDY).HasColumnName("DGSTDY").HasPrecision(13, 3);
            Property(x => x.MALHSY).HasColumnName("MALHSY");
            Property(x => x.KAYORY).HasColumnName("KAYORY").HasPrecision(13, 3);
            Property(x => x.STOFIY).HasColumnName("STOFIY").HasPrecision(13, 3);
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
