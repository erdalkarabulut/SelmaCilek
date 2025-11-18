using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.FY.Listed
{
    public class FYStBdrnListMatch
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }
        [DisplayName("Stok Kodu")]
        public string STKODU { get; set; }

        
        [DisplayName("Varyant Kodu")]
        
        public string VRKODU { get; set; }

        
        [DisplayName("Varyant Tanım")]
       
        public string VRYTNM { get; set; }

        [DisplayName("Renk Kodu")]
      
        public string RENKKD { get; set; }
        [DisplayName("Renk Tanımı")]
        public string RENKTN { get; set; }

        [DisplayName("Beden Kodu")]
       
        public string BEDNKD { get; set; }
        [DisplayName("Beden Tanımı")]
        public string BEDNTN { get; set; }

        [DisplayName("Drop Kodu")]
      
        public string DROPKD { get; set; }
        [DisplayName("Drop Tanımı")]
        public string DROPTN { get; set; }
        [DisplayName("Match")]
        public bool VMATCH { get; set; }
    }
}
