using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpfbasMap : BaseEntityMap<SPFBAS>
    {
        public SpfbasMap()
        {
            ToTable(@"SPFBAS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.SPHRTP).HasColumnName("SPHRTP").IsRequired();
            Property(x => x.SPFTNO).HasColumnName("SPFTNO").IsRequired();
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRHRKD).HasColumnName("CRHRKD");
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.MALTES).HasColumnName("MALTES");
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.DOVTRH).HasColumnName("DOVTRH");
            Property(x => x.DVCNKD).HasColumnName("DVCNKD").IsRequired();
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.TOPBRT).HasColumnName("TOPBRT");
            Property(x => x.TOPISK).HasColumnName("TOPISK");
            Property(x => x.TOPTUT).HasColumnName("TOPTUT");
            Property(x => x.TOPKDV).HasColumnName("TOPKDV");
            Property(x => x.TOPKDT).HasColumnName("TOPKDT");
            Property(x => x.TOPOTV).HasColumnName("TOPOTV").HasPrecision(18, 3);
            Property(x => x.TERTAR).HasColumnName("TERTAR");
            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.EURFYT).HasColumnName("EURFYT").HasPrecision(18, 5);
            Property(x => x.USDFYT).HasColumnName("USDFYT").HasPrecision(18, 5);
            Property(x => x.TSEVRK).HasColumnName("TSEVRK");
            Property(x => x.TRMDKD).HasColumnName("TRMDKD");
            Property(x => x.TSSRKD).HasColumnName("TSSRKD");
            Property(x => x.GCRTRH).HasColumnName("GCRTRH");
            Property(x => x.NAVMAS).HasColumnName("NAVMAS").HasPrecision(18, 3);
            Property(x => x.DIGMAS).HasColumnName("DIGMAS").HasPrecision(18, 3);
            Property(x => x.FLGKPN).HasColumnName("FLGKPN");
            Property(x => x.SIPVER).HasColumnName("SIPVER");
            Property(x => x.TLBLNO).HasColumnName("TLBLNO");
            Property(x => x.TKBGNO).HasColumnName("TKBGNO");
            Property(x => x.TKTRKD).HasColumnName("TKTRKD");
            Property(x => x.SPUTKD).HasColumnName("SPUTKD");
            Property(x => x.SPDRKD).HasColumnName("SPDRKD");
            Property(x => x.TKDRKD).HasColumnName("TKDRKD");
            Property(x => x.KAYNAK).HasColumnName("KAYNAK");
            Property(x => x.TEVKIF).HasColumnName("TEVKIF");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.DNSMKD).HasColumnName("DNSMKD");
        }
    }
}
