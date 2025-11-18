using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.FY.Listed
{
    public class FYVariantListMatch
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Varyant Kodu")]
        public string Cid { get; set; }

        [DisplayName("Product Kodu")]
        public string product_id { get; set; }

        [DisplayName("Varyant Tanımı")]
        
        public string title { get; set; }
        [DisplayName("Match")]
        public bool VMATCH { get; set; }

        [DisplayName("Cari Kodu")]
        public string CRKODU { get; set; }
    }
}
