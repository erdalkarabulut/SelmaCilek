using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY
{
    public class FyshopifyproductMap : BaseEntityMap<FYShopifyProduct>
    {
        public FyshopifyproductMap()
        {
            ToTable(@"FYShopifyProduct", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Cid).HasColumnName("Cid");
            Property(x => x.title).HasColumnName("title");
            Property(x => x.body_html).HasColumnName("body_html");
            Property(x => x.vendor).HasColumnName("vendor");
            Property(x => x.product_type).HasColumnName("product_type");
            Property(x => x.created_at).HasColumnName("created_at");
            Property(x => x.handle).HasColumnName("handle");
            Property(x => x.updated_at).HasColumnName("updated_at");
            Property(x => x.published_at).HasColumnName("published_at");
            Property(x => x.template_suffix).HasColumnName("template_suffix");
            Property(x => x.published_scope).HasColumnName("published_scope");
            Property(x => x.tags).HasColumnName("tags");
            Property(x => x.status).HasColumnName("status");
            Property(x => x.admin_graphql_api_id).HasColumnName("admin_graphql_api_id");
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}
