using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StoptmMap : BaseEntityMap<STOPTM>
    {
        public StoptmMap()
        {
            ToTable(@"STOPTM", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU");
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STKNAM).HasColumnName("STKNAM");
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.MCBELG).HasColumnName("MCBELG");
            Property(x => x.MGBELG).HasColumnName("MGBELG");
            Property(x => x.OPTMZS).HasColumnName("OPTMZS");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
