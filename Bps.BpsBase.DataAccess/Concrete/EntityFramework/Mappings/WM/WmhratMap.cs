using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmhratMap : BaseEntityMap<WMHRAT>
    {
        public WmhratMap()
        {
            ToTable(@"WMHRAT", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.WMHRKD).HasColumnName("WMHRKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
