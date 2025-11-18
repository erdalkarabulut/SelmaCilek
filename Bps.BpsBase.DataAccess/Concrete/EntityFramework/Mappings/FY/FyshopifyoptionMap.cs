using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY
{
    public class FyshopifyoptionMap : BaseEntityMap<FYShopifyOption>
    {
        public FyshopifyoptionMap()
        {
            ToTable(@"FYShopifyOption", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Cid).HasColumnName("Cid");
            Property(x => x.product_id).HasColumnName("product_id");
            Property(x => x.name).HasColumnName("name");
            Property(x => x.position).HasColumnName("position");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
        }
    }
}
