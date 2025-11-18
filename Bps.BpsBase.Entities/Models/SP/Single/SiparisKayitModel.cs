using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.Entities.Models.SP.Single
{
    public class SiparisKayitModel
    {
        public SPFBAS Baslik { get; set; }
        public List<SPFHAR> Kalems { get; set; }
        public SPFBAS TalepBaslik { get; set; }
        public List<UrunOpsiyonModel> UrunOpsiyons { get; set; }
    }
}
