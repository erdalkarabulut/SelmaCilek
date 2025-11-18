using Bps.BpsBase.Entities.Concrete.FY;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.Shopify.Stok
{
	[Serializable]
	public class ShopifyProduct
	{
        [JsonProperty("id")]
        public string Cid { get; set; }

       
        public string title { get; set; }

    
        public string body_html { get; set; }

      
        public string vendor { get; set; }

       
        public string product_type { get; set; }

       
        public DateTime? created_at { get; set; }

    
        public string handle { get; set; }

      
        public DateTime? updated_at { get; set; }

    
        public DateTime? published_at { get; set; }

       
        public string template_suffix { get; set; }

       
        public string published_scope { get; set; }

        
        public string tags { get; set; }

       
        public string status { get; set; }

        
        public string admin_graphql_api_id { get; set; }
        public List<FYShopifyVariant> variants { get; set; }

		//public List<ShopifyOption> options { get; set; }

		public List<FYShopifyImage> images { get; set; }

		
	}
}
