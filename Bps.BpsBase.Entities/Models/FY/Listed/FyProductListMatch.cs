using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.FY.Listed
{
    public class FyProductListMatch
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Product Id")]
        public string Cid { get; set; }

        [DisplayName("Product Name")]
       
        public string title { get; set; }

       
        [DisplayName("Varyant Sayısı")]
        public int VRYSAY { get; set; }

        [DisplayName("Match Sayısı")]
        public int VRMATC { get; set; }
        [DisplayName("Cari Kodu")]
        public string CRKODU { get; set; }
    }
}
