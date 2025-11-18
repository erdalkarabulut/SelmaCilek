using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CM
{
    public class CmkartMap : BaseEntityMap<CMKART>
    {
        public CmkartMap()
        {
            ToTable(@"CMKART", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.GNACIK).HasColumnName("GNACIK");
            Property(x => x.CMDRKD).HasColumnName("CMDRKD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
