using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StcinsMap : BaseEntityMap<STCINS>
    {
        public StcinsMap()
        {
            ToTable(@"STCINS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STCNSK).HasColumnName("STCNSK");
            Property(x => x.STCSNM).HasColumnName("STCSNM");
        }
    }
}
