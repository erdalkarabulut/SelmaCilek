using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnthrkMap : BaseEntityMap<GNTHRK>
    {
        public GnthrkMap()
        {
            ToTable(@"GNTHRK", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TIPKOD).HasColumnName("TIPKOD").IsRequired();
            Property(x => x.HARKOD).HasColumnName("HARKOD").IsRequired();
            Property(x => x.PARENT).HasColumnName("PARENT").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.GNICON).HasColumnName("GNICON");
            Property(x => x.EXTRA1).HasColumnName("EXTRA1");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.LANGKD).HasColumnName("LANGKD");
        }
    }
}
