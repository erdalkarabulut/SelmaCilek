using System;
using System.Collections;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SpBaslikAcikModel
    {
        [CsDisplayName("ID")]
        public int Id { get; set; }

        [CsDisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [CsDisplayName("SPHRTP")]
        public int SPHRTP { get; set; }

        [CsDisplayName("SPFTNO")]
        public int SPFTNO { get; set; }

        [CsDisplayName("EVRAKN")]
        public string EVRAKN { get; set; }

        [CsDisplayName("BELGEN")]
        public string BELGEN { get; set; }

        [CsDisplayName("BELTRH")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("TERTAR")]
        public DateTime? TERTAR { get; set; }

        [CsDisplayName("CRKODU")]
        public string CRKODU { get; set; }

        [CsDisplayName("CRUNV1")]
        public string CRUNV1 { get; set; }

        [CsDisplayName("MALTES")]
        public string MALTES { get; set; }

        [CsDisplayName("CKDEPO")]
        public string CKDEPO { get; set; }

        [CsDisplayName("GRDEPO")]
        public string GRDEPO { get; set; }

        [CsDisplayName("GRDPTN")]
        public string GRDPTN { get; set; }

        [CsDisplayName("GRDPWM")]
        public string GRDPWM { get; set; }

        [CsDisplayName("GNACIK")]
        public string GNACIK { get; set; }

        [CsDisplayName("FLGKPN")]
        public bool FLGKPN { get; set; }

        [CsDisplayName("Ekleyen Kullanıcı")]
        public string EKKULL { get; set; }

        [CsDisplayName("Eklenme Tarihi")]
        public DateTime ETARIH { get; set; }
    }
}
