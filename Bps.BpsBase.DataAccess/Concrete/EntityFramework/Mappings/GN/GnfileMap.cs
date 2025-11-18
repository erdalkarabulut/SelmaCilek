using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnfileMap : BaseEntityMap<GNFILE>
    {
        public GnfileMap()
        {
            ToTable(@"GNFILE", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.TABLNM).HasColumnName("TABLNM").IsRequired();
            Property(x => x.TABLID).HasColumnName("TABLID").IsRequired();
            Property(x => x.FLNAME).HasColumnName("FLNAME").IsRequired();
            Property(x => x.GNDOSY).HasColumnName("GNDOSY");
            Property(x => x.GNPATH).HasColumnName("GNPATH");
            Property(x => x.FLTYPE).HasColumnName("FLTYPE").IsRequired();
            Property(x => x.DEFAUL).HasColumnName("DEFAUL").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
