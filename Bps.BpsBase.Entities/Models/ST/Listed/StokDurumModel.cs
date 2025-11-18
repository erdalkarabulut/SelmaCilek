using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StokDurumModel
    {

        [DisplayName("Seç")]
        public bool checkState { get; set; }
        public string DurumKodu { get; set; }
        public string DurumText { get; set; }

        public StokDurumModel(bool _checkState, string _durumKodu, string _durumText)
        {
            checkState = _checkState;
            DurumKodu = _durumKodu;
            DurumText = _durumText;
        }
    }
}
