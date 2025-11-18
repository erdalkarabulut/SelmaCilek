using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StmaltMap : BaseEntityMap<STMALT>
    {
        public StmaltMap()
        {
            ToTable(@"STMALT", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STMLTR
            }).IsUnique(true);

            HasIndex(x =>new
            {
              x.SIRKID,x.STMLNM
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STMLTR).HasColumnName("STMLTR").IsRequired();
            Property(x => x.STMLNM).HasColumnName("STMLNM").IsRequired();
            Property(x => x.STBKDR).HasColumnName("STBKDR").IsRequired();
            Property(x => x.STCNKD).HasColumnName("STCNKD").IsRequired();
            Property(x => x.OTMTIK).HasColumnName("OTMTIK");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.FORMUL).HasColumnName("FORMUL");
            Property(x => x.STRENK).HasColumnName("STRENK");
            Property(x => x.STBDEN).HasColumnName("STBDEN");
            Property(x => x.STDROP).HasColumnName("STDROP");
        }
    }
}
