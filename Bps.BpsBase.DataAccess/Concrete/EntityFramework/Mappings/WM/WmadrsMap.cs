using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmadrsMap : BaseEntityMap<WMADRS>
    {
        public WmadrsMap()
        {
            ToTable(@"WMADRS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.WMASNO).HasColumnName("WMASNO");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.DPTIPI).HasColumnName("DPTIPI").IsRequired();
            Property(x => x.DPADRS).HasColumnName("DPADRS");
            Property(x => x.DGSTBL).HasColumnName("DGSTBL");
            Property(x => x.DCSTBL).HasColumnName("DCSTBL");
            Property(x => x.STARIH).HasColumnName("STARIH");
            Property(x => x.SDPTAR).HasColumnName("SDPTAR");
            Property(x => x.SDETAR).HasColumnName("SDETAR");
            Property(x => x.STHRTP).HasColumnName("STHRTP");
            Property(x => x.STFTNO).HasColumnName("STFTNO");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH");
            Property(x => x.SATIRN).HasColumnName("SATIRN");
            Property(x => x.DPBRNO).HasColumnName("DPBRNO");
            Property(x => x.TPLSTK).HasColumnName("TPLSTK").HasPrecision(13, 3);
            Property(x => x.USESTK).HasColumnName("USESTK").HasPrecision(13, 3);
            Property(x => x.DPLSTK).HasColumnName("DPLSTK").HasPrecision(13, 3);
            Property(x => x.DPCSTK).HasColumnName("DPCSTK").HasPrecision(13, 3);
            Property(x => x.PARTIN).HasColumnName("PARTIN");
            Property(x => x.PARTIT).HasColumnName("PARTIT");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
