using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Bps.BpsBase.Entities.Concrete.FY
{
    public class FYShopifyProduct : BaseEntity
    {



        [CsDisplayName("Cid")]
        [MaxLength(50)]
        public string Cid { get; set; }

        [CsDisplayName("title")]
        [MaxLength(150)]
        public string title { get; set; }

        [CsDisplayName("body_html")]
       
        public string body_html { get; set; }

        [CsDisplayName("vendor")]
        [MaxLength(150)]
        public string vendor { get; set; }

        [CsDisplayName("product_type")]
        [MaxLength(150)]
        public string product_type { get; set; }

        [CsDisplayName("created_at")]
        public DateTime? created_at { get; set; }

        [CsDisplayName("handle")]
        [MaxLength(150)]
        public string handle { get; set; }

        [CsDisplayName("updated_at")]
        public DateTime? updated_at { get; set; }

        [CsDisplayName("published_at")]
        public DateTime? published_at { get; set; }

        [CsDisplayName("template_suffix")]
        [MaxLength(150)]
        public string template_suffix { get; set; }

        [CsDisplayName("published_scope")]
        [MaxLength(150)]
        public string published_scope { get; set; }

        [CsDisplayName("tags")]
        [MaxLength(500)]
        public string tags { get; set; }

        [CsDisplayName("status")]
        [MaxLength(150)]
        public string status { get; set; }

        [CsDisplayName("admin_graphql_api_id")]
        [MaxLength(150)]
        public string admin_graphql_api_id { get; set; }
        [CsDisplayName("CRKODU")]
        [MaxLength(25)]
        public string CRKODU { get; set; }

        public FYShopifyProduct ShallowCopy()
        {
            return (FYShopifyProduct)this.MemberwiseClone();
        }

    }
}
