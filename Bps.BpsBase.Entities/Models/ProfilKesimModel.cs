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
    public class ProfilKesimModel
    {
        [CsDisplayName("GNMKTR")]
        public decimal GNMKTR { get; set; }

        [CsDisplayName("OLCUKD")]
        public string OLCUKD { get; set; }

        [CsDisplayName("PARTIN")]
        public string PARTIN { get; set; }
    }
}
