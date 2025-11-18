using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SprezvMap : BaseEntityMap<SPREZV>
    {
        public SprezvMap()
        {
            ToTable(@"SPREZV", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.SPBLNO).HasColumnName("SPBLNO");
            Property(x => x.SPBLTR).HasColumnName("SPBLTR");
            Property(x => x.SATIRN).HasColumnName("SATIRN");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.SPMKTR).HasColumnName("SPMKTR").HasPrecision(18, 3);
            Property(x => x.RZMKTR).HasColumnName("RZMKTR").HasPrecision(18, 3);
            Property(x => x.KLMKTR).HasColumnName("KLMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.CKDEPO).HasColumnName("CKDEPO");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
