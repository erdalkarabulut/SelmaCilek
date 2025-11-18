using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class BelgeAkisModel
    {
        [DisplayName("Yeni")]
        public string New { get; set; }

        [DisplayName("Eski")]
        public string Old { get; set; }

        [CsDisplayName("KULKOD")]
        public string UserKod { get; set; }

        [DisplayName("Tarih")]
        public DateTime Date { get; set; }

        [CsDisplayName("GNNAME")]
        public string GNNAME { get; set; }

        [CsDisplayName("GNSNAM")]
        public string GNSNAM { get; set; }
    }
}