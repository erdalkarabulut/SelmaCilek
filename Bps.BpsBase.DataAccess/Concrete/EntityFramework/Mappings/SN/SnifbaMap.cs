using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN
{
    public class SnifbaMap : BaseEntityMap<SNIFBA>
    {
        public SnifbaMap()
        {
            ToTable(@"SNIFBA", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SNTRKD).HasColumnName("SNTRKD").IsRequired();
            Property(x => x.SINFKD).HasColumnName("SINFKD").IsRequired();
            Property(x => x.SNFKOD).HasColumnName("SNFKOD").IsRequired();
            Property(x => x.SNFTAN).HasColumnName("SNFTAN");
            Property(x => x.GECBAS).HasColumnName("GECBAS").IsRequired();
            Property(x => x.GECBIT).HasColumnName("GECBIT").IsRequired();
        }
    }
}
