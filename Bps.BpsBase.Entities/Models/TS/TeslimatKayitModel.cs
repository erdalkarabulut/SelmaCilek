using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Entities.Concrete.TS;

namespace Bps.BpsBase.Entities.Models.TS
{
    public class TeslimatKayitModel
    {
        public TSFBAS Baslik { get; set; }
        public List<TSFHAR> Kalems { get; set; }
    }
}
