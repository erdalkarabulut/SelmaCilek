using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN
{
    public class SntynnMap : BaseEntityMap<SNTYNN>
    {
        public SntynnMap()
        {
            ToTable(@"SNTYNN", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.OBJKEY).HasColumnName("OBJKEY");
            Property(x => x.SNFKOD).HasColumnName("SNFKOD").IsRequired();
        }
    }
}
