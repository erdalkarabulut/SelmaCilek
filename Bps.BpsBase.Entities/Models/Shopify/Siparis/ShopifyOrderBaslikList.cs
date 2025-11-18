using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.Shopify.Siparis
{
    [Serializable]
    public class ShopifyOrderBaslikList
    {
        [DisplayName("Order ID")]
        public long CId { get; set; }

        [DisplayName("Sipariş")]
        public string Name { get; set; }
        [DisplayName("Tarih")]
        public DateTime? CreatedAt { get; set; }
        [DisplayName("Update Tarih")]
        public DateTime? Updated_at { get; set; }
        [DisplayName("Müşteri ID")]
        public long CustomerId { get; set; }
        [DisplayName("Müşteri")]
        public string CustomerName { get; set; }
        [DisplayName("Kanal")]
        public string Source { get; set; }

        [DisplayName("Ödeme Durumu")]
        public string FinancialStatus { get; set; }
        [DisplayName("Sipariş Durumu")]
        public string order_status_url { get; set; }

        [DisplayName("Gönderim Durumu")]
        public string fulfillment_status { get; set; }

        [DisplayName("Ürünler")]
        public string Stocks { get; set; }

        [DisplayName("Teslimat Durumu")]
        public string shipment_status { get; set; }

        [DisplayName("Teslimat Yöntemi")]
        public string shipping_code { get; set; }
    }
}
