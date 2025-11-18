using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models
{
    public class UrunOpsiyonModel
    {
        [CsDisplayName("SATIRN")]
        public int SATIRN { get; set; }

        [CsDisplayName("TIPKOD")]
        public string TIPKOD { get; set; }

        [CsDisplayName("HARKOD")]
        public string HARKOD { get; set; }

        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("DVCNKD")]
        [MaxLength(10)]
        public string DVCNKD { get; set; }

        [CsDisplayName("GNACIK")]
        public string GNACIK { get; set; }
    }
}