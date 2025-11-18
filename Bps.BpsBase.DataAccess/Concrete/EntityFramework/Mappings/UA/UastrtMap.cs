using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA
{
    public class UastrtMap : BaseEntityMap<UASTRT>
    {
        public UastrtMap()
        {
            ToTable(@"UASTRT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.URAKOD).HasColumnName("URAKOD").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.PARENT).HasColumnName("PARENT").IsRequired();
            Property(x => x.CHILDD).HasColumnName("CHILDD").IsRequired();
            Property(x => x.SEVIYE).HasColumnName("SEVIYE").IsRequired();
            Property(x => x.SIRANO).HasColumnName("SIRANO");
            Property(x => x.ISOPKD).HasColumnName("ISOPKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
