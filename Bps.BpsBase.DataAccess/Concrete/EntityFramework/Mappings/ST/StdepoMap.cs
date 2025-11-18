using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StdepoMap : BaseEntityMap<STDEPO>
    {
        public StdepoMap()
        {
            ToTable(@"STDEPO", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STKODU,x.URYRKD,x.DPKODU
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.ENBLKJ).HasColumnName("ENBLKJ").IsRequired();
            Property(x => x.USESTK).HasColumnName("USESTK").IsRequired().HasPrecision(13, 3);
            Property(x => x.BLKSTK).HasColumnName("BLKSTK").IsRequired().HasPrecision(13, 3);
            Property(x => x.MIPGOS).HasColumnName("MIPGOS").IsRequired();
            Property(x => x.TEDKOD).HasColumnName("TEDKOD");
            Property(x => x.DPADRS).HasColumnName("DPADRS");
            Property(x => x.ULKEKD).HasColumnName("ULKEKD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
