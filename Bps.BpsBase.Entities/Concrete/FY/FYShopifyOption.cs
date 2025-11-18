using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Bps.BpsBase.Entities.Concrete.FY
{
    public class FYShopifyOption : BaseEntity
    {
        [CsDisplayName("Cid")]
        [MaxLength(50)]
        [JsonProperty("id")]
        public string Cid { get; set; }

        [CsDisplayName("product_id")]
        [MaxLength(50)]
        public string product_id { get; set; }

        [CsDisplayName("name")]
        [MaxLength(50)]
        public string name { get; set; }

        [CsDisplayName("position")]
        public int? position { get; set; }
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        public FYShopifyOption ShallowCopy()
        {
            return (FYShopifyOption)this.MemberwiseClone();
        }

    }
}
