using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Bps.BpsBase.Entities.Concrete.FY
{
    public class FYShopifyImage : BaseEntity
    {
        [CsDisplayName("Cid")]
        [MaxLength(50)]
        [JsonProperty("id")]
        public string Cid { get; set; }

        [CsDisplayName("alt")]
        [MaxLength(150)]
        public string alt { get; set; }

        [CsDisplayName("position")]
        public int? position { get; set; }

        [CsDisplayName("product_id")]
        [MaxLength(50)]
        public string product_id { get; set; }

        [CsDisplayName("created_at")]
        public DateTime? created_at { get; set; }

        [CsDisplayName("updated_at")]
        public DateTime? updated_at { get; set; }

        [CsDisplayName("admin_graphql_api_id")]
        [MaxLength(150)]
        public string admin_graphql_api_id { get; set; }

        [CsDisplayName("width")]
        public int? width { get; set; }

        [CsDisplayName("height")]
        public int? height { get; set; }

        [CsDisplayName("src")]
        [MaxLength(150)]
        public string src { get; set; }
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        public FYShopifyImage ShallowCopy()
        {
            return (FYShopifyImage)this.MemberwiseClone();
        }

    }
}
