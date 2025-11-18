using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CM
{
    public class CmaksnMap : BaseEntityMap<CMAKSN>
    {
        public CmaksnMap()
        {
            ToTable(@"CMAKSN", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.AKSNNO).HasColumnName("AKSNNO").IsRequired();
            Property(x => x.BELGEN).HasColumnName("BELGEN").IsRequired();
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.CMDRKD).HasColumnName("CMDRKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
