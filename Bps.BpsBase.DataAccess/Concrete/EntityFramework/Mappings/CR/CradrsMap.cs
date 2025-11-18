using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR
{
    public class CradrsMap : BaseEntityMap<CRADRS>
    {
        public CradrsMap()
        {
            ToTable(@"CRADRS", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.CRKODU,x.TANIMI
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.ADRESS).HasColumnName("ADRESS").IsRequired();
            Property(x => x.MAHAKD).HasColumnName("MAHAKD");
            Property(x => x.SEMTKD).HasColumnName("SEMTKD");
            Property(x => x.ILCEKD).HasColumnName("ILCEKD");
            Property(x => x.SEHRKD).HasColumnName("SEHRKD");
            Property(x => x.ULKEKD).HasColumnName("ULKEKD").IsRequired();
            Property(x => x.ISYTEL).HasColumnName("ISYTEL");
            Property(x => x.CEPTEL).HasColumnName("CEPTEL");
            Property(x => x.ISYFAX).HasColumnName("ISYFAX");
            Property(x => x.GNONOT).HasColumnName("GNONOT");
            Property(x => x.GPSENL).HasColumnName("GPSENL");
            Property(x => x.GPSBOY).HasColumnName("GPSBOY");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
