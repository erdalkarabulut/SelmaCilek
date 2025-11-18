using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class SturopMap : BaseEntityMap<STUROP>
    {
        public SturopMap()
        {
            ToTable(@"STUROP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.TIPKOD).HasColumnName("TIPKOD").IsRequired();
            Property(x => x.HARKOD).HasColumnName("HARKOD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
