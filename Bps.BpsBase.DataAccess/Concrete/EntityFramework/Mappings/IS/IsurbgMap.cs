using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsurbgMap : BaseEntityMap<ISURBG>
    {
        public IsurbgMap()
        {
            ToTable(@"ISURBG", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ISPKOD).HasColumnName("ISPKOD");
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.ISLMNO).HasColumnName("ISLMNO");
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.PARENT).HasColumnName("PARENT");
            Property(x => x.CHILDD).HasColumnName("CHILDD");
            Property(x => x.URRVNO).HasColumnName("URRVNO");
            Property(x => x.URAKOD).HasColumnName("URAKOD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
