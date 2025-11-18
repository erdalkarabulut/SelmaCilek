using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StanagMap : BaseEntityMap<STANAG>
    {
        public StanagMap()
        {
            ToTable(@"STANAG", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STANAK).HasColumnName("STANAK").IsRequired();
            Property(x => x.STANAN).HasColumnName("STANAN");
        }
    }
}
