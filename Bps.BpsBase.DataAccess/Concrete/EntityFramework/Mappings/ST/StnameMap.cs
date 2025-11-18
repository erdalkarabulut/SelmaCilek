using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StnameMap : BaseEntityMap<STNAME>
    {
        public StnameMap()
        {
            ToTable(@"STNAME", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STKODU,x.LANGKD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.STKNAM).HasColumnName("STKNAM").IsRequired();
            Property(x => x.LANGKD).HasColumnName("LANGKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
