using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmnksbMap : BaseEntityMap<WMNKSB>
    {
        public WmnksbMap()
        {
            ToTable(@"WMNKSB", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.NKBELG).HasColumnName("NKBELG");
            Property(x => x.WMHRKD).HasColumnName("WMHRKD");
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.WMNKTR).HasColumnName("WMNKTR");
            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.BELGEN).HasColumnName("BELGEN");
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.GNONAY).HasColumnName("GNONAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
