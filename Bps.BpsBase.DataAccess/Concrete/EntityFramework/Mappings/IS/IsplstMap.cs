using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsplstMap : BaseEntityMap<ISPLST>
    {
        public IsplstMap()
        {
            ToTable(@"ISPLST", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.ISPKOD).HasColumnName("ISPKOD");
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.BASTAR).HasColumnName("BASTAR");
            Property(x => x.URRVNO).HasColumnName("URRVNO");
            Property(x => x.URAKOD).HasColumnName("URAKOD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
