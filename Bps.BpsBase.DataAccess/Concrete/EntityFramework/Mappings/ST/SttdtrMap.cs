using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class SttdtrMap : BaseEntityMap<STTDTR>
    {
        public SttdtrMap()
        {
            ToTable(@"STTDTR", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.TEDKOD,x.URYRKD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TEDKOD).HasColumnName("TEDKOD").IsRequired();
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.TEDTNM).HasColumnName("TEDTNM").IsRequired();
            Property(x => x.YAPAYK).HasColumnName("YAPAYK").IsRequired();
            Property(x => x.FASONK).HasColumnName("FASONK").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
