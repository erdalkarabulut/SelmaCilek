using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class SthrktMap : BaseEntityMap<STHRKT>
    {
        public SthrktMap()
        {
            ToTable(@"STHRKT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STHRTP).HasColumnName("STHRTP");
            Property(x => x.STFTNO).HasColumnName("STFTNO");
            Property(x => x.STNMIA).HasColumnName("STNMIA");
            Property(x => x.SATIRN).HasColumnName("SATIRN");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
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
            Property(x => x.DVCNKD).HasColumnName("DVCNKD");
            Property(x => x.DVZFYT).HasColumnName("DVZFYT").HasPrecision(18, 3);
            Property(x => x.DVZALT).HasColumnName("DVZALT").HasPrecision(18, 3);
            Property(x => x.STDVCN).HasColumnName("STDVCN");
            Property(x => x.STDFYT).HasColumnName("STDFYT").HasPrecision(18, 3);
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.GRMKTR).HasColumnName("GRMKTR").HasPrecision(18, 3);
            Property(x => x.GROLBR).HasColumnName("GROLBR");
            Property(x => x.GNTUTR).HasColumnName("GNTUTR").HasPrecision(18, 3);
            Property(x => x.VRGORN).HasColumnName("VRGORN").HasPrecision(8, 3);
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.MLKBTR).HasColumnName("MLKBTR");
            Property(x => x.VRGTUT).HasColumnName("VRGTUT").HasPrecision(8, 3);
            Property(x => x.VRGSIZ).HasColumnName("VRGSIZ");
            Property(x => x.OTVORN).HasColumnName("OTVORN");
            Property(x => x.OTVTUT).HasColumnName("OTVTUT").HasPrecision(18, 3);
            Property(x => x.BRTAGR).HasColumnName("BRTAGR").HasPrecision(8, 3);
            Property(x => x.NETAGR).HasColumnName("NETAGR").HasPrecision(8, 3);
            Property(x => x.AGOLKD).HasColumnName("AGOLKD");
            Property(x => x.OIVORN).HasColumnName("OIVORN");
            Property(x => x.OIVTUT).HasColumnName("OIVTUT").HasPrecision(18, 3);
            Property(x => x.TEVKIF).HasColumnName("TEVKIF");
            Property(x => x.ILVKDV).HasColumnName("ILVKDV").HasPrecision(18, 3);
            Property(x => x.PARTIN).HasColumnName("PARTIN");
            Property(x => x.PARTIT).HasColumnName("PARTIT");
            Property(x => x.TSALAN).HasColumnName("TSALAN");
            Property(x => x.TSTARH).HasColumnName("TSTARH");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.USTBLG).HasColumnName("USTBLG");
            Property(x => x.USTKLM).HasColumnName("USTKLM");
            Property(x => x.SADEGK).HasColumnName("SADEGK");
        }
    }
}
