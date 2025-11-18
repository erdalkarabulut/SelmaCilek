using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY
{
    public class FyshopifyimageMap : BaseEntityMap<FYShopifyImage>
    {
        public FyshopifyimageMap()
        {
            ToTable(@"FYShopifyImage", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Cid).HasColumnName("Cid");
            Property(x => x.alt).HasColumnName("alt");
            Property(x => x.position).HasColumnName("position");
            Property(x => x.product_id).HasColumnName("product_id");
            Property(x => x.created_at).HasColumnName("created_at");
            Property(x => x.updated_at).HasColumnName("updated_at");
            Property(x => x.admin_graphql_api_id).HasColumnName("admin_graphql_api_id");
            Property(x => x.width).HasColumnName("width");
            Property(x => x.height).HasColumnName("height");
            Property(x => x.src).HasColumnName("src");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
        }
    }
}
