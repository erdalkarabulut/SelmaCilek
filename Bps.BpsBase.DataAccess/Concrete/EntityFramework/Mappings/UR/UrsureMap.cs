using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UR
{
    public class UrsureMap : BaseEntityMap<URSURE>
    {
        public UrsureMap()
        {
            ToTable(@"URSURE", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ISPLID).HasColumnName("ISPLID");
            Property(x => x.ISPKOD).HasColumnName("ISPKOD").IsRequired();
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.URAKOD).HasColumnName("URAKOD").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.ISYKOD).HasColumnName("ISYKOD").IsRequired();
            Property(x => x.ISOPKD).HasColumnName("ISOPKD").IsRequired();
            Property(x => x.PERSID).HasColumnName("PERSID");
            Property(x => x.ISLTUR).HasColumnName("ISLTUR").IsRequired();
            Property(x => x.ISLMNO).HasColumnName("ISLMNO");
            Property(x => x.ISBASL).HasColumnName("ISBASL");
            Property(x => x.ISBITS).HasColumnName("ISBITS");
            Property(x => x.GRMKTR).HasColumnName("GRMKTR").HasPrecision(18, 3);
            Property(x => x.GROLBR).HasColumnName("GROLBR");
            Property(x => x.URDRKD).HasColumnName("URDRKD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
