using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.FY
{
    public class FYShopifyOrder : BaseEntity
    {
        [CsDisplayName("Cid")]
        [MaxLength(50)]
        public string Cid { get; set; }

        [CsDisplayName("SName")]
        [MaxLength(50)]
        public string SName { get; set; }

        [CsDisplayName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [CsDisplayName("Updated_at")]
        public DateTime? Updated_at { get; set; }

        [CsDisplayName("CustomerId")]
        [MaxLength(50)]
        public string CustomerId { get; set; }

        [CsDisplayName("CustomerName")]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [CsDisplayName("Source")]
        [MaxLength(50)]
        public string Source { get; set; }

        [CsDisplayName("FinancialStatus")]
        [MaxLength(50)]
        public string FinancialStatus { get; set; }

        [CsDisplayName("order_status_url")]
        [MaxLength(250)]
        public string order_status_url { get; set; }

        [CsDisplayName("fulfillment_status")]
        [MaxLength(50)]
        public string fulfillment_status { get; set; }

        [CsDisplayName("Stocks")]
        [MaxLength(50)]
        public string Stocks { get; set; }

        [CsDisplayName("shipment_status")]
        [MaxLength(50)]
        public string shipment_status { get; set; }

        [CsDisplayName("shipping_code")]
        [MaxLength(50)]
        public string shipping_code { get; set; }

        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        [CsDisplayName("Amount")]
        [MaxLength(50)]
        public string Amount { get; set; }
        [CsDisplayName("CurrencyCode")]
        [MaxLength(50)]
        public string CurrencyCode { get; set; }

        public FYShopifyOrder ShallowCopy()
        {
            return (FYShopifyOrder)this.MemberwiseClone();
        }

    }
}
