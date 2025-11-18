using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnklopMap : BaseEntityMap<GNKLOP>
    {
        public GnklopMap()
        {
            ToTable(@"GNKLOP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.PERSID).HasColumnName("PERSID").IsRequired();
            Property(x => x.ISOPKD).HasColumnName("ISOPKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
