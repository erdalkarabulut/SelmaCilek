using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class SthbasMap : BaseEntityMap<STHBAS>
    {
        public SthbasMap()
        {
            ToTable(@"STHBAS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.EVRSER).HasColumnName("EVRSER");
            Property(x => x.EVRSRN).HasColumnName("EVRSRN");
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.DOVTRH).HasColumnName("DOVTRH");
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.TOPBRT).HasColumnName("TOPBRT");
            Property(x => x.TOPISK).HasColumnName("TOPISK");
            Property(x => x.TOPTUT).HasColumnName("TOPTUT");
            Property(x => x.TOPKDV).HasColumnName("TOPKDV");
            Property(x => x.TOPKDT).HasColumnName("TOPKDT");
            Property(x => x.OPTMZS).HasColumnName("OPTMZS");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
