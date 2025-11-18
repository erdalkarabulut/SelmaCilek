using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StkartMap : BaseEntityMap<STKART>
    {
        public StkartMap()
        {
            ToTable(@"STKART", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STKODU,x.ACTIVE,x.SLINDI
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.STANKD).HasColumnName("STANKD").IsRequired();
            Property(x => x.STALKD).HasColumnName("STALKD");
            Property(x => x.STG1KD).HasColumnName("STG1KD");
            Property(x => x.STG2KD).HasColumnName("STG2KD");
            Property(x => x.STG3KD).HasColumnName("STG3KD");
            Property(x => x.STMLTR).HasColumnName("STMLTR").IsRequired();
            Property(x => x.STEKOD).HasColumnName("STEKOD");
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.SADEGK).HasColumnName("SADEGK");
            Property(x => x.SAOLKD).HasColumnName("SAOLKD").IsRequired();
            Property(x => x.MALGKD).HasColumnName("MALGKD");
            Property(x => x.BRTAGR).HasColumnName("BRTAGR").HasPrecision(8, 3);
            Property(x => x.NETAGR).HasColumnName("NETAGR").HasPrecision(8, 3);
            Property(x => x.AGOLKD).HasColumnName("AGOLKD");
            Property(x => x.GNHACM).HasColumnName("GNHACM").HasPrecision(8, 3);
            Property(x => x.HCOLKD).HasColumnName("HCOLKD");
            Property(x => x.EANTKD).HasColumnName("EANTKD");
            Property(x => x.EANKOD).HasColumnName("EANKOD");
            Property(x => x.UZUNLK).HasColumnName("UZUNLK").HasPrecision(8, 3);
            Property(x => x.GENSLK).HasColumnName("GENSLK").HasPrecision(8, 3);
            Property(x => x.YUKSLK).HasColumnName("YUKSLK").HasPrecision(8, 3);
            Property(x => x.UGYBKD).HasColumnName("UGYBKD");
            Property(x => x.KDVORN).HasColumnName("KDVORN").HasPrecision(8, 3);
            Property(x => x.PARTIT).HasColumnName("PARTIT");
            Property(x => x.FANTOM).HasColumnName("FANTOM");
            Property(x => x.PKTSAY).HasColumnName("PKTSAY");
            Property(x => x.GTIPNO).HasColumnName("GTIPNO");
            Property(x => x.UROPTB).HasColumnName("UROPTB");
            Property(x => x.STKIMG).HasColumnName("STKIMG");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.STYKOD).HasColumnName("STYKOD");
        }
    }
}
