using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StmhsbMap : BaseEntityMap<STMHSB>
    {
        public StmhsbMap()
        {
            ToTable(@"STMHSB", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STKODU,x.STFTNO,x.HSPKOD,x.DPKODU
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.HSPKOD).HasColumnName("HSPKOD").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
