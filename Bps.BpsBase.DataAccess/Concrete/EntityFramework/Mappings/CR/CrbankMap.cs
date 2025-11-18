using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR
{
    public class CrbankMap : BaseEntityMap<CRBANK>
    {
        public CrbankMap()
        {
            ToTable(@"CRBANK", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.BANKKD).HasColumnName("BANKKD").IsRequired();
            Property(x => x.BNSBKD).HasColumnName("BNSBKD");
            Property(x => x.SEHRKD).HasColumnName("SEHRKD");
            Property(x => x.BNKHSP).HasColumnName("BNKHSP");
            Property(x => x.BNIBAN).HasColumnName("BNIBAN");
            Property(x => x.VARSAY).HasColumnName("VARSAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
