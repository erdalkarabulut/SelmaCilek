using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StdurmMap : BaseEntityMap<STDURM>
    {
        public StdurmMap()
        {
            ToTable(@"STDURM", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STDKOD).HasColumnName("STDKOD");
            Property(x => x.STDNAM).HasColumnName("STDNAM");
        }
    }
}
