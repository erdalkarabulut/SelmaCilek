using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmadrtMap : BaseEntityMap<WMADRT>
    {
        public WmadrtMap()
        {
            ToTable(@"WMADRT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.DPTIPI).HasColumnName("DPTIPI").IsRequired();
            Property(x => x.DPADRS).HasColumnName("DPADRS");
            Property(x => x.DPALKD).HasColumnName("DPALKD");
            Property(x => x.DPATKD).HasColumnName("DPATKD");
            Property(x => x.DPACKD).HasColumnName("DPACKD");
            Property(x => x.DGSTBL).HasColumnName("DGSTBL");
            Property(x => x.DCSTBL).HasColumnName("DCSTBL");
            Property(x => x.STARIH).HasColumnName("STARIH");
            Property(x => x.DPASRL).HasColumnName("DPASRL");
            Property(x => x.DPCSRL).HasColumnName("DPCSRL");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
