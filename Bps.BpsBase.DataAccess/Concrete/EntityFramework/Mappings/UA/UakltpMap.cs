using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA
{
    public class UakltpMap : BaseEntityMap<UAKLTP>
    {
        public UakltpMap()
        {
            ToTable(@"UAKLTP", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KLNKOD).HasColumnName("KLNKOD");
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.URTILS).HasColumnName("URTILS");
            Property(x => x.TSRILS).HasColumnName("TSRILS");
            Property(x => x.YDKPRC).HasColumnName("YDKPRC");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
