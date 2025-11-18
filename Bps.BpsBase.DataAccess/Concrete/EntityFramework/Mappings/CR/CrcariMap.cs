using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR
{
    public class CrcariMap : BaseEntityMap<CRCARI>
    {
        public CrcariMap()
        {
            ToTable(@"CRCARI", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.CRKODU
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CRHRKD).HasColumnName("CRHRKD").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.ADCRKD).HasColumnName("ADCRKD");
            Property(x => x.ASCRKD).HasColumnName("ASCRKD");
            Property(x => x.CRUNV1).HasColumnName("CRUNV1").IsRequired();
            Property(x => x.CRUNV2).HasColumnName("CRUNV2");
            Property(x => x.CRBGKD).HasColumnName("CRBGKD");
            Property(x => x.CRSACN).HasColumnName("CRSACN");
            Property(x => x.CRSSCN).HasColumnName("CRSSCN");
            Property(x => x.CRHSP1).HasColumnName("CRHSP1");
            Property(x => x.CRHSP2).HasColumnName("CRHSP2");
            Property(x => x.CRHSP3).HasColumnName("CRHSP3");
            Property(x => x.CRDVCN).HasColumnName("CRDVCN");
            Property(x => x.CRDVC1).HasColumnName("CRDVC1");
            Property(x => x.CRDVC2).HasColumnName("CRDVC2");
            Property(x => x.CRVDYZ).HasColumnName("CRVDYZ");
            Property(x => x.CRVDY1).HasColumnName("CRVDY1");
            Property(x => x.CRVDY2).HasColumnName("CRVDY2");
            Property(x => x.KURHSK).HasColumnName("KURHSK");
            Property(x => x.VERGDA).HasColumnName("VERGDA").IsRequired();
            Property(x => x.VERGNO).HasColumnName("VERGNO").IsRequired();
            Property(x => x.TSICNO).HasColumnName("TSICNO");
            Property(x => x.VERKML).HasColumnName("VERKML");
            Property(x => x.CRODCN).HasColumnName("CRODCN");
            Property(x => x.FTADNO).HasColumnName("FTADNO");
            Property(x => x.SVADNO).HasColumnName("SVADNO");
            Property(x => x.CRAKOD).HasColumnName("CRAKOD");
            Property(x => x.EFATUR).HasColumnName("EFATUR");
            Property(x => x.ODGUNU).HasColumnName("ODGUNU");
            Property(x => x.ODTERC).HasColumnName("ODTERC");
            Property(x => x.OTVTEV).HasColumnName("OTVTEV");
            Property(x => x.CRSKOD).HasColumnName("CRSKOD");
            Property(x => x.GNMAIL).HasColumnName("GNMAIL");
            Property(x => x.GNWEBA).HasColumnName("GNWEBA");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
