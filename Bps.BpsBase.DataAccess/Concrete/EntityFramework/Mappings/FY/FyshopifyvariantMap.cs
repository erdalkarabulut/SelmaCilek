using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY
{
    public class FyshopifyvariantMap : BaseEntityMap<FYShopifyVariant>
    {
        public FyshopifyvariantMap()
        {
            ToTable(@"FYShopifyVariant", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Cid).HasColumnName("Cid");
            Property(x => x.product_id).HasColumnName("product_id");
            Property(x => x.title).HasColumnName("title");
            Property(x => x.price).HasColumnName("price").HasPrecision(18, 2);
            Property(x => x.position).HasColumnName("position");
            Property(x => x.inventory_policy).HasColumnName("inventory_policy");
            Property(x => x.compare_at_price).HasColumnName("compare_at_price").HasPrecision(18, 2);
            Property(x => x.option1).HasColumnName("option1");
            Property(x => x.option2).HasColumnName("option2");
            Property(x => x.option3).HasColumnName("option3");
            Property(x => x.created_at).HasColumnName("created_at");
            Property(x => x.updated_at).HasColumnName("updated_at");
            Property(x => x.taxable).HasColumnName("taxable");
            Property(x => x.barcode).HasColumnName("barcode");
            Property(x => x.fulfillment_service).HasColumnName("fulfillment_service");
            Property(x => x.grams).HasColumnName("grams").HasPrecision(18, 2);
            Property(x => x.inventory_management).HasColumnName("inventory_management");
            Property(x => x.requires_shipping).HasColumnName("requires_shipping");
            Property(x => x.sku).HasColumnName("sku");
            Property(x => x.weight).HasColumnName("weight").HasPrecision(18, 2);
            Property(x => x.weight_unit).HasColumnName("weight_unit");
            Property(x => x.inventory_item_id).HasColumnName("inventory_item_id");
            Property(x => x.inventory_quantity).HasColumnName("inventory_quantity").HasPrecision(18, 2);
            Property(x => x.old_inventory_quantity).HasColumnName("old_inventory_quantity").HasPrecision(18, 2);
            Property(x => x.admin_graphql_api_id).HasColumnName("admin_graphql_api_id");
            Property(x => x.image_id).HasColumnName("image_id");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
        }
    }
}
