using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmhrktMap : BaseEntityMap<WMHRKT>
    {
        public WmhrktMap()
        {
            ToTable(@"WMHRKT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.DEPOKD).HasColumnName("DEPOKD").IsRequired();
            Property(x => x.WMHRKD).HasColumnName("WMHRKD");
            Property(x => x.WMNKTR).HasColumnName("WMNKTR");
            Property(x => x.KPTIPI).HasColumnName("KPTIPI");
            Property(x => x.KPADRS).HasColumnName("KPADRS");
            Property(x => x.HPTIPI).HasColumnName("HPTIPI");
            Property(x => x.HPADRS).HasColumnName("HPADRS");
            Property(x => x.NSMNEL).HasColumnName("NSMNEL");
            Property(x => x.WMHRON).HasColumnName("WMHRON");
            Property(x => x.WMDNMK).HasColumnName("WMDNMK");
            Property(x => x.WMNSOT).HasColumnName("WMNSOT");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
