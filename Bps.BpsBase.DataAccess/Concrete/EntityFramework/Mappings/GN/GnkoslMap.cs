using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnkoslMap : BaseEntityMap<GNKOSL>
    {
        public GnkoslMap()
        {
            ToTable(@"GNKOSL", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.PROKOD).HasColumnName("PROKOD").IsRequired();
            Property(x => x.KOSULL).HasColumnName("KOSULL");
            Property(x => x.LANGKD).HasColumnName("LANGKD");
            Property(x => x.DEFALT).HasColumnName("DEFALT");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
