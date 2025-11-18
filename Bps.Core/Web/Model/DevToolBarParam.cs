using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Web.Mvc;

namespace Bps.Core.Web.Model
{
    public class DevToolBarParam
    {
        public string Grid { get; set; }

        public string EkleDiv { get; set; }
        public string DegistirDiv { get; set; }
        public string YerlesimDiv { get; set; }
        public string BelgeAkisDiv { get; set; }
        public string TopluAktarDiv { get; set; }

        public string EklePopup { get; set; }
        public string DegistirPopup { get; set; }

        public string EkleUrl { get; set; }
        public string DegistirUrl { get; set; }
        public string SilUrl { get; set; }

        public int? MenuTag { get; set; }
        public string Type { get; set; }
        public string SilMesajText { get; set; }

        public List<string> ExcluldeList { get; set; }
        public List<MVCxGridViewToolbarItem> ItemList { get; set; }


        #region Tab Icın


        public string PcName { get; set; }
        public int? TabIndexEkle { get; set; }
        public int? TabIndexDegistir { get; set; }
        public int? TabIndexKaydet { get; set; }
        public int? TabIndexIptal { get; set; }
        public bool? MultiModel { get; set; }
        public List<string> FormList { get; set; }
        public bool? WithTab { get; set; }

        #endregion
    }
}
