using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.FY.Listed
{
    public class FYStKartListMatch
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Malzeme Türü")]
        public string STMLTR { get; set; }

        [DisplayName("Stok Kodu")]
        public string STKODU { get; set; }


        [DisplayName("Stok Adı")]
        public string STKNAM { get; set; }

        [DisplayName("Varyant Sayısı")]
        public int VRYSAY { get; set; }

        [DisplayName("Match Sayısı")]
        public int VRMATC { get; set; }
        [DisplayName("Cari Kodu")]
        public string CRKODU { get; set; }
    }
}
