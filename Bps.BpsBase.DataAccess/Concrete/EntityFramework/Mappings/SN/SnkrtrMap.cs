using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN
{
    public class SnkrtrMap : BaseEntityMap<SNKRTR>
    {
        public SnkrtrMap()
        {
            ToTable(@"SNKRTR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KRKTNO).HasColumnName("KRKTNO").IsRequired();
            Property(x => x.KRKTTN).HasColumnName("KRKTTN").IsRequired();
            Property(x => x.DTTPKD).HasColumnName("DTTPKD").IsRequired();
            Property(x => x.KRKTSY).HasColumnName("KRKTSY").IsRequired();
            Property(x => x.ONDASY).HasColumnName("ONDASY").IsRequired();
            Property(x => x.FORMAT).HasColumnName("FORMAT");
        }
    }
}
