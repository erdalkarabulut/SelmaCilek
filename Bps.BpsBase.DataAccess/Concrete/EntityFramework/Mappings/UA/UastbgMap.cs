using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA
{
    public class UastbgMap : BaseEntityMap<UASTBG>
    {
        public UastbgMap()
        {
            ToTable(@"UASTBG", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.KLNKOD).HasColumnName("KLNKOD");
            Property(x => x.URAKOD).HasColumnName("URAKOD");
            Property(x => x.ALTERN).HasColumnName("ALTERN");
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
