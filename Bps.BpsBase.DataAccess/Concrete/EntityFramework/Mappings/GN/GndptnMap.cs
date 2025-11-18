using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GndptnMap : BaseEntityMap<GNDPTN>
    {
        public GndptnMap()
        {
            ToTable(@"GNDPTN", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.URYRKD,x.DPKODU
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.DPTANM).HasColumnName("DPTANM").IsRequired();
            Property(x => x.MIPGOS).HasColumnName("MIPGOS");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
