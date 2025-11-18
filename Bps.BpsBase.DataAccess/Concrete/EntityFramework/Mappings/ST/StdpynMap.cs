using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StdpynMap : BaseEntityMap<STDPYN>
    {
        public StdpynMap()
        {
            ToTable(@"STDPYN", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.DPTIPI).HasColumnName("DPTIPI").IsRequired();
            Property(x => x.DPADRS).HasColumnName("DPADRS");
            Property(x => x.DPAMAX).HasColumnName("DPAMAX").HasPrecision(13, 3);
            Property(x => x.DPAMIN).HasColumnName("DPAMIN").HasPrecision(13, 3);
            Property(x => x.DPAIKM).HasColumnName("DPAIKM").HasPrecision(13, 3);
            Property(x => x.DPAKON).HasColumnName("DPAKON").HasPrecision(13, 3);
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
