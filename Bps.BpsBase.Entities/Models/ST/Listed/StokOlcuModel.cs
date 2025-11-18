using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StokOlcuModel
    {
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("OLCUKD")]
        [MaxLength(20)]
        public string OLCUKD { get; set; }

        [DisplayName("Miktar")]
        public decimal? GNMKTR { get; set; }

        [DisplayName("Ölçü Birimi")]
        [MaxLength(20)]
        public string HedefOlcuBirimi { get; set; }

        [DisplayName("Miktar")]
        public decimal? HedefMiktar { get; set; }

    }
}
