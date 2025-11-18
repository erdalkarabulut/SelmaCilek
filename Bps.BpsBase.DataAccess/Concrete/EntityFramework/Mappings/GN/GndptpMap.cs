using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GndptpMap : BaseEntityMap<GNDPTP>
    {
        public GndptpMap()
        {
            ToTable(@"GNDPTP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.DPTIPI).HasColumnName("DPTIPI").IsRequired();
            Property(x => x.DPTIPT).HasColumnName("DPTIPT");
            Property(x => x.DGSTKD).HasColumnName("DGSTKD");
            Property(x => x.DGSTON).HasColumnName("DGSTON");
            Property(x => x.DGSTEK).HasColumnName("DGSTEK");
            Property(x => x.DGSTKR).HasColumnName("DGSTKR");
            Property(x => x.DGSTBL).HasColumnName("DGSTBL");
            Property(x => x.DGSTBR).HasColumnName("DGSTBR");
            Property(x => x.DCSTKD).HasColumnName("DCSTKD");
            Property(x => x.DCSTON).HasColumnName("DCSTON");
            Property(x => x.DCSTTM).HasColumnName("DCSTTM");
            Property(x => x.DCSTBL).HasColumnName("DCSTBL");
            Property(x => x.DCSTAY).HasColumnName("DCSTAY");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
