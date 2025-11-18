using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StaltgMap : BaseEntityMap<STALTG>
    {
        public StaltgMap()
        {
            ToTable(@"STALTG", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STANAK).HasColumnName("STANAK");
            Property(x => x.STALTK).HasColumnName("STALTK");
            Property(x => x.STALTN).HasColumnName("STALTN");
        }
    }
}
