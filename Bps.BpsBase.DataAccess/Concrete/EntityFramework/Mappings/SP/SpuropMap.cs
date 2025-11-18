using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP
{
    public class SpuropMap : BaseEntityMap<SPUROP>
    {
        public SpuropMap()
        {
            ToTable(@"SPUROP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.SATIRN).HasColumnName("SATIRN").IsRequired();
            Property(x => x.TIPKOD).HasColumnName("TIPKOD").IsRequired();
            Property(x => x.HARKOD).HasColumnName("HARKOD").IsRequired();
            Property(x => x.GFIYAT).HasColumnName("GFIYAT").HasPrecision(18, 3);
            Property(x => x.DVCNKD).HasColumnName("DVCNKD");
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
