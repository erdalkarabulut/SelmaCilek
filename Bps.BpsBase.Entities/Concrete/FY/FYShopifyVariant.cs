using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Bps.BpsBase.Entities.Concrete.FY
{
    public class FYShopifyVariant : BaseEntity
    {
        [CsDisplayName("Cid")]
        [MaxLength(50)]
        [JsonProperty("id")]
        public string Cid { get; set; }

        [CsDisplayName("product_id")]
        [MaxLength(50)]
        public string product_id { get; set; }

        [CsDisplayName("title")]
        [MaxLength(150)]
        public string title { get; set; }

        [CsDisplayName("price")]
        public decimal? price { get; set; }

        [CsDisplayName("position")]
        public int? position { get; set; }

        [CsDisplayName("inventory_policy")]
        [MaxLength(150)]
        public string inventory_policy { get; set; }

        [CsDisplayName("compare_at_price")]
        public decimal? compare_at_price { get; set; }

        [CsDisplayName("option1")]
        [MaxLength(150)]
        public string option1 { get; set; }

        [CsDisplayName("option2")]
        [MaxLength(150)]
        public string option2 { get; set; }

        [CsDisplayName("option3")]
        [MaxLength(150)]
        public string option3 { get; set; }

        [CsDisplayName("created_at")]
        public DateTime? created_at { get; set; }

        [CsDisplayName("updated_at")]
        public DateTime? updated_at { get; set; }

        [CsDisplayName("taxable")]
        public bool? taxable { get; set; }

        [CsDisplayName("barcode")]
        [MaxLength(150)]
        public string barcode { get; set; }

        [CsDisplayName("fulfillment_service")]
        [MaxLength(150)]
        public string fulfillment_service { get; set; }

        [CsDisplayName("grams")]
        public decimal? grams { get; set; }

        [CsDisplayName("inventory_management")]
        [MaxLength(150)]
        public string inventory_management { get; set; }

        [CsDisplayName("requires_shipping")]
        public bool? requires_shipping { get; set; }

        [CsDisplayName("sku")]
        [MaxLength(150)]
        public string sku { get; set; }

        [CsDisplayName("weight")]
        public decimal? weight { get; set; }

        [CsDisplayName("weight_unit")]
        [MaxLength(50)]
        public string weight_unit { get; set; }

        [CsDisplayName("inventory_item_id")]
        [MaxLength(50)]
        public string inventory_item_id { get; set; }

        [CsDisplayName("inventory_quantity")]
        public decimal? inventory_quantity { get; set; }

        [CsDisplayName("old_inventory_quantity")]
        public decimal? old_inventory_quantity { get; set; }

        [CsDisplayName("admin_graphql_api_id")]
        [MaxLength(150)]
        public string admin_graphql_api_id { get; set; }

        [CsDisplayName("image_id")]
        [MaxLength(50)]
        public string image_id { get; set; }
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        public FYShopifyVariant ShallowCopy()
        {
            return (FYShopifyVariant)this.MemberwiseClone();
        }

    }
}
