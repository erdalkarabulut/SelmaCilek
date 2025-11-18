using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StcrkdMap : BaseEntityMap<STCRKD>
    {
        public StcrkdMap()
        {
            ToTable(@"STCRKD", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.RENKKD).HasColumnName("RENKKD");
            Property(x => x.BEDNKD).HasColumnName("BEDNKD");
            Property(x => x.DROPKD).HasColumnName("DROPKD");
            Property(x => x.CRSTKO).HasColumnName("CRSTKO");
            Property(x => x.CRSTNM).HasColumnName("CRSTNM");
            Property(x => x.CRVRKO).HasColumnName("CRVRKO");
            Property(x => x.EANTKD).HasColumnName("EANTKD");
            Property(x => x.EANKOD).HasColumnName("EANKOD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
