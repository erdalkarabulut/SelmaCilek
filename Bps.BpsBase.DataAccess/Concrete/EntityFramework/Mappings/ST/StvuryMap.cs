using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StvuryMap : BaseEntityMap<STVURY>
    {
        public StvuryMap()
        {
            ToTable(@"STVURY", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.ABCGOS).HasColumnName("ABCGOS");
            Property(x => x.STNGKD).HasColumnName("STNGKD");
            Property(x => x.PLNTES).HasColumnName("PLNTES").HasPrecision(3, 0);
            Property(x => x.MGSURE).HasColumnName("MGSURE").HasPrecision(3, 0);
            Property(x => x.YNSPSV).HasColumnName("YNSPSV").IsRequired().HasPrecision(13, 3);
            Property(x => x.EMNSTK).HasColumnName("EMNSTK").IsRequired().HasPrecision(13, 3);
            Property(x => x.MPPRTB).HasColumnName("MPPRTB").HasPrecision(13, 3);
            Property(x => x.TEDTUR).HasColumnName("TEDTUR");
            Property(x => x.ASPRTB).HasColumnName("ASPRTB").HasPrecision(13, 3);
            Property(x => x.AZPRTB).HasColumnName("AZPRTB").HasPrecision(13, 3);
            Property(x => x.YUVARL).HasColumnName("YUVARL").HasPrecision(13, 3);
            Property(x => x.SAPRTB).HasColumnName("SAPRTB").HasPrecision(13, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD");
            Property(x => x.URDEPO).HasColumnName("URDEPO");
            Property(x => x.BILISK).HasColumnName("BILISK").HasPrecision(5, 2);
            Property(x => x.URNGST).HasColumnName("URNGST");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
