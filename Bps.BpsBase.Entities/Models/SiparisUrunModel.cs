using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models
{
    [Serializable]
    public class SiparisUrunModel
    {
        [CsDisplayName("ITEMNO")]
        public string ITEMNO { get; set; }
        [CsDisplayName("STKODU")]
        public string STKODU { get; set; }

        [CsDisplayName("STKNAM")]
        public string STKNAM { get; set; }

        [CsDisplayName("URNOPS")]
        public string URNOPS { get; set; }

        [CsDisplayName("GNMKTR")]
        public decimal? GNMKTR { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("GNTUTR")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("DVCNKD")]
        public string DVCNKD { get; set; }
    }
}