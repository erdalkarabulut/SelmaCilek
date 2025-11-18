using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.TS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.TS
{
    public class TsfharMap : BaseEntityMap<TSFHAR>
    {
        public TsfharMap()
        {
            ToTable(@"TSFHAR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TSHRTP).HasColumnName("TSHRTP");
            Property(x => x.TSFTNO).HasColumnName("TSFTNO");
            Property(x => x.STNMIA).HasColumnName("STNMIA");
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.SATIRN).HasColumnName("SATIRN");
            Property(x => x.USTPOS).HasColumnName("USTPOS");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.FTNKLM).HasColumnName("FTNKLM");
            Property(x => x.PARTIN).HasColumnName("PARTIN");
            Property(x => x.ISM1KD).HasColumnName("ISM1KD");
            Property(x => x.ISM2KD).HasColumnName("ISM2KD");
            Property(x => x.ISM3KD).HasColumnName("ISM3KD");
            Property(x => x.ISMSM1).HasColumnName("ISMSM1");
            Property(x => x.ISMSM2).HasColumnName("ISMSM2");
            Property(x => x.ISMSM3).HasColumnName("ISMSM3");
            Property(x => x.ISMSD1).HasColumnName("ISMSD1").HasPrecision(18, 3);
            Property(x => x.ISMSD2).HasColumnName("ISMSD2").HasPrecision(18, 3);
            Property(x => x.ISMSD3).HasColumnName("ISMSD3").HasPrecision(18, 3);
            Property(x => x.PROFLG).HasColumnName("PROFLG");
            Property(x => x.CRHRKD).HasColumnName("CRHRKD");
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.GRMKTR).HasColumnName("GRMKTR").HasPrecision(18, 3);
            Property(x => x.GROLBR).HasColumnName("GROLBR");
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.MLKBTR).HasColumnName("MLKBTR");
            Property(x => x.BRTAGR).HasColumnName("BRTAGR").HasPrecision(8, 3);
            Property(x => x.NETAGR).HasColumnName("NETAGR").HasPrecision(8, 3);
            Property(x => x.AGOLKD).HasColumnName("AGOLKD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
