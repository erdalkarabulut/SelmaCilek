using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LockedMap : EntityTypeConfiguration<LOCKED>
    {
        public LockedMap()
        {
            ToTable(@"LOCKED", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.SIRKID).HasColumnName("SIRKID").IsRequired();
            Property(x => x.TABLNM).HasColumnName("TABLNM");
            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.LOCKID).HasColumnName("LOCKID");
            Property(x => x.LCKDAT).HasColumnName("LCKDAT");
            Property(x => x.LCTIME).HasColumnName("LCTIME");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
