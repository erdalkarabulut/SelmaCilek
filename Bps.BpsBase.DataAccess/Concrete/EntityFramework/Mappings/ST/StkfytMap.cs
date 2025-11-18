using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StkfytMap : BaseEntityMap<STKFYT>
    {
        public StkfytMap()
        {
            ToTable(@"STKFYT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.DVCNKD).HasColumnName("DVCNKD").IsRequired();
            Property(x => x.KDVFLG).HasColumnName("KDVFLG");
            Property(x => x.GISKNT1).HasColumnName("GISKNT1").HasPrecision(18, 5);
            Property(x => x.GISKNT2).HasColumnName("GISKNT2").HasPrecision(18, 5);
            Property(x => x.GISKNT3).HasColumnName("GISKNT3").HasPrecision(18, 5);
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.BASTAR).HasColumnName("BASTAR");
            Property(x => x.BITTAR).HasColumnName("BITTAR");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
