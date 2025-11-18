using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsrvhrMap : BaseEntityMap<ISRVHR>
    {
        public IsrvhrMap()
        {
            ToTable(@"ISRVHR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.MALHRK).HasColumnName("MALHRK");
            Property(x => x.SONCIK).HasColumnName("SONCIK");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.DPKODU).HasColumnName("DPKODU").IsRequired();
            Property(x => x.IHTRTR).HasColumnName("IHTRTR");
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.URSPNO).HasColumnName("URSPNO");
            Property(x => x.USRSNO).HasColumnName("USRSNO");
            Property(x => x.USSTKO).HasColumnName("USSTKO");
            Property(x => x.ISLTUR).HasColumnName("ISLTUR").IsRequired();
            Property(x => x.URAGPI).HasColumnName("URAGPI");
            Property(x => x.URAGID).HasColumnName("URAGID");
            Property(x => x.URAKOD).HasColumnName("URAKOD");
            Property(x => x.URKLTP).HasColumnName("URKLTP");
            Property(x => x.SIRALM).HasColumnName("SIRALM");
            Property(x => x.ISPKOD).HasColumnName("ISPKOD");
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.ISLMNO).HasColumnName("ISLMNO");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
