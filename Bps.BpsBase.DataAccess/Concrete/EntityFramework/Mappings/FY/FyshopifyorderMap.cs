using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY
{
    public class FyshopifyorderMap : BaseEntityMap<FYShopifyOrder>
    {
        public FyshopifyorderMap()
        {
            ToTable(@"FYShopifyOrder", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Cid).HasColumnName("Cid");
            Property(x => x.SName).HasColumnName("SName");
            Property(x => x.CreatedAt).HasColumnName("CreatedAt");
            Property(x => x.Updated_at).HasColumnName("Updated_at");
            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x => x.CustomerName).HasColumnName("CustomerName");
            Property(x => x.Source).HasColumnName("Source");
            Property(x => x.FinancialStatus).HasColumnName("FinancialStatus");
            Property(x => x.order_status_url).HasColumnName("order_status_url");
            Property(x => x.fulfillment_status).HasColumnName("fulfillment_status");
            Property(x => x.Stocks).HasColumnName("Stocks");
            Property(x => x.shipment_status).HasColumnName("shipment_status");
            Property(x => x.shipping_code).HasColumnName("shipping_code");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU");
            Property(x => x.Amount).HasColumnName("Amount");
            Property(x => x.CurrencyCode).HasColumnName("CurrencyCode");
            
        }
    }
}
