using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsyropMap : BaseEntityMap<ISYROP>
    {
        public IsyropMap()
        {
            ToTable(@"ISYROP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ISYRID).HasColumnName("ISYRID").IsRequired();
            Property(x => x.ISOPKD).HasColumnName("ISOPKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
