using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpfharMap : BaseEntityMap<SPFHAR>
    {
        public SpfharMap()
        {
            ToTable(@"SPFHAR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SPHRTP).HasColumnName("SPHRTP");
            Property(x => x.SPFTNO).HasColumnName("SPFTNO");
            Property(x => x.STNMIA).HasColumnName("STNMIA");
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.EVRAKN).HasColumnName("EVRAKN");
            Property(x => x.SATIRN).HasColumnName("SATIRN");
            Property(x => x.USTPOS).HasColumnName("USTPOS");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH");
            Property(x => x.CRHRKD).HasColumnName("CRHRKD");
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.FTNKLM).HasColumnName("FTNKLM");
            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.GRDEPO).HasColumnName("GRDEPO");
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.BRTAGR).HasColumnName("BRTAGR").HasPrecision(8, 3);
            Property(x => x.NETAGR).HasColumnName("NETAGR").HasPrecision(8, 3);
            Property(x => x.AGOLKD).HasColumnName("AGOLKD");
            Property(x => x.PARTIN).HasColumnName("PARTIN");
            Property(x => x.PARTIT).HasColumnName("PARTIT");
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
            Property(x => x.DVCNKD).HasColumnName("DVCNKD");
            Property(x => x.DVZFYT).HasColumnName("DVZFYT").HasPrecision(18, 3);
            Property(x => x.DVZALT).HasColumnName("DVZALT").HasPrecision(18, 3);
            Property(x => x.STDVCN).HasColumnName("STDVCN");
            Property(x => x.STDFYT).HasColumnName("STDFYT").HasPrecision(18, 3);
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.GRMKTR).HasColumnName("GRMKTR").HasPrecision(18, 3);
            Property(x => x.GROLBR).HasColumnName("GROLBR");
            Property(x => x.VRGSIZ).HasColumnName("VRGSIZ");
            Property(x => x.GFIYAT).HasColumnName("GFIYAT").HasPrecision(18, 5);
            Property(x => x.OPSFYT).HasColumnName("OPSFYT").HasPrecision(18, 5);
            Property(x => x.GNTUTR).HasColumnName("GNTUTR").HasPrecision(18, 3);
            Property(x => x.KDVFLG).HasColumnName("KDVFLG");
            Property(x => x.GISKNT).HasColumnName("GISKNT").HasPrecision(18, 5);
            Property(x => x.VRGORN).HasColumnName("VRGORN").HasPrecision(8, 3);
            Property(x => x.OTVORN).HasColumnName("OTVORN");
            Property(x => x.OTVTUT).HasColumnName("OTVTUT").HasPrecision(18, 3);
            Property(x => x.OIVORN).HasColumnName("OIVORN");
            Property(x => x.OIVTUT).HasColumnName("OIVTUT").HasPrecision(18, 3);
            Property(x => x.VRGTUT).HasColumnName("VRGTUT").HasPrecision(8, 3);
            Property(x => x.MLKBTR).HasColumnName("MLKBTR");
            Property(x => x.TEVKIF).HasColumnName("TEVKIF");
            Property(x => x.ILVKDV).HasColumnName("ILVKDV").HasPrecision(18, 3);
            Property(x => x.TSEVRK).HasColumnName("TSEVRK");
            Property(x => x.TSSATR).HasColumnName("TSSATR");
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.FLGKPN).HasColumnName("FLGKPN");
            Property(x => x.KLNMKTR).HasColumnName("KLNMKTR").HasPrecision(18, 3);
            Property(x => x.SADEGK).HasColumnName("SADEGK");
            Property(x => x.ISPKOD).HasColumnName("ISPKOD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.ORDRID).HasColumnName("ORDRID");
            Property(x => x.LINEID).HasColumnName("LINEID");
        }
    }
}
